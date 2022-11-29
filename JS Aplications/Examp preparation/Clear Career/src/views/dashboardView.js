import { html } from '../../node_modules/lit-html/lit-html.js'
import { getAllItems } from '../API/data.js';

export async function dashboardView(ctx) {

    const offers = await getAllItems()// Get all pairs of items from the server. 

    ctx.render(dashboardTemplate(offers)) // we give the template all items so they can be rendered. 

}

function dashboardTemplate(offers) {
    // if there are no items - show empty, ELSE show each item
    const res =html`
    <section id="dashboard">
        <h2>Job Offers</h2>
        ${offers.length == 0 ? html`
        <!-- Display an h2 if there are no posts -->
        <h2>No offers yet.</h2>`
    
          : offers.map(offerTemplate)}
    
    </section>
    `
    return res;
}

//ONE PAIR OF SHOES TEMPLATE
const offerTemplate = (offer) =>html` 
<div class="offer">
    <img src="${offer.imageUrl}" alt="example1" />
    <p>
        <strong>Title: </strong><span class="title">${offer.title}</span>
    </p>
    <p><strong>Salary:</strong><span class="salary">${offer.salary}</span></p>
    <a class="details-btn" href="/dashboard/${offer._id}">Details</a>
</div>`

