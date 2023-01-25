var lines = File.ReadAllLines("/Users/leopaillard/RiderProjects/AOC2022/Day2/strategy_guide.txt");

string HandleStrategyMove(string strategyMove, string opponentMove)
{
    var resultMove = string.Empty;

    resultMove = strategyMove switch
    {
        "X" => opponentMove switch
        {
            "A" => "Z",
            "B" => "X",
            "C" => "Y",
            _ => resultMove
        },
        "Y" => opponentMove switch
        {
            "A" => "X",
            "B" => "Y",
            "C" => "Z",
            _ => resultMove
        },
        "Z" => opponentMove switch
        {
            "A" => "Y",
            "B" => "Z",
            "C" => "X",
            _ => resultMove
        },
        _ => resultMove
    };

    return resultMove;
}


int CountFightPoints(string opponentMove, string yourMove)
{
    var pointCounter = 0;

    switch (yourMove)
    {
        case "X":
            switch (opponentMove)
            {
                case "A":
                    pointCounter += 3;
                    break;
                case "B":
                    pointCounter += 0;
                    break;
                case "C":
                    pointCounter += 6;
                    break;
            }

            break;
        case "Y":
            switch (opponentMove)
            {
                case "A":
                    pointCounter += 6;
                    break;
                case "B":
                    pointCounter += 3;
                    break;
                case "C":
                    pointCounter += 0;
                    break;
            }

            break;
        case "Z":
            switch (opponentMove)
            {
                case "A":
                    pointCounter += 0;
                    break;
                case "B":
                    pointCounter += 6;
                    break;
                case "C":
                    pointCounter += 3;
                    break;
            }

            break;
    }

    return pointCounter;
}

int CountMovePoints(string move2)
{
    var pointCounter = 0;

    switch (move2)
    {
        case "X":
            pointCounter += 1;
            break;
        case "Y":
            pointCounter += 2;
            break;
        case "Z":
            pointCounter += 3;
            break;
    }

    return pointCounter;
}

var score = 0;
var resultMove = string.Empty;

foreach (var line in lines)
{
    var subs = line.Split(' ');
    resultMove = HandleStrategyMove(subs[1], subs[0]);
    score += CountMovePoints(resultMove) + CountFightPoints(subs[0], resultMove);
}

Console.WriteLine(score);