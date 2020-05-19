# BlazorGamePad

This is a component library for using gamepads with blazor. The goal is to expose the Web API, Gamepad API, as a blazor component, or components. 
You can read more about the [Gamepad API here.]( https://developer.mozilla.org/en-US/docs/Web/API/Gamepad_API )



## Getting Started

### Configuration the project

1. Add this package to a new Blazor Application.

2. Update _Imports.razor to include these namespaces.
```cshtml
@using DanielCarey.Blazor.Gamepad
@using DanielCarey.Blazor.Gamepad.Services
```

3. Reference the javascript client code in _Host.cshtml.
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

### Using the component

The GamePad component has the following properties:


1. Add the component to the page
```html
<GamePad Index="@Index" OnClientGamepadUpdate="@ClientGamepadUpdate" ShowDebug="true" OnlyNotifyOnChange="true"></GamePad>
```