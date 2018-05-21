const logGroupName = "weblog";
const maxLogsCount = 20;
var isSubscribed = false;

var subscribeButton = document.getElementById("subscribeButton");
var logButton = document.getElementById("startLogButton");
var logTable = document.getElementById("logTable");

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr")
    .build();

connection.on("Consume",
    (type, details) => {
        var index = logTable.rows.length;

        createLogRow(index, type, details);

        if (index > maxLogsCount) {
            deleteLogRow(1);
        }
    });

subscribeButton.addEventListener("click",
    event => {
        if (isSubscribed) {
            connection.invoke("Unsubscribe", logGroupName);
            isSubscribed = !isSubscribed;
            subscribeButton.value = "Subscribe";
        } else {
            connection.invoke("Subscribe", logGroupName);
            isSubscribed = !isSubscribed;
            subscribeButton.value = "Unsubscribe";
        }

        event.preventDefault();
    });

logButton.addEventListener("click",
    event => {
        var xhr = new XMLHttpRequest();

        xhr.open("POST", '/api/v1/start-log', true);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

        xhr.send();

        event.preventDefault();
    });

connection.start().catch(err => console.error(err.toString()));

function createLogRow(index, type, details) {
    var row = logTable.insertRow(index);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    cell1.innerHTML = type;
    cell2.innerHTML = details;
}

function deleteLogRow(index) {
    logTable.deleteRow(index);
}