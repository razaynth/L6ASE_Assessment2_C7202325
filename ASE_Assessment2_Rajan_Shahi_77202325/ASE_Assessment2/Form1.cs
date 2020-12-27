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
namespace ASE_Assessment2
{
    /// <summary>
    /// Main class for Form
    /// </summary>
    public partial class Form1 : Form
    {
        public Graphics g;
        Canvass NewCanvass;

        const int bitmap1 = 640;
        const int bitmap2 = 480;
        public Bitmap ShowBitmap = new Bitmap(bitmap1, bitmap2);
        /// <summary>
        /// To create a Form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            NewCanvass = new Canvass(Graphics.FromImage(ShowBitmap));
        }

       
        /// <summary>
        /// When enter key is pressed, it will excute some action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Key Event Arguments</param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String command = CommandLine.Text.Trim().ToLower();
                String multicmd = InputWindow.Text.Trim().ToLower();
                cmdReader cmd = new cmdReader();
                cmd.Cmd(command, multicmd, NewCanvass);
            }

        }
        /// <summary>
        /// To runs the application when  button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Event Arguements</param>
        private void RUN_Click(object sender, EventArgs e)
        {
            String command = CommandLine.Text.Trim().ToLower();
            String multicmd = InputWindow.Text.Trim().ToLower();
            cmdReader cmd = new cmdReader();
            cmd.Cmd(command, multicmd, NewCanvass);
            Refresh();
        }

        private void RESET_Click(object sender, EventArgs e)
        {

            // for reset button setup
            NewCanvass.Xpos = 0;
            NewCanvass.Ypos = 0;
        }
        /// <summary>
        /// Displaying window depending on the user given data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Paint Event Arguements</param>
        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImageUnscaled(ShowBitmap, 0, 0);
        }
        

         private void CLEAR_Click(object sender, EventArgs e)
        {
            InputWindow.Clear();
            CommandLine.Text = string.Empty;
        }
        /// <summary>
        /// To save any file in the file directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Event Arguements</param>

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (.txt)| *.txt";
            saveFileDialog.Title = "Save File...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fWriter = new StreamWriter(saveFileDialog.FileName);
                fWriter.Write(InputWindow.Text);
                fWriter.Close();
            }
            InputWindow.Text += "Command Save";
        }
        
        /// <summary>
        /// To loads any file from the file directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Event Arguements</param>
           private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "Text File (.txt)|*.txt";
            loadFileDialog.Title = "Open File...";

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader streamReader = new System.IO.StreamReader(loadFileDialog.FileName);
                InputWindow.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }
    }
}
