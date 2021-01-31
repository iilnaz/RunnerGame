﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame
{
    public class Road
    {
        public Transform transform;

        public Road(PointF position,Size size)
        {
            transform = new Transform(position, size);
        }
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(GameController.spritesheet, 
                new Rectangle(new Point((int)transform.position.X, (int)transform.position.Y), 
                new Size(transform.size.Width, transform.size.Height)),
                2, 58, 100, 12, GraphicsUnit.Pixel);
        }
    }
}