using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    public class UndoInfo
    {
        public int CurrentPlayer { get; set; }
        public Point Point { get; set; }

        public UndoInfo()
        {
        }

        public UndoInfo(Point point, int currentPlayer)
        {
            Point = point;
            CurrentPlayer = currentPlayer;
        }
    }
}
