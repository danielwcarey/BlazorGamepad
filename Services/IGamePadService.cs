using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorGamepad.Services {
    public interface IGamePadService {
        Task UpdateAsync(Gamepad[] gamepads);
        Task UpdateJsonAsync(JsonElement[] gamepadElements);
    }        
}