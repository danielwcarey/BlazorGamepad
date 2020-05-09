using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielCarey.Blazor.Controls {
    public class ClientGamepad {
        public string ConnectionId { get; set; } = "";

        public double[] Axes { get; set; } = new double[] { };
        public ClientGamepadButton[] Buttons { get; set; } = new ClientGamepadButton[] { };
        public bool Connected { get; set; } = false;
        //public string DisplayId { get; set; }
        public string Id { get; set; } = "";
        public int Index { get; set; } = 0;
        public string Mapping { get; set; } = "";
        public double Timestamp { get; set; } = 0;
    }
}
