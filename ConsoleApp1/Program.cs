using System.Diagnostics.Metrics;

double Annuity;
double frequencyOfDepositsR;
double annualInterestRate;
double Time;
double Compounded;
bool isRunning = true;
while (isRunning)
{
    Console.Write("Annuity -> ");
    Annuity = double.Parse(Console.ReadLine());
    Console.Write("DepositAmount -> ");
    frequencyOfDepositsR = double.Parse(Console.ReadLine());
    Console.Write("Annual Interest Rate -> ");
    annualInterestRate = double.Parse(Console.ReadLine());
    Console.Write("Amount of years -> ");
    Time = double.Parse(Console.ReadLine());
    Console.Write("Compunded annually(1), quarterly(4), monthly(12) -> ");
    Compounded = double.Parse(Console.ReadLine());

    if (Annuity == 0)
    {
        double part1 = 1 + (annualInterestRate / Compounded);
        part1 = Math.Pow(part1, (Time * Compounded));
        part1 = part1 - 1;
        part1 = part1 / (annualInterestRate / Compounded);
        part1 = part1 * frequencyOfDepositsR;
        Console.WriteLine("**************************************");
        Console.WriteLine($"The exponent was -> " + (Time * Compounded));
        Console.WriteLine($"Answer is -> " + part1);
    }
    else
    {
        double part1 = 1 + (annualInterestRate / Compounded);
        part1 = Math.Pow(part1, (Time * Compounded));
        part1 = part1 - 1;
        part1 = part1 / (annualInterestRate / Compounded);
        Console.WriteLine("**************************************");
        Console.WriteLine($"Divided {Annuity} by {part1}");
        part1 = Annuity / part1;
        Console.WriteLine($"The exponent was -> " + (Time * Compounded));
        Console.WriteLine($"Answer is -> " + part1);
    }
    Console.WriteLine("**************************************");
    Console.WriteLine("Do you want to continue? no to exit");
    string askToContinue = Console.ReadLine();
    if(askToContinue.ToLower() == "no")
    {
        isRunning = false;
    }
}
