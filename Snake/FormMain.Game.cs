/*
 * partial class FormMain.Game
 * digunakan sebagai 'game manager'
 * 
 */


using System.Media;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    partial class FormMain
    {
        Snake snake = Snake.GetInstance();
        Fruit fruit = Fruit.GetInstance();

        // soundFX
        SoundPlayer sndPick;
        SoundPlayer sndHit;

        // state digunakan sebagai penanda game cycle
        State state;
        
        // fungsi: GameInit()
        // Inisialisasi game.

        private void GameInit()
        {
            state = State.PAUSED;
            snake.Dir = Direction.UP;

            labMessage.Text = Global.MsgPaused;

            sndPick = new SoundPlayer(Global.SndPickSrc);
            sndHit = new SoundPlayer(Global.SndHitSrc);
        }

        // fungsi: GameUpdate()
        // Sebagai MainLoop game yang dipanggil oleh
        // event Tick pada Timer

        private void GameUpdate()
        {
            if (state == State.RUN)
            {
                snake.Update();
                fruit.Update();

                if (snake.Hit())
                {
                    sndHit.Play();
                    state = State.GAMEOVER;
                    labMessage.Visible = true;
                    labMessage.Text = Global.MsgGameOver;
                }

                if (snake.Eat(fruit))
                {
                    sndPick.Play();
                    Global.Score++;
                    if (Global.Score > Global.HiScore)
                        Global.HiScore = Global.Score;

                    labScore.Text = Global.Score.ToString();
                    labHiScore.Text = Global.HiScore.ToString();

                    fruit.Reset();
                }
            }

            picCanvas.Refresh();
        }

        // fungsi: GameDraw()
        // Menampilkan seluruh objek game.
        // Dipanggil oleh event Paint dari Form. 

        private void GameDraw(Graphics g)
        {
            Global.DrawGrid(g);
            snake.Draw(g);
            fruit.Draw(g);
        }

        // fungsi: ReadKey()
        // Membaca input keyboard sebagai kontrol game.

        private void GameReadKey(KeyEventArgs e)
        {
            if (state == State.RUN)
            {
                if (e.KeyCode == Keys.Up)
                    snake.Dir = Direction.UP;
                if (e.KeyCode == Keys.Right)
                    snake.Dir = Direction.RIGHT;
                if (e.KeyCode == Keys.Down)
                    snake.Dir = Direction.DOWN;
                if (e.KeyCode == Keys.Left)
                    snake.Dir = Direction.LEFT;

                if (e.KeyCode == Keys.Space)
                {
                    state = State.PAUSED;
                    labMessage.Text = Global.MsgPaused;
                    labMessage.Visible = true;
                }

                if (e.KeyCode == Keys.I)
                {
                    state = State.PAUSED;
                    labMessage.Text = Global.MsgInfo;
                    labMessage.Visible = true;
                }
            }
            else if (state == State.PAUSED)
            {
                state = State.RUN;
                labMessage.Visible = false;
            }
            else if (state == State.GAMEOVER)
            {
                if (e.KeyCode == Keys.Space)
                {
                    GameReset();
                    labMessage.Text = Global.MsgPaused;
                }
            }
        }

        // fungsi: GameReset()
        // Me-reset game setiap kali GameOver

        private void GameReset()
        {
            Global.Score = 0;
            labScore.Text = Global.Score.ToString();

            snake.Reset();
            fruit.Reset();

            state = State.PAUSED;
            snake.Dir = Direction.UP;
        }
    }
}
