var project = setInterval(projectDone, 10)
var clients = setInterval(happyClients, 10)
var coffee = setInterval(cupsCoffee, 10)
var doa = setInterval(doi, 10)
let count1 = 1;
let count2 = 1;
let count3 = 1;
let count4 = 1;

function projectDone() {
    count1++
    document.querySelector("#number1").innerHTML = count1
    if (count1 == 240) {
        clearInterval(project)
    }
}

function happyClients() {
    count2++
    document.querySelector("#number2").innerHTML = count2
    if (count2 == 340) {
        clearInterval(clients)
    }
}

function cupsCoffee() {
    count3++
    document.querySelector("#number3").innerHTML = count3
    if (count3 == 540) {
        clearInterval(coffee)
    }
}

function doi() {
    count4++
    document.querySelector("#number4").innerHTML = count4
    if (count4 == 220) {
        clearInterval(doa)
    }
}