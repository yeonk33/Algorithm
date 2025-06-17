using System;
using System.Collections.Generic;

int Precedence(char op)
{
	return op switch
	{
		'*' or '/' => 2,
		'+' or '-' => 1,
		_ => 0
	};
}

string input = Console.ReadLine();
Stack<char> stack = new Stack<char>();
string output = "";

foreach (char token in input) {
	if (char.IsLetter(token)) // 피연산자
	{
		output += token;
	} else if (token == '(') {
		stack.Push(token);
	} else if (token == ')') {
		while (stack.Count > 0 && stack.Peek() != '(')
			output += stack.Pop();
		if (stack.Count > 0 && stack.Peek() == '(')
			stack.Pop(); // '(' 제거
	} else // 연산자
	  {
		while (stack.Count > 0 && Precedence(stack.Peek()) >= Precedence(token)) {
			if (stack.Peek() == '(') break;
			output += stack.Pop();
		}
		stack.Push(token);
	}
}

while (stack.Count > 0)
	output += stack.Pop();

Console.WriteLine(output);
