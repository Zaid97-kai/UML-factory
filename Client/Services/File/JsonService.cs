using Client.Services.Figure;
using Commands.Use_Case;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Client.Services.File;

/// <summary>
/// Interface IFileService
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Opens the json.
    /// </summary>
    /// <param name="imgDiagram">The img diagram.</param>
    /// <returns>Task.</returns>
    Task OpenJson(Panel imgDiagram);

    /// <summary>
    /// Saves the json.
    /// </summary>
    /// <param name="diagram">The diagram.</param>
    /// <param name="imgDiagram">The img diagram.</param>
    /// <returns>Task.</returns>
    Task SaveJson(Diagram? diagram, Panel imgDiagram);
}

/// <summary>
/// Class JsonService.
/// </summary>
public class JsonService : IFileService
{
    /// <summary>
    /// The figure service
    /// </summary>
    private readonly IFigureService _figureService;

    /// <summary>
    /// The diagram
    /// </summary>
    private Diagram _diagram;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonService" /> class.
    /// </summary>
    //public JsonService()
    //{
    //    _diagram = new Diagram
    //    {
    //        Elements = new List<IElement?>()
    //    };
    //}

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonService" /> class.
    /// </summary>
    /// <param name="figureService">The figure service.</param>
    public JsonService(IFigureService figureService)
    {
        _figureService = figureService;

        _diagram = new Diagram
        {
            Elements = new List<IElement?>()
        };
    }

    /// <summary>
    /// Opens the json.
    /// </summary>
    /// <param name="imgDiagram">The img diagram.</param>
    /// <returns>Task.</returns>
    public async Task OpenJson(Panel imgDiagram)
    {
        _diagram.Elements?.Clear();

        var saves = new Microsoft.Win32.OpenFileDialog()
        {
            DefaultExt = ".JSON",
            Filter = "JSON (.JSON)|*.JSON"
        };

        if (saves.ShowDialog() == true)
        {
            using (var reader = new StreamReader(saves.FileName))
            {
                var json = await reader.ReadToEndAsync();

                dynamic array = JsonConvert.DeserializeObject(json)!;
                foreach (var item in array)
                {
                    if (item.TypeElement == typeof(Actor).ToString())
                    {
                        _diagram.Elements?.Add(new Actor()
                        {
                            Name = item.Name,
                            H = item.H,
                            Id = item.Id,
                            W = item.W,
                            X = item.X, 
                            Y = item.Y
                        });
                    }
                    else if (item.TypeElement == typeof(Precedent).ToString())
                    {
                        _diagram.Elements?.Add(new Precedent()
                        {
                            Name = item.Name,
                            H = item.H,
                            Id = item.Id,
                            W = item.W,
                            X = item.X, 
                            Y = item.Y
                        });
                    }
                    else if (item.TypeElement == typeof(Relation).ToString())
                    {
                        _diagram.Elements?.Add(new Relation()
                        {
                            Name = item.Name,
                            H = item.H,
                            Id = item.Id,
                            W = item.W,
                            X = item.X, 
                            Y = item.Y,
                            LinkActor = JsonConvert.DeserializeObject<Actor?>(item.LinkActor.ToString()),
                            LinkPrecedent = JsonConvert.DeserializeObject<Precedent?>(item.LinkPrecedent.ToString())
                        });
                    }
                    else if (item.TypeElement == typeof(SystemBoundary).ToString())
                    {
                        _diagram.Elements?.Add(new SystemBoundary()
                        {
                            Name = item.Name,
                            H = item.H,
                            Id = item.Id,
                            W = item.W,
                            X = item.X, 
                            Y = item.Y
                        });
                    }
                }

                _figureService.DrawShapes(_diagram, imgDiagram);
            }
        }
    }

    /// <summary>
    /// Saves the json.
    /// </summary>
    /// <param name="diagram">The diagram.</param>
    /// <param name="imgDiagram">The img diagram.</param>
    /// <returns>Task.</returns>
    public async Task SaveJson(Diagram? diagram, Panel imgDiagram)
    {
        var saves = new Microsoft.Win32.SaveFileDialog
        {
            DefaultExt = ".JSON",
            Filter = "JSON (.JSON)|*.JSON"
        };
        if (saves.ShowDialog() == true)
        {
            await using (var fileStream = new FileStream(saves.FileName, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fileStream, diagram?.Elements);
            }
        }
    }
}