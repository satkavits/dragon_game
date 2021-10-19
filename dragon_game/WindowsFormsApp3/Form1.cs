using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Diagnostics;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        static int sum1 = 0, sum2 = 0, time=60;
        static WindowsMediaPlayer pl = new WindowsMediaPlayer();
        static WindowsMediaPlayer gun = new WindowsMediaPlayer();
        static bool flag=true,pause=false;
        static string[] p = new string[100];
        
        static string[] on = new string[100];
        string temp1,temp2;
        public Form1()
        {
           
            InitializeComponent();
          pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            label6.BackColor = Color.Black;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            button5.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            this.BackColor = Color.Black;
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.Visible = false;
            if (flag == true)
            {
                pl.URL = "Undertale1.mp3";
                pictureBox1.Visible = true;
                
            }
            else
            {
                pl.URL = "gd.mp3";
                pictureBox2.Visible = true;

            }

            textBox1.Text=textBox1.Text; 
        
            pl.controls.play();
            label4.Text = textBox1.Text;


            for (int g = 0; g < 100; g++) { p[g] = "0"; }
            if (flag == true) { richTextBox4.LoadFile("score.txt", RichTextBoxStreamType.PlainText); }
            else { richTextBox4.LoadFile("score2.txt", RichTextBoxStreamType.PlainText); }

            int i = 0;

            foreach (string s in richTextBox4.Lines)
            {
                string[] tmp = s.Split(' ');

                if (tmp[0] != "")
                {
                    p[i] = tmp[0];
                    on[i] = tmp[1];
                }
                i++;
            }


            for (int write = 0; write < p.Length; write++)
            {
                for (int sort = 0; sort < p.Length - 1; sort++)
                {
                    int par1 = Int32.Parse(p[sort]);
                    int par2 = Int32.Parse(p[sort + 1]);
                    if (par1 < par2)
                    {
                        temp1 = p[sort + 1];
                        p[sort + 1] = p[sort];
                        p[sort] = temp1;
                        temp2 = on[sort + 1];
                        on[sort + 1] = on[sort];
                        on[sort] = temp2;
                    }
                }
            }
            label7.Text = p[0];



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {if (pause == false)
            {
                sum1 += 10;
            }
            label6.Text = sum1.ToString();
            gun.controls.stop();
            gun.URL = "gun.mp3";
            gun.controls.play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Maroon;
            flag = true;
            if (textBox1.Text != "")
            {
                button1.Visible = true;
            }
            Image myimage = new Bitmap("lava.jpg");
            this.BackgroundImage = myimage;
            label6.ForeColor = Color.Maroon;
            label3.ForeColor = Color.Maroon;
            button5.ForeColor = Color.Maroon;
            label5.ForeColor = Color.Maroon;
            label4.ForeColor = Color.Maroon;
            label8.ForeColor = Color.Maroon;
            label7.ForeColor = Color.Maroon;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pause == false)
            {
                
                Random r = new Random();
                int randx = r.Next(0, 1710);
                int randy = r.Next(0, 880);

                if ((flag == true)&&(time>40)) 
                {
                    if (randx < 850)
                    {
                        pictureBox1.Visible = true;
                        pictureBox4.Visible = false;
                        pictureBox1.Location = new Point(randx, randy);
                    }else
                    {
                        pictureBox4.Visible = true;
                        pictureBox1.Visible = false;
                        pictureBox4.Location = new Point(randx, randy); }
                }
                else
                {
                    if (randx < 850)
                    {
                        pictureBox5.Visible = true;
                        pictureBox2.Visible = false;
                        pictureBox5.Location = new Point(randx, randy);
                    }
                    else
                    {
                        pictureBox2.Visible = true;
                        pictureBox5.Visible = false;
                        pictureBox2.Location = new Point(randx, randy);
                    }
                }
                time--;
                label3.Text = time.ToString();
                if (time == 0)
                {
                    timer1.Stop();
                    timer2.Stop();
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox4.Visible = false;
                    pl.controls.stop();
                    richTextBox4.Text = richTextBox4.Text + "\n" + label6.Text + " " + textBox1.Text; ;
                    if (flag == true)
                    {
                        richTextBox4.SaveFile("score.txt", RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        richTextBox4.SaveFile("score2.txt", RichTextBoxStreamType.PlainText);
                    }
                    panel4.Visible = true;

                    int x = 0;

                    if (Int32.Parse(p[0]) == 0) { x = 0; }
                    else
                    {


                        for (int j = 0; j < 100; j++)
                        {
                            if ((Int32.Parse(p[j]) == 0) && (Int32.Parse(p[j - 1]) != 0))
                            {
                                x = j;
                            }

                        }
                    }
                    p[x] = label6.Text;
                    on[x] = textBox1.Text;

                    for (int write = 0; write < p.Length; write++)
                    {
                        for (int sort = 0; sort < p.Length - 1; sort++)
                        {
                            int par1 = Int32.Parse(p[sort]);
                            int par2 = Int32.Parse(p[sort + 1]);
                            if (par1 < par2)
                            {
                                temp1 = p[sort + 1];
                                p[sort + 1] = p[sort];
                                p[sort] = temp1;
                                temp2 = on[sort + 1];
                                on[sort + 1] = on[sort];
                                on[sort] = temp2;
                            }
                        }
                    }
                    for (int j = 0; j < 100; j++)
                    {
                        if (p[j] != "0")
                        {
                            richTextBox3.Text = richTextBox3.Text + p[j] + " " + on[j] + "\n";
                        }
                    }
                }
                else if (time == 40)
                {

                    timer2.Start();
                }
                
                else if ((time <= 32) && (flag == false))
                {
                    Random r2 = new Random();
                    int randx2 = r2.Next(0, 1710);
                    int randy2 = r2.Next(0, 880);
                    pictureBox3.Visible = true;
                    pictureBox3.Location = new Point(randx2, randy2);
                }
                pictureBox1.Location = new Point(randx, randy);
            }

            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((pause == false)&&(flag==true))
            {
                Random r = new Random();
                int randx = r.Next(0, 1710);
                int randy = r.Next(0, 880);
               
                    if (randx < 850)
                    {
                        pictureBox1.Visible = true;
                        pictureBox4.Visible = false;
                        pictureBox1.Location = new Point(randx, randy);
                    }
                    else
                    {
                        pictureBox4.Visible = true;
                        pictureBox1.Visible = false;
                        pictureBox4.Location = new Point(randx, randy);
                    }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pause == false)
            {
                pl.controls.pause();
                panel3.Visible = true;
                pause = true;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
            }
            else
            {
                pl.controls.play();
                panel3.Visible = false;
                pause = false;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pause = false;
            timer1.Stop();
            button1.Visible = false;
            timer2.Stop();
            panel1.Visible = true;
            panel3.Visible = false;
            label6.Text = "0";
            label6.Text = "0";
            sum2 = 0;
            sum1 = 0;
            textBox1.Text = "";
            time = 60;
            for (int g = 0; g < 100; g++) { p[g] = "0"; }
            if (flag == true) { richTextBox4.LoadFile("score.txt", RichTextBoxStreamType.PlainText); }
            else { richTextBox4.LoadFile("score2.txt", RichTextBoxStreamType.PlainText); }

            int i = 0;

            foreach (string s in richTextBox4.Lines)
            {
                string[] tmp = s.Split(' ');

                if (tmp[0] != "")
                {
                    p[i] = tmp[0];
                    on[i] = tmp[1];
                }
                i++;
            }

            for (int write = 0; write < p.Length; write++)
            {
                for (int sort = 0; sort < p.Length - 1; sort++)
                {
                    int par1 = Int32.Parse(p[sort]);
                    int par2 = Int32.Parse(p[sort + 1]);
                    if (par1 > par2)
                    {
                        temp1 = p[sort + 1];
                        p[sort + 1] = p[sort];
                        p[sort] = temp1;
                        temp2 = on[sort + 1];
                        on[sort + 1] = on[sort];
                        on[sort] = temp2;
                    }
                }
            }

           

         
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pause == false)
            {
                gun.controls.stop();
                gun.URL = "gun.mp3";
                gun.controls.play();
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

            if ((pause == false) && (sum2 > 0))
            {
                sum2 -= 5;
            }
            label6.Text = sum2.ToString();
            sum2 -= 5;

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox3_MouseHover_1(object sender, EventArgs e)
        {
            if ((pause == false)&&(sum2>0))
            {
                sum2 -= 5;
            }
            label6.Text = sum2.ToString();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            
                if (pause == false)
                {
                    sum1 += 10;
                }
                label6.Text = sum1.ToString();
                gun.controls.stop();
                gun.URL = "gun.mp3";
                gun.controls.play();
            

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            {
                if (pause == false)
                {
                    sum2 += 10;
                }
                label6.Text = sum2.ToString();
                gun.controls.stop();
                gun.URL = "gun.mp3";
                gun.controls.play();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            button1.Visible = false;
            panel1.Visible = true;
            panel4.Visible = false;
            label6.Text = "0";
            sum2 = 0;
            sum1 = 0;
            textBox1.Text = "";
            time = 60;
            for (int g = 0; g < 100; g++) { p[g] = "0"; }
            if (flag == true) { richTextBox4.LoadFile("score.txt", RichTextBoxStreamType.PlainText); }
            else { richTextBox4.LoadFile("score2.txt", RichTextBoxStreamType.PlainText); }
            
            int i = 0;

            foreach (string s in richTextBox4.Lines)
            {
                string[] tmp = s.Split(' ');

                if (tmp[0] != "")
                {
                    p[i] = tmp[0];
                    on[i] = tmp[1];
                }
                i++;
            }


            for (int write = 0; write < p.Length; write++)
            {
                for (int sort = 0; sort < p.Length - 1; sort++)
                {
                    int par1 = Int32.Parse(p[sort]);
                    int par2 = Int32.Parse(p[sort + 1]);
                    if (par1 > par2)
                    {
                        temp1 = p[sort + 1];
                        p[sort + 1] = p[sort];
                        p[sort] = temp1;
                        temp2 = on[sort + 1];
                        on[sort + 1] = on[sort];
                        on[sort] = temp2;
                    }
                }
            }

            for (int j = 0; j < 100; j++)
            {
                richTextBox3.Text = p[j] + " " + on[j] + "\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        { if (pause == false) { 
            sum2 += 10; }
           label6.Text = sum2.ToString();
            gun.controls.stop();
            gun.URL = "gun.mp3";
            gun.controls.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkCyan;
            flag = false;
            if (textBox1.Text != "") { 
           button1.Visible = true; }
            Image myimage = new Bitmap("sea.jpg");
            this.BackgroundImage = myimage;
            label6.ForeColor = Color.DarkCyan;
            label3.ForeColor = Color.DarkCyan;
            button5.ForeColor = Color.DarkCyan;
            label5.ForeColor = Color.DarkCyan;
            label4.ForeColor = Color.DarkCyan;
            label8.ForeColor = Color.DarkCyan;
            label7.ForeColor = Color.DarkCyan;
        }
    }
}
