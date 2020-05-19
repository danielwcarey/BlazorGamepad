# BlazorGamePad

This is a component library for using gamepads with blazor. The goal was to learn some of the internals of Blazor but now it might be useful to others and have decided to publish. It is based on the [Gamepad API.]( https://developer.mozilla.org/en-US/docs/Web/API/Gamepad_API ) I have only done minimal testing from one computer using Blazor-Server side and have not tested with Blazor Client Side (WASM) nor have I tested it with multiple, gamepad enabled clients. Both these scenarios are TBD (to be done). 

The GamePad does contain the signalr connectionid so that we do know, the differences between devices. I do not have a sample with user authentication and gamepad association. Mark that as TBD also.


## Getting Started

### Configuring the project

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

Add the component to the page.

```html
<GamePad Index="@Index" OnClientGamepadUpdate="@ClientGamepadUpdate" 
         ShowDebug="true" OnlyNotifyOnChange="true">
</GamePad>
```

Handle events from the gamepad.

```cs
private void ClientGamepadUpdate(ClientGamePadUpdateArgs args) {
}
```
See: [ClientGamePadUpdateArgs](/src/DanielCarey.Blazor.Controls/ClientGamepadUpdate.cs)

## Sample Screenshots


### Home Page Iterations

The home page iterates through each gamepad object and displays it's debug ui.

![](docs/Image%201.png)


### Component Test: Navigate Previous/Next Gamepads

This shows how to cycle through the attached gamepads using previous and next buttons.

![](docs/Image%202.png)


### Press a Button then use that Gamepad

This is an example of asking the user to select the controller they wish to use by selecting a button on that contoller. After the selection, we switch to the debug view for that controller.

![](docs/Image%203.png)


![](docs/Image%204.png)

## How it Works

The framework creates a signalr backchannel that pumps gamepad information from the web browser to a signalr gamepad hub, [GamepadServiceHub](/src/DanielCarey.Blazor.Controls/Services/GamepadServiceHub.cs). The GamePad control is also a client to the gamepad hub and receives the update events. 


The javascript client is  [blazor_gamepad.js.](/src/DanielCarey.Blazor.Controls/wwwroot/blazor_gamepad.js)

The GamePad component is [GamePad.razor.](/src/DanielCarey.Blazor.Controls/GamePad.razor)

## What's Next?
* Bug Fixes
* More Samples
* Client-Side Blazor
* Associate gamepad with User
* Performance Tuning
* Unit testing ¯\\\_(ツ)_/¯






