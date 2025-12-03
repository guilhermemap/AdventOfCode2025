var lines = File.ReadAllLines("input");

var total = 0L;

foreach (var line in lines)
{
    var ranges = line.Split(",");
    foreach (var range in ranges)
    {
        var split = range.Split('-');
        var start = long.Parse(split[0]);
        var end = long.Parse(split[1]);
        total += SumOfInvalidIds(start, end + 1);
    }
}

Console.WriteLine(total);
return;

long SumOfInvalidIds(long start, long end)
{
    var sum = 0L;
    for (var id = start; id < end; id++)
    {
        var str = id.ToString();
        var len = str.Length;
        if (len % 2 != 0) continue;
        var ok = true;
        var halfLen = len / 2;
        for (var i = 0; i < halfLen; i++)
        {
            if (str[i] == str[i + halfLen]) continue;
            ok = false;
            break;
        }

        if (ok)
        {
            sum += id;
        }
    }

    return sum;
}