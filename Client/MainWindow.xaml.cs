using Client.Services.Figure;
using Client.Services.File;
using Commands.Services.Use_Case;
using Commands.Use_Case;
using DiagramsElementsLibrary.Save;
using DiagramsElementsLibrary.Use_Case;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// The separator
    /// </summary>
    private const string Separator = "\r\n";

    /// <summary>
    /// The diagram
    /// </summary>
    private Diagram? _diagram = new() { Elements = new List<IElement?>()};

    /// <summary>
    /// The figure service
    /// </summary>
    private IFigureService? _figureService;

    /// <summary>
    /// The json service
    /// </summary>
    private IFileService? _jsonService;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow" /> class.
    /// </summary>
    public MainWindow()
    {
        InitializingServices(out var services1);

        InitializeComponent();
    }

    /// <summary>
    /// Initializings the services.
    /// </summary>
    /// <param name="services1">The services1.</param>
    private void InitializingServices(out IServiceCollection services1)
    {
        services1 = new ServiceCollection();
        services1.AddScoped<IFileService, JsonService>();
        services1.AddScoped<IFigureService, FigureService>();

        using var serviceProvider1 = services1.BuildServiceProvider();

        _figureService = serviceProvider1.GetService<IFigureService>();
        _jsonService = serviceProvider1.GetService<IFileService>();
    }

    /// <summary>
    /// Strings the format rich text box.
    /// </summary>
    /// <param name="richTextBox">The rich text box.</param>
    /// <returns>System.String.</returns>
    private static string StringFormatRichTextBox(RichTextBox richTextBox)
    {
        var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

        return textRange.Text;
    }

    /// <summary>
    /// Handles the KeyDown event of the TbConsole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
    private async void TbConsole_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.F1:
            {
                await ClearWhenRestarting();
                await DrawFigures();
                break;
            }
            case Key.F2:
            {
                SaveImages();
                break;
            }
            case Key.F3:
            {
                await _jsonService?.SaveJson(_diagram, ImgDiagram)!;
                break;
            }
            case Key.F4:
            {
                await ClearWhenRestarting();
                await _jsonService?.OpenJson(ImgDiagram)!;
                break;
            }
            default:
                break;
        }
    }

    /// <summary>
    /// Saves the images.
    /// </summary>
    private void SaveImages()
    {
        var saves = new Microsoft.Win32.SaveFileDialog
        {
            DefaultExt = ".PNG",
            Filter = "Image (.PNG)|*.PNG"
        };
        if (saves.ShowDialog() == true)
        {
            SaveImage.ToImageSource(ImgDiagram, saves.FileName);
        }
    }

    /// <summary>
    /// Draws the figures.
    /// </summary>
    private async Task DrawFigures()
    {
        await ClearWhenRestarting();

        ProcessingIncomingLine();

        DrawShapes();

        DrawSystemBoundary();
    }

    private void ProcessingIncomingLine()
    {
        var commandSet = StringFormatRichTextBox(TbConsole).Split(Separator);

        foreach (var command in commandSet)
        {
            if (command == string.Empty)
            {
                continue;
            }

            var regex = new Regex(@".+\+.+");
            var matchCollection = regex.Matches(command);

            _diagram?.Elements?.Add(matchCollection.Count == 0
                ? AddCommandService.AddCommandAction(command, _diagram)
                : AddRelationService.AddRelationAction(command, _diagram));
        }
    }

    /// <summary>
    /// Draws the system boundary.
    /// </summary>
    private void DrawSystemBoundary()
    {
        var element = _diagram?.Elements?.FindAll(e => e?.GetType() == typeof(Precedent)).FirstOrDefault()!;

        if (element != null)
        {
            var systemBoundary = new SystemBoundary()
            {
                Id = 0,
                Name = "System Boundary",
                X = element.X,
                Y = 0,
                W = ((element as Precedent)!).W,
                H = ImgDiagram.ActualHeight
            };
            
            _diagram?.Elements?.Add(systemBoundary);

            (new AddSystemBoundary()).Draw(systemBoundary, ImgDiagram, 0);
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Clears the when restarting.
    /// </summary>
    private async Task ClearWhenRestarting()
    {
        ImgDiagram.Children.Clear();
        _diagram?.Elements?.Clear();
        
        Counter.Reset();

        AddActor.Count = 0;
        AddActor.Canvas = new Canvas();
        
        AddRelation.Canvas = new Canvas();
    }

    /// <summary>
    /// Draws the shapes.
    /// </summary>
    private void DrawShapes()
    {
        if (_diagram?.Elements == null) 
            return;

        foreach (var element in _diagram.Elements)
        {
            if (element?.GetType() == typeof(Precedent))
            {
                (new AddPrecedent()).Draw(element, ImgDiagram, _diagram.Elements.Count - Counter.CountActors - Counter.CountRelations);
            }
            else if (element?.GetType() == typeof(Actor))
            {
                (new AddActor()).Draw(element, ImgDiagram, _diagram.Elements.Count - Counter.CountPrecedents - Counter.CountRelations);
            }
            else if (element?.GetType() == typeof(Relation))
            {
                (new AddRelation()).Draw(element, ImgDiagram, _diagram.Elements.Count - Counter.CountActors - Counter.CountPrecedents);
            }        
        }
    }
}