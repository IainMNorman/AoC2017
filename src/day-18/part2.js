"use strict"

class Prog {
    constructor(number, instructions) {
        this.instructions = instructions;
        this.pos = 0;
        this.initRegs(number);
        this.queue = [];
        this.running = true;
        this.sendCount = 0;
        this.waiting = false;
    }

    step() {
        if (this.pos < 0 || this.pos >= this.instructions.length) {
            this.running = false;
            return;
        }

        let ins = this.instructions[this.pos].replace(/(\r\n|\n|\r)/gm, "").split(" ");
        switch (ins[0]) {
            case "snd":
                this.snd(this.getValue(ins[1]));
                break;
            case "set":
                this.set(ins[1], this.getValue(ins[2]));
                break;
            case "add":
                this.add(ins[1], this.getValue(ins[2]));
                break;
            case "mod":
                this.mod(ins[1], this.getValue(ins[2]));
                break;
            case "mul":
                this.mul(ins[1], this.getValue(ins[2]));
                break;
            case "rcv":
                this.rcv(ins[1]);
                break;
            case "jgz":
                this.jgz(this.getValue(ins[1]), this.getValue(ins[2]));
                break;
            default:
                break;
        }
    }

    snd(x) {
        this.sibling.queue.push(x);
        this.sendCount++;
        this.pos++;
    }

    set(x, y) {
        this.regs.set(x, y);
        this.pos++;
    }

    add(x, y) {
        this.regs.set(x, this.regs.get(x) + y);
        this.pos++
    }

    mul(x, y) {
        this.regs.set(x, this.regs.get(x) * y);
        this.pos++
    }

    mod(x, y) {
        this.regs.set(x, this.regs.get(x) % y);
        this.pos++
    }

    rcv(x) {
        if (this.queue.length > 0) {
            this.waiting = false;
            this.regs.set(x, this.queue[0]);
            this.queue.splice(0, 1);            
            this.pos++;
        }
        else {
            this.waiting = true;
        }        
    }

    jgz(x, y) {
        if (x > 0) {
            this.pos += y
        }
        else {
            this.pos++;
        }
    }

    getValue(x) {
        if (isNaN(+x)) {
            return this.regs.get(x);
        }
        else {
            return +x;
        }
    }

    initRegs(number) {
        this.regs = new Map();
        for (let i = 0; i < this.instructions.length; i++) {
            let reg = this.instructions[i].replace(/(\r\n|\n|\r)/gm, "").split(" ")[1];
            if (isNaN(reg)) {
                if (this.regs.get(reg) == undefined) {
                    this.regs.set(reg, number);
                }
            }
        }
    }
}
var fs = require("fs");
let ins = fs.readFileSync("input.txt").toString().split("\n")
let p0 = new Prog(0, ins);
let p1 = new Prog(1, ins);
p0.sibling = p1;
p1.sibling = p0;

while (p0.running || p1.running) {
    p0.step();
    p1.step();
    if (p0.waiting && p1.waiting) {
        break
    };
}
console.log(p1.sendCount);
console.log("Done.")




