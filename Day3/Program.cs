var lines = File.ReadAllLines("/Users/leopaillard/RiderProjects/AOC2022/Day3/rucksacks_inventory.txt");

var lowerCaseAlphabet = new List<string>();
var upperCaseAlphabet = new List<string>();

for (var c = 'a'; c <= 'z'; c++)
    lowerCaseAlphabet.Add("" + c);
for (var c = 'A'; c <= 'Z'; c++)
    upperCaseAlphabet.Add("" + c);

var prioritySum = 0;

//PART 1

foreach (var line in lines)
{
    var listLength = line.Length;
    const int startIndex = 0;
    var endIndex = listLength / 2;

    var compartment1 = line.Substring(startIndex, endIndex);
    var compartment2 = line.Substring(endIndex, endIndex);

    var duplicate = string.Empty;

    foreach (var character in compartment1)
        if (compartment2.Contains(character))
            duplicate = character.ToString();

    var priority = 0;

    if (lowerCaseAlphabet.Contains(duplicate))
    {
        foreach (var letter in lowerCaseAlphabet)
            if (letter == duplicate)
                priority = lowerCaseAlphabet.IndexOf(letter) + 1;
    }
    else
    {
        foreach (var letter in upperCaseAlphabet)
            if (letter == duplicate)
                priority = upperCaseAlphabet.IndexOf(letter) + 27;
    }

    prioritySum += priority;
}

// PART 2

var index = 0;
var elf1 = string.Empty;
var elf2 = string.Empty;
var elf3 = string.Empty;
var badge = string.Empty;
prioritySum = 0;

foreach (var line in lines)
{
    switch (index)
    {
        case 0:
            elf1 = line;
            break;
        case 1:
            elf2 = line;
            break;
        case 2:
            elf3 = line;
            break;
    }

    if (index == 2)
    {
        foreach (var c in elf1.Where(c => elf2.Contains(c) && elf3.Contains(c))) badge = Convert.ToString(c);

        var priority = 0;

        if (lowerCaseAlphabet.Contains(badge))
            foreach (var letter in lowerCaseAlphabet.Where(letter => letter == badge))
                priority = lowerCaseAlphabet.IndexOf(letter) + 1;
        else
            foreach (var letter in upperCaseAlphabet.Where(letter => letter == badge))
                priority = upperCaseAlphabet.IndexOf(letter) + 27;

        prioritySum += priority;
        Console.WriteLine(prioritySum);
        index = 0;
    }
    else
    {
        index++;
    }
}