
const setupGamepadInterop = () => {

    const connection = new signalR.HubConnectionBuilder().withUrl("gamepad").build();

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

setupGamepadInterop();
