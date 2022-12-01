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


`;
