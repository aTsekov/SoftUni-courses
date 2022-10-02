function sortArr(arr, command){
    return command === 'asc' ? arr.sort((a, b) => a - b) : arr.sort((a, b) => b - a);
    // if command is 'asc' then sort ascending else sort descending. 
}

sortArr([14, 7, 17, 6, 8], 'asc');
sortArr([14, 7, 17, 6, 8], 'desc');