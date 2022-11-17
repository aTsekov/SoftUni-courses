import * as api from './api.js'
import {html, render} from  '../node_modules/lit-html/lit-html.js'
export {renderData};

const dropDown = document.getElementById("menu");

function renderData(){

    const reply = api.requester('get',"/jsonstore/advanced/dropdown",null)

    const p = html`
      ${reply.map(r => html`<option value =${r.id}>${r.text}</option>`)}   
   `

    render(p, dropDown)
}