using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cd_WinForms_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "C# Messing";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            rtb.Clear();
            rtb.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            // to force scrolling to end of added text, use the TextChanged() method
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.FileName = string.Empty;
            ofd.Title = "Open Text File";
            //ofd.Filter = "*.txt|(*.txt)|*.*|(*.*)";
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            ofd.FilterIndex = 0;

            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            // display contents of the file in the text box
            if (ofd.CheckFileExists == false)
                rtb.Text += "*** Specified file doesn't exist";
            else
                rtb.Text += File.ReadAllText(ofd.FileName);
        }

        private void bClearRTB_Click(object sender, EventArgs e)
        {
            rtb.Clear();
        }

        private void rtb_KeyDown(object sender, KeyEventArgs e)
        {
            // trap Ctrl-A but don't select all text
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                rtb.Text += ">>> trapped Ctrl-A";

                e.Handled = true;
            }

            // if Ctrl-Alt-A pressed then select all text
            if( e.Control && e.Alt && e.KeyCode.ToString() == "A")
            {
                rtb.Text += ">>> Ctrl-Alt-A trapped";
                rtb.SelectAll();
                e.Handled = true;
            }
        }

        private void rtb_TextChanged(object sender, EventArgs e)
        {
            rtb.SelectionStart = rtb.Text.Length;
            // scroll it automatically
            rtb.ScrollToCaret();
        }
    }
}
