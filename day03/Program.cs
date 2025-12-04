var lines = File.ReadAllLines("input");
var total = 0;
const int numberOfBatteries = 2;
foreach (var line in lines)
{
    var fullNumber = string.Empty;
    var lastPosition = -1;
    for (var i = 1; i <= numberOfBatteries; i++)
    {
        var howManyMissing = numberOfBatteries - i;
        var (firstDigit, firstPosition) =
            GetLargestDigit(line.Substring(lastPosition + 1, line.Length - (lastPosition + 1) - howManyMissing));
        fullNumber += firstDigit;
        lastPosition = firstPosition;
    }

    var output = int.Parse(fullNumber);
    total += output;
}

Console.WriteLine(total);
return;

(char largest, int position) GetLargestDigit(string input)
{
    var largest = 0;
    var position = 0;
    for (var i = 0; i < input.Length; i++)
    {
        var ch = input[i];
        var digit = ch - '0';
        if (digit <= largest) continue;
        largest = digit;
        position = i;
    }

    return ((char)(largest + '0'), position);
}