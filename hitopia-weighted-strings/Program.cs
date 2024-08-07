namespace hitopia_problem_test;

using System;
using System.Collections.Generic;

class WeightedStrings(string inputString, string inputQuery)
{
    private readonly Dictionary<string, int> mapString = new()
    {
        {"a", 1}, {"b", 2}, {"c", 3}, {"d", 4}, {"e", 5}, {"f", 6}, {"g", 7}, {"h", 8}, {"i", 9},
        {"j", 10}, {"k", 11}, {"l", 12}, {"m", 13}, {"n", 14}, {"o", 15}, {"p", 16}, {"q", 17},
        {"r", 18}, {"s", 19}, {"t", 20}, {"u", 21}, {"v", 22}, {"w", 23}, {"x", 24}, {"y", 25},
        {"z", 26}
    };

    private readonly string inputString = inputString;
    private readonly string inputQuery = inputQuery;
    private List<int> arrayWeightDetail = [];
    private List<string> query = [];

    public void WeightingString()
    {
        // String Weight
        var inputStringArray = (this.inputString ?? "").ToCharArray();

        int weightSum = 0;
        int weightTemp = 0;
        char stringTemp = '\0';
        List<int> weightArray = [];

        foreach (char character in inputStringArray ?? [])
        {
            int weight = this.mapString.ContainsKey(character.ToString()) ? this.mapString[character.ToString()] : 0;

            if (character == stringTemp)
            {
                weightTemp += weight;
            }
            else
            {
                weightTemp = weight;
            }

            stringTemp = character;
            weightSum += weightTemp;

            weightArray.Add(weightTemp);
        }

        // Query
        var inputQueryArray = (this.inputQuery ?? "").Split(',');

        List<string> arrayQuery = [];
        foreach (var query in inputQueryArray ?? [])
        {
            arrayQuery.Add(weightArray.Contains(int.Parse(query)) ? "YES" : "NO");
        }

        this.arrayWeightDetail = weightArray;
        this.query = arrayQuery;
    }

    public List<int> GetArrayWeightDetail()
    {
        return this.arrayWeightDetail;
    }

    public List<string> GetQuery()
    {
        return this.query;
    }

    static void Main(string[] args)
    {
        if (args.Length > 1 && args.Length < 4)
        {
            string inputString = args.Length > 0 ? args[0] : "";
            string inputQuery = args.Length > 1 ? args[1] : "";

            WeightedStrings weightedStrings = new(inputString, inputQuery);
            weightedStrings.WeightingString();

            Console.WriteLine(String.Join("\n", weightedStrings.GetArrayWeightDetail()));
            Console.WriteLine(String.Join("\n", weightedStrings.GetQuery()));
        }
    }
}

