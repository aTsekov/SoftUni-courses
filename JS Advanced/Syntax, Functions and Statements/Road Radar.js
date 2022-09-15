function Radar(currSpeed, area) {
    const motorwayLimit = 130;
    const interstateLimit = 90;
    const cityLimit = 50;
    const residentialLimit = 20;
    let limit = 0;
    if (area === 'motorway') {
        limit = motorwayLimit;
    }
    else if (area === 'interstate') {
        limit = interstateLimit;
    }
    else if (area === 'city') {
        limit = cityLimit;
    }
    else if (area === 'residential') {
        limit = residentialLimit;
    }

    currSpeed = Number(currSpeed);
    if (currSpeed <= limit) {
        console.log(`Driving ${currSpeed} km/h in a ${limit} zone`)
    }
    else{
        let status;
        let difference = currSpeed - limit;

        if (difference  <= 20 && difference > 0) {
            status = 'speeding';
        }
        else if (difference > 20 && difference <= 40){
            status = 'excessive speeding';
        }
        else{
            status = 'reckless driving'
        }
        console.log(`The speed is ${currSpeed - limit} km/h faster than the allowed speed of ${limit} - ${status}`)

    }

}

Radar('40', 'city')
Radar('21', 'residential')
Radar('120', 'interstate')
Radar('200', 'motorway')