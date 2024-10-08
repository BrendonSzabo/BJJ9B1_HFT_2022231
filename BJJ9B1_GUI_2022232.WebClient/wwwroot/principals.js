﻿let principals = [];
let connection;
let principalIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12023/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamPrincipalsCreated", (user, message) => {
        getdata();
    });
    connection.on("TeamPrincipalsDeleted", (user, message) => {
        getdata();
    });
    connection.on("TeamPrincipalsUpdated", (user, message) => {
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
    await fetch('http://localhost:12023/teamprincipals')
        .then(x => x.json())
        .then(y => {
            principals = y;
            console.log(principals);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    principals.forEach(t => {

        document.getElementById('resultarea').innerHTML +=
            `<div class="table-row">` +
            `<div class="table-data">` + t.id + "</div>" +
            `<div class="table-data">` + t.principalName + "</div>" +
            `<div class="table-data">` + t.birth + "</div>" +
            `<div class="table-data">` +
            `<button class="button fontSet" type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button style="margin-left:5%" class="button fontSet" type="button" onclick="showupdate(${t.id})">Update</button>` +
            "</div></div>";
        console.log(t.birth);
    })
}

function create() {
    let name = document.getElementById('principalName').value;
    let principalBirthDate = document.getElementById('principalBirthdate').value;

    fetch('http://localhost:12023/teamprincipals', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            principalName: name, birth: principalBirthDate
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
    fetch('http://localhost:12023/teamprincipals/' + id, {
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
    document.getElementById('principalNameToUpdate').value = principals.find(t => t['id'] == id)['principalName']
    document.getElementById('principalBirthDateToUpdate').value = principals.find(t => t['id'] == id)['birth']
    principalIdToUpdate = id;
    let elem = document.getElementById('updatable');
    elem.style.display = "block";
}

function update() {
    let name = document.getElementById('principalNameToUpdate').value;
    let pbirthdate = document.getElementById('principalBirthDateToUpdate').value;

    fetch('http://localhost:12023/teamprincipals', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            principalName: name, id: principalIdToUpdate, birth: pbirthdate
        })
    })
        .then(response => response)
        .then(data => {
            console.log('Succes:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); })
    let elem = document.getElementById('updatable');
    elem.style.display = "none";
}