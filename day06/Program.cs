var lines = File.ReadAllLines("input");
var totalLines = lines.Length;
var array = new int[totalLines - 1][];
var columns = lines[0].Split().Count(s => !string.IsNullOrWhiteSpace(s));
var sinais = new char[columns];

for (var i = 0; i < totalLines; i++)
{
    var line = lines[i];
    var split = line.Split();
    var j = 0;

    if (i == totalLines - 1)
    {
        foreach (var s in split)
        {
            if (string.IsNullOrEmpty(s)) continue;
            sinais[j] = s[0];
            j++;
        }
    }
    else
    {
        array[i] = new int[columns];
        foreach (var digits in split)
        {
            if (string.IsNullOrEmpty(digits)) continue;
            array[i][j] = int.Parse(digits);
            j++;
        }
    }
}

var total = 0L;
for (var j = 0; j < columns; j++)
{
    var subtotal = 0L;
    if (sinais[j] == '+')
    {
        for (var i = 0; i < totalLines - 1; i++)
        {
            subtotal += array[i][j];
        }
    }
    else if (sinais[j] == '*')
    {
        subtotal = 1;
        for (var i = 0; i < totalLines - 1; i++)
        {
            subtotal *= array[i][j];
        }
    }

    Console.WriteLine($"columns {j} {sinais[j]}: {subtotal}");
    total += subtotal;
}

Console.WriteLine(total);