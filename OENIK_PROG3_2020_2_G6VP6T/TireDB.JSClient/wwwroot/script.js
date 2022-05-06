let brands = [];
let connection = null;
getdata();
setupSignalR();
let statresults = [];
let brandIdToUpdate = -1


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53910/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BrandCreated", (user, message) => {
        getdata();
    });

    connection.on("BrandDeleted", (user, message) => {
        getdata();
    });

    connection.on("BrandUpdated", (user, message) => {
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
    await fetch('http://localhost:53910/Brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    brands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}


function showupdate(id) {
    document.getElementById('brandnametoupdate').value = brands.find(t => t['id'] == id)['name']
    document.getElementById('updateformdiv').style.display = 'flex'
    brandIdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:53910/Brand/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('brandname').value;
    fetch('http://localhost:53910/Brand', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name : name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    let name = document.getElementById('brandnametoupdate').value;
    brandIdToUpdate
    fetch('http://localhost:53910/Brand', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, id : brandIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}



async function getdatabrandavarages() {
    await fetch('http://localhost:53910/Stat/AveragePerBrand')
        .then(x => x.json())
        .then(y => {
            statresults = y;
            brandavaragesdisplay();
        });
}
function brandavaragesdisplay() {
    document.getElementById('statresultarea').innerHTML = "";
    statresults.forEach(t => {
        document.getElementById('statresultarea').innerHTML += "<tr><td>" + "Brand name: " + t.brandName + " | Avarage price: " + t.avaragePrice + "</td></tr>"
    });
}

async function getbrandsums() {
    await fetch('http://localhost:53910/Stat/TirePriceSUMs')
        .then(x => x.json())
        .then(y => {
            statresults = y;
            getbrandsumsdisplay();
        });
}
function getbrandsumsdisplay() {
    document.getElementById('statresultarea').innerHTML = "";
    statresults.forEach(t => {
        document.getElementById('statresultarea').innerHTML += "<tr><td>" + "Brand name: " + t.brandName + " | Sum price: " + t.priceSum + "</td></tr>"
    });
}

async function gettirebydiameter() {
    let diameter = document.getElementById('diameterput').value
    await fetch('http://localhost:53910/Stat/TireByDiameters?diameter=' + diameter)
        .then(x => x.json())
        .then(y => {
            statresults = y;
            gettirebydiameterdisplay();
        });
}
function gettirebydiameterdisplay() {
    document.getElementById('statresultarea').innerHTML = "";
    statresults.forEach(t => {
        document.getElementById('statresultarea').innerHTML += "<tr><td>" + "Diameter: " + t.diameter + " | Brand name: " + t.brandName + " | Tire name: " + t.tireName + "</td></tr>"
    });
}
