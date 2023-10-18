using System.Xml.Serialization;
using Shapes.Helpers;

namespace Shapes.Shapes;

[XmlRoot("Triangle")]
public class Triangle : Shape
{
    [XmlAttribute("b")] public double Base { get; set; }

    [XmlAttribute("a")] public double SideOne { get; set; }

    [XmlAttribute("c")] public double SideTwo { get; set; }
}