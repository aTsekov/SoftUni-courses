import { html } from '../../node_modules/lit-html/lit-html.js'
import { getAllItems } from '../API/data.js';

export async function dashboardView(ctx) {

    const shoes = await getAllItems()// Get all pairs of items from the server. 

    ctx.render(dashboardTemplate(shoes)) // we give the template all items so they can be rendered. 

   
}

function dashboardTemplate(shoes) {
     // if there are no items - show empty, ELSE show each item
    const res =html`
    <section id="dashboard">
        <h2>Collectibles</h2>
        ${shoes.length == 0 ? html`
        <!-- Display an h2 if there are no posts -->
        <h2>There are no items added yet.</h2>`

          : shoes.map(shoeCardTemplate)}
    
    </section>    
    `
    return res;
}

//ONE PAIR OF SHOES TEMPLATE
const shoeCardTemplate = (shoesPair) =>html` 
<ul class="card-wrapper">
    <!-- Display a li with information about every post (if any)-->
    <li class="card">
        <img src="${shoesPair.imageUrl}" alt="travis" />
        <p>
            <strong>Brand: </strong><span class="brand">${shoesPair.brand}</span>
        </p>
        <p>
            <strong>Model: </strong><span class="model">${shoesPair.model}</span>
        </p>
        <p><strong>Value:</strong><span class="value">${shoesPair.value}</span>$</p>
        <a class="details-btn" href="/dashboard/${shoesPair._id}">Details</a>
    </li>
</ul>`

