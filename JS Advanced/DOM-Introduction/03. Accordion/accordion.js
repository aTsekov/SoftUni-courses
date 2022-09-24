 
    function toggle() {
      let button = document.getElementsByClassName("button")[0];
      
      let divElement = document.getElementById("extra")

      if(button.textContent == 'More') {
        divElement.style.display = 'block';
        button.textContent = 'Less';
      }
      else if(button.textContent == 'Less') {
        divElement.style.display = 'none';
        button.textContent = 'More';
      }
    }
