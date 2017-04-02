using System;
using System.Collections;
using System.Collections.Generic;
namespace RoadsAndLibraries {
    class Program {
        static long depthFirstSearch(int city, IDictionary<int, HashSet<int>> hackerLand, bool[] visited, long count) {
            visited[city] = true;

            HashSet<int> neighbors = hackerLand[city];
            foreach (int cit in neighbors) {
                if (!visited[cit]) {
                    count = 1 + depthFirstSearch(cit, hackerLand, visited, count);
                }
            }

            return count;
        }

        static long getMinimumCost(int ncities, int mroads, long clib, long croad, IDictionary<int, HashSet<int>> hackerLand) {
            long cost = 0;

            bool[] visited = new bool[ncities + 1];
            for (int city = 1; city <= ncities; city++) {
                if (!visited[city]) {
                    long clusterSize = depthFirstSearch(city, hackerLand, visited, 1);

                    cost += clib;
                    if (clib > croad) {
                        cost += ((clusterSize - 1) * croad);
                    } else {
                        cost += ((clusterSize - 1) * clib);
                    }
                }
            }

            return cost;
        }

        static void Main(String[] args) {

            int q = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < q; i++) {
                string[] tokens = Console.ReadLine().Split(' ');
                int ncities = Convert.ToInt32(tokens[0]);
                int mroads = Convert.ToInt32(tokens[1]);
                int clib = Convert.ToInt32(tokens[2]);
                int croad = Convert.ToInt32(tokens[3]);

                IDictionary<int, HashSet<int>> hackerLand = new Dictionary<int, HashSet<int>>();
                for (int node = 1; node <= ncities; node++) {
                    hackerLand.Add(node, new HashSet<int>());
                }

                for (int r = 0; r < mroads; r++) {
                    string[] tokens_city = Console.ReadLine().Split(' ');
                    int city_1 = Convert.ToInt32(tokens_city[0]);
                    int city_2 = Convert.ToInt32(tokens_city[1]);
                    hackerLand[city_1].Add(city_2);
                    hackerLand[city_2].Add(city_1);
                }

                Console.WriteLine(getMinimumCost(ncities, mroads, clib, croad, hackerLand));
            }
        }
    }
}