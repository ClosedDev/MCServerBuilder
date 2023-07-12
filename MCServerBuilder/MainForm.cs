using Newtonsoft.Json.Linq;
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

namespace MCServerBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(Program.datafolder))
            {
                Directory.CreateDirectory(Program.datafolder);
            }

            createServerButtons();
        }

        private void createServerButtons()
        {
            string path = Program.datafolder + "\\servers.json";

            try
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "{}");
                }

                StreamReader sr = new StreamReader(path);
                string json = sr.ReadToEnd();
                sr.Close();

                JObject jsonObj = JObject.Parse(json);

                if (jsonObj["servers"] == null)
                {
                    MessageBox.Show("text");
                    JArray tmp_array = new JArray();
                    jsonObj["servers"] = tmp_array;
                    File.WriteAllText(path, jsonObj.ToString());
                    tmp_array = null;
                }

                JArray array = (JArray) jsonObj["servers"];

                int i = 0;
                foreach (JObject obj in array)
                {
                    Button bt = new Button();
                    bt.Name = i.ToString();
                    bt.Location = new Point(200 + (i * 100), 100);
                    bt.Text = (string)obj["name"];
                    bt.Size = new Size(100, 50);
                    bt.Visible = true;
                    bt.Click += onClick;
                    Controls.Add(bt);
                    i++;
                }


            } catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void onClick(object sender, EventArgs e)
        {
            string path = Program.datafolder + "\\servers.json";
            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();
            sr.Close();
            JObject jsonObj = JObject.Parse(json);
            JArray array = (JArray)jsonObj["servers"];
            

            Button btn = (Button) sender;
            int server = int.Parse(btn.Name);

            JObject jobj = (JObject)array[server];

            if (!Directory.Exists((string)jobj["dir"]))
            {
                MessageBox.Show("서버를 찾을 수 없습니다: " + (string)jobj["dir"], "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift)
            {
                DialogResult result = MessageBox.Show("종료하시겠습니까?", "Exit",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}