using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces;
public interface ICounters
{
    public int Circles { get; set; }
    public int Quadrilaterals { get; set; }
    public int Triangles { get; set; }
}
