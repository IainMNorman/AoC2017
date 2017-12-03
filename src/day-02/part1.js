var lineReader = require('readline').createInterface({
  input: require('fs').createReadStream('input.txt')
});

var output = 0;

lineReader.on('line', function (line) {
  cells = line.split('\t');
  cells.sort((a,b) => {
    return +b - +a;
  });
  output += cells[0] - cells[cells.length-1];
});

lineReader.on('close', function (line) {
  console.log(output);
});

