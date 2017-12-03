var lineReader = require('readline').createInterface({
  input: require('fs').createReadStream('input.txt')
});

var output = 0;

lineReader.on('line', function (line) {
  cells = line.split('\t');
  loop1:
  for (var i = 0; i < cells.length; i++) {
    for (var j = 0; j < cells.length; j++) {
      if (i != j) {
        let result = +cells[i] / +cells[j];
        //console.log(result);
        if (result == Math.floor(result)) {
          output += result;
          break loop1;
        }
      }
    }
  }
});

lineReader.on('close', function (line) {
  console.log(output);
});

