using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC_project1
{
	
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			txtInput.Text = "num $a = 10, $y;\ndisplay < $a;\n{\nnum $x = 7;\ndisplay < $x;\n$y = 50;\n}\ndisplay < $y;";
			txtInput.Text = "num $a = 10;\r\nnum $b = 5;\r\nis($a > $b){\r\n    display < 'a is greater';\r\n}\r\nelis($a == $b){\r\n    display < 'a is equal to b';\r\n}\r\nel{\r\n    display < 'a is less';\r\n}";
			txtInput.Text = "num $a = 2;\r\nnum $b = 5;\r\nis($a > $b){\r\n    display < 'a is greater';\r\n}\r\nelis($a < $b){\r\n    display < 'a is less';\r\n}\r\nel{\r\n    display < 'a is equal to b';\r\n}";
		}

		string[] input;
		int i = 0;
		#region Regex
		//initialization
		Regex ILine = new Regex(@"^[\$][a-zA-Z][a-zA-Z0-9]*[' ']*=[' ']*[0-9][0-9]*[.]*[0-9][0-9]*;$");

		//Regex ILine = new Regex(@"\$+\w*\s*=\s*\d+(\.\d+)?;$");

		//--- INT
		// declaration multiple
		Regex IntdMLine = new Regex(@"^num [\$]+[a-zA-Z][a-zA-Z0-9]*[,][\s*][\$+][a-zA-Z][a-zA-Z0-9]*[' ']*[,' 'a-zA-Z0-9']*;$");
		//Regex IntdMLine = new Regex(@"^num\s*\$+\w*\d*\s*?,\$+\w*\d*\s*?;$");
		// declaration
		Regex IntdLine = new Regex(@"^num [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*;$");
		// initialization can also assign any in variable e.g a=b
		Regex IntILine = new Regex(@"^\$+\w*\d*\s*?=[' ']*\$+[a-zA-Z0-9]+;$");
		// initialization and declaration
		Regex IntIdLine = new Regex(@"^num [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[' ']*[0-9][0-9]*;$");
		//1 initilization and declaration and 1 initialization only
		Regex IntIdMLine = new Regex(@"^num [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[' ']*[0-9][0-9]*[,][\s*][\$+][a-zA-Z][a-zA-Z0-9]*[' ']*[,' 'a-zA-Z0-9']*;$");

		//--- FLOAT
		// declaration
		Regex FloatdLine = new Regex(@"^flo [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*;$");
		// declaration multiple
		Regex FloatdMLine = new Regex(@"^flo [\$]+[a-zA-Z][a-zA-Z0-9]*[,][a-zA-Z][a-zA-Z0-9]*[' ']*[,' 'a-zA-Z0-9']*;$");
		// initialization and declaration
		Regex FloatIdLine = new Regex(@"^flo [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[' ']*[0-9][0-9]*;$");


		//--- CHARACTER
		//declaration
		Regex ChrdLine = new Regex(@"^chr [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*;$");
		// initialiazation
		Regex ChrILine = new Regex(@"^[\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[ ']+.*[ ']+;$");
		// initialization
		Regex ChrIdLine = new Regex(@"^chr [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[ ']+.*[ ']+;$");

		//--- STRING
		//declaration
		Regex StrdLine = new Regex(@"^str [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*;$");
		// initialization
		Regex StrILine = new Regex(@"^[\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[ '""]+.*['""]+;$");
		// declaration and initialization
		Regex StrIdLine = new Regex(@"^str [\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[ '""]+.*['""]+;$");

		//--- OUT
		//"print string"
		Regex CoutSLine = new Regex(@"^display < \'[a-zA-Z0-9' '\=]*\';$");
		//Regex CoutSLine = new Regex(@"^out < '(.*?)';$");
		//"print variable"
		Regex CoutVLine = new Regex(@"^display < \$+[a-zA-Z0-9' ']*;$");
		//"print with variable"
		Regex CoutCLine = new Regex(@"^display < \'[a-zA-Z0-9' '\=]*\'[\s*][\+][\s*][\$+][a-zA-Z][a-zA-Z0-9]*;$");

		Regex InLine = new Regex(@"^in > [\$+][a-zA-Z][a-zA-Z0-9]*;$");

		//For arithmetic Expresion
		//Only for Constant
		//Regex AILine = new Regex(@"^[\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[' ']*[0-9][0-9]*[-+*/][0-9][0-9]*[0-9' '\\-+*/' '0-9]*;$");
		Regex AILine = new Regex(@"^[\$]+[a-zA-Z][a-zA-Z0-9]*\s*=\s*[0-9]+[-+*/][0-9]+[0-9\s\-+*/\s0-9]*;$");
		//for Constant and variables
		Regex MAILine = new Regex(@"^[\$]+[a-zA-Z][a-zA-Z0-9]*[' ']*=[' ']*[a-zA-Z0-9][a-zA-Z0-9]*[-+*/][a-zA-Z0-9][a-zA-Z0-9]*[a-zA-Z0-9' '\-+*/ ' 'a-zA-Z0-9]*;$");

		//For display Expresion
		Regex DisplayExpression = new Regex(@"^display < (.+?)\s*;$");
		//For variable Inilization with expression
		//Regex MALine = new Regex(@"^([\$][a-zA-Z][a-zA-Z0-9])\s=\s*([$a-zA-Z0-9\s\+\-\*/]+);$");
		// for @a =@a + 3;
		Regex MALine = new Regex(@"^\$+[a-zA-Z][a-zA-Z0-9]*\s*=\s*\$?[a-zA-Z0-9]+\s*[-+/]\s*[0-9]+;$");
		//For Conditional Logic
		private Regex IfCondition = new Regex(@"^is\((.+?)\)\s*\{");
		private Regex ElseIfCondition = new Regex(@"^elis\((.+?)\)\s*\{");
		private Regex ElseCondition = new Regex(@"^el\s*\{");
		private Regex BlockEnd = new Regex(@"^\}");


		//For Switch Case
		Regex optionPattern = new Regex(@"option\((?<val>.+?)\)\s*\{");
		Regex optPattern = new Regex(@"opt\s+(?<case>.+?):");
		Regex defaultPattern = new Regex(@"def:");

		#endregion


		List<SymbolTable> symbolTable = new List<SymbolTable>();
		List<ScopeSymbolTable> ScopeSymbolTable = new List<ScopeSymbolTable>();
		bool build = true;
		bool conditionSatisfied = false;

		public void Validate(string line, string scope)
		{

			string[] words = line.Split(' ');
			#region Forint
			if (words[0] == "num")
			{
				//for declaration
				if (IntdLine.IsMatch(line))
				{
					//txtOutput.AppendText("<" + words[0] + ">" + "\n");
					//txtOutput.AppendText("<" + words[1].Trim(new Char[] { ';' }) + ">" + "\n");
					SymbolTable st = new SymbolTable();
					st.name = words[1].Trim(new Char[] { ';' });
					st.datatype = words[0];
					st.Value = "0";
					//symbolTable.Add(st);
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Add(st);
				}
				//for Multiple declaration
				else if (IntdMLine.IsMatch(line))
				{
					foreach (var w in words)
					{
						txtOutput.AppendText("<" + w.Trim(new Char[] { ';', ',' }) + ">" + "\n");
					}
				}
				//for intialization

				//for intialization and declaration
				else if (IntIdLine.IsMatch(line))
				{
					//string[] Iwords = words[2].Split('=');
					//txtOutput.AppendText("<" + words[0] + ">" + "\n");
					//txtOutput.AppendText("<" + words[1] + ">" + "\n");
					//txtOutput.AppendText("<" + words[2] + ">" + "\n");
					//txtOutput.AppendText("<" + words[3].Trim(new Char[] { ';' }) + ">" + "\n");
					////txtOutput.AppendText(Iwords[1].Trim(new Char[] { ';' }) + "\n");

					//data.Add(words[1], words[3].Trim(new Char[] { ';' }));
					//txtOutput.AppendText(Iwords[1].Trim(new Char[] { ';' }) + "\n");

					string[] Iwords = words[1].Split('=');
					SymbolTable st = new SymbolTable();
					st.name = Iwords[0];
					st.datatype = words[0];
					st.Value = words[3].Trim(new Char[] { ';', '=' });
					//symbolTable.Add(st);
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Add(st);

				}
				else if (IntIdMLine.IsMatch(line))
				{
					//string[] dwords = words[2].Split(',');
					//string[] Iwords = dwords[0].Split('=');
					//txtOutput.AppendText("<" + words[0] + ">" + "\n");
					//txtOutput.AppendText("<" + words[1] + ">" + "\n");
					//txtOutput.AppendText("<" + words[2] + ">" + "\n");
					//txtOutput.AppendText("<" + words[3].Trim(new Char[] { ';' }) + ">" + "\n");
					//data.Add(words[1], words[3].Trim(new char[] { ',' }));
					//data.Add(words[4], "");

					string[] Iwords = words[1].Split('=');
					SymbolTable st1 = new SymbolTable();
					st1.name = Iwords[0];
					st1.datatype = words[0];
					st1.Value = words[3].Trim(new Char[] { ',', '=' });
					//symbolTable.Add(st1);
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Add(st1);

					SymbolTable st2 = new SymbolTable();
					st2.name = words[4].Trim(new Char[] { ';' });
					st2.datatype = words[0];
					st2.Value = "0";
					//symbolTable.Add(st2);
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Add(st2);
				}
				else
				{
					txtError.Text += $"Error at Line: {line}";
					txtOutput.Text = "Build Failed";
				}
			}
			else if (IntILine.IsMatch(line))
			{
				string[] Iwords = words[1].Split('=');
				//txtOutput.AppendText("<" + words[0] + ">" + "\n");
				//txtOutput.AppendText("<" + words[1] + ">" + "\n");
				//txtOutput.AppendText("<" + words[2].Trim(new Char[] { ';' }) + ">" + "\n");
				//txtOutput.AppendText(Iwords[1].Trim(new Char[] { ';' }) + "\n");
				var v1 = ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(s => s.name == words[2].Trim(new Char[] { ';' })).First();
				var v2 = ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(s => s.name == words[0]).First();
				if (v1 != null)
				{
					v2.Value = v1.Value;
				}
			}

			else if (AILine.IsMatch(line))
			{	string[] Iwords = line.Split('=');
				foreach (var sy in ScopeSymbolTable)
				{
					var ans = Evaluate(Iwords[1].Trim(new Char[] { ';' }), sy.SymbolTable);
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(x => x.name == Iwords[0].Trim()).FirstOrDefault().Value = ans.ToString();
				}
			}
			else if (MAILine.IsMatch(line)){
				string[] Iwords = line.Split('=');
				foreach (var sy in ScopeSymbolTable)
				{
					var ans = Evaluate(Iwords[1].Trim(new Char[] { ';' }), sy.SymbolTable);
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(x => x.name == Iwords[0].Trim()).FirstOrDefault().Value = ans.ToString();
				}
			}
			#endregion

			#region Forfloat
			else if (words[0] == "flo")
			{
				//for declaration
				if (FloatdLine.IsMatch(line))
				{
					//txtOutput.AppendText("<" + words[0] + ">" + "\n");
					//txtOutput.AppendText("<" + words[1].Trim(new Char[] { ';' }) + ">" + "\n");

					SymbolTable st = new SymbolTable();
					st.name = words[1].Trim(new Char[] { ';' });
					st.datatype = words[0];
					st.Value = "0.0";
					//symbolTable.Add(st);
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Add(st);
				}
				//for Multiple declaration
				else if (FloatdMLine.IsMatch(line))
				{
					txtOutput.AppendText("<" + words[0] + ">" + "\n");
					foreach (var w in words[1].Split(','))
					{
						string[] Iwords = w.Split('=');
						txtOutput.AppendText("<" + Iwords[0].Trim(new Char[] { ';' }) + ">" + "\n");
					}
				}

				//for intialization and declaration
				else if (FloatIdLine.IsMatch(line))
				{
					//string[] Iwords = words[1].Split('=');
					//txtOutput.AppendText("<" + words[0] + ">" + "\n");
					//txtOutput.AppendText("<" + Iwords[0] + ">" + "\n");
					//txtOutput.AppendText("<=>" + "\n");
					//txtOutput.AppendText("<" + Iwords[1].Trim(new Char[] { ';' }) + ">" + "\n");

					string[] Iwords = words[1].Split('=');
					SymbolTable st = new SymbolTable();
					st.name = Iwords[0];
					st.datatype = words[0];
					st.Value = Iwords[1].Trim(new Char[] { ';' });
					//symbolTable.Add(st);
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Add(st);
				}
				else
				{
					txtError.Text += $"Error at Line: {line}";
					txtOutput.Text = "Build Failed";
					build = false;
				}
			}
			#endregion
			#region Forchr
			if (words[0] == "chr")
			{
				if (ChrdLine.IsMatch(line))
				{
					txtOutput.AppendText("<" + words[0] + ">" + "\n");
					txtOutput.AppendText("<" + words[1].Trim(new Char[] { ';' }) + ">" + "\n");
				}
				else if (ChrIdLine.IsMatch(line))
				{
					txtOutput.AppendText("<" + words[0] + ">" + "\n");
					txtOutput.AppendText("<" + words[1] + ">" + "\n");
					txtOutput.AppendText("<" + words[2] + ">" + "\n");
					txtOutput.AppendText("<" + words[3].Trim(new Char[] { ';' }) + ">" + "\n");
				}
			}

			else if (ChrILine.IsMatch(line) && words[2].Trim(new Char[] { ';', '\'' }).Length == 1)
			{
				txtOutput.AppendText("<" + words[0] + ">" + "\n");
				txtOutput.AppendText("<" + words[1] + ">" + "\n");
				txtOutput.AppendText("<" + words[2].Trim(new Char[] { ';' }) + ">" + "\n");
			}
			#endregion
			#region Forstring
			if (words[0] == "str")
			{
				if (StrdLine.IsMatch(line))
				{
					txtOutput.AppendText("<" + words[0] + ">" + "\n");
					txtOutput.AppendText("<" + words[1].Trim(new Char[] { ';' }) + ">" + "\n");
				}
				else if (StrIdLine.IsMatch(line))
				{
					txtOutput.AppendText("<" + words[0] + ">" + "\n");
					txtOutput.AppendText("<" + words[1] + ">" + "\n");
					txtOutput.AppendText("<" + words[2] + ">" + "\n");
					txtOutput.AppendText("<" + words[3].Trim(new Char[] { ';' }) + ">" + "\n");
				}
			}
			if (StrILine.IsMatch(line))
			{
				txtOutput.AppendText("<" + words[0] + ">" + "\n");
				txtOutput.AppendText("<" + words[1] + ">" + "\n");
				txtOutput.AppendText("<" + words[2].Trim(new Char[] { ';' }) + ">" + "\n");
			}
			#endregion
			#region Fordoub
			if (words[0] == "doub")
			{
				if (IntdLine.IsMatch(line))
				{
					txtOutput.AppendText("<" + words[0] + ">" + "\n");
					txtOutput.AppendText("<" + words[1].Trim(new Char[] { ';' }) + ">" + "\n");
				}
			}
			#endregion
			else if (ILine.IsMatch(line))
			{
				//string[] Iwords = line.Split('=');
				//txtOutput.AppendText("<" + Iwords[0] + ">" + "\n");
				//txtOutput.AppendText("<=>" + "\n");
				//txtOutput.AppendText("<" + Iwords[1].Trim(new Char[] { ';' }) + ">" + "\n");

				string[] Iwords = line.Split('=');
				//var a = ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(x => x.name == Iwords[0]).FirstOrDefault().Value = Iwords[1].Trim(new Char[] { ';' });
				// symbolTable.Add(new Tuple<string, string, string>(Iwords[0], words[0], Iwords[1].Trim(new Char[] { ';' })));

				if (ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(x => x.name == Iwords[0]).FirstOrDefault() != null)
				{
					ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(x => x.name ==
					Iwords[0].Trim()).FirstOrDefault().Value = Iwords[1].Trim(new Char[] { ';' });
				}
				else
				{
					var sy = ScopeSymbolTable.Where(x => x.Scope == "Global").FirstOrDefault();
					var xy = sy.SymbolTable.Where(x => x.name == Iwords[0].Trim()).FirstOrDefault();
					xy.Value = Iwords[1].Trim(new Char[] { ';' });
				}
			}

			//for dublicate variable
			//checkDuplicate(line);
			else if (InLine.IsMatch(line))
			{
				//string[] Iwords = words[1].Split('=');
				//txtOutput.AppendText("<" + words[0] + ">" + "\n");
				//txtOutput.AppendText("<" + words[1] + ">" + "\n");
				//txtOutput.AppendText("<" + words[2].Trim(new Char[] { ';' }) + ">" + "\n");
				//txtOutput.AppendText(Iwords[1].Trim(new Char[] { ';' }) + "\n");
				var v1 = ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(s => s.name == words[2].Trim(new Char[] { ';' })).FirstOrDefault();
				Take_input inp = new Take_input();
				if (v1.datatype != null)
				{
					inp.ShowDialog();
					v1.Value = Take_input.value;
				}
			}
			if (CoutSLine.IsMatch(line))
			{
				string[] coutwords = line.Split('\'');
				//txtOutput.AppendText("<" + coutwords[0] + ">" + "\n");
				//txtOutput.AppendText("<" + coutwords[1] + ">" + "\n");
				txtOutput.AppendText( coutwords[1] + "\n");
			}
			else if (CoutVLine.IsMatch(line))
			{
				//string[] coutwords = line.Split(' ');
				//txtOutput.AppendText("<" + coutwords[0] + ">" + "\n");
				//txtOutput.AppendText("<" + coutwords[2].Trim(new Char[] { ';' }) + ">" + "\n");

				//var v1 = ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(s => s.name == coutwords[2].Trim(new Char[] { ';' })).FirstOrDefault();
				//txtOutput.AppendText(coutwords[2].Trim(new char[] { '\'' }) + v1.Value);


				string[] coutwords = line.Split('<');
				bool Isstring = true;
				foreach (var c in coutwords[1].Trim(new Char[] { ';',' ' }))
				{
					Isstring = Char.IsLetter(c);
				}
				if (Isstring)
				{
					if (ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(x => x.name ==
					coutwords[1].Trim(new Char[] { ';' ,' '})).FirstOrDefault() != null)
					{
						txtOutput.AppendText(ScopeSymbolTable.Where(x => x.Scope ==
						scope).FirstOrDefault().SymbolTable.Where(x => x.name == coutwords[1].Trim(new Char[] { ';', ' ' })).FirstOrDefault().Value + "\r\n");
					}
					else if (ScopeSymbolTable.Where(x => x.Scope == "Global").FirstOrDefault().SymbolTable.Where(x => x.name
					== coutwords[1].Trim(new Char[] { ';', ' ' })).FirstOrDefault() != null)
					{
						txtOutput.AppendText(ScopeSymbolTable.Where(x => x.Scope ==
						"Global").FirstOrDefault().SymbolTable.Where(x => x.name == coutwords[1].Trim(new Char[] { ';', ' ' })).FirstOrDefault().Value + "\r\n");
					}
					else{
							build = false;
					} 
				}
				else
				{ 
					txtOutput.AppendText(coutwords[1].Trim(new Char[] { ';', ' ' }) + "\r\n");
				}
			}
			else if (CoutCLine.IsMatch(line))
			{
				//string[] coutwords = line.Split(' ');
				//txtOutput.AppendText("<" + coutwords[0] + ">" + "\n");
				//txtOutput.AppendText("<" + coutwords[2] + ">" + "\n");
				//txtOutput.AppendText("<" + coutwords[3] + ">" + "\n");
				//txtOutput.AppendText("<" + coutwords[4].Trim(new Char[] { ';' }) + ">" + "\n");

				//var v1 = ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault().SymbolTable.Where(s => s.name == coutwords[coutwords.Length - 1].Trim(new Char[] { ';' })).FirstOrDefault();
				//txtOutput.AppendText(coutwords[2].Trim(new char[] { '\'' }) + v1.Value);

				string[] coutwords = line.Split('\'');
				if (ScopeSymbolTable.Where(x => x.Scope == scope).FirstOrDefault() != null)
				{
					txtOutput.AppendText(coutwords[1] + ScopeSymbolTable.Where(x => x.Scope ==
					scope).FirstOrDefault().SymbolTable.Where(x => x.name == coutwords[2].Trim(new Char[] { ';', '+', ' ' })).FirstOrDefault().Value + "\r\n");
					}
			}

			// For If Condition
			if (IfCondition.IsMatch(line))
			{
				string condition = IfCondition.Match(line).Groups[1].Value;
				Queue<string> blockLines = ExtractBlock(input, ref i); // Extract block lines for the condition

				ValidateConditionalBlock(condition, scope, blockLines);
				return;
			}

			if (!conditionSatisfied)
			{
				// For Else If Condition
				if (ElseIfCondition.IsMatch(line))
				{
					string condition = ElseIfCondition.Match(line).Groups[1].Value;
					Queue<string> blockLines = ExtractBlock(input, ref i); // Extract block lines for the condition
					ValidateConditionalBlock(condition, scope, blockLines);
					return;
				}
			}

			if (!conditionSatisfied)
			{
				// For Else Condition
				if (ElseCondition.IsMatch(line))
				{
					Queue<string> blockLines = ExtractBlock(input, ref i); // Extract block lines for the else block
					ValidateElseBlock(scope, blockLines);
					return;
				}
			}


			// For Block End
			if (BlockEnd.IsMatch(line))
			{
				// Handle block closure
				return;
			}

			// For 'option' (switch statement)
			else if (line.StartsWith("option"))
			{
				string[] lines = txtInput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
				int currentLine = Array.IndexOf(lines, line); // Find the starting line
				ParseSwitch(lines, ref currentLine, scope);
			}

			else if (MALine.IsMatch(line))
			{
				// Logic for handling assignment expressions
				Match match = Regex.Match(line, @"^($[a-zA-Z][a-zA-Z0-9])\s=\s*([$a-zA-Z0-9\s\+\-\*/]+);$");
				string leftVar = match.Groups[1].Value; // Full variable name (e.g., @a)
				string rightExpression = match.Groups[2].Value; // Expression on the right-hand side

				// Find the correct scope and symbol table
				ScopeSymbolTable currentScope = ScopeSymbolTable
					.Where(x => x.Scope == scope)
					.FirstOrDefault();

				if (currentScope != null)
				{
					// Find the left-hand variable in the symbol table
					SymbolTable leftSymbol = currentScope.SymbolTable
						.Find(sym => sym.name == leftVar);

					if (leftSymbol != null)
					{
						// Resolve the right-hand expression
						string resolvedExpression = ResolveExpression(rightExpression, currentScope.SymbolTable);
						//string sendexp = leftSymbol.name+ "=" + resolvedExpression;

						// Remove all spaces from the expression
						string exp = resolvedExpression.Replace(" ", string.Empty);
						// Evaluate the resolved expression
						double result = Evaluate(exp, currentScope.SymbolTable);

						// Update the variable value in the symbol table
						leftSymbol.Value = result.ToString();
						Console.WriteLine($"Updated {leftVar} to {result}");
					}
				}
				else
				{
					Console.WriteLine($"Scope {scope} not found.");
				}
			}

			//For Display Expression
			else if (DisplayExpression.IsMatch(line))
			{
				string expression = DisplayExpression.Match(line).Groups[1].Value;
				foreach (var scopeTable in ScopeSymbolTable)
				{
					if (scopeTable.Scope == scope)
					{
						string result = Helperfunctions.ParseDisplayExpression(expression, scopeTable.SymbolTable);
						txtOutput.AppendText($"{result}\n");
						return;
					}
				}
				//txtError.Text += $"Scope not found for expression: {expression}\n";
			}

			//else
			//{
			//	txtError.Text += $"Unknown syntax: {line}\n";
			//}

		}


		private void button1_Click(object sender, EventArgs e)
		{
			build = true;
			string[] Input = txtInput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			input = Input;

			txtOutput.Text = "";
			txtError.Text = "";
			txtScope.Text = "";
			int Sn = 0;
			ScopeSymbolTable = new List<ScopeSymbolTable>();
			ScopeSymbolTable GlobalSymbolTable = new ScopeSymbolTable
			{
				Scope = "Global",
				SymbolTable = new List<SymbolTable>()
			};
			ScopeSymbolTable.Add(GlobalSymbolTable);


			for (i=0; i < Input.Length; i++)
			{
				if (Input[i] != "{")
				{
					Validate(Input[i], "Global");
					if (build == false)
					{
						txtOutput.Text = "Build Failed ";
						break;
					}
				}
				if (Input[i] == "{")
				{
					Sn++;
					ScopeSymbolTable SymbolTable = new ScopeSymbolTable();
					SymbolTable.Scope = "Scope" + Sn;
					SymbolTable.SymbolTable = new List<SymbolTable>();
					ScopeSymbolTable.Add(SymbolTable);
					i++;
					while (Input[i] != "}")
					{
						Validate(Input[i], "Scope" + Sn);
						if (build == false)
						{
							txtOutput.Text ="Build Failed ";
							break;
						}
						i++;
					}
				}
			}

			#region ShowTable
			if (build)
			{
				foreach (var sy in ScopeSymbolTable)
				{
					txtScope.AppendText("     "+sy.Scope + "\n");
					foreach (var row in sy.SymbolTable)
					{
						txtScope.AppendText(row.datatype + "\t" + row.name + "\t" + row.Value + "\n");
					}
				}

				//foreach (var row in symbolTable)
				//{
				//	txtScope.AppendText(row.datatype + "\t" + row.name + "\t" + row.Value + "\n");
				//}
			}
			#endregion
		 }

	//	public double Evaluate(string input, List<SymbolTable> symbolTable)
	//	{
	//		// Precedence map for operators
	//		var precedence = new Dictionary<string, int>
	//{
	//	{ "+", 1 },
	//	{ "-", 1 },
	//	{ "*", 2 },
	//	{ "/", 2 },
	//	{ "sqrt", 3 }
	//};

	//		Stack<string> ops = new Stack<string>();
	//		Stack<double> vals = new Stack<double>();

	//		string expr = "(" + input.Trim() + ")";

	//		for (int i = 0; i < expr.Length; i++)
	//		{
	//			string s = expr.Substring(i, 1);

	//			if (string.IsNullOrWhiteSpace(s))
	//				continue;

	//			if (s.Equals("("))
	//			{
	//				ops.Push(s);
	//			}
	//			else if (s.Equals(")"))
	//			{
	//				while (ops.Peek() != "(")
	//				{
	//					EvaluateTopOperation(ops, vals);
	//				}
	//				ops.Pop();
	//			}
	//			else if (precedence.ContainsKey(s))
	//			{
	//				while (ops.Count > 0 && ops.Peek() != "(" && precedence[ops.Peek()] >= precedence[s])
	//				{
	//					EvaluateTopOperation(ops, vals);
	//				}
	//				ops.Push(s);
	//			}
	//			else
	//			{
	//				string operand = s;
	//				while (i + 1 < expr.Length && char.IsLetterOrDigit(expr[i + 1]))
	//				{
	//					operand += expr[++i];
	//				}

	//				if (double.TryParse(operand, out double value))
	//				{
	//					vals.Push(value);
	//				}
	//				else
	//				{
	//					var symbol = symbolTable.FirstOrDefault(x => x.name == operand);
	//					if (symbol != null)
	//					{
	//						vals.Push(Double.Parse(symbol.Value)); // Use double-typed Value
	//					}
	//					else
	//					{
	//						throw new ArgumentException($"Unknown symbol: {operand}");
	//					}
	//				}
	//			}
	//		}

	//		while (ops.Count > 0)
	//		{
	//			EvaluateTopOperation(ops, vals);
	//		}

	//		return vals.Pop();
	//	}

	//	private void EvaluateTopOperation(Stack<string> ops, Stack<double> vals)
	//	{
	//		string op = ops.Pop();
	//		double v = vals.Pop();

	//		switch (op)
	//		{
	//			case "+":
	//				v = vals.Pop() + v;
	//				break;
	//			case "-":
	//				v = vals.Pop() - v;
	//				break;
	//			case "*":
	//				v = vals.Pop() * v;
	//				break;
	//			case "/":
	//				v = vals.Pop() / v;
	//				break;
	//			case "sqrt":
	//				v = Math.Sqrt(v);
	//				break;
	//			default:
	//				throw new ArgumentException($"Unsupported operator: {op}");
	//		}

	//		vals.Push(v);
	//	}

		//Check Duplicate Variable
		void checkDuplicate(string line)
		{
			string[] output = txtOutput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			List<string> result = new List<string>();
			for (int i = 0; i <= output.Length - 1; i++)
			{

				for (int j = i; j <= output.Length - 1; j++)
				{
					if (j != i && output[i] == output[j])
					{
						result.Add($"Duplicate Variable at: {output[j]}\n");
					}
				}
			}
			if (result.Count > 0)
			{
				txtError.Text += $"Error at Line: {line}\n";
				result.Add("Build Failed");
			}
			else
			{
				//result.Add("Build Succeed");
			}

			foreach (var res in result)
			{
				txtOutput.AppendText(res);
			}
		}

		// Extract a block of lines enclosed in curly braces
		private Queue<string> ExtractBlock(string[] inputLines, ref int currentIndex)
		{
			Queue<string> blockLines = new Queue<string>();
			currentIndex++; // Move to the first line inside the block

			int blockDepth = 1; // Track nested block depth
			while (currentIndex < inputLines.Length && blockDepth > 0)
			{
				string line = inputLines[currentIndex].Trim();

				if (line == "{")
				{
					blockDepth++; // Entering a nested block
				}
				else if (line == "}")
				{
					blockDepth--; // Exiting a block
					return blockLines;
				}

				if (blockDepth > 0)
				{
					blockLines.Enqueue(line);
				}

				currentIndex++;
			}

			return blockLines;
		}
		// Validate and execute a conditional block
		private void ValidateConditionalBlock(string condition, string scope, Queue<string> blockLines)
		{
			foreach (var scopeTable in ScopeSymbolTable)
			{
				if (scopeTable.Scope == scope)
				{
					bool conditionResult = Helperfunctions.EvaluateCondition(condition, scopeTable.SymbolTable);
					if (conditionResult)
					{
						conditionSatisfied = conditionResult;
						ExecuteBlock(scopeTable.SymbolTable, blockLines);
					}
					return;
				}
			}
			txtError.Text += $"Scope not found for condition: {condition}\n";
		}

		// Validate and execute an else block
		private void ValidateElseBlock(string scope, Queue<string> blockLines)
		{
			foreach (var scopeTable in ScopeSymbolTable)
			{
				if (scopeTable.Scope == scope)
				{
					ExecuteBlock(scopeTable.SymbolTable, blockLines);
					return;
				}
			}
			txtError.Text += $"Scope not found for else block.\n";
		}

		public void ExecuteBlock(List<SymbolTable> symbolTable, Queue<string> blockLines)
		{
			while (blockLines.Count > 0)
			{
				string line = blockLines.Dequeue();

				// Handle nested blocks
				if (line == "{")
				{
					// Create a new symbol table for the nested block
					ScopeSymbolTable nestedScope = new ScopeSymbolTable
					{
						Scope = "Nested",
						SymbolTable = new List<SymbolTable>()
					};

					ScopeSymbolTable.Add(nestedScope);

					// Recursively execute nested block
					ExecuteBlock(nestedScope.SymbolTable, blockLines);
				}
				else if (line == "}")
				{
					// End of current block
					return;
				}
				else
				{
					// Validate and execute line in the current block
					Validate(line, "Nested");
				}
			}
		}

		//For Switch Case
		public void ExecuteSwitch(string switchValue, Dictionary<string, Queue<string>> cases, Queue<string> defaultCase, string scope)
		{
			double evaluatedValue = Helperfunctions.EvaluateExpression(switchValue, symbolTable);
			string evaluatedValue_str = Convert.ToString(evaluatedValue);

			if (cases.ContainsKey(evaluatedValue_str))
			{
				ExecuteBlock(symbolTable, cases[evaluatedValue_str]);
			}
			else if (defaultCase.Count > 0)
			{
				ExecuteBlock(symbolTable, defaultCase);
			}
			else
			{
				//txtOutput.AppendText($"No matching case and no default case for value: {evaluatedValue}\n");
			}
		}

		public void ParseSwitch(string[] lines, ref int currentLine, string scope)
		{
			string switchValue = null;
			Dictionary<string, Queue<string>> cases = new Dictionary<string, Queue<string>>();
			Queue<string> defaultCase = new Queue<string>();

			while (currentLine < lines.Length)
			{
				string line = lines[currentLine].Trim();

				if (line.StartsWith("option"))
				{
					var match = Regex.Match(line, @"option\((?<val>.+?)\)");
					if (match.Success)
					{
						switchValue = match.Groups["val"].Value;
					}
					else
					{
						//txtError.Text += $"Invalid option syntax at line {currentLine + 1}.\n";
						return;
					}
				}
				else if (line.StartsWith("opt"))
				{
					var match = Regex.Match(line, @"opt\s+(?<case>\d+):");
					if (match.Success)
					{
						string caseValue = match.Groups["case"].Value;
						currentLine++;
						Queue<string> caseBlock = Helperfunctions.ParseBlock(lines, ref currentLine);
						if (!cases.ContainsKey(caseValue))
						{
							cases.Add(caseValue, caseBlock);
						}
						else
						{
							//txtError.Text += $"Duplicate case value '{caseValue}' at line {currentLine + 1}.\n";
						}
					}
					else
					{
						//txtError.Text += $"Invalid case syntax at line {currentLine + 1}.\n";
					}
				}
				else if (line.StartsWith("def:"))
				{
					currentLine++;
					defaultCase = Helperfunctions.ParseBlock(lines, ref currentLine);
				}
				else if (line == "}")
				{
					break; // End of switch block
				}
				else
				{
					currentLine++;
				}
			}

			if (switchValue == null)
			{
				//txtError.Text += $"Switch value missing in option block.\n";
				return;
			}

			ExecuteSwitch(switchValue, cases, defaultCase, scope);
		}

		static string ResolveExpression(string expression, List<SymbolTable> symbolTable)
		{
			// Split the expression into tokens
			var tokens = expression.Split(new char[] { ' ', '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var token in tokens)
			{
				// Check if the token is a variable (starts with @)
				if (token.StartsWith("$"))
				{
					SymbolTable variable = symbolTable.FirstOrDefault(sym => sym.name == token);

					if (variable != null && !string.IsNullOrEmpty(variable.Value))
					{
						// Replace the variable with its value
						expression = expression.Replace(token, variable.Value);
					}
					else
					{
						throw new Exception($"Variable {token} not found or has no value.");
					}
				}
			}

			return expression;
		}

		public double Evaluate(string input, List<SymbolTable> symbolTable)
		{
			int r;
			string expr = "(" + input.Trim() + ")";
			Stack<string> ops = new Stack<string>();
			Stack<double> vals = new Stack<double>();

			for (int i = 0; i < expr.Length; i++)
			{
				string s = expr.Substring(i, 1);

				if (s.Equals("("))
				{
					// Do nothing, just skip the opening parenthesis
				}
				else if (s.Equals("+") || s.Equals("-") || s.Equals("*") || s.Equals("/"))
				{
					ops.Push(s); // Push the operator to the stack
				}
				else if (s.Equals(")"))
				{
					// Evaluate the expression when encountering closing parenthesis
					while (ops.Count > 0)
					{
						string op = ops.Pop();
						double v = vals.Pop();

						if (op.Equals("+"))
							v = vals.Pop() + v;
						else if (op.Equals("-"))
							v = vals.Pop() - v;
						else if (op.Equals("*"))
							v = vals.Pop() * v;
						else if (op.Equals("/"))
							v = vals.Pop() / v;

						vals.Push(v);
					}
				}
				else
				{
					// This part handles both variables and numbers
					string token = s;

					// Check if the token is a number (not a single character, but a full number like 11)
					while (i + 1 < expr.Length && Char.IsDigit(expr[i + 1]))
					{
						i++;
						token += expr[i]; // Append the next character to form a full number
					}

					// If it's a variable, look up its value in the symbol table
					if (Char.IsDigit(token[0]))
					{
						vals.Push(Double.Parse(token)); // Push the numeric value
					}
					else
					{
						// For variables, retrieve their value from the symbol table
						SymbolTable variable = symbolTable.FirstOrDefault(sym => sym.name == token);
						if (variable != null)
						{
							vals.Push(Double.Parse(variable.Value)); // Push the value of the variable
						}
						else
						{
							throw new Exception($"Variable {token} not found in symbol table.");
						}
					}
				}
			}

			return vals.Pop(); // Return the final result
		}
	}
}

