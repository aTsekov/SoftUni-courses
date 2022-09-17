function solve(commands){
    let resultArr = [];
    let num = 1;
    for (let  command of commands) {
        if(command === 'add'){
            resultArr.push(num);
            num++;
        }
        else if(command === 'remove'){
            resultArr.pop(resultArr[resultArr.length])
            num++;
        }
    };
    if (resultArr.length === 0){
        console.log('Empty');
    }
    else{
        
        console.log(resultArr.join('\n'));
    }

};

solve(['add', 
'add', 
'add', 
'add']);
solve(['add', 
'add', 
'remove', 
'add', 
'add']);
solve(['remove', 
'remove', 
'remove']
);