var websocket = new WebSocket('ws://127.0.0.1:5000');

websocket.onopen = function (e) {

};

websocket.onclose = function (e) {

};

websocket.onmessage = function (e) {
    const encodedMsg = `Hub says ${e.data}`;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
};

websocket.onerror = function (e) {

};

function sendMessage() {
    var message = document.getElementById("message").value;
    websocket.send(message);
}