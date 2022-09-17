function sortNames(arr){
    arr.sort((a,b) => a.localeCompare(b));// sort names. With localeCompare we make sure that small/capital letters are  disregarded.

    for (let i = 0; i < arr.length; i++) {
        arr[i] = i+1 + '.' + arr[i]
        
    }
     console.log(arr.join('\n'));
}

sortNames(["John", "Bob", "Christina", "Ema"])