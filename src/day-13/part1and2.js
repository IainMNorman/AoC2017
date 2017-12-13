var input = [{
    tick: 0,
    size: 5
  },
  {
    tick: 1,
    size: 2
  },
  {
    tick: 2,
    size: 3
  },
  {
    tick: 4,
    size: 4
  },
  {
    tick: 6,
    size: 6
  },
  {
    tick: 8,
    size: 4
  },
  {
    tick: 10,
    size: 8
  },
  {
    tick: 12,
    size: 6
  },
  {
    tick: 14,
    size: 6
  },
  {
    tick: 16,
    size: 8
  },
  {
    tick: 18,
    size: 6
  },
  {
    tick: 20,
    size: 9
  },
  {
    tick: 22,
    size: 8
  },
  {
    tick: 24,
    size: 10
  },
  {
    tick: 26,
    size: 8
  },
  {
    tick: 28,
    size: 8
  },
  {
    tick: 30,
    size: 12
  },
  {
    tick: 32,
    size: 8
  },
  {
    tick: 34,
    size: 12
  },
  {
    tick: 36,
    size: 10
  },
  {
    tick: 38,
    size: 12
  },
  {
    tick: 40,
    size: 12
  },
  {
    tick: 42,
    size: 12
  },
  {
    tick: 44,
    size: 12
  },
  {
    tick: 46,
    size: 12
  },
  {
    tick: 48,
    size: 14
  },
  {
    tick: 50,
    size: 12
  },
  {
    tick: 52,
    size: 14
  },
  {
    tick: 54,
    size: 12
  },
  {
    tick: 56,
    size: 14
  },
  {
    tick: 58,
    size: 12
  },
  {
    tick: 60,
    size: 14
  },
  {
    tick: 62,
    size: 14
  },
  {
    tick: 64,
    size: 14
  },
  {
    tick: 66,
    size: 14
  },
  {
    tick: 68,
    size: 14
  },
  {
    tick: 70,
    size: 14
  },
  {
    tick: 72,
    size: 14
  },
  {
    tick: 76,
    size: 14
  },
  {
    tick: 80,
    size: 18
  },
  {
    tick: 84,
    size: 14
  },
  {
    tick: 90,
    size: 18
  },
  {
    tick: 92,
    size: 17
  }
];

var testInput = [{
    tick: 0,
    size: 3
  },
  {
    tick: 1,
    size: 2
  },
  {
    tick: 4,
    size: 4
  },
  {
    tick: 6,
    size: 4
  }
];

//input = testInput;

function GetFirewallPosition(tick, size) {
  var size = size - 1;
  var pos = tick % (size * 2);
  if (pos > size) {
    return size - (pos - size);
  }
  return pos;
}

// for (let i = 0; i < 16; i++) {
//   console.log(GetFirewallPosition(i, 5));
// }

var severity = 0;

for (let i = 0; i < input.length; i++) {
  if (GetFirewallPosition(input[i].tick, input[i].size) == 0) {
    severity += (input[i].tick * input[i].size);
  }
}

console.log(severity);

var delay = 0;
while (true) {
  var hit = false;
  for (let i = 0; i < input.length; i++) {
    if (GetFirewallPosition(input[i].tick + delay, input[i].size) == 0) {
      hit = true;
      break;
    }
  }
  if (!hit) {
    break;
  }
  delay++;
}
console.log(delay);