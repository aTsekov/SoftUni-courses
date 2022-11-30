import {html} from '../../node_modules/lit-html/lit-html.js'
import {updateItemById} from '.././API/data.js';
import {getItemById } from '.././API/data.js';
import { updateNav } from './navView.js';

export async function editView(ctx) {

    const id = ctx.params.id
    const pairOfShoes = await getItemById(id);
    const isLogged = Boolean(ctx.user);
    const isOwner = isLogged && ctx.user._id == pairOfShoes._ownerId; 

    ctx.render(editTemplate(onSubmit,pairOfShoes))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {brand,model,imageUrl,release,designer,value} = Object.fromEntries(formData);
        if(!brand || !model|| !imageUrl || !release || !designer || !value){
            return alert ("All fields are required!")
        }
        if(isOwner){
            await updateItemById(id,{brand,model,imageUrl,release,designer,value});
            updateNav();            
            ctx.page.redirect(`/dashboard/${id}`); // redirect to the dashboard page.
        }
       
    }
}

function editTemplate(handler,pairOfShoes) {
    const res =html`<section id="edit">
    <div class="form">
      <h2>Edit item</h2>
      <form @submit =${handler} class="edit-form">
      <input
                type="text"
                name="brand"
                id="shoe-brand"
                placeholder="Brand"
                .value=${pairOfShoes.brand}
              />
              <input
                type="text"
                name="model"
                id="shoe-model"
                placeholder="Model"
                .value=${pairOfShoes.model}
              />
              <input
                type="text"
                name="imageUrl"
                id="shoe-img"
                placeholder="Image url"
                .value=${pairOfShoes.imageUrl}
              />
              <input
                type="text"
                name="release"
                id="shoe-release"
                placeholder="Release date"
                .value=${pairOfShoes.release}
              />
              <input
                type="text"
                name="designer"
                id="shoe-designer"
                placeholder="Designer"
                .value=${pairOfShoes.designer}
              />
              <input
                type="text"
                name="value"
                id="shoe-value"
                placeholder="Value"
                .value=${pairOfShoes.value}
              />

        <button type="submit">post</button>
      </form>
    </div>
  </section>`

    return res;
}