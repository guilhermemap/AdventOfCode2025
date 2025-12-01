var lines = File.ReadAllLines("input");

var position = 50; // position must be between 0 and 99
var zeroCounts = 0;
foreach (var line in lines)
{
    var lastPosition = position;
    var direction = line[0] == 'L' ? -1 : 1;
    var number = int.Parse(line[1..]);
    if (number > 99)
    {
        zeroCounts += number / 100; // added for second part
        number %= 100;
    }

    position += number * direction;
    if (position % 100 == 0)
    {
        zeroCounts++;
        //Console.WriteLine("zero++");
    }

    switch (position)
    {
        // added for second part
        case < 0:
            position += 100;
            if (lastPosition != 0)
            {
                zeroCounts++;
                //Console.WriteLine("zero++");
            }

            break;
        case > 99:
            position -= 100;
            if (position != 0)
            {
                zeroCounts++;
                //Console.WriteLine("zero++");
            }

            break;
    }

    //Console.WriteLine($"{line} position {lastPosition} => {position}");
}

Console.WriteLine($"{zeroCounts}");