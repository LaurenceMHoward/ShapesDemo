using System.Xml.Serialization;

namespace Shapes.Shapes;

[XmlRoot("Triangle")]
public sealed class Triangle : Shape
{
    [XmlAttribute("b")] public double Base { get; set; }

    [XmlAttribute("a")] public double SideOne { get; set; }

    [XmlAttribute("c")] public double SideTwo { get; set; }
}