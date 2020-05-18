using System;
using System.Collections.Generic;
using System.Text;

namespace DanielCarey.Blazor.Controls {
    public class ClientGamePadUpdateArgs {
        public ClientGamepad? PreviousValue { get; set; } = null;
        public ClientGamepad? CurrentValue { get; set; } = null;
        public List<int> ChangedAxesIndexes { get; } = new List<int>();
        public List<int> ChangedButtonIndexes { get; } = new List<int>();
        public int PreviousGamePadCount { get; set; } = 0;
        public int CurrentGamePadCount { get; set; } = 0;
    }

}
