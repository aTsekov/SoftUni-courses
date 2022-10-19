class SmartHike {
    constructor(userName){
        this.userName = userName;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }
    addGoal (peak, altitude){

        if(this.goals[peak] === undefined){ // if it does not exist

            this.goals[peak] = altitude;
            return `You have successfully added a new goal - ${peak}`;
        }
        else{
           return `${peak} has already been added to your goals`
        }
    }
    hike (peak, time, difficultyLevel){
        if(this.goals[peak] === undefined){
            throw new Error(`${peak} is not in your current goals`);
        }
        else if(this.goals[peak] === peak && this.resources <= 0){
            throw new Error("You don't have enough resources to start the hike");
        }
        let currentResources = this.resources;
        let multipliedTime = time * 10;
        if((currentResources - multipliedTime) < 0){
            return "You don't have enough resources to complete the hike";
        }
        else{
            this.resources -= multipliedTime;
            let obj = {peak,time,difficultyLevel}
            this.listOfHikes.push(obj);
            return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left` // should turn this in to percentage?
        }
    }
    rest (time){
        this.resources += time * 10;

        if(this.resources> 100){
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`
        }
        else{
           return `You have rested for ${time} hours and gained ${time*10}% resources`

        }
    }
    showRecord (criteria){
        if(this.listOfHikes.length === 0){
            return `${this.userName} has not done any hiking yet`
        }
        if(criteria === "hard" || criteria === "easy"){
            
            let sortedHikes = [];
            for (const obj of this.listOfHikes) {

                if(obj.difficultyLevel === criteria){
                    sortedHikes.push(obj)
                }
                
            }
            sortedHikes.sort((a, b) => Number(a.time) - Number(b.time));
            //if no hikes with this criteria:
           if(sortedHikes.length === 0) {
            return `${this.userName} has not done any ${criteria} hiking yet`
           }else{
            return `${this.userName}'s best ${criteria} hike is ${sortedHikes[0]["peak"]} peak, for ${sortedHikes[0]["time"]} hours`
           }
           
           
        }  
       else if (criteria === "all"){
    
         let report = `All hiking records:\n`;
         for (const i of this.listOfHikes) {
            report += `${this.userName} hiked ${i.peak} for ${i.time} hours`
         }
         return report;
       }

    } 
}


const user = new SmartHike('Vili');
user.addGoal('Musala', 2925);
user.hike('Musala', 8, 'hard');
console.log(user.showRecord('easy'));
user.addGoal('Vihren', 2914);
user.hike('Vihren', 4, 'hard');
console.log(user.showRecord('hard'));
user.addGoal('Rui', 1706);
user.hike('Rui', 3, 'easy');
console.log(user.showRecord('all'));

