namespace Shapes.Shapes;

using System.Xml.Serialization;

using Helpers;

[XmlRoot("Circle")]
public class Circle : Shape
{
    [XmlAttribute("Radius")] public double Radius { get; set; }
}