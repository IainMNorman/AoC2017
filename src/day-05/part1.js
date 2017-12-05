console.log("AoC 2017 Day 5 Part 1");

var lineReader = require('readline').createInterface({
  input: require('fs').createReadStream('input.txt')
});

var ins = [];

lineReader.on('line', function (line) {
  ins.push(+line);
});

lineReader.on('close', function (line) {
  console.log("Steps: " + go());
});

function go() {
  let curPos = 0;
  let count = 0;
  while (true) {
    if (ins[curPos] == undefined || ins[curPos] == NaN) break;
    if (curPos < 0 || curPos > ins.length) {
      break;
    }
    let newPos = getNewPos(curPos, ins);
    ins[curPos]++;
    count++;
    curPos = newPos;
  }
  return count;
}

function getNewPos(curPos, ins) {
  return curPos + ins[curPos];
}