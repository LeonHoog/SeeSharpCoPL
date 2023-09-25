Console.Write("Please enter an untyped lambda function: ");

string input = string.Empty;

// Read input until an empty line is entered
string? _input;
while (!string.IsNullOrEmpty(_input = Console.ReadLine()))
    input += _input += "\n";
input = input.TrimEnd('\n');