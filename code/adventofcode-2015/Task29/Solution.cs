using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;
using System.Collections.Generic;

namespace adventofcode_2015.Task29
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2015/day/15/ task
        /// </summary>
        public static int Function(List<List<int>> inp)
        {
            var result = 0;
            for (int i = 0; i <= 100; i++)
            {
                for (int j = 0; j <= 100 - i; j++)
                {
                    for (int k = 0; k <= 100 - i - j; k++)
                    {
                        var n = 100 - i - k - j;
                        var a = inp[0][0] * i + inp[1][0] * j + inp[2][0] * k + inp[3][0] * n;
                        var b = inp[0][1] * i + inp[1][1] * j + inp[2][1] * k + inp[3][1] * n;
                        var c = inp[0][2] * i + inp[1][2] * j + inp[2][2] * k + inp[3][2] * n;
                        var d = inp[0][3] * i + inp[1][3] * j + inp[2][3] * k + inp[3][3] * n;
                        result = Math.Max(result, Math.Max(0, a) *
                            Math.Max(0, b) * Math.Max(0, c) *
                           Math.Max(0, d));

                    }
                }
            }

            return result;
        }

        private static void NotWorkingGASolver()
        {
            var chromosome = new FloatingPointChromosome(
                new double[] { 0, 0, 0, 0 },
                new double[] { 100, 100, 100, 100 },
                new int[] { 10, 10, 10, 10 },
                new int[] { 0, 0, 0, 0 });
            var population = new Population(50, 100, chromosome);

            var fitness = new FuncFitness((c) =>
            {
                var fc = c as FloatingPointChromosome;
                var values = fc.ToFloatingPoints();
                var x1 = values[0];
                var x2 = values[1];
                var x3 = values[2];
                var x4 = values[3];

                if (x1 + x2 + x3 + x4 != 100)
                    return 0;

                // 3 0 0 -3
                //-3 3 0 0
                //-1 0 4 0
                // 0 0 -2 2
                var a = x1 * 3 + x2 * -3 + x3 * -1 + x4 * 0;
                var b = x1 * 0 + x2 * 3 + x3 * 0 + x4 * 0;
                var d = x1 * 0 + x2 * 0 + x3 * 4 + x4 * -2;
                var e = x1 * -3 + x2 * 0 + x3 * 0 + x4 * 2;

                if (a < 0 || b < 0 || d < 0 || e < 0)
                {
                    return 0;
                }

                var result = a * b * d * e;
                return result;
            });

            var selection = new EliteSelection();
            var crossover = new UniformCrossover(0.1f);
            var mutation = new DisplacementMutation();
            var termination = new FitnessStagnationTermination(1000);
            var ga = new GeneticAlgorithm(
                population,
                fitness,
                selection,
                crossover,
                mutation);
            ga.Termination = termination;

            var latestFitness = 0.0;
            ga.GenerationRan += (sender, e) =>
            {
                var bestChromosome = ga.BestChromosome as FloatingPointChromosome;
                var bestFitness = bestChromosome.Fitness.Value;
                if (bestFitness != latestFitness)
                {
                    latestFitness = bestFitness;
                    var phenotype = bestChromosome.ToFloatingPoints();

                    Console.WriteLine(
                        "Generation {0,2}: ({1},{2}),({3},{4}) = {5}",

                        ga.GenerationsNumber,
                        phenotype[0],
                        phenotype[1],
                        phenotype[2],
                        phenotype[3],
                        bestFitness);
                }
            };
            ga.Start();
        }
    }
}