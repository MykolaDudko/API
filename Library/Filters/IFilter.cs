using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Filters;
public interface IFilter
{
    int Offset { get; set; } 
    int Limit { get; set; }
}
