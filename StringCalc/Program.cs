using StringCalc;

Computer comp = new();

while (true)
{
    Console.WriteLine("Enter the expression:");
    Console.Write(">>> ");
    string input = Console.ReadLine();
    Console.WriteLine(comp.Calc(input));

}