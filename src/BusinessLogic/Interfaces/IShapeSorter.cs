﻿namespace BusinessLogic.Interfaces;

using Shapes.Shapes;
using Flight;

public interface IShapeSorter
{
    public List<Shape> Shapes { get; set; }

    public void SortList(SortLogic sortParameter, SortLogic sortDirection);

    public (int Circles, int Triangles, int Quadrilaterals) GetShapesCount();
}