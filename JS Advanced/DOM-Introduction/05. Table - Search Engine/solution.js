function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let tableRows = Array.from(document.querySelectorAll('tbody tr')); 
      let searchStr = document.getElementById('searchField').value;
      //If any of the rows contain the submitted string, add a class select to that row. 
      //Note that more than one row may contain the given string. 
      for (const row of tableRows) {

         if (!row.innerText.includes(searchStr)) {
            row.classList.remove('select');
         }
         else {
            row.className = 'select';
         }
      }
   }

   
}