//import {html, render} from  './node_modules/lit-html/lit-html.js'; // with this import the app does not work
import {html, render} from 'https://unpkg.com/lit-html?module'; // with this one it works without problems. 

const form = document.querySelector('form'); //Select the form.  and add event listener.

form.addEventListener("submit", onsubmit);
const divRoot = document.getElementById('root'); // select the div element that we will put the new HTML. 

function onsubmit(e){ // this is the event listener function.
    e.preventDefault();

    const formData = new FormData(form); // collect data from the form. 

    const {towns} = Object.fromEntries(formData); // not sure what exactly this does, but transforms the data somehow 

    const townsArr = towns.split(", ");// make the data into an array.
    renderTownList(townsArr)
    form.reset();


}
function renderTownList(data){
    const result = createTownList(data)
    render(result, divRoot) // render the data. Basically attaching the created html to the div element with the render function that
    //comes from lit-html. 
}

function createTownList(data){ // this function creates the html with the html key word rd that comes from lit-html.
    // create one ul and then for each element with the map create <li> element
    const ul = html`
        <ul>
        ${data.map(el => html`<li>${el}</li>`)}
        </ul>
    `
    return ul;
}
