var rawStacks = File.ReadAllLines("/Users/leopaillard/RiderProjects/AOC2022/Day5/stacks.txt");
var rawMoves = File.ReadAllLines("/Users/leopaillard/RiderProjects/AOC2022/Day5/moves.txt");
var stacksDict = new Dictionary<int, LinkedList<string>>();
var movesDict = new Dictionary<int, LinkedList<int>>();
var indexStacks = 0;
var indexMoves = 0;

// CREATE DICTIONARIES

foreach (var line in rawStacks)
{
    var stackSplit = line.Split(",");
    //var stack = stackSplit.ToList();
    var stack = new LinkedList<string>();
    foreach (var crate in stackSplit) stack.AddLast(crate);
    stacksDict.Add(indexStacks, stack);

    indexStacks++;
}

foreach (var line in rawMoves)
{
    var moveSplit = line.Split(",");
    //var move = moveSplit.Select(value => Convert.ToInt32(value)).ToList();
    var move = new LinkedList<int>();
    foreach (var value in moveSplit) move.AddLast(Convert.ToInt32(value));
    movesDict.Add(indexMoves, move);

    indexMoves++;
}

// DISPLAY STACKS BEFORE

var index = 1;

Console.WriteLine("*******");
Console.WriteLine("BEFORE");
Console.WriteLine("-------------");

foreach (var stack in stacksDict)
{
    Console.WriteLine($"STACK {index}");
    Console.WriteLine("-------------");
    foreach (var crate in stack.Value) Console.WriteLine(crate);
    index++;
    Console.WriteLine("-------------");
}

// PROCESS MOVES

// PART 1

/*foreach (var move in movesDict.Values)
    for (var i = 0; i < move.ElementAt(0); i++)
    {
        stacksDict[move.ElementAt(2) - 1].AddFirst(stacksDict[move.ElementAt(1) - 1].ElementAt(0));
        stacksDict[move.ElementAt(1) - 1].RemoveFirst();
    }*/

// PART 2

foreach (var move in movesDict.Values)
{
    var intermediaryList = new List<string>();
    
    for (var i = 0; i < move.ElementAt(0); i++)
    {
        intermediaryList.Add(stacksDict[move.ElementAt(1) - 1].ElementAt(0));
        stacksDict[move.ElementAt(1) - 1].RemoveFirst();
    }

    for (var i = intermediaryList.Count; i > 0 ; i--)
    {
        stacksDict[move.ElementAt(2) - 1].AddFirst(intermediaryList[i - 1]);
    }
}

// DISPLAY STACKS AFTER

index = 1;

Console.WriteLine("*******");
Console.WriteLine("AFTER");
Console.WriteLine("-------------");

foreach (var stack in stacksDict)
{
    Console.WriteLine($"STACK {index}");
    Console.WriteLine("-------------");
    foreach (var crate in stack.Value) Console.WriteLine(crate);
    index++;
    Console.WriteLine("-------------");
}

// DISPLAY TOP CRATES

index = 1;
var topCrates = string.Empty;

Console.WriteLine("===========");
Console.WriteLine("TOP CRATES");
Console.WriteLine("===========");

foreach (var stack in stacksDict.Values)
{
    topCrates += stack.ElementAt(0);
    Console.WriteLine($"stack {index} : {stack.ElementAt(0)}");
    Console.WriteLine("-------------");
    index++;
}

Console.WriteLine($"RESULT = {topCrates}");