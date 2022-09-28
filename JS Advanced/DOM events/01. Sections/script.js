function create(words) {
   

   for (const word of words) {
      let div = document.createElement('div');
      let p = document.createElement('p');
      p.innerText= word;
      div.appendChild(p);
      p.style.display="none";
      div.addEventListener('click', showP)
      document.getElementById('content').appendChild(div);
   }

   function showP(event) {
      
      let p = event.target.children[0];


      p.style.display="block";

   }

   
}