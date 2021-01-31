using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerGame
{
    public class Physics
    {
        public Transform transform;
        float gravity;
        public float attackSpeed;
        public float a;

        public bool isJumping;
        public bool isCrouching;
        public static bool isAttack;

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            attackSpeed = 0;
            a = 0.4f;
            isJumping = false;
            isCrouching = false;
            isAttack = false;
        }

        public void ApplyPhysics()
        {
            CalculatePhysics();
        }
        public void CalculatePhysics()
        {
            if (transform.position.Y < 150 || isJumping)
            {
                transform.position.Y += gravity;
                gravity += a;
            }
            if (transform.position.Y > 150)
            {
                isJumping = false;
            }
        }

        public bool isCollide()
        {
            for (int i = 0; i < GameController.cactuses.Count; i++)
            {
                var cactus = GameController.cactuses[i];
                PointF delta = new PointF();
                delta.X = (transform.position.X + transform.size.Width / 2) -
                    (cactus.transform.position.X + cactus.transform.size.Width / 2);
                delta.Y = (transform.position.Y + transform.size.Height / 2) -
                    (cactus.transform.position.Y + cactus.transform.size.Height / 2);

                if (Math.Abs(delta.X) <= transform.size.Width / 2 + cactus.transform.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= transform.size.Height / 2 + cactus.transform.size.Height / 2)
                    {
                        return true;
                    }

                }
            }
                        
            if (isAttack)
            {
                
                EnemyBird enemy = Form1.enemy;
                CalculatePhysicsForAttack(enemy);
                
                PointF alfa = new PointF();
                alfa.X = (transform.position.X + transform.size.Width / 2) -
                    (enemy.physics.transform.position.X + enemy.physics.transform.size.Width / 2);
                alfa.Y = (transform.position.Y + transform.size.Height / 2) -
                    (enemy.physics.transform.position.Y + enemy.physics.transform.size.Height / 2);

                if (Math.Abs(alfa.X) <= transform.size.Width / 2 + enemy.physics.transform.size.Width / 2)
                {
                    if (Math.Abs(alfa.Y) <= transform.size.Height / 2 + enemy.physics.transform.size.Height / 2)
                    {
                        return true;
                    }
                }
                return false;

                
            }
            else
            {
                //CalculatePhysicsForAttack(enemy);
                EnemyBird enemy = new EnemyBird(new PointF(15, 35), new Size(50, 50));

                //CalculatePhysicsForAttack(enemy);
                if ((enemy.physics.transform.position.X >= 60 || enemy.physics.transform.position.Y >= 100) && !isCrouching)
                {
                    return true;
                }
                return false;
            }
        }

        public void CalculatePhysicsForAttack(EnemyBird enemy)
        {
            if (isAttack)
            {
                enemy.physics.transform.position.X += attackSpeed;
                enemy.physics.transform.position.Y = enemy.physics.transform.position.X * 1.5f + 12.5f;

                if (enemy.physics.transform.position.Y >= 110 || enemy.physics.transform.position.X >= 65)
                {
                    isAttack = false;
                    enemy.physics.transform.position = new PointF(15, 35);

                }
                
            }
            
        }

        public void AddForceForAttack()
        {
            if (isAttack)
            {
                attackSpeed = 1;
            }
        }
        public bool Attack()
        {
            int rand = RandomInt();
            if (rand % 4 == 0)
            {
                isAttack = true;
                return isAttack;
                
            }
            return isAttack; 
                        


        }
                
        public void AddForce()
        {
            if (!isJumping)
            {
                isJumping = true;
                gravity = -10;
            }
        }

        public static int RandomInt()
        {
            Random r = new Random();
            int random = r.Next(1, 11);
            return random;
        }
    }
}
