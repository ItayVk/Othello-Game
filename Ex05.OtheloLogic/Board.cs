using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.OtheloLogic
{
    public class Board
    {
        private readonly int r_BoardSize;
        private readonly eCell[,] r_BoardCells;

        public Board(int i_Size)
        {
            r_BoardSize = i_Size;
            r_BoardCells = new eCell[i_Size, i_Size];
            resetBoard();
        }

        private void resetBoard()
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    r_BoardCells[row, col] = eCell.Empty;
                }
            }

            r_BoardCells[(r_BoardSize / 2) - 1, (r_BoardSize / 2) - 1] = eCell.White;
            r_BoardCells[(r_BoardSize / 2) - 1, (r_BoardSize / 2)] = eCell.Black;
            r_BoardCells[(r_BoardSize / 2), (r_BoardSize / 2)] = eCell.White;
            r_BoardCells[(r_BoardSize / 2), (r_BoardSize / 2) - 1] = eCell.Black;
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        public eCell[,] BoardCells
        {
            get
            {
                return r_BoardCells;
            }
        }

        public eCell getCellState(int i_Row, int i_Col)
        {
            return r_BoardCells[i_Row, i_Col];
        }

        public void setCellState(int i_Row, int i_Col, eCell i_CellState)
        {
            r_BoardCells[i_Row, i_Col] = i_CellState;
        }

        public bool IsValidMove(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            bool isValidMove = true;

            if (i_Row < 0 || i_Row >= r_BoardSize || i_Col < 0 || i_Col >= r_BoardSize)
            {
                isValidMove = false;
            }
            else if (getCellState(i_Row, i_Col) != eCell.Empty)
            {
                isValidMove = false;
            }

            return isValidMove && hasFlippableCells(i_Row, i_Col, i_CurrentPlayer);
        }

        private bool hasFlippableCells(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            int flippableCount = 0;

            for (int xDirection = -1; xDirection <= 1; xDirection++)
            {
                for (int yDirection = -1; yDirection <= 1; yDirection++)
                {
                    if (xDirection != 0 || yDirection != 0)
                    {
                        flippableCount += countFlippableCells(i_Row, i_Col, i_CurrentPlayer.PlayerColor, xDirection, yDirection);
                    }
                }
            }

            return flippableCount > 0;
        }

        private int countFlippableCells(int i_Row, int i_Col, eCell i_PlayerColor, int i_XDirection, int i_YDirection)
        {
            int row = i_Row + i_XDirection;
            int col = i_Col + i_YDirection;
            int flippableCount = 0;
            eCell opponentColor = (i_PlayerColor == eCell.Black) ? eCell.White : eCell.Black;

            while (row >= 0 && row < r_BoardSize && col >= 0 && col < r_BoardSize && getCellState(row, col) == opponentColor)
            {
                flippableCount++;
                row += i_XDirection;
                col += i_YDirection;
            }

            return (row >= 0 && row < r_BoardSize && col >= 0 && col < r_BoardSize && getCellState(row, col) == i_PlayerColor)
                ? flippableCount : 0;
        }

        public void FlipCells(int i_Row, int i_Col, Player i_CurrentPlayer)
        {
            for (int xDirection = -1; xDirection <= 1; xDirection++)
            {
                for (int yDirection = -1; yDirection <= 1; yDirection++)
                {
                    if (xDirection != 0 || yDirection != 0)
                    {
                        flipInDirection(i_Row, i_Col, i_CurrentPlayer.PlayerColor, xDirection, yDirection);
                    }
                }
            }
        }

        private void flipInDirection(int i_Row, int i_Col, eCell i_PlayerColor, int i_XDirection, int i_YDirection)
        {
            int flippableCells = countFlippableCells(i_Row, i_Col, i_PlayerColor, i_XDirection, i_YDirection);
            int row = i_Row + i_XDirection;
            int col = i_Col + i_YDirection;

            for (int i = 0; i < flippableCells; i++)
            {
                setCellState(row, col, i_PlayerColor);
                row += i_XDirection;
                col += i_YDirection;
            }
        }
    }
}
