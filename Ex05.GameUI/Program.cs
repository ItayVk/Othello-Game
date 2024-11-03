using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameUI
{
    public class Program
    {
        public static void Main()
        {
            GameSettingsForm gameSettings = new GameSettingsForm();
            gameSettings.ShowDialog();
        }

    }
}
