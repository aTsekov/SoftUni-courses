import {html} from '../../node_modules/lit-html/lit-html.js'
import {updateItemById} from '.././API/data.js';
import {getItemById } from '.././API/data.js';
import { updateNav } from './navView.js';

export async function editView(ctx) {

    const id = ctx.params.id
    const offer = await getItemById(id);
    const isLogged = Boolean(ctx.user);
    const isOwner = isLogged && ctx.user._id == offer._ownerId; 

    ctx.render(editTemplate(onSubmit,offer))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {title,imageUrl,category,description,requirements,salary} = Object.fromEntries(formData);
        if(!title || !imageUrl|| !category || !description || !requirements || !salary){
            return alert ("All fields are required!")
        }
        if(isOwner){
            await updateItemById(id,{title,imageUrl,category,description,requirements,salary});
            updateNav();            
            ctx.page.redirect(`/dashboard/${id}`); // redirect to the dashboard page.
        }
       
    }
}

function editTemplate(handler,offer) {
    const res =html`<section id="edit">
    <div class="form">
      <h2>Edit offer</h2>
      <form @submit =${handler} class="edit-form">
        <input
          type="text"
          name="title"
          id="job-title"
          placeholder="Title"
          .value=${offer.title}
        />
        <input
          type="text"
          name="imageUrl"
          id="job-logo"
          placeholder="Company logo url"
          .value=${offer.imageUrl}
        />
        <input
          type="text"
          name="category"
          id="job-category"
          placeholder="Category"
          .value=${offer.category}
        />
        <textarea
          id="job-description"
          name="description"
          placeholder="Description"
          rows="4"
          cols="50"
          .value=${offer.description}
        ></textarea>
        <textarea
          id="job-requirements"
          name="requirements"
          placeholder="Requirements"
          rows="4"
          cols="50"
          .value=${offer.requirements}
        ></textarea>
        <input
          type="text"
          name="salary"
          id="job-salary"
          placeholder="Salary"
          .value=${offer.salary}
        />

        <button type="submit">post</button>
      </form>
    </div>
  </section>`

    return res;
}