using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.OtheloLogic
{
    public class Game
    {
        private readonly Board r_GameBoard;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Player m_CurrentPlayer;
        private bool m_IsGameOver;

        public Game(int i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_IsIncludePC)
        {
            r_GameBoard = new Board(i_BoardSize);
            r_Player1 = new Player(i_Player1Name, eCell.Black);
            r_Player2 = i_IsIncludePC ? new Player(i_Player2Name, eCell.White, true) : new Player(i_Player2Name, eCell.White);
            m_CurrentPlayer = r_Player1;
            m_IsGameOver = false;
        }

        public List<(int, int)> GetValidMoves(Player i_Player)
        {
            List<(int, int)> validMovesList = new List<(int, int)>();

            for (int row = 0; row < r_GameBoard.BoardSize; row++)
            {
                for (int col = 0; col < r_GameBoard.BoardSize; col++)
                {
                    if (r_GameBoard.IsValidMove(row, col, i_Player))
                    {
                        validMovesList.Add((row, col));
                    }
                }
            }

            return validMovesList;
        }

        public void MakeMove(int i_Row, int i_Col)
        {
            if (r_GameBoard.IsValidMove(i_Row, i_Col, m_CurrentPlayer))
            {
                r_GameBoard.setCellState(i_Row, i_Col, m_CurrentPlayer.PlayerColor);
                r_GameBoard.FlipCells(i_Row, i_Col, m_CurrentPlayer);
                m_IsGameOver = GetValidMoves(r_Player1).Count == 0 && GetValidMoves(r_Player2).Count == 0;
            }
        }

        public void CountFinalScore()
        {
            for (int row = 0; row < r_GameBoard.BoardSize; row++)
            {
                for (int col = 0; col < r_GameBoard.BoardSize; col++)
                {
                    if (r_GameBoard.BoardCells[row, col] == r_Player1.PlayerColor)
                    {
                        r_Player1.PlayerScore++;
                    }
                    else if (r_GameBoard.BoardCells[row,col] == r_Player2.PlayerColor)
                    {
                        r_Player2.PlayerScore++;
                    }
                }
            }
        }

        public void SwitchTurn()
        {
            m_CurrentPlayer = (m_CurrentPlayer == r_Player1) ? r_Player2 : r_Player1;
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
            set
            {
                m_CurrentPlayer = value;
            }
        }

        public Board GameBoard
        {
            get
            {
                return r_GameBoard;
            }
        }

        public Player Player1
        {
            get
            {
                return r_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return r_Player2;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return m_IsGameOver;
            }
            set
            {
                m_IsGameOver = value;
            }
        }
    }
}
