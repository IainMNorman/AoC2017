var _ = require('lodash');

var lineReader = require('readline').createInterface({
  input: require('fs').createReadStream('input.txt')
});

var output = 0;

function validPassword(array) {
  return _.uniq(array).length == array.length;
}

lineReader.on('line', function (line) {
  passwords = line.split(' ');
  passwords = passwords.map(x => [...x].sort().join(''));
  if (validPassword(passwords)) {
    output++;
  }
});

lineReader.on('close', function (line) {
  console.log(output);
});