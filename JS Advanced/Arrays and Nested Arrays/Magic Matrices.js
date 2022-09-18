function magicMatrix(arr) {
    let currRowSum = 0;
    let nextRowSum = 0;
    for (let row = 0; row < arr.length - 1; row++) {
        
        for (let col = 0; col < arr.length; col++) {
            currRowSum += arr[row][col];
            nextRowSum += arr[row+1][col];
            
        }
        if(currRowSum !== nextRowSum){
            //console.log(false)
            return false
        }
        
    }
    //console.log(true)
    return true;

}

magicMatrix([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]);
magicMatrix([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]);