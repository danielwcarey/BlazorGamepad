using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielCarey.Blazor.Gamepad.Sample.Services {
    public class Gamepad {
        public string ConnectionId { get; set; }

        public double[] Axes { get; set; }
        public GamepadButton[] Buttons { get; set; }
        public bool Connected { get; set; }
        //public string DisplayId { get; set; }
        public string Id { get; set; }
        public int Index { get; set; }
        public string Mapping { get; set; }
        public double Timestamp { get; set; }
    }
}
