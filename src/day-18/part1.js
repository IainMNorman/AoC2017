var fs = require("fs");

partOne(fs.readFileSync("input.txt").toString().split("\n"));

function partOne(input) {
    var regs = new Map();

    for (let i = 0; i < input.length; i++) {
        reg = input[i].substr(4, 1);
        if (isNaN(+reg)) {
            if (regs.get(reg) == undefined) {
                regs.set(reg, 0);
            }
        }
    }

    var lastFreq = 0;
    var pos = 0;

    while (pos >= 0 || pos < input.length) {
        let ins = input[pos].replace(/(\r\n|\n|\r)/gm,"").split(" ");
        switch (ins[0]) {
            case "snd":
                snd(getValue(ins[1]));
                break;
            case "set":
                set(ins[1], getValue(ins[2]));
                break;
            case "add":
                add(ins[1], getValue(ins[2]));
                break;
            case "mod":
                mod(ins[1], getValue(ins[2]));
                break;
            case "mul":
                mul(ins[1], getValue(ins[2]));
                break;
            case "rcv":
                rcv(getValue(ins[2]));
                console.log(lastFreq);
                break;
            case "jgz":
                jgz(getValue(ins[1]), getValue(ins[2]));
                break;
            default:
                break;
        }

    }

    console.log("End.");    

    function snd(x) {
        lastFreq = x;
        pos++;
    }

    function set(x, y) {
        regs.set(x, y);
        pos++;
    }

    function add(x, y) {
        regs.set(x, regs.get(x) + y);
        pos++
    }

    function mul(x, y) {
        regs.set(x, regs.get(x) * y);
        pos++
    }

    function mod(x, y) {
        regs.set(x, regs.get(x) % y);
        pos++
    }

    function rcv(x) {
        if (regs.get(x) != 0) {
            console.log(lastFreq);
            process.exit();
        };
        pos++;
    }

    function jgz(x, y) {
        if (x > 0) {
            pos += y
        }
        else {
            pos++;
        }
    }

    function getValue(x) {
        if (isNaN(+x)) {
            return regs.get(x);
        }
        else {
            return +x;
        }
    }
}

