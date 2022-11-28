import { html, nothing } from '../../node_modules/lit-html/lit-html.js'
import { getItemById } from '../API/data.js';
import { deleteItemById } from '../API/data.js';



export async function detailsView(ctx) {

    const id = ctx.params.id
    const pairOfShoes = await getItemById(id);
    const isLogged = Boolean(ctx.user);
    const isOwner = isLogged && ctx.user._id == pairOfShoes._ownerId; // if the user is the creator of the record, then he will see the 
    // edit and the details button. 
    ctx.render(detailsTemplate(pairOfShoes, isOwner, onDelete));

    async function onDelete(){
        
        const choice = confirm('Are you sure you want to delete this item?') // this will make a pop-up with ok or cancel and not like alert with ok only.
        if (choice){
            await deleteItemById(id);
            ctx.page.redirect('/dashboard')
        }
    }

}

const detailsTemplate = (pairOfShoes, isOwner,onDelete) =>html`

<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Shoe Details</p>
        <div id="img-wrapper">
            <img src="${pairOfShoes.imageUrl}" alt="example1" />
        </div>
        <div id="info-wrapper">
            <p>Brand: <span id="details-brand">${pairOfShoes.brand}</span></p>
            <p>
                Model: <span id="details-model">${pairOfShoes.model}</span>
            </p>
            <p>Release date: <span id="details-release">${pairOfShoes.release}</span></p>
            <p>Designer: <span id="details-designer">${pairOfShoes.designer}</span></p>
            <p>Value: <span id="details-value">${pairOfShoes.value}</span></p>
        </div>
        ${isOwner ? html`
        <div id="action-buttons">
            <a href="/edit/${pairOfShoes._id}" id="edit-btn">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>
        </div>` : nothing}

    </div>
</section>

`;

