import { html ,render} from '../../node_modules/lit-html/lit-html.js'
import{logout} from '.././API/data.js';
import page from '../../node_modules/page/page.mjs';


const nav = document.querySelector('header');


export async function updateNav(ctx){
    
    const hasUser = JSON.parse(sessionStorage.getItem("userData"));
    render(createNavTemp(hasUser),nav)

    
    
    // ctx.render(createNavTemp(hasUser), nav); 
}

function createNavTemp(hasUser) {
    
    const res =html`   
    <a id="logo" href="/"><img id="logo-img" src="./images/logo.png" alt="" /></a>
     <nav>
          <div>
            <a href="/dashboard">Dashboard</a>
            <a href="/search">Search</a>
          </div>
            ${ hasUser ?
            html`
          <!-- Logged-in users -->
          <div class="user">
            <a href="/addPair">Add Pair</a>
            <a @click=${onLogout}href="/dashboard">Logout</a>
          </div>`
            :
          html`<!-- Guest users -->
          <div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
          </div>
        </nav>`
            }
    `
    return res;
}


export function onLogout(){
    logout();
    updateNav();
    page.redirect('/')
    
    
}

