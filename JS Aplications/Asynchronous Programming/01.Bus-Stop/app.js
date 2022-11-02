async function getInfo() { // Make the func async meaning we will be getting info with a get request within it. 
    
    const userInputElement = document.getElementById('stopId');   // get the user's input and use it in th URL below.
    const urlGetBusInfo = `http://localhost:3030/jsonstore/bus/businfo/${userInputElement.value}`

    const stopNameElement = document.getElementById('stopName'); // the bus stop element that we will populate later
    const busList = document.getElementById('buses') //the buses list that we will populate later. 

    busList.innerHTML = ""; // make the bus list and the user input empty every time before we start the actual change
    userInputElement.value = "";

    try{ // if the server does not return an error
        const response = await fetch(urlGetBusInfo); //get the responce by using the aways fetch and the URL. This will get the info 
        //from the server.
        const data = await response.json();// make the response to look like a json object. This is actually the promise.

        stopNameElement.textContent = data.name; // set the bus stop name to be the name from the data. 

        Object.entries(data.buses).forEach(([busNumber, timeArrive]) =>{ // make an array of KVP

            const li = document.createElement('li');
            li.textContent = `Bus ${busNumber} arrives in ${timeArrive} minutes`
            busList.appendChild(li);
        })


    }
    catch(error){ // if error

        stopNameElement.textContent = "Error";
    }
    



}