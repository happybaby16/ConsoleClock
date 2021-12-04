using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClock.Model.State
{
    public static class States
    {
        public enum CollectionStates { Clock = 0, Timer = 1, Stopwatch=2}
        public static int State { get; set; }
    }
}
