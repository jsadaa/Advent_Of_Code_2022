var buffer = File.ReadAllText("/Users/leopaillard/RiderProjects/AOC2022/Day6/datastream_buffer.txt");

var patternIndex = 14;
var bufferLinkedList = new LinkedList<string>();
var hasDuplicates = true;

foreach (var c in buffer)
{
    bufferLinkedList.AddLast(Convert.ToString(c));
}

// PART 1

while (hasDuplicates)
{
    var patternList = new LinkedList<string>();
    
    var indexOfItem = 0;
    
    for (var i = 0; i < 14; i++)
    {
        patternList.AddLast(bufferLinkedList.ElementAt(indexOfItem));
        indexOfItem++;
    }

    var recurrenceCounter = new Dictionary<string, int>();

    foreach (var c in patternList)
    {
        if (recurrenceCounter.ContainsKey(c))
        {
            recurrenceCounter[c] += 1;
        }
        else
        {
            recurrenceCounter[c] = 1;
        }
    }

    var isDuplicated = false;
    
    foreach (var item in recurrenceCounter.Where(item => item.Value > 1))
    {
        isDuplicated = true;
    }

    if (!isDuplicated)
    {
        hasDuplicates = false;
        Console.WriteLine(patternIndex);
    }

    if (!hasDuplicates)
    {
        break;
    }
    
    bufferLinkedList.RemoveFirst();
    patternIndex++;
}

// PART 2




