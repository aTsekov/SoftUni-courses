function attachEventsListeners() {

    //get all of the buttons by input type. 
    let buttons = Array.from(document.querySelectorAll("input[type=button]"));
    // create an event listener for each button.
    for (let button of buttons) {
        button.addEventListener("click", convert);
    }

    function convert(e) {

        let value = Number(e.target.parentElement.querySelector("input[type=text]").value);
        let unit = e.target.id;

        if (unit === "daysBtn") {
            populate(value);
        }
        else if (unit === "hoursBtn") {
            populate(value / 24);
        }
        else if (unit === "minutesBtn") {
            populate(value / 24 / 60);
        }
        else if (unit === "secondsBtn") {
            populate(value / 24 / 60 / 60);
        }
    }
    function populate(value) {
        let inputs = Array.from (document.querySelectorAll("input[type = text]"));
        inputs.shift().value = value;
        let currentValue = value * 24;
        for (let input of inputs) {
            input.value = currentValue;
            currentValue *= 60;
        }
    
    }
}

