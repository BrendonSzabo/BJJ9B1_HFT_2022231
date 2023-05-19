let britishdrivers;
let oldestdriver;
let youngestdriver;
let bestteam;
let worstteam;
let bestteampricipal;
let teamdebut20th;
let mostchampionshipteampricipal;
let principalswithwin;
let principalsdebut20th;
let principalofbestteam;

function britishest() {
    fetch(`http://localhost:12023/Statistics/GetBritishDrivers`)
        .then(x => x.json())
        .then(y => {
            britishdrivers = y;
            DisplayerDriver(y);
        })
}
function oldest() {
    fetch(`http://localhost:12023/Statistics/GetOldestDriver`)
        .then(x => x.json())
        .then(y => {
            oldestdriver = y;
            DisplayerDriver(y);
        })
}
function youngest() {
    fetch(`http://localhost:12023/Statistics/GetYoungestDriver`)
        .then(x => x.json())
        .then(y => {
            youngestdriver = y;
            DisplayerDriver(y);
        })
}
function bestestteam() {
    fetch(`http://localhost:12023/Statistics/GetBestTeam`)
        .then(x => x.json())
        .then(y => {
            bestteam = y;
            DisplayerTeam(y);
        })
}
function worstestteam() {
    fetch(`http://localhost:12023/Statistics/GetWorstTeam`)
        .then(x => x.json())
        .then(y => {
            worstteam = y;
            DisplayerTeam(y);
        })
}
function bestprinc() {
    fetch(`http://localhost:12023/Statistics/GetBestTeamPrincipal`)
        .then(x => x.json())
        .then(y => {
            bestteampricipal = y;
            DisplayerTeamPrincipal(y);
        })
}
function team20() {
    fetch(`http://localhost:12023/Statistics/TeamsDebutIn20thCentury`)
        .then(x => x.json())
        .then(y => {
            teamdebut20th = y;
            DisplayerTeam(y);
        })
}
function championship() {
    fetch(`http://localhost:12023/Statistics/GetMostChampionshipWinTeamPrincipal`)
        .then(x => x.json())
        .then(y => {
            mostchampionshipteampricipal = y;
            DisplayerTeamPrincipal(y);
        })
}
function winners() {
    fetch(`http://localhost:12023/Statistics/GetPrincipalsWithWin`)
        .then(x => x.json())
        .then(y => {
            principalswithwin = y;
            DisplayerTeamPrincipal(y);
        })
}
function princ20() {
    fetch(`http://localhost:12023/Statistics/GetPrincipalWhoDebutedIn20thCentury`)
        .then(x => x.json())
        .then(y => {
            principalsdebut20th = y;
            DisplayerTeamPrincipal(y);
        })
}
function princbest() {
    fetch(`http://localhost:12023/Statistics/GetPrincipalOfBestTeam`)
        .then(x => x.json())
        .then(y => {
            principalofbestteam = y;
            DisplayerTeamPrincipal(y);
        })
}
function DisplayerDriver(data) {
    document.getElementById('resultdiv').innerHTML = "";
    data.forEach((t, index) => {
        console.log(index + ", " + t.teamName + ", " + typeof (t))
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + (parseInt(index) + 1) + "</td><td>" + t.driverName + "</td></tr>";
    })
}
function DisplayerTeamPrincipal(data) {
    document.getElementById('resultdiv').innerHTML = "";
    data.forEach((t, index) => {
        console.log(index + ", " + t.teamName + ", " + typeof (t))
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + (parseInt(index) + 1) + "</td><td>" + t.principalName + "</td></tr>";
    })
}
function DisplayerTeam(data) {
    document.getElementById('resultdiv').innerHTML = "";
    data.forEach((t, index) => {
        console.log(index + ", " + t.teamName + ", " + typeof (t))
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + (parseInt(index) + 1) + "</td><td> " + t.teamName +"</td></tr>";
    })
}
