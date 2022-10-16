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
        let IsPlantInGarden = this.plants.some( p => p.plantName === plantName);
        if( !IsPlantInGarden){
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        let currentPlant = this.plants.find(plant => plant.plantName === plantName);
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
    harvestPlant(plantName){
        let IsPlantInGarden = this.plants.some( p => p.plantName === plantName);
        if( !IsPlantInGarden){
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        let currentPlant = this.plants.find(plant => plant.plantName === plantName);
        if( currentPlant.ripe === false){
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`)
        }
       
        let curr = this.plants.filter(p => p.plantNames === plantName)
        this.plants = curr;
        let plantForStorage = {
            plantName: currentPlant.plantName,
            quantity: currentPlant.quantity
        }
        this.storage.push(plantForStorage);
        this.spaceAvailable += currentPlant.quantity; // Is this correct? Do I need to increase the spaceAvailable like this?
        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport(){
        let ArrOfNames = [];
        for (const name of this.plants) {
            ArrOfNames.push(name);
        }
        let report = `The garden has ${this.spaceAvailable } free space left.\nPlants in the garden: ${ArrOfNames.join(', ')}`;
    }


}


const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());





        
    


