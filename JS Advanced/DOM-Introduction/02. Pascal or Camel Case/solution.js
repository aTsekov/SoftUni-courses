 function solve() {
      let input = document.getElementById('text').value;
      let command = document.getElementById('naming-convention').value;
      let place = document.getElementById('result');

      let resultArr = input.toLowerCase().split(' ');
      let resultStr ="";

      for (let i = 0; i < resultArr.length; i++) {
            
            let currentWord = resultArr[i];
            if (command === "Camel Case") {
                  
                  if(i === 0) {
                        resultStr += currentWord;
                  }
                  else{
                        resultStr += currentWord[0].toUpperCase() + currentWord.substring(1)
                  }
            }
            else if (command === "Pascal Case") {
                  resultStr += currentWord[0].toUpperCase() + currentWord.substring(1);
            }
            else{
                  resultStr = 'Error!';
            }
      }
      place.innerText = resultStr;

}