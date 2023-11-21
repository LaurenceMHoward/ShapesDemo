namespace ShapesConsoleApp.HostedService;

using BusinessLogic.Interfaces;
using BusinessLogic.Flight;
using Microsoft.Extensions.Hosting;

public class ProgramService(IShapeSorter shapeSorter, ICollectionFactory collectionGenerator, IXmlExporter xmlExporter)
    : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        shapeSorter.Shapes = collectionGenerator.CreateShapeCollection(100);
        shapeSorter.SortList(SortLogic.ByPerimeter, SortLogic.Descending);
        xmlExporter.ExportShapeCollection(shapeSorter.Shapes);
        Console.WriteLine("Exported file is in the application folder");
        var (circles, triangles, quadrilaterals) = shapeSorter.GetShapesCount();
        Console.WriteLine(
            $"The following were generated -> Circles: {circles}; Triangles: {triangles}; Quadrilaterals: {quadrilaterals}");
        Console.WriteLine();
        Console.WriteLine();
        return Task.CompletedTask;
    }
}