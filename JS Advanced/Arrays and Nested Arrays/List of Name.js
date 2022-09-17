function sortNames(arr){
    arr.sort();
    for (let i = 0; i < arr.length; i++) {
        arr[i] = i+1 + '.' + arr[i]
        
    }
     console.log(arr.join('\n'));
}

sortNames(["John", "Bob", "Christina", "Ema"])