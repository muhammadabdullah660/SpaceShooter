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
        Random rand = new Random();
        PictureBox enemyBlue;
        PictureBox enemyRed;
        PictureBox enemyBlack;
        string enemyBlueDirection = "MovingRight";
        string enemyRedDirection = "MovingLeft";
        //string enemyBlackDirection = "";
        public Form1 ()
        {
            InitializeComponent();
        }

        private void Form1_Load (object sender , EventArgs e)
        {
            enemyBlue = createEnemy(SpaceShooter.Properties.Resources.enemyBlue5);
            enemyRed = createEnemy(SpaceShooter.Properties.Resources.enemyRed4);
            enemyBlack = createEnemy(SpaceShooter.Properties.Resources.enemyBlack3);
            addControlIntoForm(enemyBlue);
            addControlIntoForm(enemyRed);
            addControlIntoForm(enemyBlack);
        }

        private void timeGameLoop_Tick (object sender , EventArgs e)
        {
            //UFO Movement
            ufoMovement();
            //Firing System
            firingSystem();
            //Firing Bullets
            foreach (PictureBox fire in pbFires)
            {
                fire.Top -= 20;
            }
            //Removing Bullets
            for (int i = 0 ; i < pbFires.Count ; i++)
            {
                if (pbFires[i].Bottom < 0)
                {
                    pbFires.RemoveAt(i);
                }
            }
            enemyMovement(enemyBlue , ref enemyBlueDirection);
            enemyMovement(enemyRed , ref enemyRedDirection);
            enemyMovementIntelli(enemyBlack);
        }
        public void ufoMovement ()
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow) || Keyboard.IsKeyPressed(Key.D))
            {
                if ((pbUFO.Left + pbUFO.Width < this.Width))
                {
                    pbUFO.Left += 20;
                }
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow) || Keyboard.IsKeyPressed(Key.A))
            {
                if (pbUFO.Left > 0)
                {
                    pbUFO.Left -= 20;

                }
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow) || Keyboard.IsKeyPressed(Key.W))
            {
                if (pbUFO.Top > 0)
                {
                    pbUFO.Top -= 20;
                }
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow) || Keyboard.IsKeyPressed(Key.S))
            {
                if (pbUFO.Top + pbUFO.Width + 10 < this.Height)
                {
                    pbUFO.Top += 20;
                }

            }
        }
        public void firingSystem ()
        {
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                PictureBox pbFire = new PictureBox();
                Image imgRedFire = SpaceShooter.Properties.Resources.laserRed01;
                pbFire.Image = imgRedFire;
                pbFire.Width = imgRedFire.Width;
                pbFire.Height = imgRedFire.Height;
                pbFire.BackColor = Color.Transparent;
                //Location/Point
                System.Drawing.Point fireLocation = new System.Drawing.Point();
                fireLocation.X = pbUFO.Left + (pbUFO.Width / 2) - 5;
                fireLocation.Y = pbUFO.Top;
                pbFire.Location = fireLocation;
                addFireIntoList(pbFire);
                addControlIntoForm(pbFire);

            }
        }
        public void enemyMovement (PictureBox enemy , ref string enemyDirection)
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
        public void enemyMovementIntelli (PictureBox enemy)
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
        public void addFireIntoList (PictureBox pbFire)
        {
            pbFires.Add(pbFire);
        }
        public void addControlIntoForm (Control item)
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
