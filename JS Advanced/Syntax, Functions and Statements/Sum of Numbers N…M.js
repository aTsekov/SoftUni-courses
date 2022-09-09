
console.log( sumNums('-8', '20'));


function sumNums(a, b) {
    let numA = Number(a);
    let numB = Number(b);

    let result = 0;
    

    for(let i = numA; i <= numB; i++) {

        result += i;
    }
    return result;

}


