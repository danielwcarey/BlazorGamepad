using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DanielCarey.Blazor.Controls.Services {
    public class GamepadServiceHub : Hub<IGamePadService> {
        public static string ChannelName = "blazorgamepad";

        public GamepadServiceHub() { }

        public async Task UpdateAsync(ClientGamepad[] gamepads) {
            await Clients.All.UpdateAsync(gamepads);
        }

        public async Task UpdateJsonAsync(JsonElement[] gamepadElements) {
            var gamepads = new List<ClientGamepad>();
            foreach (var gamepadElement in gamepadElements) {
                var rawString = gamepadElement.GetRawText();
                var gamepad = JsonSerializer.Deserialize<ClientGamepad>(rawString);
                gamepads.Add(gamepad);
            }
            await UpdateAsync(gamepads.ToArray());
        }

        public async Task AddConnectionAsync(string connectionId) {
            await Clients.All.AddConnectionAsync(connectionId);
        }

        public async Task RemoveConnectionAsync(string connectionId) {
            await Clients.All.RemoveConnectionAsync(connectionId);
        }

    }
}
