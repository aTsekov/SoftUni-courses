class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        //{name}/{age}/{playerValue}
        let arrayOfGivenPlayers = [];        
        let counter = 0;
        for (let i of footballPlayers) {
            i = i.split('/')
            
            arrayOfGivenPlayers [counter] = {
                name : i [0],
                age:  i[1],
                playerValue: i[2]
            };
            counter++;
        }

        for (const playerObj of arrayOfGivenPlayers) {
            let currPlayerName = playerObj.name;

            if (this.invitedPlayers.some(obj => obj.name === currPlayerName)) {
                let currPlayr = this.invitedPlayers.find(obj => obj.name === currPlayerName);

                if (playerObj.playerValue > currPlayr.playerValue) {
                    
                   
                    currPlayr.playerValue=playerObj.playerValue 
                }
            }
            else {
                this.invitedPlayers.push(playerObj)
            }
        }
        let final = "You successfully invite ";
        let tempArr = [];
        for (const i of this.invitedPlayers) {
            if(!tempArr.includes(i.name)){
                tempArr.push(i.name);
            }
            
        }
        final += tempArr.join(', ') + ".";
        return final;
    }
    signContract(selectedPlayer){
        let playrData = [];        
        let counter = 0;
        playrData.push(selectedPlayer)

        for (let i of playrData) {
            
            i = i.split('/') ;     
            if(!this.invitedPlayers.some( p => p.name === i[0])){ //if player does not exist in the list
                throw new Error(`${i[0]} is not invited to the selection list!`);
            }
            let currplayer = this.invitedPlayers.find( p => p.name ===i[0]);
            if(currplayer.playerValue > i[1]){ //if player does not exist in the list
                let diff = Number(currplayer.playerValue) - Number(i[1]);
                throw new Error(`The manager's offer is not enough to sign a contract with ${currplayer.name}, ${diff} million more are needed to sign the contract!`);
            }
            currplayer.playerValue = "Bought";

            return `Congratulations! You sign a contract with ${currplayer.name} for ${i[1]} million dollars.`
            
        }

    }

    ageLimit(name, age){

        if(!this.invitedPlayers.find( p => p.name ===name)){
            throw new Error(`${name} is not invited to the selection list!`);
        }
        
        let currplayer = this.invitedPlayers.find( p => p.name === name)
        

        if(currplayer.age < age)   {
            let diff = age - currplayer.age;
            if (diff < 5){
                return `${name} will sign a contract for ${diff} years with ${this.clubName} in ${this.country}!`;
            }
            else{
                return`${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`
            }
        }  
        else{
            return `${name} is above age limit!`;
        }  
        
             

    }
    transferWindowResult(){
        let report = "Players list:\n";
        this.invitedPlayers.sort((a,b) => a.name.localeCompare(b.name));

        for (const pl of this.invitedPlayers) {
            report += `Player ${pl.name}-${pl.playerValue}\n`;
        }
        return report;
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());