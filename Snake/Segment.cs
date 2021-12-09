/*
 * class: Segment
 * Komponen pembentuk tubuh Snake. Snake terdiri
 * dari sekumpulan Segment.
 * 
 * Segment menyimpan informasi posisi x dan y
 */

namespace Snake
{
    class Segment
    {
        int posX;
        int posY;

        // konstruktor default

        public Segment()
        {
            posX = 0;
            posY = 0;
        }

        // konstruktor dengan parameter lokasi x, y

        public Segment(int x, int y)
        {
            posX = x;
            posY = y;
        }

        // fungsi: Copy()
        // Menyalin posisi x, y dari Segment lain.
        // Fungsi ini memungkinkan tiap Segment dapat
        // tersambung satu sama lain.

        public void Copy(Segment s)
        {
            posX = s.posX;
            posY = s.posY;
        }

        // property: X

        public int X
        {
            set { posX = value; }
            get { return posX; }
        }

        // property: Y

        public int Y
        {
            set { posY = value; }
            get { return posY; }
        }
    }
}
