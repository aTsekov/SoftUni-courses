import {html} from '../../node_modules/lit-html/lit-html.js'
import {createItem} from '.././API/data.js';
import { updateNav } from './navView.js';

export async function createPageView(ctx) {

    ctx.render(addPairTemplate(onSubmit))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {title,description,imageUrl,address,phone} = Object.fromEntries(formData);
        if(!title || !description|| !imageUrl || !address || !phone){
            return alert ("All fields are required!")
        }
        await createItem({title,description,imageUrl,address,phone});
        updateNav();
        ctx.page.redirect("/dashboard"); // redirect to the dashboard page.
    }
}

function addPairTemplate(handler) {
    const res =html`
    <section id="create-page" class="auth">
    <form @submit =${handler}  id="create">
                <h1 class="title">Create Post</h1>

                <article class="input-group">
                    <label for="title">Post Title</label>
                    <input type="title" name="title" id="title">
                </article>

                <article class="input-group">
                    <label for="description">Description of the needs </label>
                    <input type="text" name="description" id="description">
                </article>

                <article class="input-group">
                    <label for="imageUrl"> Needed materials image </label>
                    <input type="text" name="imageUrl" id="imageUrl">
                </article>

                <article class="input-group">
                    <label for="address">Address of the orphanage</label>
                    <input type="text" name="address" id="address">
                </article>

                <article class="input-group">
                    <label for="phone">Phone number of orphanage employee</label>
                    <input type="text" name="phone" id="phone">
                </article>

                <input type="submit" class="btn submit" value="Create Post">
            </form>
        </section>`

    return res;
}