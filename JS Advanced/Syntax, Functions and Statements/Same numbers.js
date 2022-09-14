function solve(inputNum) {


    let numAsStr = String(inputNum);
    let firstDigit = numAsStr[0];
    let isSame = true;
    let sum = 0;
    for (let i = 0; i < numAsStr.length; i++) {
        sum += Number(numAsStr[i]);

        if (numAsStr[i] != firstDigit) {
             isSame = false;
        };
    };

   console.log(isSame);
   console.log(sum);
};

solve(2222222);
solve(1234);