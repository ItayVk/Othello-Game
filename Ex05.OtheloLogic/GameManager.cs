using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.OtheloLogic
{
    public class GameManager
    {
        private Game m_OtheloGame;

        public GameManager(int i_BoardSize, bool i_IsAgainstPC)
        {
            m_OtheloGame = new Game(i_BoardSize, "Red", "Yellow", i_IsAgainstPC);
        }

        public Game OtheloGame
        {
            get
            {
                return m_OtheloGame;
            }
            set
            {
                m_OtheloGame = value;
            }
        }

        public bool HandleMove(int i_Row, int i_Col)
        {
            bool isMoveOccured = false;

            if (m_OtheloGame.GameBoard.IsValidMove(i_Row, i_Col, m_OtheloGame.CurrentPlayer))
            {
                m_OtheloGame.MakeMove(i_Row, i_Col);
                isMoveOccured = true;
            }

            return isMoveOccured;
        }
    }
}
