var lines = File.ReadAllLines("input");
var total = 0;
foreach (var line in lines)
{
    // there must be a second digit, so the last one can't be the first
    var (firstDigit, firstPosition) = GetLargestDigit(line[..^1]);
    var (secondDigit, secondPosition) = GetLargestDigit(line[(firstPosition + 1)..]);
    var output = int.Parse($"{line[firstPosition]}{line[secondPosition + firstPosition + 1]}");
    Console.WriteLine($"{line} => {output}");
    total += output;
}

Console.WriteLine(total);
return;

(int largest, int position) GetLargestDigit(string input)
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

    return (largest, position);
}