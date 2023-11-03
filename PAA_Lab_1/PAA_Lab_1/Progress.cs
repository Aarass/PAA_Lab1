using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_1
{
    internal class Progress
    {
        private int m_Size;
        public Progress(int size)
        {
            m_Size = size;
            Console.CursorVisible = false;
        }
        public void ShowProgress(float percentage)
        {
            if (percentage < 0f || percentage > 1f)
                return;

            Console.SetCursorPosition(0, Console.CursorTop);

            int filled = (int)(m_Size * percentage);
            string s = "";
            for (int i = 0; i < filled; i++)
                s += '█';
            for (int i = filled; i < m_Size; i++)
                s += '▓';

            Console.Write(s);
        }
        public void HideProgress()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < m_Size + 1; i++)
                Console.Write(' ');
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}
