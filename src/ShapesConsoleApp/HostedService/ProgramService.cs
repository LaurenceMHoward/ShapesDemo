namespace ShapesConsoleApp.HostedService;

using BusinessLogic.Interfaces;
using BusinessLogic.Sorting;

using Microsoft.Extensions.Hosting;

public class ProgramService : BackgroundService
{
    private readonly IShapeSorter _shapeSorter;
    private readonly ICollectionFactory _collectionGenerator;
    private readonly IXmlExporter _xmlExporter;

    public ProgramService(IShapeSorter shapeSorter, ICollectionFactory collectionGenerator, IXmlExporter xmlExporter)
    {
        this._shapeSorter = shapeSorter;
        this._collectionGenerator = collectionGenerator;
        this._xmlExporter = xmlExporter;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _shapeSorter.Shapes = _collectionGenerator.CreateShapeCollection(100);
        _shapeSorter.SortList(SortLogic.ByPerimeter, SortLogic.Descending);
        this._xmlExporter.ExportShapeCollection(this._shapeSorter.Shapes);
        Console.WriteLine("Exported file is in the application folder");
        var counts = _shapeSorter.GetShapesCount();
        Console.WriteLine($"Circles: {counts.Circles}; Triangles: {counts.Triangles}; Quadrilaterals: {counts.Quadrilaterals} ");
        Console.WriteLine();
        Console.WriteLine();
        return Task.CompletedTask;
    }
}