using Ex05.OtheloLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameUI
{
    public partial class OtheloGameForm : Form
    {
        private readonly int r_BoardSize;
        private readonly bool r_IsAgainstPC;
        private int m_NumOfBlackWins;
        private int m_NumOfWhiteWins;
        private PictureBoxBoard[,] m_PictureBoxBoard;
        private readonly Image r_RedCoin = Properties.Resources.CoinRed;
        private readonly Image r_YellowCoin = Properties.Resources.CoinYellow;
        private GameManager m_OtheloGameManager;
        private Timer m_PcTurnTimer;

        public OtheloGameForm(int i_BoardSize, bool i_IsAgainstPC)
        {
            InitializeComponent();
            r_BoardSize = i_BoardSize;
            r_IsAgainstPC = i_IsAgainstPC;
            m_NumOfBlackWins = 0;
            m_NumOfWhiteWins = 0;
            m_PcTurnTimer = i_IsAgainstPC ? new Timer() : null;
            buildPictureBoxBoard();
            defineFormSize();
            startGame();
        }

        private void defineFormSize()
        {
            this.Height = 50 * r_BoardSize + 80;
            this.Width = 50 * r_BoardSize + 60;
        }

        private void buildPictureBoxBoard()
        {
            int distanceFromLeft = 20;
            int distanceFromTop = 20;
            m_PictureBoxBoard = new PictureBoxBoard[r_BoardSize, r_BoardSize];

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    m_PictureBoxBoard[row, col] = createPictureBox(row, col, distanceFromLeft, distanceFromTop, 50);
                    this.Controls.Add(m_PictureBoxBoard[row, col]);
                    distanceFromLeft += 50;
                }

                distanceFromTop += 50;
                distanceFromLeft = 20;
            }
        }

        private PictureBoxBoard createPictureBox(int i_Row, int i_Col, int i_Left, int i_Top, int i_PictureBoxSize)
        {
            PictureBoxBoard pictureBox = new PictureBoxBoard();
            pictureBox.Width = i_PictureBoxSize;
            pictureBox.Height = i_PictureBoxSize;
            pictureBox.Left = i_Left;
            pictureBox.Top = i_Top;
            pictureBox.Row = i_Row;
            pictureBox.Column = i_Col;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BorderStyle = BorderStyle.Fixed3D;

            return pictureBox;
        }

        private void startGame()
        {
            m_OtheloGameManager = new GameManager(r_BoardSize, r_IsAgainstPC);
            runGame();
        }

        private void runGame()
        {
            showGameBoard();
            this.Text = string.Format("Othello - {0}'s Turn", m_OtheloGameManager.OtheloGame.CurrentPlayer.PlayerName);
            if (!m_OtheloGameManager.OtheloGame.IsGameOver)
            {
                if (checkIfThereAreValidMoves())
                {
                    if (m_OtheloGameManager.OtheloGame.CurrentPlayer.IsPC)
                    {
                        PcTurn();
                    }
                    else
                    {
                        showValidMoves();
                    }
                }
                else
                {
                    string switchTurnMsg = string.Format("{0} has no valid moves.{1}Now it's {2}'s turn.", 
                        m_OtheloGameManager.OtheloGame.CurrentPlayer.PlayerName,
                        Environment.NewLine,
                        m_OtheloGameManager.OtheloGame.CurrentPlayer == m_OtheloGameManager.OtheloGame.Player1 ? m_OtheloGameManager.OtheloGame.Player2.PlayerName : m_OtheloGameManager.OtheloGame.Player1.PlayerName);
                    
                    MessageBox.Show(switchTurnMsg, "Othello - No Valid Moves", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_OtheloGameManager.OtheloGame.SwitchTurn();
                    runGame();
                }
            }
            else
            {
                m_OtheloGameManager.OtheloGame.CountFinalScore();
                if (m_OtheloGameManager.OtheloGame.Player1.PlayerScore > m_OtheloGameManager.OtheloGame.Player2.PlayerScore)
                {
                    m_NumOfBlackWins++;
                }
                else
                {
                    m_NumOfWhiteWins++;
                }
                
                gameOverMessage();
            }
        }

        private void showGameBoard()
        {
            initGameBoard();
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    switch (m_OtheloGameManager.OtheloGame.GameBoard.BoardCells[row, col])
                    {
                        case eCell.Black:
                            m_PictureBoxBoard[row, col].Image = r_RedCoin;
                            break;

                        case eCell.White:
                            m_PictureBoxBoard[row, col].Image = r_YellowCoin;
                            break;
                    }

                    m_PictureBoxBoard[row, col].Enabled = true;
                }
            }
        }

        private void initGameBoard()
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    m_PictureBoxBoard[row, col].Enabled = false;
                    m_PictureBoxBoard[row, col].BackColor = Color.LightGray;
                    m_PictureBoxBoard[row, col].Image = null;
                    m_PictureBoxBoard[row, col].Click -= new EventHandler(this.pictureBoxButton_Click);
                }
            }
        }

        private bool checkIfThereAreValidMoves()
        {
            List<(int, int)> validMoves = m_OtheloGameManager.OtheloGame.GetValidMoves(m_OtheloGameManager.OtheloGame.CurrentPlayer);
            
            return validMoves.Count > 0;
        }

        private void showValidMoves()
        {
            List<(int, int)> validMoves = m_OtheloGameManager.OtheloGame.GetValidMoves(m_OtheloGameManager.OtheloGame.CurrentPlayer);
            foreach (var move in validMoves)
            {
                int row = move.Item1;
                int col = move.Item2;
                m_PictureBoxBoard[row, col].Enabled = true;
                m_PictureBoxBoard[row, col].BackColor = Color.Green;
                m_PictureBoxBoard[row, col].Click += new EventHandler(this.pictureBoxButton_Click);
            }
        }

        private void pictureBoxButton_Click(object sender, EventArgs e)
        {
            PictureBoxBoard pictureBox = sender as PictureBoxBoard;
            PlayerTurn(pictureBox);
        }

        private void PlayerTurn(PictureBoxBoard i_SelectedPictureBox)
        {
            m_OtheloGameManager.HandleMove(i_SelectedPictureBox.Row, i_SelectedPictureBox.Column);
            m_OtheloGameManager.OtheloGame.SwitchTurn();
            runGame();
        }

        private void PcTurn()
        {
            m_PcTurnTimer.Interval = 1000;
            m_PcTurnTimer.Tick += new EventHandler(pcTurnTimer_Tick);
            m_PcTurnTimer.Start();
        }

        private void pcTurnTimer_Tick(object sender, EventArgs e)
        {
            m_PcTurnTimer.Stop();
            m_PcTurnTimer.Tick -= pcTurnTimer_Tick;
            List<(int, int)> validMovesPc = m_OtheloGameManager.OtheloGame.GetValidMoves(m_OtheloGameManager.OtheloGame.CurrentPlayer);
            (int, int) chosenPcMove = PcMoves.SmartMovePC(validMovesPc, r_BoardSize);
            m_OtheloGameManager.HandleMove(chosenPcMove.Item1, chosenPcMove.Item2);
            m_OtheloGameManager.OtheloGame.SwitchTurn();
            runGame();
        }

        private void gameOverMessage()
        {
            string winnerMsg = getWinner();
            DialogResult endGameDialogResult = MessageBox.Show(winnerMsg, "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (endGameDialogResult == DialogResult.Yes)
            {
                startGame();
            }
            else
            {
                this.Close();
            }
        }

        private string getWinner()
        {
            string winnerMsg;
            if (m_OtheloGameManager.OtheloGame.Player1.PlayerScore != m_OtheloGameManager.OtheloGame.Player2.PlayerScore)
            {
                winnerMsg = string.Format("{0} Won!! ({1}/{2}) ({3}/{4})", 
                    m_OtheloGameManager.OtheloGame.Player1.PlayerScore > m_OtheloGameManager.OtheloGame.Player2.PlayerScore ? m_OtheloGameManager.OtheloGame.Player1.PlayerName : m_OtheloGameManager.OtheloGame.Player2.PlayerName,
                    Math.Max(m_OtheloGameManager.OtheloGame.Player1.PlayerScore, m_OtheloGameManager.OtheloGame.Player2.PlayerScore),
                    Math.Min(m_OtheloGameManager.OtheloGame.Player1.PlayerScore, m_OtheloGameManager.OtheloGame.Player2.PlayerScore),
                    m_OtheloGameManager.OtheloGame.Player1.PlayerScore > m_OtheloGameManager.OtheloGame.Player2.PlayerScore ? m_NumOfBlackWins : m_NumOfWhiteWins,
                    m_OtheloGameManager.OtheloGame.Player1.PlayerScore < m_OtheloGameManager.OtheloGame.Player2.PlayerScore ? m_NumOfBlackWins : m_NumOfWhiteWins);
            }
            else
            {
                winnerMsg = string.Format("It's a tie! (Total games result: {0} - {1} wins, {2} - {3} wins)",
                    m_OtheloGameManager.OtheloGame.Player1.PlayerName,
                    m_NumOfBlackWins,
                    m_OtheloGameManager.OtheloGame.Player2.PlayerName,
                    m_NumOfWhiteWins);
            }

            winnerMsg += string.Format("{0}Would you like another round?", Environment.NewLine);

            return winnerMsg;
        }
    }
}