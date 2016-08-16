using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smasher
{
    public partial class Form1 : Form
    {
        
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            Random random = new Random();
            //Adding random keys to listBox
            listBox1.Items.Add((Keys)random.Next(65,90));
            if (listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game over!");
                timer1.Stop();
                MessageBox.Show("Press OK to try again");
                difficultyProgressBar.Value = 0;
                listBox1.Items.Clear();
                timer1.Start();
                
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                if(timer1.Interval > 400)
                {
                    timer1.Interval -= 10;
                }
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;
                difficultyProgressBar.Maximum = 900;
                difficultyProgressBar.Minimum = 0;
                difficultyProgressBar.Value = 800 - timer1.Interval;
                stats.Update(true);

            }
            else
            {
                stats.Update(false);

            }

            correctLabel.Text = "Correct: " + stats.correct;
            missedLabel.Text = "Missed: " + stats.missed;
            accuracyLabel.Text = "Accuracy: " + stats.accuracy + "%";
            tatalLabel.Text = "Total: " + stats.total;
        }
    }
}
