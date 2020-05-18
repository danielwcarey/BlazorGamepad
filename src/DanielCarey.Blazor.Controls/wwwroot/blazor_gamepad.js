const gamepad_setupInterop = () => {

    const connection = new signalR.HubConnectionBuilder().withUrl("blazorgamepad").build();

    const update = () => {
        const gamepads = navigator.getGamepads();
        if (gamepads === null) return;

        let gps = Array.from(gamepads);

        let gamepadObjects =
            gps.map((gp) => {
                if (gp == null) return null;

                return {
                    ConnectionId: connection.connectionId,
                    Axes: gp.axes,
                    Buttons: gp?.buttons.map((b) => {
                        return {
                            Value: b.value,
                            Pressed: b.pressed
                        };
                    }) ?? [],
                    Connected: gp.connected,
                    Id: gp.id,
                    Index: gp.index,
                    Mapping: gp.mapping,
                    Timestamp: gp.timestamp
                };
            }).filter(gp => {
                return gp != null;
            });

        //console.log(connection);
        connection.invoke('UpdateJsonAsync', gamepadObjects);
    }

    const tick = (timestamp) => {
        //function tick(timestamp) {
        const rafId = requestAnimationFrame(tick);
        update();
    }

    connection
        .start()
        .then(() => tick())
        .catch(err => document.write(err));
};

const gamepad_loadScript = (url, callback) => {
    // Adding the script tag to the head as suggested before
    const head = document.head;
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = url;

    // Then bind the event to the callback function.
    // There are several events for cross browser compatibility.
    script.onreadystatechange = callback;
    script.onload = callback;

    // Fire the loading
    head.appendChild(script);
}

// Need to add a way to configure the server to disable the built-in signalr javascript client (and use a self
// provded version )
if (typeof(signalR) === 'undefined') {
    gamepad_loadScript('/_content/DanielCarey.Blazor.Controls/lib/microsoft/signalr/dist/browser/signalr.min.js', gamepad_setupInterop);
} else {
    gamepad_setupInterop();
}


