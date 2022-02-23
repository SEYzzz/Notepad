using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            fontDialog1.ShowColor = true;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Сохранить изменения?", "Выход", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
                return;
            else if(result == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                сохранитьToolStripMenuItem_Click(sender, e);
                this.Close();
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            richTextBox1.Text = Convert.ToString(System.IO.File.ReadAllText(filename));
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rslt = printDialog1.ShowDialog();
            if (rslt == DialogResult.Cancel)
                return;
            else
            {

            }
        }

        //сохранение файлов в разных кодировках
        private void uTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text, encoding: Encoding.UTF32);
        }
        private void aSCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text, encoding: Encoding.ASCII);
        }
        private void uTF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text, encoding: Encoding.UTF7);
        }

        //открытие файлов в разных кодировках
        private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            richTextBox1.Text = Convert.ToString(System.IO.File.ReadAllText(filename, encoding: Encoding.UTF32));
        }
        private void uTF7ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            richTextBox1.Text = Convert.ToString(System.IO.File.ReadAllText(filename, Encoding.UTF7));
        }
        private void aSCIIToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            richTextBox1.Text = Convert.ToString(System.IO.File.ReadAllText(filename, Encoding.ASCII));
        }

        //правка
        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.SelectedText.Equals(null))
            {
                richTextBox1.Cut();
            }
        }
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.SelectedText.Equals(null))
            {
                richTextBox1.Copy();
            }
        }
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                richTextBox1.Paste();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad by Liza", "О программе");
        }

        //шрифт
        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.SelectionColor = fontDialog1.Color;
        }
    }
}
