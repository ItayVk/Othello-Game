using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.OtheloLogic
{
    public class PcMoves
    {
        // PC move according euclidian distance from the center (details above the helper method).
        public static (int, int) SmartMovePC(List<(int, int)> i_ValidMoves, int i_BoardSize)
        {
            (int, int) bestMove;

            if (i_ValidMoves.Count == 0)
            {
                bestMove = (-1, -1);
            }
            else
            {
                bestMove = i_ValidMoves[0];
                int centerBoard = i_BoardSize / 2;
                int firstRow = bestMove.Item1;
                int firstColumn = bestMove.Item2;
                double bestScore = calculateMoveScore(firstRow, firstColumn, i_BoardSize, centerBoard);

                for (int i = 1; i < i_ValidMoves.Count; i++)
                {
                    int row = i_ValidMoves[i].Item1;
                    int column = i_ValidMoves[i].Item2;
                    double currentScore = calculateMoveScore(row, column, i_BoardSize, centerBoard);

                    if (currentScore < bestScore)
                    {
                        bestScore = currentScore;
                        bestMove = (row, column);
                    }
                }
            }

            return bestMove;
        }

        // Helper method to calculate the move's score
        // The calculations based on Euclidian distances from the center of the board, and takes in account 3 more things:
        // 1. Corners - Corners are the most stable positions, so if one is available it will be chosen as the best move.
        // 2. Edges (not the corners) - Moves along the edges are given a lower score by reducing the impact of the Euclidean distance.
        // 3. Cells near corners - Moves near corners are risky because they can allow the opponent to capture the corner. These moves are given a higher risk factor.
        private static double calculateMoveScore(int i_Row, int i_Column, int i_BoardSize, int i_CenterBoard)
        {
            int bestMove = -1;
            double distanceToCenter = Math.Sqrt(Math.Pow(i_Row - i_CenterBoard, 2) + Math.Pow(i_Column - i_CenterBoard, 2));
            bool isCorner = (i_Row == 0 || i_Row == i_BoardSize - 1) && (i_Column == 0 || i_Column == i_BoardSize - 1);
            
            if (isCorner)
            {
                bestMove = 0;
            }

            bool isEdge = (i_Row == 0 || i_Row == i_BoardSize - 1 || i_Column == 0 || i_Column == i_BoardSize - 1);
            double edgeScore = isEdge ? 0.5 : 1.0;
            bool nearCorner = (i_Row == 1 || i_Row == i_BoardSize - 2) && (i_Column == 1 || i_Column == i_BoardSize - 2);
            double riskFactor = nearCorner ? 1.5 : 1.0;

            return bestMove == 0 ? bestMove : distanceToCenter * edgeScore * riskFactor;
        }

        // PC move according Random.Next
        // Not using that method because we use the SmartMovePC method
        public (int, int) RandomMovePC(List<(int, int)> i_ValidMoves, int i_BoardSize)
        {
            Random random = new Random();
            var randomChoice = i_ValidMoves[random.Next(i_ValidMoves.Count)];
            
            return i_ValidMoves.Count > 0 ? randomChoice : (-1, -1);
        }
    }
}
