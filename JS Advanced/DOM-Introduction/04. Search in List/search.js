function search() {

   let towns = Array.from(document.querySelectorAll("#towns li"));
   let textToSearch = document.getElementById('searchText').value;


   let count = 0;

   for (let town of towns) {
      let text = town.textContent;

      if (text.includes(textToSearch)) {
         town.style.textDecoration = "underline";
         town.style.fontWeight = "bold";
         count++;
      }
      else {
         town.style.textDecoration = "none";
         town.style.fontWeight = "";
      }

   }

   document.getElementById("result").innerHTML = `${count} matches found`;
}
