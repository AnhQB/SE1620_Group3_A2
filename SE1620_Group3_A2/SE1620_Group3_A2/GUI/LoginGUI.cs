using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace SE1620_Group3_A2.GUI
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void bthLogin_Click(object sender, EventArgs e)
        {
            string name, pass;
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            name = conf["User:Name"];
            pass = conf["User:Password"];

            string namel = txtName.Text;
            string passl = txtPass.Text;
            //if (namel.Equals(name) && passl.Equals(pass))
            //{
            //    MessageBox.Show("You are logged in as administrator");
            //}
            //else
            //{
            //    MessageBox.Show("Don't have that user ");
            //}

            MessageBox.Show($"Don't {name}: {namel} + {pass}: {passl}");


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
