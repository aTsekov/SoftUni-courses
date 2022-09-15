function Cook(num, ...commands) {

    let result = Number(num);
    for (i = 0; i < commands.length; i++) {
        if (commands[i] === 'chop'){
            result /= 2;
        }
        else if (commands[i] === 'dice') {
           result = Math.sqrt(result);
        }
        else if (commands[i] === 'spice') {
            result += 1;
        }
        else if (commands[i] === 'bake') {
            result *= 3;
        }
        else if (commands[i] === 'fillet') {
            result *= 0.8;
        }

        console.log(result);

    }
}

Cook('32', 'chop', 'chop', 'chop', 'chop', 'chop')
console.log('--------------')
Cook('9', 'dice', 'spice', 'chop', 'bake', 'fillet')