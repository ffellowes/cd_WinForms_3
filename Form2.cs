using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cd_WinForms_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        /// <summary>
        /// Add the new items to the listbox on the main form
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">events</param>
        private void button3_Click(object sender, EventArgs e)
        {
            //
            if (richTextBox1.Text.Length == 0)
                Close();

            var lines = richTextBox1.Text.Split('\n').ToList();


            // with ListBox components set to Internal in Form1.cs
            ListBox lbp = ((Form1)this.Owner).lb;
            // same for ComboBox
            ComboBox cbp = ((Form1)this.Owner).cb;

            // see this as well about owner and child
            // https://stackoverflow.com/questions/3419159/how-to-get-all-child-controls-of-a-windows-forms-form-of-a-specific-type-button
            foreach (var el in lines)
            {
                lbp.Items.Add(el.ToString());
                cbp.Items.Add(el.ToString());
            }
            

            Close();
        }

        /// <summary>
        /// Just return without updating the listbox
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">events</param>
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Add a new item to the listbox
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">events</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                if (richTextBox1.Lines.Length > 0)
                    richTextBox1.AppendText("\n");

                richTextBox1.AppendText(textBox1.Text);

                textBox1.Clear();

                // put the focus back here
                textBox1.Focus();
            }
        }
    }
}
