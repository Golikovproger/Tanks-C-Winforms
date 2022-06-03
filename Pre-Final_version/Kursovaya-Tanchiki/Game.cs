using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Kursovaya_Tanchiki
{
    
    public partial class Game : Form
    {
        PictureBox maintank;
        PictureBox secondtank;
        PictureBox shoot;
        PictureBox shoot2;
        PictureBox base1;
        PictureBox base2;
        int speed = 3;
        private int direction = 2;
        private int direction2 = 3;
        private int directionbullet;
        public int directionbullet2;
        bool up, up2, down, down2, left, left2, right, right2, keytracking = true , keytracking2=true, shut=true, shut2=true, сheckifgamestop = true;

       

        public Game()
        {
            InitializeComponent();
            maintank = new PictureBox();
            secondtank = new PictureBox();
            shoot = new PictureBox();
            shoot.Location = new Point(-1, -1);
            shoot.Size = new Size(0, 0);
            shoot2 = new PictureBox();
            shoot2.Location = new Point(-1, -1);
            shoot2.Size = new Size(0, 0);
            base1 = new PictureBox();
            base2 = new PictureBox();
            generate(this);
            Bases(this);
            Tank(2, this);
        }

        private void generate(Control control) //отрисовка игрового поля
        {
            string w = Properties.Resources.lvl1;
            Regex reg = new Regex("\r");
            w = reg.Replace(w, "");
            string[] arr = w.Split('\n'); // массив содержащий уровень по строчно
            List<char> bloknot = new List<char>(); // массив содержащий символы по которым стоится уровень
            for (int x = 0; x < arr.Length; x++)
            {
                foreach (char item in arr[x])
                {
                    bloknot.Add(item);
                }

                for (int y = 0; y < arr[0].Length; y++)
                {
                    PictureBox picture = new PictureBox();
                    control.Controls.Add(picture);

                    picture.Location = new Point((control.ClientSize.Width / 2 - ((arr.Length * 25) / 2)) + y * 25,
                                                   (control.ClientSize.Height / 2 - ((arr[0].Length * 25) / 2)) + x * 25); 
                    picture.Size = new Size(25, 25); 
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;



                    if (bloknot[y] == '#')
                    {
                        picture.Image = Properties.Resources.wall;
                        picture.Tag = "wall";
                    }
                   
                    else if (bloknot[y] == '.')
                    {
                        picture.Image = null;
                        picture.Tag = "space";
                    }

                }
                bloknot.Clear();
            }
        }



        private void Tank(int direction, Control control) //отрисовка танков
        {
            maintank.Image = Properties.Resources.SmallTankPlayerUp_1;
            maintank.Tag = "TANK";

            maintank.Size = new Size(40, 40);
            maintank.SizeMode = PictureBoxSizeMode.StretchImage;
            control.Controls.Add(maintank);
            maintank.Location = new Point(220, 600);
            secondtank.Image = Properties.Resources.TankPlayer2Down;
            secondtank.Tag = "TANK2";
            secondtank.Size = new Size(40, 40);
            secondtank.SizeMode = PictureBoxSizeMode.StretchImage;
            control.Controls.Add(secondtank);
            secondtank.Location = new Point(380, 6);
        }
        private void Bases(Control control) //отрисовка баз
        {
            base1.Image = Properties.Resources.BaseFirTank;
            base1.Tag = "BaseFirstPlayer";
            base1.Size = new Size(40, 40);
            base1.SizeMode = PictureBoxSizeMode.StretchImage;
            base1.Location = new Point(300, 600);
            control.Controls.Add(base1);

            base2.Image = Properties.Resources.BaseSecTank;
            base2.Tag = "BaseSecondPlayer";
            base2.Size = new Size(40, 40);
            base2.SizeMode = PictureBoxSizeMode.StretchImage;
            base2.Location = new Point(300, 6);
            control.Controls.Add(base2);

        }
        private void Form2_KeyUp(object sender, KeyEventArgs e) // обработчик при отжатии клавиши с клавиатуры
        {
            keytracking = true;
            keytracking2 = true;
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Down )
            {
                down = false;
            }
            if (e.KeyCode == Keys.A)
            {
                left2 = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right2 = false;
            }
            if (e.KeyCode == Keys.W)
            {
                up2 = false;
            }
            if (e.KeyCode == Keys.S)
            {
                down2 = false;
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e) //обработчик при нажатии клавиши с клавиатуры
        {


            if (e.KeyCode == Keys.Left && keytracking == true && сheckifgamestop == true && maintank.Left >=0) // при нажатии на левую кнопку 
            {
                left = true;
                maintank.Image = Properties.Resources.SmallTankPlayerLeft_1;
                direction = 0;
                keytracking = false;

            }
            else if (e.KeyCode == Keys.Right && keytracking == true && сheckifgamestop == true && maintank.Left <= 615  ) // при нажатии на правую кнопку 
            {
                right = true;
                maintank.Image = Properties.Resources.SmallTankPlayerRight_1;
                direction = 1;
                keytracking = false;



            }
            else if (e.KeyCode == Keys.Up && keytracking == true && сheckifgamestop == true && maintank.Location.Y >= 0) // при нажатии на кнопку вверх
            {
                up = true;
                keytracking = false;

                maintank.Image = Properties.Resources.SmallTankPlayerUp_1;
                direction = 2;
            }
            else if (e.KeyCode == Keys.Down && keytracking == true && сheckifgamestop == true && maintank.Top <= 600) // при нажатии на кнопку вниз
            {
                down = true;
                maintank.Image = Properties.Resources.SmallTankPlayerDown_1;
                direction = 3;
                keytracking = false;

            }
            if (e.KeyCode == Keys.A && keytracking2 == true && сheckifgamestop == true && secondtank.Left >= 0) // при нажатии на левую кнопку 
            {
                left2 = true;
                secondtank.Image = Properties.Resources.TankPlayer2Left;
                direction2 = 0;
                keytracking2 = false;
            }
            else if (e.KeyCode == Keys.D && keytracking2 == true && сheckifgamestop == true && secondtank.Left <= 615) // при нажатии на правую кнопку 
            {
                right2 = true;
                secondtank.Image = Properties.Resources.TankPlayer2Right;
                direction2 = 1;
                keytracking2 = false;
            }
            else if (e.KeyCode == Keys.W && keytracking2 == true && сheckifgamestop == true && secondtank.Location.Y >= 0) // при нажатии на кнопку вверх
            {
                up2 = true;
                secondtank.Image = Properties.Resources.TankPlayer2Up;
                direction2 = 2;
                keytracking2 = false;
            }
            else if (e.KeyCode == Keys.S && keytracking2 == true && сheckifgamestop == true && secondtank.Top <= 600) // при нажатии на кнопку вниз 
            {
                down2 = true;
                secondtank.Image = Properties.Resources.TankPlayer2Down;
                direction2 = 3;
                keytracking2 = false;
            }
            else if (e.KeyCode == Keys.NumPad0 && shut ==true)
            {
                
                shut = false;
                shoot.Image = Properties.Resources.Bullet;
                shoot.Size = new Size(10, 10);
                shoot.SizeMode = PictureBoxSizeMode.StretchImage;
                shoot.Tag = "bullet";
                shoot.Location = new Point(maintank.Location.X+15, maintank.Location.Y+14);
                
                 this.Controls.Add(shoot);
                directionbullet = direction;
                 Timerbullet.Start();
            }
            else if (e.KeyCode == Keys.Space && shut2 == true)
            {
                
                shut2 = false;
                shoot2.Image = Properties.Resources.Bullet;
                shoot2.Size = new Size(10, 10);
                shoot2.SizeMode = PictureBoxSizeMode.StretchImage;
                shoot2.Tag = "bullet2";
                shoot2.Location = new Point(secondtank.Location.X + 15, secondtank.Location.Y + 14);
                
                this.Controls.Add(shoot2);
                directionbullet2 = direction2;
                Timerbullet.Start();
            }
        }

       

        private void TimerforFirstTank(object sender, EventArgs e) //метод для коллизии и движения первого танка
        {

            // Коллизия
            int X = maintank.Location.X;
            int Y = maintank.Location.Y;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "space")
                {
                    this.Controls.Remove(x);
                }
                if (x is PictureBox && (string)x.Tag == "TANK2")
                {
                    
                        if (maintank.Bounds.IntersectsWith(x.Bounds) && direction == 2)
                        {
                            up = false;
                            maintank.Location = new Point(X, Y + 1);
                            break;

                        }
                        else if (maintank.Bounds.IntersectsWith(x.Bounds) && direction == 3)
                        {
                            down = false;
                            maintank.Location = new Point(X, Y - 1);
                            break;


                        }
                        else if (maintank.Bounds.IntersectsWith(x.Bounds) && direction == 0)
                        {
                            left = false;
                            maintank.Location = new Point(X + 1, Y);
                            break;
                        }
                        else if (maintank.Bounds.IntersectsWith(x.Bounds) && direction == 1)
                        {
                            right = false;
                            maintank.Location = new Point(X - 1, Y);
                            break;
                        }
                    

                }


                    if (x is PictureBox && (string)x.Tag == "wall" )
                {
                    if (maintank.Bounds.IntersectsWith(x.Bounds) && direction == 2)
                    {
                        up = false;
                        maintank.Location = new Point(X, Y+3);
                        break;

                    }
                    else if (maintank.Bounds.IntersectsWith(x.Bounds) && direction == 3)
                    {
                        down = false;
                        maintank.Location = new Point(X, Y-3);
                        break;


                    }
                    else if (maintank.Bounds.IntersectsWith(x.Bounds) && direction == 0)
                    {
                        left = false;
                        maintank.Location = new Point(X+3, Y);
                        break;
                    }
                    else if (maintank.Bounds.IntersectsWith(x.Bounds) && direction == 1)
                    {
                        right = false;
                        maintank.Location = new Point(X-3, Y);
                        break;
                    }
                    
                }

            }

        

            // Движение
            if (left == true && maintank.Left >= 0)
            {
                maintank.Left -= speed;
                right = false;
                up = false;
                down = false;
            }

            if (right == true && maintank.Left <= 605)
            {
                maintank.Left += speed;
                left = false;
                up = false;
                down = false;
            }

            if (up == true && maintank.Top >=0)
            {
                maintank.Top -= speed;
                left = false;
                right = false;
                down = false;
            }

            if (down == true && maintank.Top <= 600)
            {
                maintank.Top += speed;
                left = false;
                up = false;
                right = false;
            }
            
        }
        private void TimerforSec(object sender, EventArgs e) //метод для коллизия и движения второго танка
        {
            // Коллизия
            int X2 = secondtank.Location.X;
            int Y2 = secondtank.Location.Y;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "space")
                {
                    this.Controls.Remove(x);
                }

                if (x is PictureBox && (string)x.Tag == "TANK")
                {
                   
                        //if (secondtank.Bounds.IntersectsWith(x.Bounds) && direction2 == 2)
                        //{
                        //    up2 = false;
                        //    maintank.Location = new Point(X2, Y2+1);
                        //    break;

                        //}
                        //else if (secondtank.Bounds.IntersectsWith(x.Bounds) && direction2 == 3)
                        //{
                        //    down2 = false;
                        //    maintank.Location = new Point(X2, Y2-1);
                        //    break;
                        //}
                        //else if (secondtank.Bounds.IntersectsWith(x.Bounds) && direction2 == 0)
                        //{
                        //    left2 = false;
                        //    maintank.Location = new Point(X2+1, Y2);
                        //    break;
                        //}
                        //else if (secondtank.Bounds.IntersectsWith(x.Bounds) && direction2 == 1)
                        //{
                        //    right2 = false;
                        //    maintank.Location = new Point(X2-1, Y2);
                        //    break;
                        //}
                    
                }

                if (x is PictureBox && (string)x.Tag == "wall" )
                {
                    
                    if (secondtank.Bounds.IntersectsWith(x.Bounds) && direction2 == 2)
                    {
                        up2 = false;
                        secondtank.Location = new Point(X2, Y2 + 3);
                        break;

                    }
                    else if (secondtank.Bounds.IntersectsWith(x.Bounds) && direction2 == 3)
                    {
                        down2 = false;
                        secondtank.Location = new Point(X2, Y2 - 3);
                        break;
                    }
                    else if (secondtank.Bounds.IntersectsWith(x.Bounds) && direction2 == 0)
                    {
                        left2 = false;
                        secondtank.Location = new Point(X2 + 3, Y2);
                        break;
                    }
                    else if (secondtank.Bounds.IntersectsWith(x.Bounds) && direction2 == 1)
                    {
                        right2 = false;
                        secondtank.Location = new Point(X2 - 3, Y2);
                        break;
                    }
                }

            }



            // Движение
           
            if (left2 == true && secondtank.Left >= 0)
            {
                secondtank.Left -= speed;
                right2 = false;
                up2 = false;
                down2 = false;
            }
            if (right2 == true && secondtank.Left <= 605)
            {
                secondtank.Left += speed;
                left2 = false;
                up2 = false;
                down2 = false;
            }
            if (up2 == true && secondtank.Top >= 0)
            {
                secondtank.Top -= speed;
                left2 = false;
                right2 = false;
                down2 = false;
            }
            if (down2 == true && secondtank.Top <= 600)
            {
                secondtank.Top += speed;
                left2 = false;
                up2 = false;
                right2 = false;
            }
        
    }

        private void Tick(object sender, EventArgs e) //метод для задержки перед закрытием формы
        {
            this.Close();
        }
        
       
        private void TimerforBullet(object sender, EventArgs e) //коллизия снаряда
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "wall")
                {
                    if (shoot.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(shoot);
                        this.Controls.Remove(x);
                        shut = true;
                        shoot.Location = new Point(-20, -20);

                    }
                    if (shoot2.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(shoot2);
                        this.Controls.Remove(x);
                        shut2 = true;
                        shoot2.Location = new Point(-20, -20);

                    }
                }
                

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    if (shoot.Top < 0 || shoot.Top > 635 || shoot.Left < 0 || shoot.Left >= 635)
                    {
                        this.Controls.Remove(shoot);
                        shut = true;
                    }
                    Point sh = shoot.Location;
                    if (directionbullet==2)
                    {
                        sh.Y -= 10;
                        shoot.Location = sh;
                      
                    }
                    else if (directionbullet==3)
                    {
                        sh.Y += 10;
                        shoot.Location = sh;
                    }
                    else if(directionbullet==0)
                    {
                        sh.X -= 10;
                        shoot.Location = sh;
                    }
                    else if (directionbullet ==1)
                    {
                        sh.X += 10;
                        shoot.Location = sh;
                    }
                   
                    


                }

                if (x is PictureBox && (string)x.Tag == "bullet2")
                {
                    if (shoot2.Top < 0 || shoot2.Top > 635 || shoot2.Left < 0 || shoot2.Left >= 635)
                    {
                        this.Controls.Remove(shoot2);
                        shut2 = true;
                    }
                    Point sh2 = shoot2.Location;
                    if (directionbullet2 == 2)
                    {
                        sh2.Y -= 10;
                        shoot2.Location = sh2;

                    }
                    else if (directionbullet2 == 3)
                    {
                        sh2.Y += 10;
                        shoot2.Location = sh2;
                    }
                    else if (directionbullet2 == 0)
                    {
                        sh2.X -= 10;
                        shoot2.Location = sh2;
                    }
                    else if (directionbullet2 == 1)
                    {
                        sh2.X += 10;
                        shoot2.Location = sh2;
                    }
                }
            }
            
        }
        private void TimerForEnd(object sender, EventArgs e) //завершение игры
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "TANK2" || (string)x.Tag == "BaseSecondPlayer")
                {
                    if (shoot.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(shoot);
                        this.Controls.Remove(shoot2);
                        this.Controls.Remove(x);
                        shut = false;
                        shut2 = false;
                        сheckifgamestop = false;
                        PictureBox finish = new PictureBox();
                        finish.Image = Properties.Resources.WinPlayer1;
                        finish.Size = new Size(200, 90);
                        finish.Location = new Point(250, 300);
                        this.Controls.Add(finish);
                        finish.BringToFront();
                        Timer t = new Timer();
                        t.Interval = 5000;
                        t.Start();
                        t.Tick += new EventHandler(Tick);

                    }


                }
                if (x is PictureBox && (string)x.Tag == "TANK" || (string)x.Tag == "BaseFirstPlayer")
                {
                    if (shoot2.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(shoot2);
                        this.Controls.Remove(shoot);
                        this.Controls.Remove(x);

                        shut2 = false;
                        shut = false;
                        сheckifgamestop = false;
                        PictureBox finish = new PictureBox();
                        finish.Image = Properties.Resources.WinPlayer2;
                        finish.Size = new Size(200, 90);
                        finish.Location = new Point(250, 300);
                        this.Controls.Add(finish);
                        finish.BringToFront();
                        Timer t = new Timer();
                        t.Interval = 5000;
                        t.Start();
                        t.Tick += new EventHandler(Tick);
                    }

                }
            }
        }

    }
}
