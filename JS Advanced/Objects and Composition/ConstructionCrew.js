function workerFunc(dataObj) {
    let result = {}
    result.weight = dataObj.weight;
    result.experience = dataObj.experience;
    result.levelOfHydrated = dataObj.levelOfHydrated;
    result.dizziness = dataObj.dizziness;

    if(result.dizziness){
        let waterToAdd = 0.1 * result.weight * result.experience;
        result.levelOfHydrated += waterToAdd;
        result.dizziness = false;
    }
   
        console.log(result)
    return result;  
    

}

workerFunc({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
});
workerFunc({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
});
workerFunc({
    weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false
});
