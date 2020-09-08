using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        private ChessBoardManager chessBoardManager;
        SocketManager socket;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            chessBoardManager = new ChessBoardManager(pnlChessBoard, txbPlayerName, picMark);
            chessBoardManager.OnPlayerMarked += ChessBoardManager_OnPlayerMarked;
            chessBoardManager.OnEndedGame += ChessBoardManager_OnEndedGame;

            progressBar.Step = Cons.COOL_DOWN_STEP;
            progressBar.Maximum = Cons.COOL_DOWN_TIMER;
            timerCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;
            this.FormClosing += Form1_FormClosing;

            socket = new SocketManager();
            NewGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerCoolDown.Stop();
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
                if (chessBoardManager.CheckImage()) return;
                timerCoolDown.Start();
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch
                {
                }
            }
        }

        private void ChessBoardManager_OnEndedGame(object sender, EventArgs e)
        {
            EndGame();
            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
        }

        private void ChessBoardManager_OnPlayerMarked(object sender, ButtonClickEvent e)
        {
            progressBar.Value = 0;
            pnlChessBoard.Enabled = false;
            timerCoolDown.Start();

            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));
            Listen();
        }

        private void EndGame()
        {
            timerCoolDown.Stop();
            progressBar.Value = 0;
            //MessageBox.Show("Kết thúc trò chơi");
            undoToolStripMenuItem.Enabled = false;
            pnlChessBoard.Enabled = false;
        }

        private void timerCoolDown_Tick(object sender, EventArgs e)
        {
            progressBar.PerformStep();
            if (progressBar.Value == progressBar.Maximum)
            {
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));
                EndGame();
            }
        }

        //Tạo ván mới
        private void NewGame()
        {
            undoToolStripMenuItem.Enabled = true;
            timerCoolDown.Stop();
            progressBar.Value = 0;
            chessBoardManager.DrawChessBoard();

        }

        //Undo
        private void Undo()
        {
            timerCoolDown.Stop();
            progressBar.Value = 0;
            if (!chessBoardManager.Undo())
            {
                MessageBox.Show("Undo fail", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Quit
        private void Quit()
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
            pnlChessBoard.Enabled = true;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            socket.IP = txbIP.Text;
            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                pnlChessBoard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnlChessBoard.Enabled = false;
                Listen();
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txbIP.Text))
            {
                txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }

        private void Listen()
        {
            Thread listenThread = new Thread(() => {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch
                {
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() => {
                        NewGame();
                        pnlChessBoard.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() => {
                        progressBar.Value = 0;
                        pnlChessBoard.Enabled = true;
                        timerCoolDown.Start();
                        chessBoardManager.OtherPlayerMark(data.Point);
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    Undo();
                    progressBar.Value = 0;
                    break;
                case (int)SocketCommand.END_GAME:
                    MessageBox.Show("Thắng bởi 5 dấu trên 1 hàng");
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Hết giờ!");
                    break;
                case (int)SocketCommand.QUIT:
                    timerCoolDown.Stop();
                    MessageBox.Show("Đối thủ đã thoát!");
                    break;
                default:
                    break;
            }

            Listen();
        }
    }
}

//Sửa Progressbar theo thread
