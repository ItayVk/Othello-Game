using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.OtheloLogic
{
    public class Player
    {
        private readonly string r_PlayerName;
        private readonly eCell r_PlayerColor;
        private readonly bool r_IsPC;
        private int m_PlayerScore;

        public Player(string i_Name, eCell i_Color, bool i_IsPC = false)
        {
            r_PlayerName = i_Name;
            r_PlayerColor = i_Color;
            r_IsPC = i_IsPC;
            m_PlayerScore = 0;
        }

        public string PlayerName
        {
            get
            {
                return r_PlayerName;
            }
        }

        public eCell PlayerColor
        {
            get
            {
                return r_PlayerColor;
            }
        }

        public bool IsPC
        {
            get
            {
                return r_IsPC;
            }
        }

        public int PlayerScore
        {
            get
            {
                return m_PlayerScore;
            }
            set
            {
                m_PlayerScore = value;
            }
        }
    }
}
