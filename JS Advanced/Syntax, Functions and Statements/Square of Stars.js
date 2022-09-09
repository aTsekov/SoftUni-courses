
function sq (a){
    if(typeof a != 'number'){
         a = 5;
    }
    

    for(let j = 0; j < a; j++){
        console.log(`${('* '.repeat(a)).trimEnd()}`);
    }
    
    
}

sq(3);
