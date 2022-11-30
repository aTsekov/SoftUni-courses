import { html } from '../../node_modules/lit-html/lit-html.js'
import { getAllItems } from '../API/data.js';

export async function dashboardView(ctx) {

    const posts = await getAllItems()// Get all pairs of items from the server. 

    ctx.render(dashboardTemplate(posts)) // we give the template all items so they can be rendered. 


}

function dashboardTemplate(posts) {
    // if there are no items - show empty, ELSE show each item
    const res =html`
    <section id="dashboard">
        <h2>Collectibles</h2>
        ${posts.length == 0 ? html`
        <!-- Display an h2 if there are no posts -->
        
            <section id="dashboard-page">
                <h1 class="title">All Posts</h1>
    
                <!-- Display a div with information about every post (if any)-->
                <div class="all-posts">`
    
                  : posts.map(postsTemplate)}
            </div>
        </section>
    `
    return res;
}

//ONE PAIR OF posts TEMPLATE
const postsTemplate = (post) =>html` 
<div class="post">
    <h2 class="post-title">${post.title}</h2>
    <img class="post-image" src="${post.imageUrl}" alt="Material Image">
    <div class="btn-wrapper">
        <a href="/details" class="details-btn btn">Details</a>
    </div>
`

