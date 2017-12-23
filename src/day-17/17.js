console.log(partOne(356, 2017));
console.log(partTwo(356, 50000000));

function partOne(step, runs) {
    var pos = 0;
    var array = [0];

    for (let i = 0; i < runs; i++) {
        pos = ((pos + step) % array.length) + 1;
        array.splice(pos, 0, i + 1);
    }
    
    return array[pos + 1];
}

function partTwo(step, runs) {
    var pos = 0;
    var array = 1;
    var lastPos1 = 0;

    for (let i = 0; i < runs; i++) {
        pos = ((pos + step) % array) + 1;
        if (pos == 1) {
            lastPos1 = i;
        };
        array++;
    }

    return lastPos1 + 1;
}