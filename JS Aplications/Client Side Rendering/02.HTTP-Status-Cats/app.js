import { cats } from "./catSeeder.js";
import { html, render } from '../node_modules/lit-html/lit-html.js';

const allCatsSection = document.getElementById("allCats");
displayCats()

function displayCats() {
    const ul = html`
    <ul>
    ${cats.map(cat => renderCat(cat))}

    </ul>
    `
    render(ul, allCatsSection)
}

function renderCat(cat) {
    const oneCat = html`
    <li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn" @click = "${onClick}">Show status code</button>
        <div class="status" style="display: none" id="${cat.id}">
    <h4>Status Code: ${cat.statusCode}</h4>
    <p>${cat.statusMessage}</p>
    </div>
        
    </div>
    </li>
    `
    return oneCat;
}

function onClick(e) {

    let contentDiv = e.target.parentElement.querySelector("div");
    let divCurrentStyle = contentDiv.style.display

    if(divCurrentStyle === "none"){
        contentDiv.style.display = "block"
        e.target.textContent = "Hide status code";
    }
    else if(divCurrentStyle === "block"){
        contentDiv.style.display = "none"
    }

}