using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunnerGame
{
    public class EnemyBird
    {
        public Physics physics;
        int frameCount = 0;
        int animationCount = 0;
        public static bool isAttack = false;
        
        public EnemyBird(PointF position,Size size)
        {
            physics = new Physics(position, size);
                        
        }
                              
        public void DrawSprite(Graphics g)
        {
            frameCount++;
            if (frameCount <= 10)
                animationCount = 0;
            else if (frameCount > 10 && frameCount <= 20)
                animationCount = 1;
            else
                frameCount = 0;
            g.DrawImage(GameController.EnemySprite,
                new Rectangle(new Point((int)physics.transform.position.X, (int)physics.transform.position.Y),
                new Size(physics.transform.size.Width, physics.transform.size.Height)),
                1007 + 46*animationCount, 0, 46, 42, GraphicsUnit.Pixel);
        }

    }
}
