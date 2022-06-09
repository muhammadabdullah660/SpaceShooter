using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        List<PictureBox> pbFires = new List<PictureBox>();
        List<PictureBox> enemyFires = new List<PictureBox>();
        List<PictureBox> enemies = new List<PictureBox>();
        Random rand = new Random();
        PictureBox enemyBlue;
        PictureBox enemyRed;
        PictureBox enemyBlack;
        string enemyBlueDirection = "MovingRight";
        string enemyRedDirection = "MovingLeft";
        int enemyBlueTimeToFire;
        int enemyBlueLastTimeToFire;
        int enemyRedTimeToFire;
        int enemyRedLastTimeToFire;
        int enemySpeed;
        //string enemyBlackDirection = "";
        public Form1 ()
        {
            InitializeComponent();
        }

        private void Form1_Load (object sender , EventArgs e)
        {
            enemyBlue = createEnemy(SpaceShooter.Properties.Resources.enemyBlue5);
            enemyRed = createEnemy(SpaceShooter.Properties.Resources.enemyRed4);
            //enemyBlack = createEnemy(SpaceShooter.Properties.Resources.enemyBlack3);
            addControlIntoForm(enemyBlue);
            addControlIntoForm(enemyRed);
            enemies.Add(enemyBlue);
            enemies.Add(enemyRed);
            // addControlIntoForm(enemyBlack);
            enemyBlueTimeToFire = 90;
            enemyBlueLastTimeToFire = 0;
            enemyRedTimeToFire = 60;
            enemyRedLastTimeToFire = 0;
            enemySpeed = 20;
        }

        private void timeGameLoop_Tick (object sender , EventArgs e)
        {
            //UFO Movement
            ufoMovement();
            //Firing System
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                createBullet();
            }
            enemyMovement(enemyBlue , ref enemyBlueDirection);
            enemyMovement(enemyRed , ref enemyRedDirection);
            // enemyMovementIntelli(enemyBlack);
            //Firing Bullets
            fireBullet();
            //Removing Bullets
            removeBullet();
            detectCollison();
            //Enemy Bullets 
            enemyRedLastTimeToFire++;
            enemyBlueLastTimeToFire++;
            if (enemyRedLastTimeToFire == enemyRedTimeToFire)
            {
                Image imgRedEnemyFire = SpaceShooter.Properties.Resources.laserRed09;
                createEnemyBullet(imgRedEnemyFire , enemyRed);
                enemyRedLastTimeToFire = 0;
            }
            if (enemyBlueLastTimeToFire == enemyBlueTimeToFire)
            {
                Image imgBlueEnemyFire = SpaceShooter.Properties.Resources.laserBlue09;
                createEnemyBullet(imgBlueEnemyFire , enemyBlue);
                enemyBlueLastTimeToFire = 0;
            }


            progressBar1.Left = pbUFO.Left;
        }
        private void detectCollison ()
        {
            foreach (PictureBox fire in pbFires)
            {
                foreach (PictureBox enemy in enemies)
                {
                    if (fire.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        enemies.Remove(enemy);
                        this.Controls.Remove(enemy);
                        fire.Visible = false;
                        break;
                    }
                }

            }
            foreach (PictureBox fire in enemyFires)
            {

                if (fire.Bounds.IntersectsWith(pbUFO.Bounds))
                {
                    if (progressBar1.Value >= 0)
                    {
                        progressBar1.Value -= 10;
                    }

                }

            }
        }
        private void fireBullet ()
        {
            foreach (PictureBox fire in pbFires)
            {
                fire.Top -= 20;
            }
            foreach (PictureBox fire in enemyFires)
            {
                fire.Top += 20;
            }
        }
        private void removeBullet ()
        {
            for (int i = 0 ; i < pbFires.Count ; i++)
            {
                if (pbFires[i].Bottom < 0)
                {
                    pbFires.RemoveAt(i);
                }
            }
            for (int i = 0 ; i < enemies.Count ; i++)
            {
                if (enemies[i].Top >= this.Height || enemies[i].Visible == false)
                {
                    enemyFires.RemoveAt(i);
                }
            }

        }
        private void createBullet ()
        {
            Image imgRedFire = SpaceShooter.Properties.Resources.laserRed01;
            PictureBox pbFire = firingSystem(imgRedFire , pbUFO);
            addFireIntoList(pbFire , pbFires);
            addControlIntoForm(pbFire);
        }
        private void createEnemyBullet (Image img , PictureBox source)
        {
            PictureBox enemyFire = firingSystemEnemy(img , source);
            addFireIntoList(enemyFire , enemyFires);
            addControlIntoForm(enemyFire);
        }
        private void ufoMovement ()
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow) || Keyboard.IsKeyPressed(Key.D))
            {
                if ((pbUFO.Left + pbUFO.Width + 30 < this.Width))
                {
                    pbUFO.Left += enemySpeed;
                }
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow) || Keyboard.IsKeyPressed(Key.A))
            {
                if (pbUFO.Left - 20 > 0)
                {
                    pbUFO.Left -= enemySpeed;

                }
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow) || Keyboard.IsKeyPressed(Key.W))
            {
                if (pbUFO.Top > 0)
                {
                    pbUFO.Top -= enemySpeed;
                }
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow) || Keyboard.IsKeyPressed(Key.S))
            {
                if (pbUFO.Top + pbUFO.Width + 30 < this.Height)
                {
                    pbUFO.Top += enemySpeed;
                }

            }
        }
        private PictureBox firingSystem (Image fireImage , PictureBox source)
        {

            PictureBox pbFire = new PictureBox();
            pbFire.Image = fireImage;
            pbFire.Width = fireImage.Width;
            pbFire.Height = fireImage.Height;
            pbFire.BackColor = Color.Transparent;
            //Location/Point
            System.Drawing.Point fireLocation = new System.Drawing.Point();
            fireLocation.X = source.Left + (source.Width / 2) - 5;
            fireLocation.Y = source.Top;
            pbFire.Location = fireLocation;
            return pbFire;
        }
        private PictureBox firingSystemEnemy (Image fireImage , PictureBox source)
        {

            PictureBox pbFire = new PictureBox();
            pbFire.Image = fireImage;
            pbFire.Width = fireImage.Width;
            pbFire.Height = fireImage.Height;
            pbFire.BackColor = Color.Transparent;
            // Location/Point
            // System.Drawing.Point fireLocation = new System.Drawing.Point();
            pbFire.Left = source.Left + 45;
            pbFire.Top = source.Top + 60;
            //pbFire.Location = fireLocation;
            return pbFire;
        }
        private void enemyMovement (PictureBox enemy , ref string enemyDirection)
        {
            if (enemyDirection == "MovingRight")
            {
                enemy.Left += 10;
            }
            else if (enemyDirection == "MovingLeft")
            {
                enemy.Left -= 10;
            }
            if (enemy.Left + enemy.Width > this.Width)
            {
                enemyDirection = "MovingLeft";
            }
            if (enemy.Left <= 2)
            {
                enemyDirection = "MovingRight";
            }
        }
        private void enemyMovementIntelli (PictureBox enemy)
        {
            /*if (enemy.Left > pbUFO.Left)
            {
                enemy.Left -= pbUFO.Left;
            }
            else if (enemy.Left < pbUFO.Left)
            {
                enemy.Left += pbUFO.Left;
            }*/
            /* if (enemy.Left + enemy.Width > this.Width)
             {
                 enemyDirection = "MovingLeft";
             }
             if (enemy.Left <= 2)
             {
                 enemyDirection = "MovingRight";
             }*/
        }
        private void addFireIntoList (PictureBox pbFire , List<PictureBox> firesList)
        {
            firesList.Add(pbFire);
        }
        private void addControlIntoForm (Control item)
        {
            this.Controls.Add(item);
        }
        private PictureBox createEnemy (Image img)
        {
            PictureBox pbEnemy = new PictureBox();
            int left = rand.Next(30 , this.Width); ;
            int top = rand.Next(5 , img.Height + 20); ;
            pbEnemy.Left = left;
            pbEnemy.Top = top;
            pbEnemy.Height = img.Height;
            pbEnemy.Width = img.Width;
            pbEnemy.BackColor = Color.Transparent;
            pbEnemy.Image = img;
            return pbEnemy;
        }
    }
}
