function walk(steps, footPrint, speed) {
    let distanceInMeters = steps * footPrint;
    let speedMetersInSec = speed / 3.6;
    let time = distanceInMeters / speedMetersInSec;
    let rest = Math.floor(distanceInMeters / 500);

    let timeInMin = Math.floor(time / 60);

    let timeInSec = Number(time - (timeInMin * 60)).toFixed(0);
    let timeInH = Math.floor(time / 3600);
    timeInMin += rest;
    timeInH += Math.floor(timeInMin / 60);
    timeInMin = timeInMin % 60;

    let formattedH = timeInH < 10 ? `0${timeInH}` : `${timeInH}`;
    let formattedM = timeInMin < 10 ? `0${timeInMin}` : `${timeInMin}`;
    let formattedS = timeInSec < 10 ? `0${timeInSec}` : `${timeInSec}`;
    console.log(`${formattedH}: ${formattedM}:${formattedS}`);

}

walk(4000, 0.60, 5);
walk(2564, 0.70, 5.5);
