using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorGamepad.Services {
    public class TrackingCircuitHandler : CircuitHandler {
        private HashSet<Circuit> _circuits = new HashSet<Circuit>();

        public override Task OnConnectionUpAsync(Circuit circuit,
            CancellationToken cancellationToken) {
            _circuits.Add(circuit);

            return Task.CompletedTask;
        }

        public override Task OnConnectionDownAsync(Circuit circuit,
            CancellationToken cancellationToken) {
            _circuits.Remove(circuit);

            return Task.CompletedTask;
        }

        public int ConnectedCircuits => _circuits.Count;
        
    }
}
