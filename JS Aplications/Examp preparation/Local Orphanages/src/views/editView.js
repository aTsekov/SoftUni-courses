import {html} from '../../node_modules/lit-html/lit-html.js'
import {updateItemById} from '.././API/data.js';
import {getItemById } from '.././API/data.js';
import { updateNav } from './navView.js';

export async function editView(ctx) {

    const id = ctx.params.id
    const post = await getItemById(id);
    const isLogged = Boolean(ctx.user);
    const isOwner = isLogged && ctx.user._id == post._ownerId; 

    ctx.render(editTemplate(onSubmit,post))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {title,description,imageUrl,address,phone} = Object.fromEntries(formData);
        if(!title || !description|| !imageUrl || !address || !phone){
            return alert ("All fields are required!")
        }
        if(isOwner){
            await updateItemById(id,{title,description,imageUrl,address,phone});
            updateNav();            
            ctx.page.redirect(`/dashboard/${id}`); // redirect to the dashboard page.
        }
       
    }
}

function editTemplate(handler,post) {
    const res =html`<section id="edit-page" class="auth">
    <form @submit =${handler} id="edit">
        <h1 class="title">Edit Post</h1>

        <article class="input-group">
            <label for="title">Post Title</label>
            <input type="title" name="title" id="title" .value="${post.title}">
        </article>

        <article class="input-group">
            <label for="description">Description of the needs </label>
            <input type="text" name="description" id="description" .value="${post.description}">
        </article>

        <article class="input-group">
            <label for="imageUrl"> Needed materials image </label>
            <input type="text" name="imageUrl" id="imageUrl" .value="${post.imageUrl}">
        </article>

        <article class="input-group">
            <label for="address">Address of the orphanage</label>
            <input type="text" name="address" id="address" .value="${post.address}">
        </article>

        <article class="input-group">
            <label for="phone">Phone number of orphanage employee</label>
            <input type="text" name="phone" id="phone" .value="${post.phone}">
        </article>

        <input type="submit" class="btn submit" value="Edit Post">
    </form>
</section>`

    return res;
}