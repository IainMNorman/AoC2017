function getCoords(tileNum) {
    // 0 index it
    tileNum--;

    let tileNumRootFloored = Math.floor(Math.sqrt(tileNum));

    let x =
        (
            Math.round(tileNumRootFloored / 2) *
            Math.pow(-1, tileNumRootFloored + 1)
        )
        +
        (
            Math.pow(-1, tileNumRootFloored + 1) *
            (
                ((tileNumRootFloored * (tileNumRootFloored + 1)) - tileNum) -
                Math.abs((tileNumRootFloored * (tileNumRootFloored + 1)) - tileNum)
            )
            / 2
        );

    let y = 
        (
            Math.round(tileNumRootFloored / 2) * 
            Math.pow(-1, tileNumRootFloored)
        )
        +
        (
            Math.pow(-1, tileNumRootFloored + 1) * 
            (
                ((tileNumRootFloored * (tileNumRootFloored + 1)) - tileNum) + 
                Math.abs((tileNumRootFloored * (tileNumRootFloored + 1)) - tileNum)
            ) 
            / 2
        );

    return { "x": x, "y": y };
}

function getDistance(coords)
{
    return (Math.abs(coords.x) + Math.abs(coords.y));
}
console.log(getDistance(getCoords(1)));
console.log(getDistance(getCoords(12)));
console.log(getDistance(getCoords(23)));
console.log(getDistance(getCoords(1024)));
console.log(getDistance(getCoords(361527)));