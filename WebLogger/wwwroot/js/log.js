const connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr")
    .build();

const logGroupName = "weblog";
var isSubscribed = false;

var subscribeButton = document.getElementById("subscribeButton");
var logButton = document.getElementById("startLogButton");

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