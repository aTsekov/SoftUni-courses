function solve() {

    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');
    let infoBoxElement = document.getElementsByClassName("info")[0];
    let currentStop = "";
    let nextStop = "depot"

    
        async function depart() {
            try{
                let urlBusStopId = `http://localhost:3030/jsonstore/bus/schedule/${nextStop}`;
                const response = await fetch(urlBusStopId); 
                const data = await response.json();
                 currentStop = data.name;
                 nextStop = data.next;
                infoBoxElement.innerHTML = `Next stop ` + currentStop;
                departButton.disabled = true;
                arriveButton.disabled = false;

            }
            catch(error){
                infoBoxElement.innerHTML = "Error"
            }
           
            
        }
    
        function arrive() {
            try{
            infoBoxElement.innerHTML = `Arriving at ` + currentStop;
            departButton.disabled = false;
            arriveButton.disabled = true;
            }
            catch(error){
                infoBoxElement.innerHTML = "Error"
            }
        }

    
    
    

    return {
        depart,
        arrive
    };
}

let result = solve();