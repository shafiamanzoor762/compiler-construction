using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CC_project1
{


	public class Helperfunctions
	{

		// Method to Evaluate Expressions
		public static double EvaluateExpression(string expression, List<SymbolTable> symbolTable)
		{
			foreach (var symbol in symbolTable)
			{
				expression = expression.Replace(symbol.name, symbol.Value);
			}
			// Use DataTable for basic arithmetic evaluation
			try
			{
				var result = new System.Data.DataTable().Compute(expression, null);
				return Convert.ToDouble(result);
			}
			catch
			{
				Console.WriteLine($"Invalid Expression: {expression}");
				return 0;
			}
		}

		// Method to Parse and Evaluate Display
		public static string ParseDisplayExpression(string expression, List<SymbolTable> symbolTable)
		{
			var parts = expression.Split(new[] { '<' }, StringSplitOptions.RemoveEmptyEntries);
			string result = string.Empty;

			foreach (var part in parts)
			{
				string trimmedPart = part.Trim();
				if (trimmedPart.StartsWith("\"") && trimmedPart.EndsWith("\""))
				{
					// Handle string literals
					result += trimmedPart.Trim('"') + " ";
				}
				else
				{
					// Handle expressions
					double value = EvaluateExpression(trimmedPart, symbolTable);
					result += value + " ";
				}
			}

			return result.Trim();
		}

		// Method to Evaluate Conditions
		//public static bool EvaluateCondition(string condition, List<SymbolTable> symbolTable)
		//{
		//	foreach (var symbol in symbolTable)
		//	{
		//		condition = condition.Replace(symbol.name, symbol.Value);
		//	}
		//	try
		//	{
		//		var result = new System.Data.DataTable().Compute(condition, null);
		//		return Convert.ToBoolean(result);
		//	}
		//	catch
		//	{
		//		//txtError.Text += $"Invalid Condition: {condition}\n";
		//		return false;
		//	}
		//}

		public static bool EvaluateCondition(string condition, List<SymbolTable> symbolTable)
		{
			// Replace logical operators with DataTable.Compute-compatible operators
			condition = condition.Replace("&&", "AND")
								 .Replace("||", "OR")
								 .Replace("==", "=")
								 .Replace("!=", "<>")
								 .Replace("true", "1")
								 .Replace("false", "0");

			// Replace symbols with their values
			foreach (var symbol in symbolTable)
			{
				condition = condition.Replace(symbol.name, symbol.Value);
			}

			try
			{
				// Evaluate the condition
				var result = new System.Data.DataTable().Compute(condition, null);

				// Return the boolean result
				return Convert.ToBoolean(result);
			}
			catch (Exception ex)
			{
				// Log or handle invalid conditions
				Console.WriteLine($"Invalid Condition: {condition}. Error: {ex.Message}");
				return false;
			}
		}


		//===========FOR SWITCH STATMENT=============
		public static Queue<string> ParseBlock(string[] lines, ref int currentLine)
		{
			Queue<string> blockLines = new Queue<string>();

			while (currentLine < lines.Length)
			{
				string line = lines[currentLine].Trim();

				if (line == "{" || line == "}")
				{
					currentLine++;
					continue;
				}

				blockLines.Enqueue(line);
				currentLine++;

				if (line == "}")
				{
					break;
				}
			}

			return blockLines;
		}

	}

}
