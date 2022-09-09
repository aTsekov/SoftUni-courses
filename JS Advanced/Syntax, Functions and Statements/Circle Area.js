
area(5);
area('name');

function area(radius) {

    if (typeof radius === 'number') {
        let result = radius ** 2 * Math.PI
        console.log(result.toFixed(2)); // toFixed(2) is like toString in C# but here it's needed because we cannot round the number to
        // a particular sign after the decimal point. 
    }
    else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof radius}.`)
    }

}