var input = File.ReadAllLines("input");

// add blank border to input
var lineLength = input[0].Length + 2;
var totalLines = input.Length + 2;
var blankLine = new char[lineLength];
for (var i = 0; i < lineLength; i++)
{
    blankLine[i] = '.';
}

var lines = new char[totalLines][];
lines[0] = blankLine;
for (var i = 1; i < totalLines - 1; i++)
{
    lines[i] = new char[lineLength];
    lines[i][0] = '.';
    for (var j = 1; j < lineLength - 1; j++)
    {
        lines[i][j] = input[i - 1][j - 1];
    }

    lines[i][lineLength - 1] = '.';
}

lines[totalLines - 1] = blankLine;

var total = 0;
for (var i = 0; i < totalLines; i++)
{
    var line = lines[i];
    for (var j = 0; j < lineLength; j++)
    {
        var ch = line[j];
        if (ch == '@')
        {
            if (CanBeAccessed(lines, i, j, 3))
            {
                total++;
                // Console.WriteLine($"{i},{j},{total}");
            }
        }
    }
}

Console.WriteLine(total);
return;


bool CanBeAccessed(char[][] array, int i, int j, int max)
{
    var number = 0;
    for (var x = i - 1; x <= i + 1; x++)
    {
        for (var y = j - 1; y <= j + 1; y++)
        {
            if (array[x][y] == '@')
            {
                number++;
            }
        }
    }

    return number <= max + 1; // 1 is the one in the center, doesn't count
}