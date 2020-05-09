using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanielCarey.Blazor.Gamepad.Sample.Services {
    public static class GamepadEndpointRouteBuilderExtensions {
        public static GamepadEndpointRouteBuilder MapGamepadRoute(this IEndpointRouteBuilder endpoints) {
            
            endpoints.MapHub<GamepadServiceHub>(GamepadServiceHub.ChannelName);
            
            return new GamepadEndpointRouteBuilder();
        }
        public static GamepadEndpointRouteBuilder MapGamepadRoute(this IEndpointRouteBuilder endpoints, string path) {
            
            endpoints.MapHub<GamepadServiceHub>(path);

            return new GamepadEndpointRouteBuilder();
        }
    }
}
