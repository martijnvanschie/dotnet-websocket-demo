const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000/chathub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("connected");
    } catch (err) {
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(async () => {
    await start();
});

connection.on("ReceiveMessage", (message) => {
    const encodedMsg = `Hub says ${message}`;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

// Start the connection.
start();

/* this is here to show an alternative to start, with a then
connection.start().then(() => console.log("connected"));
*/

/* this is here to show another alternative to start, with a catch
connection.start().catch(err => console.error(err));
*/

function sendMessage() {
    var message = document.getElementById("message").value;

    connection.invoke("SendMessage", message)
        .catch(err => console.error(err));
}