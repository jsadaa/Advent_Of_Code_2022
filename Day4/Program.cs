var lines = File.ReadAllLines("/Users/leopaillard/RiderProjects/AOC2022/Day4/assignment_pairs.txt");

// PART 1

var isFullyContainedCounter = 0;

foreach (var line in lines)
{
    var rangeAssignment1 = new List<int>();
    var rangeAssignment2 = new List<int>();
    var isFullyContained = false;
    var containCounter = 0;
    var index = 1;
    var splitPair = line.Split(",");
    foreach (var assignment in splitPair)
    {
        var sectionsRange = assignment.Split("-");
        for (var c = Convert.ToInt32(sectionsRange[0]); c <= Convert.ToInt32(sectionsRange[1]); c++)
            switch (index)
            {
                case 1:
                    rangeAssignment1.Add(c);
                    break;
                case 2:
                    rangeAssignment2.Add(c);
                    break;
            }

        index++;
    }

    foreach (var item in rangeAssignment1)
        if (rangeAssignment2.Contains(item))
            containCounter++;

    if (rangeAssignment1.Count == containCounter) isFullyContained = true;

    if (isFullyContained == false)
    {
        containCounter = 0;

        foreach (var item in rangeAssignment2)
            if (rangeAssignment1.Contains(item))
                containCounter++;

        if (rangeAssignment2.Count == containCounter) isFullyContained = true;
    }

    if (isFullyContained) isFullyContainedCounter++;
}

Console.WriteLine(isFullyContainedCounter);

// PART 2

var overlapCounter = 0;

foreach (var line in lines)
{
    var hasOverlaps = false;
    var rangeAssignment1 = new List<int>();
    var rangeAssignment2 = new List<int>();
    var index = 1;
    var splitPair = line.Split(",");
    foreach (var assignment in splitPair)
    {
        var sectionsRange = assignment.Split("-");
        for (var c = Convert.ToInt32(sectionsRange[0]); c <= Convert.ToInt32(sectionsRange[1]); c++)
            switch (index)
            {
                case 1:
                    rangeAssignment1.Add(c);
                    break;
                case 2:
                    rangeAssignment2.Add(c);
                    break;
            }

        index++;
    }

    foreach (var item in rangeAssignment1)
        if (rangeAssignment2.Contains(item))
            hasOverlaps = true;

    if (hasOverlaps) overlapCounter++;
}

Console.WriteLine(overlapCounter);