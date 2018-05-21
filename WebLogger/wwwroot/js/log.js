const connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr")
    .build();

const logGroupName = "weblog";
var isSubscribed = false;

var subscribeButton = document.getElementById("subscribeButton");

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

connection.start().catch(err => console.error(err.toString()));