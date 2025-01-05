using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC_project1
{
	public partial class Take_input : Form
	{
		public Take_input()
		{
			InitializeComponent();
		}

		public static string value = "0";
		private void button1_Click(object sender, EventArgs e)
		{
			value = textBox1.Text;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			this.Close();
		}
	}
}
