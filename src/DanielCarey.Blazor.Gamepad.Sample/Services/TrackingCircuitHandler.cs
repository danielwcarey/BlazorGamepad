using DanielCarey.Blazor.Gamepad.Services;
using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DanielCarey.Blazor.Gamepad.Sample.Services {
    public class TrackingCircuitHandler : CircuitHandler {
        private HashSet<Circuit> _circuits = new HashSet<Circuit>();
        private readonly IGamePadService _gamePadService;

        //public TrackingCircuitHandler(IGamePadService gamePadService) {
        //    _gamePadService = gamePadService;
        //}
        public TrackingCircuitHandler() {
        }

        public override Task OnConnectionUpAsync(Circuit circuit,
            CancellationToken cancellationToken) {

#if DEBUG
            System.Diagnostics.Debug.Write($"Up: {circuit.Id}");
#endif
            _circuits.Add(circuit);
            //_gamePadService.AddConnectionAsync(circuit.Id);

            return Task.CompletedTask;
        }

        public override Task OnConnectionDownAsync(Circuit circuit,
            CancellationToken cancellationToken) {

#if DEBUG
            System.Diagnostics.Debug.Write($"Down: {circuit.Id}");
#endif
            _circuits.Remove(circuit);
            //_gamePadService.RemoveConnectionAsync(circuit.Id);

            return Task.CompletedTask;
        }

        public int ConnectedCircuits => _circuits.Count;
        
    }
}
