var _ = require('lodash');

var lineReader = require('readline').createInterface({
  input: require('fs').createReadStream('input.txt')
});

var output = 0;

function validPassword(array) {
  return _.uniq(array).length == array.length;
}

lineReader.on('line', function (line) {
  items = line.split(' ');
  if (validPassword(items)) {
    output++;
  }
});

lineReader.on('close', function (line) {
  console.log(output);
});