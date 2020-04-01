using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorGamepad.Services {

    public delegate void GamepadClientEventHandler(object sender, Gamepad[] gamepads);
    public delegate void GamepadClientJsonEventHandler(object sender, JsonElement[] gamepadElements);

    public class GamepadServiceClient : IGamePadService {

        private readonly HubConnection _hubConnection;

        public GamepadServiceClient(HubConnection hubConnection) {
            _hubConnection = hubConnection;
            InitEvents();
            _hubConnection.StartAsync();
        }

        #region Send events to the hub
        public Task UpdateAsync(Gamepad[] gamepads) => _hubConnection.SendAsync(nameof(IGamePadService.UpdateAsync), gamepads);
        public Task UpdateJsonAsync(JsonElement[] gamepadElements) => _hubConnection.SendAsync(nameof(IGamePadService.UpdateJsonAsync), gamepadElements);
        #endregion

        #region Receive events from the hub
        // Wire the events to the hub connection.
        private void InitEvents() {
            _hubConnection.On<Gamepad[]>(nameof(IGamePadService.UpdateAsync), (gamepads) => OnUpdate?.Invoke(this, gamepads));
            _hubConnection.On<JsonElement[]>(nameof(IGamePadService.UpdateJsonAsync), (gamepadElements) => OnUpdateJson?.Invoke(this, gamepadElements));
        }

        // Provide a delegate to call when the event is received from the hub
        //public EventHandler<Gamepad[]> OnUpdate { get; set; }
        //public EventHandler<JsonElement[]> OnUpdateJson { get; set; }
        public GamepadClientEventHandler OnUpdate { get; set; }
        public GamepadClientJsonEventHandler OnUpdateJson { get; set; }
        #endregion
    }
}
