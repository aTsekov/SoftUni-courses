import { html } from '../../node_modules/lit-html/lit-html.js'
import { getAllItems } from '../API/data.js';

export async function dashboardView(ctx) {

    const posts = await getAllItems()// Get all pairs of items from the server. 

    ctx.render(dashboardTemplate(posts)) // we give the template all items so they can be rendered. 


}

function dashboardTemplate(posts) {
    // if there are no items - show empty, ELSE show each item
    const res =html`
<section id="dashboard-page">
            <h1 class="title">All Posts</h1>
    ${posts.length == 0 ? html`
    <!-- Display an h2 if there are no posts -->
    <h1 class="title no-posts-title">No posts yet!</h1>`

         : posts.map(postCardTemplate)}

</section>
   `
    return res;
}

//ONE PAIR OF SHOES TEMPLATE
const postCardTemplate = (post) =>html`
<div class="all-posts">
    <div class="post">
        <h2 class="post-title">${post.title}</h2>
        <img class="post-image" src="${post.imageUrl}" alt="Material Image">
        <div class="btn-wrapper">
            <a href="/dashboard/${post._id}" class="details-btn btn">Details</a>
        </div>
    </div>
</div>
`