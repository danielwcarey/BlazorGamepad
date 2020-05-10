using System;
using System.Collections.Generic;
using System.Text;

namespace DanielCarey.Blazor.Controls {
    public class ClientGamepadUpdateArgs {
        public ClientGamepad? PreviousValue { get; set; } = null;
        public ClientGamepad? NewValue { get; set; } = null;
        public List<int> ChangedAxesIndexes { get; } = new List<int>();
        public List<int> ChangedButtonIndexes { get; } = new List<int>();
    }

}
