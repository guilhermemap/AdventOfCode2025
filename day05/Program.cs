var lines = File.ReadAllLines("input");
List<(long first, long last)> ranges = [];
List<long> ingredients = [];
var readingRanges = true;
foreach (var line in lines)
{
    if (readingRanges)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            readingRanges = false;
            continue;
        }

        var splits = line.Split('-');
        var first = long.Parse(splits[0]);
        var last = long.Parse(splits[1]);
        ranges.Add((first, last));
    }
    else // reading ingredient now
    {
        ingredients.Add(long.Parse(line));
    }
}

var orderedRanges = ranges.OrderBy(r => r.first).ThenBy(a => a.last).ToList();

var total = 0L;
var previousLast = 0L;
foreach (var r in orderedRanges)
{
    var beginning = r.first <= previousLast ? previousLast + 1 : r.first;
    var subtotal = r.last - beginning + 1;
    if (subtotal > 0)
    {
        total += subtotal;
    }

    previousLast = r.last;
}

// var totalFresh = 0;
// foreach (var ingredient in ingredients)
// {
//     var fresh = false;
//     foreach (var range in ranges)
//     {
//         if (ingredient >= range.first && ingredient <= range.last)
//         {
//             fresh = true;
//             break;
//         }
//     }
//
//     if (fresh)
//     {
//         totalFresh++;
//     }
// }

Console.WriteLine($"Part two: {total}");