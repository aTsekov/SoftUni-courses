import { html } from '../../node_modules/lit-html/lit-html.js'
import { getAllItems } from '../API/data.js';

export async function dashboardView(ctx) {

    const albums = await getAllItems()// Get all pairs of items from the server. 

    ctx.render(dashboardTemplate(albums)) // we give the template all items so they can be rendered. 

   
}

function dashboardTemplate(albums) {
     // if there are no items - show empty, ELSE show each item
    const res =html`
    <!-- Dashboard page -->
    <section id="dashboard">
        <h2>Albums</h2>
        <ul class="card-wrapper">
        ${albums.length == 0 ? html`
        <!-- Display an h2 if there are no posts -->
        <h2>There are no albums added yet.</h2>`

          : albums.map(albumCardTemplate)}
    </ul>
    </section>    
    `
    return res;
}

//ONE PAIR OF albums TEMPLATE
const albumCardTemplate = (album) =>html` 

          <!-- Display a li with information about every post (if any)-->
          <li class="card">
            <img src="${album.imageUrl}" alt="travis" />
            <p>
              <strong>Singer/Band: </strong><span class="singer">${album.singer}</span>
            </p>
            <p>
              <strong>Album name: </strong><span class="album">${album.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${album.sales}</span></p>
            <a class="details-btn" href="dashboard/${album._id}">Details</a>
          </li>
`

