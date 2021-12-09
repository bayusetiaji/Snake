/*
 * class Snake.
 * Class singleton sebagai representasi dari Snake.
 * Dibuat singleton karena hanya butuh 1 instance saja.
 * 
 * Snake terdiri dari sekumpulan Segment yang tersimpan 
 * di List. Tiap segment terhubung satu sama lain membentuk
 * rangkaian panjang.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        static Snake instance;
        Direction dir;

        List<Segment> segments;
        SolidBrush brush;

        int posX;
        int posY;
        int velX;
        int velY;

        float gsize;

        // konstruktor
        // akses private, untuk menghindari instansiasi secara langsung
        private Snake()
        {
            gsize = Global.GridSize;

            segments = new List<Segment>();
            brush = new SolidBrush(Color.DeepSkyBlue);

            Reset();
        }

        // fungsi: GetInstance()
        // Mengambil instans yang bersifat static

        public static Snake GetInstance()
        {
            instance = new Snake();
            return instance;
        }

        // fungsi: Update
        // Melakukan update terhadap lokasi Snake,
        // dan membentuk rangkaian Segment agar selalu 
        // terhubung

        public void Update()
        { 
            
            posX += velX;
            posY += velY;

            Segment frontS = new Segment();
            frontS.Copy(segments[0]);

            segments[0].X = posX;
            segments[0].Y = posY;

            for (var i = 1; i < segments.Count; i++)
            {
                Segment currS = new Segment();
                currS.Copy(segments[i]);

                segments[i].Copy(frontS);
                frontS.Copy(currS);
            }
        }

        // fungsi: Draw()
        // Menggambar semua Segment ke kanvas

        public void Draw(Graphics g)
        {
            
            foreach(var s in segments)
                g.FillRectangle(brush, s.X * gsize, s.Y * gsize, gsize, gsize);
        }

        // fungsi: Eat
        // Memeriksa apakah Snake memakan Fruit
        // atau tidak.

        public bool Eat(Fruit f)
        {
            if(posX == f.X && posY == f.Y)
            {
                segments.Add(new Segment(posX, posY));
                return true;
            }

            return false;
        }

        // fungsi: Hit()
        // Memeriksa apakah Snake membentur tepi kanvas atau 
        // membentur tubuhnya sendiri.

        public bool Hit()
        {
            if (posX <= 0 || posX >= Global.CanvasWidthG - 1 || 
                posY <= 0 || posY >= Global.CanvasHeightG - 1)
                return true;

            for (var i = 1; i < segments.Count; i++)
                if (posX == segments[i].X && posY == segments[i].Y)
                    return true;

                return false;
        }

        // fungsi: Reset
        // Me-reset semua variabel Snake.

        public void Reset()
        {
            posX = Global.CanvasWidthG / 2;
            posY = Global.CanvasHeightG / 2;

            velX = 0;
            velY = 0;

            segments.Clear();
            for (var i = 0; i < 3; i++)
                segments.Add(new Segment(posX, posY + i));

            dir = Direction.UP;
        }

        // property: Dir
        // Untuk mengakses / set arah gerak Snake
        // seperti yang terdefinisi di enum Direction

        public Direction Dir
        {
            set 
            { 
                dir = value;

                if (dir == Direction.UP)
                {
                    velX = 0;
                    velY = -1;
                }
                else if (dir == Direction.RIGHT)
                {
                    velX = 1;
                    velY = 0;
                }
                else if (dir == Direction.DOWN)
                {
                    velX = 0;
                    velY = 1;
                }
                else if (dir == Direction.LEFT)
                {
                    velX = -1;
                    velY = 0;
                }
            }

            get { return dir; }
        }
    }
}
