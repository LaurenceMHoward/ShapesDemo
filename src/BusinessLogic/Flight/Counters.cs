namespace BusinessLogic.Flight;

using Interfaces;

public class Counters : ICounters
{
    public int Circles { get; set; }
    public int Quadrilaterals { get; set; }
    public int Triangles { get; set; }
}