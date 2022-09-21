function createCar(carData) {

    let result = {}
    let createEngine = {

        "Small engine": { power: 90, volume: 1800 },
        "Normal engine": { power: 120, volume: 2400 },
        "Monster engine": { power: 200, volume: 3500 }
    }
    result.model = carData.model;
    if (carData.power <= 90) {
        result.engine = createEngine["Small engine"];
    } else if (carData.power <= 120) {
        result.engine = createEngine["Normal engine"];
    }
    else {
        result.engine = createEngine["Monster engine"];
    }
    if (carData.carriage === 'hatchback') {
        result.carriage = {
            type: 'hatchback',
            color: carData.color
        }
    } else {
        result.carriage = {
            type: 'coupe',
            color: carData.color
        }
    }
    if (carData.wheelsize % 2 === 0) {
        let size = carData.wheelsize - 1;
        result.wheelsize = [size, size, size, size]
    }
    else {
        size = carData.wheelsize;
        result.wheelsize = [size, size, size, size]
    }
    console.table(result)
    return result;

}


createCar({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
});
createCar({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
})