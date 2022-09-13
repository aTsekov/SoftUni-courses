function fruit(fruit, weight,price){
    let kg = weight /1000;
    let totalMoney = price * kg;
    console.log(`I need $${totalMoney.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`)
}