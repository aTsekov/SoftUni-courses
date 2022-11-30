import {html} from '../../node_modules/lit-html/lit-html.js'
import {createItem} from '.././API/data.js';
import { updateNav } from './navView.js';

export async function createPageView(ctx) {

    ctx.render(addPairTemplate(onSubmit))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {brand,model,imageUrl,release,designer,value} = Object.fromEntries(formData);
        if(!brand || !model|| !imageUrl || !release || !designer || !value){
            return alert ("All fields are required!")
        }
        await createItem({brand,model,imageUrl,release,designer,value});
        updateNav();
        ctx.page.redirect("/dashboard"); // redirect to the dashboard page.
    }
}

function addPairTemplate(handler) {
    const res =html`
    <section id="create">
          <div class="form">
            <h2>Add item</h2>
            <form @submit =${handler} class="create-form">
              <input
                type="text"
                name="brand"
                id="shoe-brand"
                placeholder="Brand"
              />
              <input
                type="text"
                name="model"
                id="shoe-model"
                placeholder="Model"
              />
              <input
                type="text"
                name="imageUrl"
                id="shoe-img"
                placeholder="Image url"
              />
              <input
                type="text"
                name="release"
                id="shoe-release"
                placeholder="Release date"
              />
              <input
                type="text"
                name="designer"
                id="shoe-designer"
                placeholder="Designer"
              />
              <input
                type="text"
                name="value"
                id="shoe-value"
                placeholder="Value"
              />

              <button type="submit">post</button>
            </form>
          </div>
        </section>`

    return res;
}