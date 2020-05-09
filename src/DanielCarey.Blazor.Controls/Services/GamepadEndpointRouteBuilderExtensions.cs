using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// This Extension builder requires IEndpointRouteBuilder, which isn't available in a separate NuGet package.
/// I optioned to just add the line to Startup.cs and include it in the instructions:
///   endpoints.MapHub<GamepadServiceHub>(GamepadServiceHub.ChannelName);
///   
/// This behavior may a security feature, where adding razor component dlls do not inject themselves
/// into the routing pipeline.
/// 
/// I did change the sdk target of the project to <Project Sdk="Microsoft.NET.Sdk.Web"/> but then received
/// errors concerning a static startup method; even if a dummy was supplied, I then worried about the
/// custom targets and build properties pulled in by <Project Sdk="Microsoft.NET.Sdk.Razor"/>
/// 
/// </summary>
#region Assembly Microsoft.AspNetCore.Routing, Version=3.1.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\3.1.2\ref\netcoreapp3.1\Microsoft.AspNetCore.Routing.dll
#endregion
#region Assembly Microsoft.AspNetCore.SignalR, Version=3.1.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// C:\Program Files\dotnet\packs\Microsoft.AspNetCore.App.Ref\3.1.2\ref\netcoreapp3.1\Microsoft.AspNetCore.SignalR.dll
#endregion

namespace DanielCarey.Blazor.Controls.Services {
    //public static class GamepadEndpointRouteBuilderExtensions {
    //    public static GamepadEndpointRouteBuilder MapGamepadRoute(this IEndpointRouteBuilder endpoints) {
            
    //        endpoints.MapHub<GamepadServiceHub>(GamepadServiceHub.ChannelName);
            
    //        return new GamepadEndpointRouteBuilder();
    //    }
    //    public static GamepadEndpointRouteBuilder MapGamepadRoute(this IEndpointRouteBuilder endpoints, string path) {
            
    //        endpoints.MapHub<GamepadServiceHub>(path);

    //        return new GamepadEndpointRouteBuilder();
    //    }
    //}
    
}
