﻿namespace DeBroglie
{
    public class Topology
    {
        public Directions Directions { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool Periodic { get; set; }

        public int GetIndex(int x, int y)
        {
            return x + y * Width;
        }

        public void GetCoord(int index, out int x, out int y)
        {
            x = index % Width;
            y = index / Width;
        }

        public bool TryMove(int index, int direction, out int dest)
        {
            int x, y;
            GetCoord(index, out x, out y);
            return TryMove(x, y, direction, out dest);
        }

        public bool TryMove(int x, int y, int direction, out int dest)
        {
            if (TryMove(x, y, direction, out x, out y))
            {
                dest = GetIndex(x, y);
                return true;
            }
            else
            {
                dest = -1;
                return false;
            }
        }

        public bool TryMove(int x, int y, int direction, out int destx, out int desty)
        {
            x += Directions.DX[direction];
            y += Directions.DY[direction];
            if (Periodic)
            {
                if (x < 0) x += Width;
                if (x >= Width) x -= Width;
                if (y < 0) y += Height;
                if (y >= Height) y -= Height;
            }
            else
            {
                if (x < 0 || x >= Width || y < 0 || y >= Height)
                {
                    destx = -1;
                    desty = -1;
                    return false;
                }
            }
            destx = x;
            desty = y;
            return true;
        }
    }
}