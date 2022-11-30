import { html } from '../../node_modules/lit-html/lit-html.js'
import {login} from '../API/data.js';
import { updateNav } from './navView.js';


export async function loginView(ctx) {

    ctx.render(loginTemplate(onSubmit))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const {email,password} = Object.fromEntries(formData);
        if(!email || !password){
            return alert ("All fields are required!")
        }
        await login(email, password);
        updateNav();
        ctx.page.redirect("/dashboard"); // redirect to the dashboard page.
    }
}



function loginTemplate(handler) {
    const res =html`
     <section id="login-page" class="auth">
            <form @submit =${handler}id="login">
                <h1 class="title">Login</h1>

                <article class="input-group">
                    <label for="login-email">Email: </label>
                    <input type="email" id="login-email" name="email">
                </article>

                <article class="input-group">
                    <label for="password">Password: </label>
                    <input type="password" id="password" name="password">
                </article>

                <input type="submit" class="btn submit-btn" value="Log In">
            </form>
        </section>`

    return res;
}