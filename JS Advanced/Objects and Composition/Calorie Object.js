function calorieObject(data) {
    let result = {}

    for (let i = 0; i < data.length; i += 2) {
        result[data[i]] = Number(data[i + 1]); // this waw we create an object of each KVP. 


    }

    console.log(result)
}




calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52'])
console.log('-------------')
calorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42'])


// Here is an example of the different syntax for filling an object:

function solve(){

    //A new object is declared.
    let car1 = {}
    //these are 3 different ways to create a property and give it a value
    // FIRST WAY
    car1.name = "Volvo";
    //SECOND WAY
    car1["another name"] = "another Volvo"
    //THIRD WAY
    let name = "name3";
    car1[name] = "Third Volvo";

}
