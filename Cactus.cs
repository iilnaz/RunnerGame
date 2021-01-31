using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame
{
    public class Cactus
    {
        public Transform transform;
        int posX;

        public Cactus(PointF position,Size size)
        {
            transform = new Transform(position, size);
            ChoosePic();
        }

        public void ChoosePic()
        {
            Random r = new Random();
            int random = r.Next(0, 4);
            switch (random)
            {
                case 0:
                    {
                        posX = 333;
                        break;
                    }
                case 1:
                    {
                        posX = 357;
                        break;
                    }
                case 2:
                    {
                        posX = 383;
                        break;
                    }
                case 3:
                    {
                        posX = 408;
                        break;
                    }
            }
        }

        public void DrawSprite(Graphics g)
        {
            
            g.DrawImage(GameController.spritesheet,
                new Rectangle(new Point((int)transform.position.X, (int)transform.position.Y),
                new Size(transform.size.Width, transform.size.Height)),
                posX, 0, 23, 51, GraphicsUnit.Pixel);
        }
    }
}
