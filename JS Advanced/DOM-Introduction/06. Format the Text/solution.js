function solve() {

  let input = document.getElementById('input').value;
  let output = document.getElementById('output');

  let resultArr = input.split('.');
  resultArr.pop();

  let counter = 0;
  let threeSentences = '';
  let flag = false;
  for (let i = 0; i < resultArr.length; i++) {


    if (counter <= 3) {
      threeSentences += resultArr[i] + '. ';
      counter++;
      if (counter === 3 || resultArr.length === i + 1) {
        flag = true;
        counter = 0;
      }
    }


    if (flag === true) {
      let res = `<p>${threeSentences.trimEnd()}</p>`;
      output.innerHTML += res;
      res = '';
      threeSentences = "";
      flag = false;

    }

  }

}