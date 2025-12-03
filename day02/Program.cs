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
        if (IsInvalidIdRecursive(id))
        {
            sum += id;
        }
    }

    return sum;
}

bool IsInvalidId(long id)
{
    var str = id.ToString();
    var len = str.Length;
    if (len % 2 != 0) return false;
    var ok = true;
    var halfLen = len / 2;
    for (var i = 0; i < halfLen; i++)
    {
        if (str[i] == str[i + halfLen]) continue;
        ok = false;
        break;
    }

    return ok;
}

bool IsInvalidIdRecursive(long id)
{
    var str = id.ToString();
    var len = str.Length;
    var halfLen = len / 2;
    for (var i = 1; i <= halfLen; i++)
    {
        if (IsRepetition(str, i))
        {
            return true;
        }
    }

    return false;
}

bool IsRepetition(string str, int bit)
{
    var totalLength = str.Length;
    if (totalLength % bit != 0) return false;
    var firstBit = str[..bit];
    for (var i = bit; i < totalLength; i += bit)
    {
        if (str.Substring(i, bit) != firstBit)
        {
            return false;
        }
    }

    return true;
}