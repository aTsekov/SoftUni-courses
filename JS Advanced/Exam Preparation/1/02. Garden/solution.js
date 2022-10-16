class Garden{

    constructor( spaceAvailable){
        this.spaceAvailable = spaceAvailable
        this.plants = [];
        this.storage = [];
    }

    addPlant (plantName, spaceRequired){
        if(this.spaceAvailable < spaceRequired){
            throw new Error("Not enough space in the garden.")
        }

        let plant = {
            plantName: plantName,
            spaceRequired: spaceRequired,
            ripe: false,
            quantity : 0
        };

        this.plants.push(plant);
        this.spaceAvailable -= spaceRequired;
        return `The ${plantName} has been successfully planted in the garden.`

    }

    ripenPlant(plantName, quantity){
        let IsPlantInGarden = plants.filter( p => p.plantName === plantName);
        if( !IsPlantInGarden){
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        let currentPlant = plants.find(plant => plant.plantName === plantName);
        if( currentPlant.ripe === true){
            throw new Error(`The ${plantName} is already ripe.`)
        }
        if(quantity <= 0){
            throw new Error(`The quantity cannot be zero or negative.`);
        }
        currentPlant.ripe = true;
        currentPlant.quantity = quantity;
        if(quantity === 1){
            return `${quantity} ${plantName} has successfully ripened.`
        }
        else{
            return `${quantity} ${plantName}s have successfully ripened.`
        }
    }


}


const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('olive', 50));


        
    


