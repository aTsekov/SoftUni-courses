document.getElementById('firstNumber').value; // Select the element with ID "firstNumber" and take its value

document.getElementById('result').innerText = result // The innerText property sets or returns the text content of an element.(in this case
// an element with ID "result")

document.getElementsByClassName("button")[0]; //hat returns a collection and we need only one element from it, 
//so the correct way is to use getElementsByClassName("button")[0] as it will return the needed span element. span.button

//This selects the TAG <span> with class button. Another way to do the same as the row above. 
document.querySelector('span.button');
<span class="button" onclick="toggle()">More</span>;

// The display property specifies if/how an element is displayed. Elements in HTML are mostly "inline" or "block" elements:
// An inline element has floating content on its left and right side. A block element fills the entire line,
// and nothing can be displayed on its left or right side. (divElement is a variable)
divElement.style.display = 'none';
divElement.style.display = 'block';

let towns = Array.from(document.querySelectorAll("#towns li")); // Here we select <ul> with id towns with the # and then all of its 
//<li> elements which are in the <ul> towns. 

town.style.textDecoration = "underline"; // each town(text or item in the list) gets text decoration and becomes bold. 
town.style.fontWeight = "bold";

for (const row of tableRows) {

    if (!row.innerText.includes(searchStr)) { // if the text is not found remove the style from the class 'select' in the css file.
       row.classList.remove('select');
    }
    else {
       row.className = 'select';// if the text is found add the class 'select' from the css file to the object and this way we apply
       //the style from the css file. 
    }
 }

 // event listener
 function create(words) {
   for (const word of words) {
      let div = document.createElement('div'); // create a new HTML element.
      let p = document.createElement('p');// create a second HTML element
      p.innerText= word; // in the inner text of the paragraph put one of the words
      div.appendChild(p); // attach the new  p to the new div
      p.style.display="none"; // mark it's style as none so it is not visible
      div.addEventListener('click', showP) // make an event listener for click events. 
      // showP is a function and wr listen to event when one of the paragraphs is clicked
      //when it's clicked make the style of the paragraph be visible. 
      document.getElementById('content').appendChild(div);
   }
   function showP(event) {    
      let p = event.target.children[0];
      p.style.display="block";
   } 
}

//get all of the buttons by input type. 
let buttons = Array.from(document.querySelectorAll("input[type=button]"));

