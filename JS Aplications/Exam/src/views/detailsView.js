import { html, nothing } from '../../node_modules/lit-html/lit-html.js'
import { getItemById } from '../API/data.js';
import { deleteItemById } from '../API/data.js';



export async function detailsView(ctx) {

    const id = ctx.params.id
    const album = await getItemById(id);
    const isLogged = Boolean(ctx.user);
    const isOwner = isLogged && ctx.user._id == album._ownerId; // if the user is the creator of the record, then he will see the 
    // edit and the details button. 
    ctx.render(detailsTemplate(album, isOwner, onDelete));

    async function onDelete(){
        
        const choice = confirm('Are you sure you want to delete this item?') // this will make a pop-up with ok or cancel and not like alert with ok only.
        if (choice){
            await deleteItemById(id);
            ctx.page.redirect('/dashboard')
        }
    }

}

const detailsTemplate = (album, isOwner,onDelete) =>html`

<section id="details">
        <div id="details-wrapper">
          <p id="details-title">Album Details</p>
          <div id="img-wrapper">
            <img src="${album.imageUrl}" alt="example1" />
          </div>
          <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
            <p>
              <strong>Album name:</strong><span id="details-album">${album.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
          </div>
          <!-- <div id="likes">Likes: <span id="likes-count">0</span></div> -->

        ${isOwner ? html`
        <div id="action-buttons">
            <!-- <a href="" id="like-btn">Like</a> -->
            <a href="/edit/${album._id}" id="edit-btn">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>
          </div>` : html`
          <div id="action-buttons">
          <a href="" id="like-btn">Like</a>
          </div>
          `}

    </div>
</section>

`;

