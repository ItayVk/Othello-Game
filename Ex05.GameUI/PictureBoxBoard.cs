using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameUI
{
    public class PictureBoxBoard : PictureBox
    {
        private int m_Row;
        private int m_Column;

        public int Row
        {
            get
            {
                return m_Row;
            }
            set
            {
                m_Row = value;
            }
        }

        public int Column
        {
            get
            {
                return m_Column;
            }
            set
            {
                m_Column = value;
            }
        }
    }
}
