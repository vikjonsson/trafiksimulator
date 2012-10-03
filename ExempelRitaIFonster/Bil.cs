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
        Random rand = new Random();
        int a;
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
            a = rand.Next(0, 2);
            //måste vänster och vänstersväng i trevägskorsning
            if (map[centerY/20, centerX/20] == 2)
            {
                //måste vänster
                if ((dir == Riktning.upp && map[(centerY-20)/20, centerX/20] == 0) ||
                    (dir == Riktning.ner && map[(centerY+20)/20, centerX/20] == 0) ||
                    (dir == Riktning.höger && map[centerY/20, (centerX+20)/20] == 0) ||
                    (dir == Riktning.vänster && map[centerY/20, (centerX-20)/20] == 0))
                {
                    bytRiktning(Riktning.vänster);    
                }
                //kan svänga vänster
                else if ((dir == Riktning.vänster && map[centerY/20, (centerX-20)/20] == 1) ||
                    (dir == Riktning.upp && map[(centerY-20)/20, centerX/20] == 1) ||
                    (dir == Riktning.ner && map[(centerY+20)/20, centerX/20] == 1) ||
                    (dir == Riktning.höger && map[centerY/20, (centerX+20)/20] == 1))
                {
                    if (a == 1)
                    {
                        bytRiktning(Riktning.vänster);
                    }
                }
                
            }
            //måste höger och högersväng i trevägskorsning
            if (map[centerY/20, centerX/20]==3)
            {
                //måste höger
                if ((dir == Riktning.upp && map[centerY/20, (centerX-20)/20] == 1) ||
                    (dir == Riktning.ner && map[centerY/20, (centerX+20)/20] == 1) ||
                    (dir == Riktning.höger && map[(centerY-20)/20, centerX/20] == 1) ||
                    (dir == Riktning.vänster && map[(centerY+20)/20, centerX/20] == 1))
                {
                    bytRiktning(Riktning.höger);
                }
                //kan svänga höger
                else if ((dir == Riktning.höger && map[centerY/20, (centerX+20)/20] == 3) ||
                    (dir == Riktning.vänster && map[centerY/20, (centerX-20)/20] == 3) || (dir == Riktning.vänster && map[centerY/20, (centerX-20)/20] == 2) ||
                    (dir == Riktning.upp && map[(centerY-20)/20, centerX/20] == 3) || (dir == Riktning.upp && map[(centerY-20)/20, centerX/20] == 2) ||
                    (dir == Riktning.ner && map[(centerY+20) / 20, centerX / 20] == 3))
                {
                    if (a == 1)
                    {
                        bytRiktning(Riktning.höger);
                    }
                }
            }
            //4-vägskorsning
            if (map[centerY/20, centerX/20] == 4)
            {
                //högersväng
                if ((dir == Riktning.upp && map[(centerY+20)/20, centerX/20] == 4)||
                    (dir == Riktning.ner && map[(centerY-20)/20, centerX/20] == 4) ||
                    (dir == Riktning.höger && map[centerY/20, (centerX+20)/20] == 4)||
                    (dir == Riktning.vänster && map[centerY/20, (centerX-20)/20] == 4))
                {
                    if (a==1)
                    {
                        bytRiktning(Riktning.höger);
                    }
                }
                //vänstersväng
                if ((dir == Riktning.upp && map[(centerY+20)/20, centerX/20] == 1) ||
                    (dir == Riktning.vänster && map[centerY/20, (centerX-20)/20] == 1) ||
                    (dir == Riktning.ner && map[(centerY+20)/20, centerX/20] == 1) ||
                    (dir == Riktning.höger && map[centerY/20, (centerX+20)/20] == 1))
                {
                    if (a==1)
                    {
                        bytRiktning(Riktning.vänster);
                    }
                }
            }
            //3-vägskorsning
            /*if (map[centerY/20, centerX/20] == 5)
            {
                //högersväng
                if ((dir == Riktning.upp && map[(centerY+20)/20, centerX/20] == 5) ||
                    (dir == Riktning.höger && map[centerY/20, (centerX+20)/20] == 5) ||
                    (dir == Riktning.vänster && map[centerY/20, (centerX-20)/20] == 5) ||
                    (dir == Riktning.ner && map[(centerY-20)/20, centerX/20] == 5))
                {
                    if (a==1)
                    {
                        bytRiktning(Riktning.höger);
                    }
                }
            }*/
            
            //flytta bilen 20px i riktning
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
