using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        private int currentPlayer;
        private TextBox txbPlayerName;
        private PictureBox picMark;
        private List<Player> player;
        private List<List<Button>> matrix;
        private event EventHandler<ButtonClickEvent> _OnPlayerMarked;
        private event EventHandler _OnEndedGame;
        private Stack<UndoInfo> playTimeLine;

        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        public TextBox TxbPlayerName
        {
            get { return txbPlayerName; }
            set { txbPlayerName = value; }
        }

        public PictureBox PicMark
        {
            get { return picMark; }
            set { picMark = value; }
        }

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public Stack<UndoInfo> PlayTimeLine
        {
            get { return playTimeLine; }
            set { playTimeLine = value; }
        }

        public event EventHandler<ButtonClickEvent> OnPlayerMarked
        {
            add
            {
                _OnPlayerMarked += value;
            }
            remove
            {
                _OnPlayerMarked -= value;
            }
        }

        public event EventHandler OnEndedGame
        {
            add
            {
                _OnEndedGame += value;
            }
            remove
            {
                _OnEndedGame -= value;
            }
        }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox picMark)
        {
            this.ChessBoard = chessBoard;
            this.TxbPlayerName = playerName;
            this.PicMark = picMark;
            initPlayer();
            PicMark.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void initPlayer()
        {
            player = new List<Player>()
            {
                new Player("Player 1", Image.FromFile(Application.StartupPath + "\\Resources\\x.png")),
                new Player("Player 2", Image.FromFile(Application.StartupPath + "\\Resources\\o.png"))
            };
        }
        #endregion

        #region Methods
        //Vẽ bàn cờ
        public void DrawChessBoard()
        {
            chessBoard.Enabled = true;
            chessBoard.Controls.Clear();
            CurrentPlayer = 1;
            ChangePlayer();
            PlayTimeLine = new Stack<UndoInfo>();

            Matrix = new List<List<Button>>();
            Button oldButton = new Button() { Width = 0, Height = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.CHESS_BOARD_WIDGHT; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDGHT,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        Tag = i.ToString()
                    };
                    btn.Click += Btn_Click;
                    chessBoard.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    oldButton = btn;
                }

                oldButton.Location = new Point(0, oldButton.Location.Y + oldButton.Height);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }

        public void OtherPlayerMark(Point point)
        {
            Button button = Matrix[point.Y][point.X];
            if (button.BackgroundImage != null) return;
            chessBoard.Enabled = true;
            button.BackgroundImage = player[CurrentPlayer].Mark;
            PlayTimeLine.Push(new UndoInfo(getChessPoint(button), CurrentPlayer));
            ChangePlayer();

            if (IsEndGame(button))
            {
                EndGame();
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.BackgroundImage != null) return;
            button.BackgroundImage = player[CurrentPlayer].Mark;
            PlayTimeLine.Push(new UndoInfo(getChessPoint(button), CurrentPlayer));
            ChangePlayer();

            if (_OnPlayerMarked != null)
            {
                _OnPlayerMarked(this, new ButtonClickEvent(getChessPoint(button)));
            }
            if (IsEndGame(button))
            {
                EndGame();
            }
        }

        //Đổi người chơi
        private void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer == 0 ? 1 : 0;
            TxbPlayerName.Text = player[CurrentPlayer].Name;
            PicMark.BackgroundImage = player[CurrentPlayer].Mark;
        }

        //Lấy tọa độ button
        private Point getChessPoint(Button button)
        {
            int vertical = Convert.ToInt32(button.Tag);
            int holizontal = Matrix[vertical].IndexOf(button);
            Point point = new Point(holizontal, vertical);
            return point;
        }

        //Thông báo kết thúc game
        public void EndGame()
        {
            if (_OnEndedGame != null)
            {
                _OnEndedGame(this, new EventArgs());
            }
        }

        //Kiểm tra theo hàng
        private bool IsEndHolizontal(Button button)
        {
            Point point = getChessPoint(button);
            int countLeft = 0;
            int countRight = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == button.BackgroundImage)
                {
                    countLeft++;
                }
                else break;
            }

            for (int i = point.X + 1; i < Cons.CHESS_BOARD_WIDGHT; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == button.BackgroundImage)
                {
                    countRight++;
                }
                else break;
            }
            return countLeft + countRight == 5;
        }

        //Kiểm tra theo cột
        private bool IsEndVertical(Button button)
        {
            Point point = getChessPoint(button);
            int countTop = 0;
            int countBottom = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == button.BackgroundImage)
                {
                    countTop++;
                }
                else break;
            }

            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == button.BackgroundImage)
                {
                    countBottom++;
                }
                else break;
            }
            return countTop + countBottom == 5;
        }

        //Kiểm tra theo đường chéo chính
        private bool IsEndMainDiagonal(Button button)
        {
            Point point = getChessPoint(button);
            int countTopLeft = 0;
            int countBottomRight = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0) break;
                if (Matrix[point.Y - i][point.X - i].BackgroundImage == button.BackgroundImage)
                {
                    countTopLeft++;
                }
                else break;
            }

            for (int i = 1; i <= Cons.CHESS_BOARD_WIDGHT - point.X; i++)
            {
                if (point.X + i >= Cons.CHESS_BOARD_WIDGHT || point.Y + i >= Cons.CHESS_BOARD_HEIGHT) break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == button.BackgroundImage)
                {
                    countBottomRight++;
                }
                else break;
            }
            return countTopLeft + countBottomRight == 5;
        }

        //Kiểm tra theo đường chéo phụ
        private bool IsEndSubDiagonal(Button button)
        {

            Point point = getChessPoint(button);
            int countTopRight = 0;
            int countBottomLeft = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >= Cons.CHESS_BOARD_WIDGHT || point.Y - i < 0) break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == button.BackgroundImage)
                {
                    countTopRight++;
                }
                else break;
            }

            for (int i = 1; i <= Cons.CHESS_BOARD_WIDGHT - point.X; i++)
            {
                if (point.X - i < 0 || point.Y + i >= Cons.CHESS_BOARD_HEIGHT) break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == button.BackgroundImage)
                {
                    countBottomLeft++;
                }
                else break;
            }
            return countTopRight + countBottomLeft == 5;
        }

        private bool IsEndGame(Button button)
        {
            return IsEndHolizontal(button) || IsEndVertical(button) || IsEndMainDiagonal(button) || IsEndSubDiagonal(button);
        }

        //Kiểm tra xem button có chứa backgroundImage?
        public bool CheckImage()
        {
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                foreach (Button btn in Matrix[i])
                {
                    if (btn.BackgroundImage != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Undo
        public bool Undo()
        {
            if (PlayTimeLine.Count == 0) return false;
            Point oldPoint = PlayTimeLine.Pop().Point;
            Button btn = Matrix[oldPoint.Y][oldPoint.X];
            btn.BackgroundImage = null;

            if (PlayTimeLine.Count == 0) return false;
            CurrentPlayer = PlayTimeLine.Peek().CurrentPlayer;
            ChangePlayer();
            return true;
        }
        #endregion
    }

    public class ButtonClickEvent : EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint
        {
            get
            {
                return clickedPoint;
            }

            set
            {
                clickedPoint = value;
            }
        }

        public ButtonClickEvent(Point point)
        {
            this.ClickedPoint = point;
        }
    }
}

////Point X VS Y bị hoán đổi vị trí // khi kiểm tra kết thúc trò chơi