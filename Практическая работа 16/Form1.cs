﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_работа_16
{
    public partial class Form1 : Form
    {
        int veter, vector, schetchik;        
        Rectangle r1, r2;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)//если нажата стрелка влево
                vector = -12;//вектор смещения влево
            if (e.KeyData == Keys.Right)//если нажата стрелка вправо
                vector = 12;//вектор смещения вправо
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int skorost_padenia = 5;//скорость падения семки вниз
            //перемещение по X с учетом ветра и вектора управления
            pictureBox3.Left = pictureBox3.Left + veter + vector;
            //Перемещение по Y
            pictureBox3.Top = pictureBox3.Top + skorost_padenia;
            schetchik++;//Увеличиваем значение
            if (schetchik > 10)
                schetchik = 0;
            //Если семка скрылся за форму
            if (pictureBox3.Top >= pictureBox1.Height)
            {
                timer1.Enabled = false;
                MessageBox.Show("Проигрыш");
            }
            r1 = pictureBox3.DisplayRectangle; r2 = pictureBox2.DisplayRectangle;
            r1.Location = pictureBox3.Location; r2.Location = pictureBox2.Location;
            //если попал на голубя
            if (r1.IntersectsWith(r2)==true)
            {
                timer1.Enabled = false;
                MessageBox.Show("Вы накормили голубя!");
            }
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random r = new Random();//рандом
            //задаем расположение объекта semka по координате Х от 100 д 200
            pictureBox3.Left = r.Next(50, 400);
            //задаем расположения объекта semka по координате y
            pictureBox3.Top = -120;
            timer1.Enabled = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            vector = 0;//перестает управлять шаром
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 639;
            this.Height = 479;
            this.MaximizeBox = false;//офф кнопка развёртывая
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            pictureBox3.Height = 60;//высота семки
            pictureBox3.Width = 80;//ширина семки         
            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            Random r = new Random();//рандом
            //задаем расположение объекта semka по координате Х от 100 д 200
            pictureBox3.Left = r.Next(50, 400);
            //задаем расположения объекта semka по координате y
            pictureBox3.Top = -120;
            veter = r.Next(8);//задаем силу ветра
            vector = 0;//обнуляем скорость смешения
            schetchik = 1;//счетчик для отображения картинок
        }
    }
}
