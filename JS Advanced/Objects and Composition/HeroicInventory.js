function heroicInventory(input){
    // • We need an array that will hold our hero data. That is the first thing we create.
 let result = [];
// • Next, we need to loop over the whole input and process it. Let’s do that with a simple for loop.
 for (const i of input) {
    //• Every element from the input holds data about a hero, however, the elements from the data we need are separated by some delimiter,
    // so we just split each string with that delimiter.
    // • Next, we need to take the elements from the string array, which is a result of the string split, and by destructuring assignment 
    //syntax, we assign the array properties. Don’t forget to parse the number.
    let [name, level, items] = i.split(' / ');
    level = Number(level);
    //you will notice that there might be a case where the hero has no items; in that case, using destructuring is ok and when there are no items, our property items will be undefined and trying to spit it will throw an error.
    //That is why we need to perform a simple check using the ternary operator.
    items = items ? items.split(', ') : []; //If there are any items in the input, the variable will be set to the split version of them. 
    //If not, it will just be set to an empty array.

    // • We have now extracted the needed data – we have stored the input name in a variable, we have parsed the given level to a number, and we have also split the items that the hero holds by their delimiter, which would result in a string array of elements. 
    //By definition, the items are strings, so we don’t need to process the array we’ve made anymore. 
    result.push({name, level, items})
 }
 // • Lastly, we need to turn the array of objects we have made, into a JSON string, which is done by the JSON.stringify() function
 console.log(JSON.stringify(result));
}

heroicInventory(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara'])