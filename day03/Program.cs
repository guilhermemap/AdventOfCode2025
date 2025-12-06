var lines = File.ReadAllLines("input");
var total = 0L;
const int numberOfBatteries = 12;
foreach (var line in lines)
{
    var fullNumber = string.Empty;
    var lastPosition = -1;
    for (var i = 1; i <= numberOfBatteries; i++)
    {
        var howManyMissing = numberOfBatteries - i;
        var (firstDigit, firstPosition) =
            GetLargestDigit(line, lastPosition, howManyMissing);
        Console.WriteLine($"{firstDigit}: {firstPosition}");
        fullNumber += firstDigit;
        lastPosition = firstPosition;
    }

    Console.WriteLine(line + " -> " + fullNumber);
    var output = long.Parse(fullNumber);
    total += output;
}

Console.WriteLine(total);
return;

(char largest, int position) GetLargestDigit(string input, int lastPosition, int howManyMissing)
{
    var largest = 0;
    var position = 0;
    for (var i = lastPosition + 1; i < input.Length - howManyMissing; i++)
    {
        var ch = input[i];
        var digit = ch - '0';
        if (digit <= largest) continue;
        largest = digit;
        position = i;
    }

    return ((char)(largest + '0'), position);
}