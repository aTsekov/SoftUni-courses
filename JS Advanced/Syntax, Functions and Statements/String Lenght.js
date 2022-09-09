
let a = 'pasta';
let b = '5';
let c = '22.3';
averageLenght(a,b,c);

function averageLenght(a, b, c) {
let sumLenght = a.length + b.length + c.length;
let averageLenght = Math.floor(sumLenght / 3);
console.log(sumLenght);
console.log(averageLenght);

}
