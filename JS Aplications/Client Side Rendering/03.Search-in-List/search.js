import { towns} from './towns.js'; 
import {html, render} from  '../node_modules/lit-html/lit-html.js';

let divTowns = document.getElementById('towns');


showCities();
let searchButton = document.getElementsByTagName("button")[0];
 searchButton.addEventListener('click', search);


function showCities() {

   let textToSearch = document.getElementById('searchText').value;
   let cities = html`
   <ul>
     ${towns.map( townsName => createLiTemplate( townsName, textToSearch))}                
   </ul>
   `
   update(cities, divTowns)
}

function createLiTemplate(towns, textToSearch) {
   return html`
   <li class = "${(textToSearch && towns.includes(textToSearch)) ? "active" : ""}">${towns}</li>
   `
   // if texToToSearch is not undefined or empty and towns include the text to search then make the class active 
   //else, do not make it active.
}

function update(result, divEl){
    render(result, divEl)
}

function numberOfMatches(){
   let count = document.querySelectorAll(".active").length;
   let divResult = document.getElementById('result')
   let res = html`<p>${count} matches found</p>`;
   render(res, divResult)
   
}


function search() {
   showCities();
   numberOfMatches();
   
   



}
