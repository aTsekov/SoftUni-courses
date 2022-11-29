import {html} from '../../node_modules/lit-html/lit-html.js'
import {createItem} from '.././API/data.js';
import { updateNav } from './navView.js';

export async function createOfferView(ctx) {

    ctx.render(addOfferTemplate(onSubmit))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {title,imageUrl,category,description,requirements,salary} = Object.fromEntries(formData);
        if(!title || !imageUrl|| !category || !description || !requirements || !salary){
            return alert ("All fields are required!")
        }
        await createItem({title,imageUrl,category,description,requirements,salary});
        updateNav();
        ctx.page.redirect("/dashboard"); // redirect to the dashboard page.
    }
}

function addOfferTemplate(handler) {
    const res =html`
    <section id="create">
          <div class="form">
            <h2>Create Offer</h2>
            <form @submit =${handler} class="create-form">
              <input
                type="text"
                name="title"
                id="job-title"
                placeholder="Title"
              />
              <input
                type="text"
                name="imageUrl"
                id="job-logo"
                placeholder="Company logo url"
              />
              <input
                type="text"
                name="category"
                id="job-category"
                placeholder="Category"
              />
              <textarea
                id="job-description"
                name="description"
                placeholder="Description"
                rows="4"
                cols="50"
              ></textarea>
              <textarea
                id="job-requirements"
                name="requirements"
                placeholder="Requirements"
                rows="4"
                cols="50"
              ></textarea>
              <input
                type="text"
                name="salary"
                id="job-salary"
                placeholder="Salary"
              />

              <button type="submit">post</button>
            </form>
          </div>
        </section>`

    return res;
}