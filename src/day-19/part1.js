let fs = require('fs');

fs.readFile(__dirname + '/input.txt', 'utf8', (err, data) => {
    let map = data.split('\n').map((l) => [...l.replace('\r', '')]);
    let coords = { r: 0, c: map[0].indexOf('|') }
    let dir = { r: 1, c: 0 }
    let letters = [];
    let steps = 0;
    while(true) {
        steps++;
        if(map[coords.r][coords.c] === '+') {
            if(dir.r === 0) {
                dir.c = 0;
                dir.r = (map[coords.r - 1] && map[coords.r - 1][coords.c] && map[coords.r - 1][coords.c] !== ' ') ? -1 : 1;
            } else {
                dir.r = 0;
                dir.c = (map[coords.r][coords.c - 1] && map[coords.r][coords.c - 1] !== ' ') ? -1 : 1;
            }
        } else if(map[coords.r][coords.c].match(/[A-Z]/)) {
            letters.push(map[coords.r][coords.c]);
        }
        coords.r += dir.r;
        coords.c += dir.c;
        if(!map[coords.r] || !map[coords.r][coords.c] || map[coords.r][coords.c] === ' ') {
            break;
        }
    }

    console.log(letters.join(''));
    console.log(steps);
});

