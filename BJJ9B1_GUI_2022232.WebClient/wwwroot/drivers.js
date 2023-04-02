﻿let drivers = [];
let connection;
let driverIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12023/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("DriversCreated", (user, message) => {
        getdata();
    });
    connection.on("DriversDeleted", (user, message) => {
        getdata();
    });
    connection.on("DriversUpdated", (user, message) => {
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
    await fetch('http://localhost:12023/drivers')
        .then(x => x.json())
        .then(y => {
            drivers = y;
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    drivers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            `<div class="table-row">` +
            `<div class="table-data">` + t.id + "</div>" +
            `<div class="table-data">` + t.driverName + "</div>" +
            `<div class="table-data">` +
            `<button class="button fontSet" type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button style="margin-left:5%" class="button fontSet" type="button" onclick="showupdate(${t.id})">Update</button>` +
            "</div></div>";
    })
}

function create() {
    let name = document.getElementById('driverName').value;

    fetch('http://localhost:12023/drivers', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            driverName: name
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
    fetch('http://localhost:12023/drivers/' + id, {
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
    document.getElementById('driverNameToUpdate').value = drivers.find(t => t['id'] == id)['driverName']
    driverIdToUpdate = id;
}

function update() {
    let name = document.getElementById('driverNameToUpdate').value;

    fetch('http://localhost:12023/drivers', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            driverName: name, id: driverIdToUpdate
        })
    })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); })
}