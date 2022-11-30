import {html} from '../../node_modules/lit-html/lit-html.js'
import {register} from '.././API/data.js';
import { updateNav } from './navView.js';


export async function registerView(ctx) {

    ctx.render(registerTemplate(onSubmit))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const data = Object.fromEntries(formData);
        if(!data.email || !data.password || !data["repeatPassword"]) {
            return alert ("All fields are required!")
        }
        if (data.password !== data["repeatPassword"]) {
            return alert ("The passwords do not match!")
        }
        
        await register(data.email, data.password);
        updateNav();
        ctx.page.redirect("/dashboard"); // redirect to the dashboard page.
    }
}



function registerTemplate(handler) {
    const res =html`
    <section id="register-page" class="auth">
            <form @submit =${handler} id="register">
                <h1 class="title">Register</h1>

                <article class="input-group">
                    <label for="register-email">Email: </label>
                    <input type="email" id="register-email" name="email">
                </article>

                <article class="input-group">
                    <label for="register-password">Password: </label>
                    <input type="password" id="register-password" name="password">
                </article>

                <article class="input-group">
                    <label for="repeat-password">Repeat Password: </label>
                    <input type="password" id="repeat-password" name="repeatPassword">
                </article>

                <input type="submit" class="btn submit-btn" value="Register">
            </form>
        </section>`

    return res;
}