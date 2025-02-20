using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CC_project1
{
	public partial class Project : Form
	{
		public Project()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ProcessAndExecuteCode(richTextBox1.Text, richTextBox2);
		}

		public static void ProcessAndExecuteCode(string inputCode, RichTextBox txt)
		{
			// Parse input lines into a list
			Queue<string> lines = new Queue<string>(inputCode.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));

			// Variables for processing
			Dictionary<string, int> variables = new Dictionary<string, int>();
			StringBuilder output = new StringBuilder();

			while (lines.Count > 0)
			{
				string line = lines.Dequeue().Trim();

				if (line.StartsWith("num"))
				{
					// Variable declaration and initialization
					string[] parts = line.Substring(3).Split(new[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
					foreach (string part in parts)
					{
						string[] varAndValue = part.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						string varName = varAndValue[0].Trim();
						int value = varAndValue.Length > 1 ? int.Parse(varAndValue[1].Trim()) : 0;

						variables[varName] = value;
					}
				}
				else if (line.StartsWith("when"))
				{
					// Process a while loop
					string condition = line.Substring(5).Trim('(', ')');
					while (EvaluateCondition(condition, variables))
					{
						ProcessBlock(lines, variables, output);
					}
				}
				else
				{
					// Unexpected input
					throw new InvalidOperationException("Unrecognized statement: " + line);
				}
			}

			// Display the output in the TextBox
			txt.Text = output.ToString();
		}

		private static bool EvaluateCondition(string condition, Dictionary<string, int> variables)
		{
			// Replace variables in the condition with their values and evaluate
			foreach (var variable in variables)
			{
				condition = condition.Replace("$" + variable.Key, variable.Value.ToString());
			}

			return (bool)new System.Data.DataTable().Compute(condition, "");
		}

		private static void ProcessBlock(Queue<string> lines, Dictionary<string, int> variables, StringBuilder output)
		{
			while (lines.Count > 0)
			{
				string line = lines.Dequeue().Trim();

				if (line == "}")
				{
					break; // End of block
				}

				if (line.StartsWith("in >"))
				{
					// Input variable
					string varName = line.Substring(4).Trim('$', ';');
					variables[varName] = 1; // Simulating user input with a value (you can customize this)
				}
				else if (line.Contains("="))
				{
					// Assignment operation
					string[] parts = line.Split(new[] { '=' }, 2);
					string varName = parts[0].Trim('$', ' ');
					string expression = parts[1].Trim(';');

					foreach (var variable in variables)
					{
						expression = expression.Replace("$" + variable.Key, variable.Value.ToString());
					}

					variables[varName] = (int)new System.Data.DataTable().Compute(expression, "");
				}
				else if (line.StartsWith("is"))
				{
					// If condition
					string condition = line.Substring(3).Trim('(', ')');
					if (EvaluateCondition(condition, variables))
					{
						ProcessBlock(lines, variables, output);
					}
					else
					{
						SkipBlock(lines);
					}
				}
				else if (line.StartsWith("el"))
				{
					// Else block
					ProcessBlock(lines, variables, output);
				}
				else if (line.StartsWith("display <"))
				{
					// Display operation
					string displayText = line.Substring(9).Trim(';', ' ', '\'');
					foreach (var variable in variables)
					{
						displayText = displayText.Replace("$" + variable.Key, variable.Value.ToString());
					}

					output.AppendLine(displayText);
				}
			}
		}

		private static void SkipBlock(Queue<string> lines)
		{
			int openBraces = 1;

			while (lines.Count > 0 && openBraces > 0)
			{
				string line = lines.Dequeue().Trim();

				if (line == "{")
				{
					openBraces++;
				}
				else if (line == "}")
				{
					openBraces--;
				}
			}
		}

		private void richTextBox2_TextChanged(object sender, EventArgs e)
		{

		}
	}

}
