/*
 * struct: Global
 * Menyimpan seting variabel / konstanta yang digunakan dalam game.
 */

using System.Drawing;

namespace Snake
{
    struct Global
    {
        // ukuran 'kanvas' merujuk pada ukuran komponen PictureBox
        // yang digunakan pada Form
        public const float CanvasWidth = 400f;
        public const float CanvasHeight = 400f;

        // kanvas direpresentasikan dengan grid-grid
        // 1 grid ukuran 16px.
        public const float GridSize = 16f;

        // ukuran kanvas dalam satuan grid.
        public const int CanvasWidthG = (int)(CanvasWidth / GridSize);
        public const int CanvasHeightG = (int)(CanvasHeight / GridSize);

        // variabel untuk score
        public static int Score = 0;
        public static int HiScore = 0;

        // string untuk pesan yang muncul saat Pause, GameOver
        public const string MsgPaused = "Press any key to Play / Resume";
        public const string MsgGameOver = "Gameover. Press SPACE to Start new game.";
        public const string MsgInfo = "- SNaked -\n\nProgram: Bayu Setiaji\nGameplay: Bayu Setiaji\n\n" +
            "Programmed with GDI on .NET";

        // file sumber soundFX
        public const string SndPickSrc = "pick.wav";
        public const string SndHitSrc = "hit.wav";

        // fungsi: DrawGrid()
        // Menggambar grid pada kanvas. Grid harus digambar
        // pertama kali sebelum objek game lain digambar.

        public static void DrawGrid(Graphics g)
        {
            var w = (int)(CanvasWidth / GridSize);
            var h = w;

            SolidBrush brush = new SolidBrush(Color.FromArgb(25, 25, 25));

            for (var y = 0; y < h; y++)
                for (var x = 0; x < w; x++)
                    if((x + y) % 2 == 0)
                        g.FillRectangle(brush, x * GridSize, y * GridSize, GridSize, GridSize);

            brush.Dispose();
        }
    }
}