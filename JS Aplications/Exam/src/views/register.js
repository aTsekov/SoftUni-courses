import {html} from '../../node_modules/lit-html/lit-html.js'
import {register} from '.././API/data.js';
import { updateNav } from './navView.js';


export async function registerView(ctx) {

    ctx.render(registerTemplate(onSubmit))
    

   async function onSubmit(e){
        
        e.preventDefault();
        const formData = new FormData(e.target) // e.target should point to the form
        const data = Object.fromEntries(formData);
        if(!data.email || !data.password || !data["re-password"]) {
            return alert ("All fields are required!")
        }
        if (data.password !== data["re-password"]) {
            return alert ("The passwords do not match!")
        }
        
        await register(data.email, data.password);
        updateNav();
        ctx.page.redirect("/dashboard"); // redirect to the dashboard page.
    }
}



function registerTemplate(handler) {
    const res =html`
    <section id="register">
        <div class="form">
          <h2>Register</h2>
          <form @submit =${handler} class="login-form">
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">register</button>
            <p class="message">Already registered? <a href="/login">Login</a></p>
          </form>
        </div>
      </section>`

    return res;
}