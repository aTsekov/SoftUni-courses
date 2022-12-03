import {html} from '../../node_modules/lit-html/lit-html.js'
import {createItem} from '.././API/data.js';
import { updateNav } from './navView.js';

export async function addNewAlbumView(ctx) {

    ctx.render(addAlbumTemplate(onSubmit))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {singer,album,imageUrl,release,label,sales} = Object.fromEntries(formData);
        if(!singer || !album|| !imageUrl || !release || !label || !sales){
            return alert ("All fields are required!")
        }
        await createItem({singer,album,imageUrl,release,label,sales});
        updateNav();
        ctx.page.redirect("/dashboard"); // redirect to the dashboard page.
    }
}

function addAlbumTemplate(handler) {
    const res =html`
    <section id="create">
        <div class="form">
          <h2>Add Album</h2>
          <form @submit =${handler} class="create-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
            <input type="text" name="album" id="album-album" placeholder="Album" />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
            <input type="text" name="release" id="album-release" placeholder="Release date" />
            <input type="text" name="label" id="album-label" placeholder="Label" />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
          </form>
        </div>
      </section>`

    return res;
}