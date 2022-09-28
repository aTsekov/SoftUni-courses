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