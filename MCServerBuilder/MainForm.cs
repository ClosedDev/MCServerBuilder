using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCServerBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            int ii = 0;
            List<String> values = new List<String>(new String[] { "1", "2", "3" });
            foreach (Object i in values)
            {
                ii++;   
                Button serverButton = new Button();
                this.Controls.Add(serverButton);

                serverButton.Name = ii.ToString();
                serverButton.Location = new Point(200 + (ii * 50), 100);
                serverButton.Text = ii.ToString();
                serverButton.Size = new Size(50, 50);
                serverButton.Visible = true;
                serverButton.Click += new System.EventHandler(onClickServerButton);
            }
        }

        private void onClickServerButton(object sender, EventArgs e)
        {
            Button serverButton = (Button) sender;
            MessageBox.Show(serverButton.Name, "Test",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("종료하시겠습니까?", "Exit",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}