let teams = [];
let connection;
let teamIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12023/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamsCreated", (user, message) => {
        getdata();
    });
    connection.on("TeamsDeleted", (user, message) => {
        getdata();
    });
    connection.on("TeamsUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:12023/teams')
        .then(x => x.json())
        .then(y => {
            teams = y;
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    teams.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            `<div class="table-row">` +
            `<div class="table-data">` + t.id + "</div>" +
            `<div class="table-data">` + t.teamName + "</div>" +
            `<div class="table-data">` +
            `<button class="button fontSet" type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button style="margin-left:5%" class="button fontSet" type="button" onclick="showupdate(${t.id})">Update</button>` +
            "</div></div>";
    })
}

function create() {
    let name = document.getElementById('teamName').value;

    fetch('http://localhost:12023/teams', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            teamName: name
        })
    })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); })
}

function remove(id) {
    fetch('http://localhost:12023/teams/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); })
}

function showupdate(id) {
    document.getElementById('teamNameToUpdate').value = teams.find(t => t['id'] == id)['teamName']
    teamIdToUpdate = id;
}

function update() {

    let name = document.getElementById('teamNameToUpdate').value;

    fetch('http://localhost:12023/teams', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            teamName: name, id: teamIdToUpdate
        })
    })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); })
}