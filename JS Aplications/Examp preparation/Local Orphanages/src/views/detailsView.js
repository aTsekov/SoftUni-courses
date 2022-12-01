import { html, nothing } from '../../node_modules/lit-html/lit-html.js'
import { getItemById } from '../API/data.js';
import { deleteItemById } from '../API/data.js';



export async function detailsView(ctx) {

    const id = ctx.params.id
    const post = await getItemById(id);
    const isLogged = Boolean(ctx.user);
    const isOwner = isLogged && ctx.user._id == post._ownerId; // if the user is the creator of the record, then he will see the 
    // edit and the details button. 
    ctx.render(detailsTemplate(post, isOwner, onDelete));

    async function onDelete() {
        

        const choice = confirm('Are you sure you want to delete this item?') // this will make a pop-up with ok or cancel and not like alert with ok only.
        if (choice) {
            await deleteItemById(id);
            ctx.page.redirect('/dashboard')
        }
    }

}

const detailsTemplate = (post, isOwner, onDelete) =>html`

<section id="details-page">
    <h1 class="title">Post Details</h1>

    <div id="container">
        <div id="details">
            <div class="image-wrapper">
                <img src="${post.imageUrl}" alt="Material Image" class="post-image">
            </div>
            <div class="info">
                <h2 class="title post-title">${post.title}</h2>
                <p class="post-description">Description: ${post.description}</p>
                <p class="post-address">Address: ${post.address}</p>
                <p class="post-number">Phone number: ${post.phone}</p>
                <p class="donate-Item">Donate Materials: 0</p>

                ${isOwner ? html`
                <div class="btns">
                    <a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="delete-btn btn">Delete</a>

                </div>` : nothing}

            </div>
        </div>
    </div>
</section>

`;

