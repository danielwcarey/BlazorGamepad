using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DanielCarey.Blazor.Gamepad.Services;

namespace Microsoft.Extensions.DependencyInjection {
    public static class GamepadDependencyInjectionExtensions {
        public static IGamepadServiceBuilder AddGamepadServices(this IServiceCollection services) {
            return new GamepadServiceBuilder { };
        }

        public static IGamepadServiceBuilder AddGamepadServices(this IServiceCollection services, Action<GamepadServiceOptions> configure) {
            return new GamepadServiceBuilder { };
        }
    }

}
