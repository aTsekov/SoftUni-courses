import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { homeView } from './views/homeView.js';
import { createPageView } from './views/createPageView.js';
import { dashboardView } from './views/dashboardView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { updateNav } from './views/navView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
//import { createMyPostsView } from './views/myPostsView.js';



const root = document.getElementById('main-content'); // DO NOT FORGET TO ADJUST THE ROOT!!!

//page(renderMiddleware); to test


page("/", renderMiddleware, dashboardView);
page("/dashboard", renderMiddleware, dashboardView);
page("/dashboard/:id", renderMiddleware, detailsView);
page("/edit/:id", renderMiddleware, editView);
page("/createPage", renderMiddleware, createPageView);
//page("/myPosts", renderMiddleware, createMyPostsView); // !!!!!!!!!!!!!!!!
page("/login", renderMiddleware, loginView);
page("/register", renderMiddleware, registerView); 
page("*", homeView);

updateNav();
page.start();

//window.login = api.login; //this is just to test is the login works
//window.register = api.register;
//await window.login("antk@abv.bg","12345") // this is for the browser to test if the login works
//await window.register ("antk@abv.bg","12345")test

function renderMiddleware(ctx, next) {
    ctx.render = (content) => render(content, root) // content is the html template that will be written and root is the element
   //that will be the "parent" of the new html code. 

    const user = JSON.parse(sessionStorage.getItem("userData"));
    if (user){ // we place the user in the context.
        ctx.user = user;
    }
    next();
}