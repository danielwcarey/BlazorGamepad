using System.Text.Json;
using System.Threading.Tasks;

namespace DanielCarey.Blazor.Gamepad.Sample.Services {
    public interface IGamePadService {
        Task UpdateAsync(Gamepad[] gamepads);
        Task UpdateJsonAsync(JsonElement[] gamepadElements);
        Task AddConnectionAsync(string connectionId);
        Task RemoveConnectionAsync(string connectionId);
    }        
}