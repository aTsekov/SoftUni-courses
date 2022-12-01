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
    <!-- Navigation -->
    
    
    <h1><a href="/">Orphelp</a></h1>

<nav>
    <a href="/">Dashboard</a>
            ${ hasUser ?
            html`
          <!-- Logged-in users -->
          <div id="user">
                    <a href="/myPosts">My Posts</a>
                    <a href="/createPage">Create Post</a>
                    <a @click=${onLogout} href="/dashboard">Logout</a>
                </div>`
            :
          html`<!-- Guest users -->
            <div id="guest">
                    <a href="/login">Login</a>
                    <a href="/register">Register</a>
                </div>
            </nav>`
            }`
    return res;
}


export function onLogout(){
    logout();
    updateNav();
    page.redirect('/')
    
    
}

