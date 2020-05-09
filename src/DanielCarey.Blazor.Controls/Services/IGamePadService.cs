using System.Text.Json;
using System.Threading.Tasks;

namespace DanielCarey.Blazor.Controls.Services {
    public interface IGamePadService {
        Task UpdateAsync(ClientGamepad[] gamepads);
        Task UpdateJsonAsync(JsonElement[] gamepadElements);
        Task AddConnectionAsync(string connectionId);
        Task RemoveConnectionAsync(string connectionId);
    }        
}