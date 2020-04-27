System.register("main", ["../wwwroot/js/signalr/dist/browser/signalr.js"], function (exports_1, context_1) {
    "use strict";
    var signalR, connection, update;
    var __moduleName = context_1 && context_1.id;
    //const update = () => {
    //    const ctrlInfo = document.getElementById('ctrlInfo') as HTMLInputElement;
    //    if (ctrlInfo === null) return;
    //
    //    const gamepads = navigator.getGamepads();
    //
    //    ctrlInfo.value = "no gamepad";
    //
    //    const gamepad = gamepads[0];
    //    if (gamepad === null) return;
    //
    //    ctrlInfo.value = gamepad.id;
    //}
    function tick(timestamp) {
        const rafId = requestAnimationFrame(tick);
        update();
    }
    return {
        setters: [
            function (signalR_1) {
                signalR = signalR_1;
            }
        ],
        execute: function () {
            connection = new signalR.HubConnectionBuilder().withUrl("//gamepad").build();
            connection.start();
            update = () => {
                const gamepads = navigator.getGamepads();
                if (gamepads === null)
                    return;
                connection.send('Update', 'Client', gamepads);
            };
            tick();
        }
    };
});
//# sourceMappingURL=app.js.map