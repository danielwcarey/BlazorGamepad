# DanielCarey.Blazor.Gamepad

This component creates a signalr connection from the web browser and the asp.net core and starts
sending client gamepad information on every requestAnimationFrame().

1. Add this package to a new Blazor Application.

2. Update _Imports.razor to include these namespaces.
```cshtml
@using DanielCarey.Blazor.Gamepad
@using DanielCarey.Blazor.Gamepad.Services
```

3. Add the javascript client to _Host.cshtml.
```html
<script src="/_content/DanielCarey.Blazor.Gamepad/blazor_gamepad.js"></script>
```

4. Update ConfigureServices in Startup.cs 
```cs
public void ConfigureServices(IServiceCollection services) {
    services.AddSignalR();
    services.AddGamepadServices(); 
}
```

5. Update Configure in Startup.cs
```cs
public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
    app.UseStaticFiles();

    app.UseRouting();

    app.UseEndpoints(endpoints => {
        endpoints.MapHub<GamepadServiceHub>(GamepadServiceHub.ChannelName);
    });
}
```