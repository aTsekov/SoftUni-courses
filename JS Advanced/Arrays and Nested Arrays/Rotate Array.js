function rotate(arr,loops){

    for(let i = 0; i < loops; i++ ){
        let elToMove = arr.pop();
        arr.unshift(elToMove);
    }
    console.log(arr.join(' '));
}

rotate(['1', 
'2', 
'3', 
'4'], 
2);

rotate(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15);