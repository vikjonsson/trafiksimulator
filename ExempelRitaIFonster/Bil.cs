using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ExempelRitaIFonster
{
    enum Riktning {höger,ner,vänster,upp};

    class Bil
    {
        int centerX;
        int centerY;
        int tileSize;
        Riktning dir;
        int[,] map;

        public Bil(int x, int y, int tileSizeInPixels, Riktning bilensStartRiktning, int[,] map)
        {
            centerX = x;
            centerY = y;
            dir = bilensStartRiktning;
            tileSize = tileSizeInPixels;
            this.map = map;
        }

        public void move()
        {
            if (map[centerY/20, centerX/20] == 2)
            {
                bytRiktning(Riktning.höger);
            }
            if (map[centerY/20, centerX/20] == 5)
            {
                bytRiktning(Riktning.vänster);
            }
            //öka på lämplig kordinat - baserat på bilens nuvarande riktning
            if (dir == Riktning.höger)
                centerX += tileSize;
            if (dir == Riktning.vänster)
                centerX -= tileSize;
            if (dir == Riktning.upp)
                centerY -= tileSize;
            if (dir == Riktning.ner)
                centerY += tileSize;
        }

        public void bytRiktning(Riktning nyRiktning)
        {
            if (nyRiktning == Riktning.höger) 
            {
                if (dir == Riktning.höger)
                {
                    dir = Riktning.ner;
                }
                else if (dir == Riktning.vänster)
                {
                    dir = Riktning.upp;
                }
                else if (dir == Riktning.ner)
                {
                    dir = Riktning.vänster;   
                }
                else
                {
                    dir = Riktning.höger;
                }
            }
            else
            {
                if (dir == Riktning.höger)
                {
                    dir = Riktning.upp;
                }
                else if (dir == Riktning.vänster)
                {
                    dir = Riktning.ner;
                }
                else if (dir == Riktning.ner)
                {
                    dir = Riktning.höger;
                }
                else
                {
                    dir = Riktning.vänster;
                }
            }
        }

        public void DrawBil(Graphics g)
        {
            //skaffa grafikhantag
           // Graphics g = f.CreateGraphics();

            //sätt centrum och rotera  efter riktning
            g.TranslateTransform((float)centerX, (float)centerY);
            if(dir==Riktning.ner)
                g.RotateTransform(90.0F);
            if(dir==Riktning.upp)
                g.RotateTransform(270.0F);
            if (dir == Riktning.vänster)
                g.RotateTransform(180.0F);
           
            //ange "bilens" punkter och rita ut den
            int half = tileSize / 2;
            int fjardedel = half / 2;

            Point ett = new Point(-half, -half);
            Point tva = new Point(fjardedel, -half);
            Point tre = new Point(half, 0);
            Point fyra = new Point(fjardedel, half);
            Point fem = new Point(-half, half);
            Point sex = new Point(-fjardedel, 0);
            Point[] punkter = new Point[] { ett, tva, tre, fyra, fem,sex };
            g.FillPolygon(Brushes.Blue, punkter);

            //frisläpp grafikhantaget
           // g.Dispose();
        }
       
    }
}
