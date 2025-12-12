var input = File.ReadAllLines("input");
var totalLines = input.Length;
var lineLength = input[0].Length;
var lines = new (char, long)[totalLines][];

for (var i = 0; i < totalLines; i++)
{
    lines[i] = new (char, long)[lineLength];
    for (var j = 0; j < lineLength; j++)
    {
        lines[i][j].Item1 = input[i][j];
        lines[i][j].Item2 = 0;
    }
}

var initialPosition = input[0].IndexOf('S');
if (initialPosition == -1) throw new Exception("no initial position S");
lines[1][initialPosition].Item1 = '|';
lines[1][initialPosition].Item2 = 1;
var splitCount = 0;
for (var i = 2; i < totalLines; i += 2)
{
    for (var j = 0; j < lineLength; j++)
    {
        if (lines[i - 1][j].Item1 == '|')
        {
            if (lines[i][j].Item1 == '^')
            {
                splitCount++;
                var left = j - 1;
                if (left >= 0)
                {
                    lines[i + 1][left].Item1 = '|';
                    lines[i + 1][left].Item2 += lines[i - 1][j].Item2;
                }

                var right = j + 1;
                if (right < totalLines)
                {
                    lines[i + 1][right].Item1 = '|';
                    lines[i + 1][right].Item2 += lines[i - 1][j].Item2;
                }
            }
            else
            {
                lines[i + 1][j].Item1 = '|';
                lines[i + 1][j].Item2 += lines[i - 1][j].Item2;
            }
        }
    }
}

Console.WriteLine(splitCount);
Console.WriteLine(lines[totalLines - 1].Sum(l => l.Item2));