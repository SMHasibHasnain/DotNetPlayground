bool isNum1InputValid = double.TryParse(Console.ReadLine(), out double num1);
bool isOperatorInputValid = char.TryParse(Console.ReadLine(), out char opt);
bool isNum2InputValid = double.TryParse(Console.ReadLine(), out double num2);

Dictionary<char, Func<double, double, double>> pairs = new Dictionary<char, Func<double, double, double>>();

pairs['+'] = (num1, num2) =>
{
    return num1 + num2;
};

pairs['-'] = (num1, num2) =>
{
    return num1 - num2;
};

pairs['*'] = (num1, num2) =>
{
    return num1 * num2;
};

pairs['/'] = (num1, num2) =>
{
    return num1 / num2;
};

var operation = pairs[opt];

var result = operation(num1, num2);

Action<double> print = (result) =>
{
    System.Console.WriteLine($"{num1} {opt} {num2} = {result}");
};

print(result);