import { html, nothing } from '../../node_modules/lit-html/lit-html.js'
import { getItemById } from '../API/data.js';
import { deleteItemById } from '../API/data.js';



export async function detailsView(ctx) {

    const id = ctx.params.id
    const offer = await getItemById(id);
    const isLogged = Boolean(ctx.user);
    const isOwner = isLogged && ctx.user._id == offer._ownerId; // if the user is the creator of the record, then he will see the 
    // edit and the details button. 
    ctx.render(detailsTemplate(offer, isOwner, onDelete));

    async function onDelete(){
        
        const choice = confirm('Are you sure you want to delete this item?') // this will make a pop-up with ok or cancel and not like alert with ok only.
        if (choice){
            await deleteItemById(id);
            ctx.page.redirect('/dashboard')
        }
    }

}

const detailsTemplate = (offer, isOwner,onDelete) =>html`

<section id="details">
          <div id="details-wrapper">
            <img id="details-img" src="${offer.imageUrl}" alt="example1" />
            <p id="details-title">${offer.title}</p>
            <p id="details-category">
              Category: <span id="categories">${offer.category}</span>
            </p>
            <p id="details-salary">
              Salary: <span id="salary-number">${offer.salary}</span>
            </p>
            <div id="info-wrapper">
              <div id="details-description">
                <h4>Description</h4>
                <span
                  >${offer.description}</span
                >
              </div>
              <div id="details-requirements">
                <h4>Requirements</h4>
                <span
                  >${offer.requirements}</span
                >
              </div>
            </div>
            <!-- <p>Applications: <strong id="applications">1</strong></p> -->
        ${isOwner ? html`
        <div id="action-buttons">
              <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
              <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>

              <!--Bonus - Only for logged-in users ( not authors )-->
              <!-- <a href="" id="apply-btn">Apply</a>
            </div> -->
            ` : nothing}


    </div>
</section>

`;

