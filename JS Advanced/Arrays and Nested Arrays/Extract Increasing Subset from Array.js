function solve(arr) {

    let arrResult = [];
    let currentBiggest = 0;
    arrResult.push(arr[0]);
    currentBiggest = arr[0];
    for (let i = 0; i < arr.length; i++) {    
        if (arr[i + 1] >= currentBiggest) {
            currentBiggest = arr[i + 1];
            arrResult.push(currentBiggest);
        }
    }
    return arrResult;
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]);

solve([1,
    2,
    3,
    4]);
solve([20,
    3,
    2,
    15,
    6,
    1]);
