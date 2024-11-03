using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameUI
{
    public partial class GameSettingsForm : Form
    {
        private readonly int r_MinBoardSize;
        private readonly int r_MaxBoardSize;
        private int m_BoardSize;
        private bool m_IsAgainstPC;

        public GameSettingsForm()
        {
            InitializeComponent();
            r_MinBoardSize = 6;
            r_MaxBoardSize = 12;
            m_BoardSize = r_MinBoardSize;
            m_IsAgainstPC = false;
        }

        private void changeBoardSize()
        {
            m_BoardSize = m_BoardSize == r_MaxBoardSize ? r_MinBoardSize : m_BoardSize + 2;
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            changeBoardSize();
            string boardSizeMsg = string.Format("Board size: {0}x{0} (click to increase)", m_BoardSize);
            Button boardSize = sender as Button;
            boardSize.Text = boardSizeMsg;
        }

        private void playAgainstPcButton_Click(object sender, EventArgs e)
        {
            m_IsAgainstPC = true;
            startGame();
        }

        private void playAgainstUserButton_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void startGame()
        {
            this.Hide();
            OtheloGameForm newGame = new OtheloGameForm(m_BoardSize, m_IsAgainstPC);
            newGame.ShowDialog();
            this.Close();
        }
    }
}
