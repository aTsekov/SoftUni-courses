function calc(numOne, numTwo, operation) {
    let result;

    if (operation == '+'){
        result = numOne + numTwo;
    }
    else if (operation == '-') {
        result = numOne - numTwo;
    }
    else if (operation == '*'){
        result = numOne * numTwo;
    }
    else if (operation == '/') {
        result = numOne / numTwo;
    }
    else if (operation == '%'){
        result = numOne % numTwo;
    }
    else if (operation == '**'){
        result = numOne ** numTwo;
    }
    console.log(result);

}