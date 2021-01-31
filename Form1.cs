using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunnerGame
{
    public partial class Form1 : Form
    {
        Dino dino;
        public static EnemyBird enemy;
        Timer mainTimer;
        Timer enemyTimer;
        Timer enemyAttackAnimationTimer;

        public Form1()
        {
            InitializeComponent();
            this.Width = 700;
            this.Height = 300;
             
            DoubleBuffered = true;
            this.Paint += new PaintEventHandler(DrawGame);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            this.KeyDown += new KeyEventHandler(OnKeyboardDown);

            mainTimer = new Timer();
            mainTimer.Interval = 10;
            mainTimer.Tick += new EventHandler(Update);

            enemyTimer = new Timer();
            enemyTimer.Interval = 1000;
            enemyTimer.Tick += new EventHandler(UpdateForAttack);

            enemyAttackAnimationTimer = new Timer();
            enemyAttackAnimationTimer.Interval = 10;
            enemyAttackAnimationTimer.Tick += new EventHandler(UpdateForAnimationAttack);
            Init();
        }

        private void UpdateForAnimationAttack(object sender, EventArgs e)
        {
            enemy.physics.CalculatePhysicsForAttack(enemy);
        }

        private void UpdateForAttack(object sender, EventArgs e)
        {
            bool isAttack = enemy.physics.Attack();

            if (isAttack)
            {
                enemy.physics.AddForceForAttack();
                
            }
            
        }

        private void OnKeyboardDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (!dino.physics.isJumping)
                    {
                        dino.physics.isCrouching = true;
                        dino.physics.isJumping = false;
                        dino.physics.transform.size.Height = 25;
                        dino.physics.transform.position.Y = 174;

                    }
                    break;
            }
        }
                
        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!dino.physics.isCrouching)
                    {
                        dino.physics.isCrouching = false;
                        dino.physics.AddForce();
                                               

                    }
                    break;
                case Keys.Down:
                    dino.physics.isCrouching = false;
                    dino.physics.transform.size.Height = 50;
                    dino.physics.transform.position.Y = 150.2f;
                    break;
            }
        }

        
        public void Init()
        {
            GameController.Init();
            dino = new Dino(new PointF(90, 149), new Size(50, 50));
            enemy = new EnemyBird(new PointF(15, 35), new Size(50, 50));
            mainTimer.Start();
            enemyTimer.Start();
            enemyAttackAnimationTimer.Start();
            
            Invalidate();

        }

        public void Update(object sender, EventArgs e)
        {
            dino.score++;
            this.Text = $"Score:{dino.score}";
            if (dino.physics.isCollide())
            {
                Init();
            }
            dino.physics.ApplyPhysics();
            GameController.MoveMap();
            Invalidate();
        }
                       
        public void DrawGame(object sender,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            dino.DrawSprite(g);
            
            enemy.DrawSprite(g);
            GameController.DrawObjects(g);
        }
    }
}
