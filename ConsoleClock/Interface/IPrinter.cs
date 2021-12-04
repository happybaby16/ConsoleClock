using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClock.Interface
{
    public interface IPrinter
    {
        int Hours { get; set; }
        int Minutes { get; set; }
        int Seconds { get; set; }
        int Preview { get;}
    }
}
