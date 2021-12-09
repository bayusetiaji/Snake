/*
 * class Fruit.
 * Class singleton sebagai representasi dari Fruit.
 * Dibuat singleton karena hanya butuh 1 instance saja.
 * 
 * Setiap kali Fruit akan di-reset ketika 'dimakan' oleh 
 * Snake atau waktu hidupnya habis.
 * 
 */

using System;
using System.Drawing;

namespace Snake
{
    class Fruit
    {
        static Fruit instance;
        SolidBrush brush;
        
        int posX;
        int posY;
        float gsize;
        float life;
        
        // konstruktor
        // akses private untu menghindari instansiasi secara langsung
        private Fruit()
        {
            brush = new SolidBrush(Color.OrangeRed);
            gsize = Global.GridSize;
            Reset();
        }

        // fungsi: GetInstance()
        // Mengambil instans yang bersifat static
        public static Fruit GetInstance()
        {
            instance = new Fruit();
            return instance;
        }

        // fungsi: Update()
        // Update state life
        public void Update()
        {
            life -= 0.05f;
            if (life <= 0)
                Reset();
        }

        // fungsi: Draw()
        // Menggambar ke kanvas
        public void Draw(Graphics g)
        {
            g.FillRectangle(brush, X * gsize, Y * gsize, gsize, gsize);
        }

        // fungsi: Reset()
        // Reset state
        public void Reset()
        {
            Random rnd = new Random();
            posX = rnd.Next(1, Global.CanvasWidthG - 1);
            posY = rnd.Next(1, Global.CanvasHeightG - 1);
            life = 1;
        }

        // properti-properti x dan y
        public int X
        {
            get { return posX; }
        }

        public int Y
        {
            get { return posY; }
        }
    }
}
