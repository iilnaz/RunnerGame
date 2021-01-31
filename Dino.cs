using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame
{
    public class Dino
    {
        public Physics physics;
        public int framesCount;
        public int animationCount = 0;
        public int dustFramesCount;
        public int dustAnimationCount = 0;
        public int score;
        public RectangleF dust;

        public Dino(PointF position,Size size)
        {
            physics = new Physics(position, size);
            framesCount = 0;
            score = 0;
        }

        public void DrawSprite(Graphics g)
        {
            if (physics.isCrouching)
            {
                DrawNeededSprite(g,1112,18,59,30,59,1.35f);
            }
            else
            {
                DrawNeededSprite(g,936,0,44,48,44,1); 
            }
            MakeDust(g);
        }

        public void MakeDust(Graphics g)
        {
            dustFramesCount++;
            if (dustFramesCount <= 10)
            {
                dustAnimationCount = 0;
            }
            else if (dustFramesCount > 10 && dustFramesCount <= 20)
                dustAnimationCount = 1;
            else if (dustFramesCount > 20)
                dustFramesCount = 0;
            if (!physics.isJumping)
            {
                dust = new RectangleF(new PointF(90+ 5*dustAnimationCount, 193 + 3 * dustAnimationCount), new Size(15, 6));
                Color color = Color.FromArgb(100,Color.Beige);
                SolidBrush dustBrush = new SolidBrush(color);
                g.FillRectangle(dustBrush, dust);
                dustBrush.Dispose();
            }
        }
        public void DrawNeededSprite(Graphics g,int posX,int posY, int width, int height, int delta, float multiplier)
        {
            framesCount++;
            if (framesCount <= 10)
            {
                animationCount = 0;
            }
            else if (framesCount > 10 && framesCount <= 20)
                animationCount = 1;
            else if (framesCount > 20)
                framesCount = 0;

            g.DrawImage(GameController.spritesheet,
                new Rectangle(new Point((int)physics.transform.position.X, (int)physics.transform.position.Y),
                new Size((int)(physics.transform.size.Width * multiplier), physics.transform.size.Height)),
                posX+delta*animationCount, posY, width, height, GraphicsUnit.Pixel);

        }
    }
}
