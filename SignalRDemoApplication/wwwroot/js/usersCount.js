// create connection
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();
// connect to methods that hub invokes aka receives notification from hub
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();
});

// invoke hub methods aka send notification to hub
function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoaded"); //it does not expect a value in return 
    //connectionUserCount.invoke("NewWindowLoaded"); //it expects a value in return 
}
// start connection
function fulfilled() {
    // do something on start 
    console.log("connection to user hub successful");
    newWindowLoadedOnClient();
}

function rejected() {
    // rejected logs
}

connectionUserCount.start().then(fulfilled, rejected);


