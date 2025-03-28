using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PraktikaIND2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "numbers.txt";
                if (File.Exists(filePath))
                {
                    var numbers = File.ReadAllLines(filePath)
                                      .Select(line => int.Parse(line));
                    var positiveNumbers = numbers.Where(n => n >= 0);
                    var negativeNumbers = numbers.Where(n => n < 0);
                    var result = positiveNumbers.Concat(negativeNumbers);
                    textBox1.Text=(string.Join(" ", result));
                }
                else
                {
                    MessageBox.Show("Файл не найден или его нет");
                }
            }
            catch
            {
                MessageBox.Show("Неверный ввод");
            }
        }
    }
}
