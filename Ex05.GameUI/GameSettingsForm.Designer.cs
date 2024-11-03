namespace Ex05.GameUI
{
    partial class GameSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boardSizeButton = new System.Windows.Forms.Button();
            this.playAgainstPcButton = new System.Windows.Forms.Button();
            this.playAgainstUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boardSizeButton
            // 
            this.boardSizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardSizeButton.Location = new System.Drawing.Point(22, 35);
            this.boardSizeButton.Name = "boardSizeButton";
            this.boardSizeButton.Size = new System.Drawing.Size(554, 67);
            this.boardSizeButton.TabIndex = 0;
            this.boardSizeButton.Text = "Board Size: 6x6 (click to increase)";
            this.boardSizeButton.UseVisualStyleBackColor = true;
            this.boardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // playAgainstPcButton
            // 
            this.playAgainstPcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgainstPcButton.Location = new System.Drawing.Point(22, 134);
            this.playAgainstPcButton.Name = "playAgainstPcButton";
            this.playAgainstPcButton.Size = new System.Drawing.Size(267, 67);
            this.playAgainstPcButton.TabIndex = 1;
            this.playAgainstPcButton.Text = "Play against the computer (One Player)";
            this.playAgainstPcButton.UseVisualStyleBackColor = true;
            this.playAgainstPcButton.Click += new System.EventHandler(this.playAgainstPcButton_Click);
            // 
            // playAgainstUserButton
            // 
            this.playAgainstUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgainstUserButton.Location = new System.Drawing.Point(309, 134);
            this.playAgainstUserButton.Name = "playAgainstUserButton";
            this.playAgainstUserButton.Size = new System.Drawing.Size(267, 67);
            this.playAgainstUserButton.TabIndex = 2;
            this.playAgainstUserButton.Text = "Play against your friend (Two Players)";
            this.playAgainstUserButton.UseVisualStyleBackColor = true;
            this.playAgainstUserButton.Click += new System.EventHandler(this.playAgainstUserButton_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 238);
            this.Controls.Add(this.playAgainstUserButton);
            this.Controls.Add(this.playAgainstPcButton);
            this.Controls.Add(this.boardSizeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button boardSizeButton;
        private System.Windows.Forms.Button playAgainstPcButton;
        private System.Windows.Forms.Button playAgainstUserButton;
    }
}