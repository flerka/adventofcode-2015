﻿using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2015.Task27;

public record HorseStats(string Name, int Speed, int RunDur, int RestDur);
public class HorseState
{
    public int Run, RunDur, RestDur = 0;
    public bool IsResting = false;
}

public class Solution
{
    /// <summary>
    /// Solution for the first https://adventofcode.com/2015/day/14/ task
    /// </summary>
    public static int Function(List<HorseStats> input, int seconds)
    {
        var statsData = input.ToDictionary(i => i.Name, k => k);
        var stateData = input.ToDictionary(i => i.Name, k => new HorseState());
        for (var i = 0; i <= seconds; i++)
        {
            foreach (var horseName in stateData.Keys)
            {
                var state = stateData[horseName];
                var stats = statsData[horseName];
                _ = state.IsResting switch
                {
                    false => Run(state, stats),
                    true => Rest(state, stats)
                };
            }
        }

        return stateData.Values.Max(i => i.Run);
    }

    private static HorseState Run(HorseState state, HorseStats stats)
    {
        state.RunDur++;
        state.Run += stats.Speed;
        if (state.RunDur == stats.RunDur)
        {
            state.IsResting = true;
            state.RunDur = 0;
        }

        return state;
    }

    private static HorseState Rest(HorseState state, HorseStats stats)
    {
        state.RestDur++;
        if (state.RestDur == stats.RestDur)
        {
            state.IsResting = false;
            state.RestDur = 0;
        }

        return state;
    }
}