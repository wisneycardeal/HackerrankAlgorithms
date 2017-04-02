using System;

namespace QuensAttackII {
    class Program {
        static void Main(string[] args) {

            var data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int rows = data[0];
            int countObstacles = data[1];

            var queen = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int qx = queen[0];
            int qy = queen[1];

            // Directions:
            // 0 = left,  1 = left and up,    2 = up,   3 = right and up,
            // 4 = right, 5 = right and down, 6 = down, 7 = left and down
            int[] distances = new int[8];

            // Initialize distance to edge of board in each direction.
            distances[0] = qx;
            distances[2] = qy;
            distances[4] = rows + 1 - qx;
            distances[6] = rows + 1 - qy;
            distances[1] = Math.Min(distances[0], distances[2]);
            distances[3] = Math.Min(distances[4], distances[2]);
            distances[5] = Math.Min(distances[4], distances[6]);
            distances[7] = Math.Min(distances[0], distances[6]);

            for (int i = 0; i < countObstacles; i++) {
                var obstacle = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int dx = obstacle[0] - queen[0];
                int dy = obstacle[1] - queen[1];
                int direction = 0;
                int distance = 0;

                if (dx == 0) {
                    // Up or down.
                    direction = (dy < 0) ? 2 : 6;
                    distance = Math.Abs(dy);
                } else if (dy == 0) {
                    // Left or right.
                    direction = (dx < 0) ? 0 : 4;
                    distance = Math.Abs(dx);
                } else if (Math.Abs(dx) == Math.Abs(dy)) {
                    // Diagonal.
                    if (dx < 0) {
                        // Left up or left down
                        direction = (dy < 0) ? 1 : 7;
                    } else {
                        // Right up or right down
                        direction = (dy < 0) ? 3 : 5;
                    }
                    distance = Math.Abs(dx);
                } else {
                    // Not in any of the 8 directions, skip this obstacle.
                    continue;
                }
                // If this obstacle is closer than the previous obstacle in
                // this direction, then update the distance to the nearest
                // obstacle.
                if (distance < distances[direction]) {
                    distances[direction] = distance;
                }
            }

            // Compute the number of spaces the queen can move.  Note that
            // we need to subtract 1 from each direction because the queen
            // can't move on to the square of the obstacle.
            int total = 0;
            for (int i = 0; i < 8; i++) {
                total += distances[i] - 1;
            }
            Console.WriteLine(total);
        }
    }
}
