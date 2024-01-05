const api = "https://localhost:7054/";

function getClubs() {
    fetch(api + "club/all")
        .then(function (response) {
            return response.json();
        })
        .then(function (myJson) {
            console.log(myJson);
        });
}

function getStanding(id) {
    fetch(api + "Standing/" + id)
        .then(function (response) {
            return response.text();
        })
        .then(function (html) {
            document.getElementById("container").innerHTML = html;
        });
}


getStanding(1);