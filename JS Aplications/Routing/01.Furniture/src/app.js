import { render } from '../node_modules/lit-html/lit-html.js';
import * as api from './api/data.js'

import page from "../node_modules/page/page.mjs";

import { catalogView } from "./views/catalog.js";
import { createView } from "./views/create.js";
import { detailsView } from "./views/details.js";
import { editView } from "./views/edit.js";
import { loginView } from "./views/login.js";
import { myFurnitureView } from "./views/myFurniture.js";
import { registerView } from "./views/register.js";

const root = document.querySelector(".container"); // this is the element where all views will be rendered in. 
//These are the different pages that will be displayed in the browser. THey are the same in the index.html file.
page("/",renderMiddleware, catalogView)
page("/catalog",renderMiddleware,catalogView)
page("/create",renderMiddleware,createView)
page("/details/:id",renderMiddleware,detailsView)
page("/edit/:id",renderMiddleware,editView)
page("/login",renderMiddleware,loginView)
page("/register",renderMiddleware,registerView)
page("/my-furniture",renderMiddleware,myFurnitureView)
page("*",catalogView)
page.start();

 //window.login = api.login; this is just to test is the login works
 //window.register = api.register;
// await window.login("antk@abv.bg","12345") // this is for the browser to test if the login works
// await window.register ("antk@abv.bg","12345")



function renderMiddleware(ctx, next){
    ctx.render = (content) => render(content, root) // content is the html template that will be written and root is the element
    //that will be the "parent" of the new html code. 
    next();
}