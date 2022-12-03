import {html} from '../../node_modules/lit-html/lit-html.js'
import {updateItemById} from '.././API/data.js';
import {getItemById } from '.././API/data.js';
import { updateNav } from './navView.js';

export async function editView(ctx) {

    const id = ctx.params.id
    const album = await getItemById(id);
    const isLogged = Boolean(ctx.user);
    const isOwner = isLogged && ctx.user._id == album._ownerId; 

    ctx.render(editTemplate(onSubmit,album))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {singer,album,imageUrl,release,label,sales} = Object.fromEntries(formData);
        if(!singer || !album|| !imageUrl || !release || !label || !sales){
            return alert ("All fields are required!")
        }
        if(isOwner){
            await updateItemById(id,{singer,album,imageUrl,release,label,sales});
            updateNav();            
            ctx.page.redirect(`/dashboard/${id}`); // redirect to the dashboard page.
        }
       
    }
}

function editTemplate(handler,album) {
    const res =html`<section id="edit">
    <div class="form">
      <h2>Edit Album</h2>
      <form @submit =${handler} class="edit-form">
        <input type="text" name="singer" id="album-singer" placeholder="Singer/Band"  .value=${album.singer} />
        <input type="text" name="album" id="album-album" placeholder="Album" .value=${album.album} />
        <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value=${album.imageUrl} />
        <input type="text" name="release" id="album-release" placeholder="Release date" .value=${album.release} />
        <input type="text" name="label" id="album-label" placeholder="Label" .value=${album.label} />
        <input type="text" name="sales" id="album-sales" placeholder="Sales" .value=${album.sales} />

        <button type="submit">post</button>
      </form>
    </div>
  </section>`

    return res;
}