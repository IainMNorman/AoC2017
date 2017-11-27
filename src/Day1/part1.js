var lineReader = require('readline').createInterface({
  input: require('fs').createReadStream('input.txt')
});

var output;

lineReader.on('line', function (line) {
  // solution
});

console.log(output);
