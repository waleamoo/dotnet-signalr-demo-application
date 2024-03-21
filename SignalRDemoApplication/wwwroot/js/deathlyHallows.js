var cloakSpan = document.getElementById("cloakCounter");
var stoneSpan = document.getElementById("stoneCounter");
var wandSpan = document.getElementById("wandCounter");
// create connection
var connectionDeathlyHallows = new signalR.HubConnectionBuilder().withUrl("/hubs/deathlyhallows").build();
// connect to methods that hub invokes aka receives notification from hub
connectionDeathlyHallows.on("updateDealthlyHallowCount", (cloak, stone, wand) => {
    cloakSpan.innerText = cloak.toString();
    stoneSpan.innerText = stone.toString();
    wandSpan.innerText = wand.toString();
});

// invoke hub methods aka send notification to hub - Inside the Controller class

// start connection
function fulfilled() {
    // do something on start 
    connectionDeathlyHallows.invoke("GetRaceStatus").then((raceCounter) => {
        cloakSpan.innerText = raceCounter.cloak.toString();
        stoneSpan.innerText = raceCounter.stone.toString();
        wandSpan.innerText = raceCounter.wand.toString();
    });
    newWindowLoadedOnClient();
}

function rejected() {
    // rejected logs
}

connectionDeathlyHallows.start().then(fulfilled, rejected);


