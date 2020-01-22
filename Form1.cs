using cs_classlib_messagebox;
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
        /// <summary>
        /// share this type of component with child form(s)
        /// </summary>        
        public object ListBox { get; internal set; }

        public Form1()
        {
            InitializeComponent();

            this.Text = "C# Messing";
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ;

            rtb.Clear();
            rtb.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            // to force scrolling to end of added text, use the TextChanged() method

            // clear the listbox
            lb.Items.Clear();
            // clear the combobox
            cb.Items.Clear();

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

        #region RichTextBox Events
        /// <summary>
        /// RichTextBox keyboard handling
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">keyboard events</param>
        private void rtb_KeyDown(object sender, KeyEventArgs e)
        {
            // trap Ctrl-A but don't select all text
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                rtb.Text += ">>> trapped Ctrl-A";

                e.Handled = true;
            }

            // if Ctrl-Alt-A pressed then select all text
            if (e.Control && e.Alt && e.KeyCode.ToString() == "A")
            {
                rtb.Text += ">>> Ctrl-Alt-A trapped";
                rtb.SelectAll();
                e.Handled = true;
            }
        }

        /// <summary>
        /// ensure RichTextBox scrolls down automatically
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">events</param>
        private void rtb_TextChanged(object sender, EventArgs e)
        {
            rtb.SelectionStart = rtb.Text.Length;
            // scroll it automatically
            rtb.ScrollToCaret();
        }
        #endregion

        /// <summary>
        /// When form tries to close always ask for user confirmation using custom positionable messagebox
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">close events</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = cmbForm.Show("Do you really want to quit?", "Exit", "Yes", "No", Form1.ActiveForm);

            e.Cancel = res == DialogResult.No;
        }

        private void bAddToListBox_Click(object sender, EventArgs e)
        {
            Form2 listTool = new Form2();

            // need to show this modally, remembering to pass this Form
            listTool.ShowDialog(this);
        }
    }
}
