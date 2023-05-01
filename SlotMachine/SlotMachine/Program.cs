using SlotMachine.Interfaces;
using SlotMachine.Services;

namespace SlotMachine
{
    public class Program
    {
        private const string asterisk = "*";
        public static void Main()
        {
            decimal initialAmount;
            decimal totalAmount;

            Console.Write("Enter your initial amount: ");
            while (!decimal.TryParse(Console.ReadLine(), out initialAmount)
                || initialAmount <= 0)
            {
                Console.Write("Invalid input, please enter a valid amount: ");
            }

            totalAmount = initialAmount;

            string[] slotOptions = { "A", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "B", "B", "P", "P", "P", asterisk };

            Dictionary<string, double> coefficients = new Dictionary<string, double>
            {
                { "A", 0.4},
                { "B", 0.6},
                { "P", 0.8},
                { asterisk, 0},
            };

            Random random = new Random();

            byte spinCount = 4;
            decimal betAmount;
            ISlotMachineService slotMachineService = new SlotMachineService();
            while (totalAmount > 0)
            {
                Console.Write("Please the amount you wish to bet: ");
                while (!decimal.TryParse(Console.ReadLine(), out betAmount)
                    || betAmount < 0
                    || betAmount > totalAmount
                    || totalAmount <= 0)
                {
                    Console.Write("Invalid input, please enter a valid amount: ");
                }

                totalAmount -= betAmount;
                for (int i = 0; i < spinCount; i++)
                {
                    int firstIndex = random.Next(slotOptions.Length);
                    int secondIndex = random.Next(slotOptions.Length);
                    int thirdIndex = random.Next(slotOptions.Length);

                    if (slotMachineService.CheckForWinningLine(slotOptions[firstIndex], slotOptions[secondIndex], slotOptions[thirdIndex]))
                    {
                        decimal totalCoefficient = (decimal)coefficients[slotOptions[firstIndex]]
                            + (decimal)coefficients[slotOptions[secondIndex]]
                            + (decimal)coefficients[slotOptions[thirdIndex]];
                        decimal amountWon = decimal.Round(totalCoefficient * betAmount, 2);
                        totalAmount += amountWon;
                    }
                }

                Console.WriteLine($"Your current balance is: {totalAmount}");
            }

            Console.WriteLine($"You won: {(totalAmount - initialAmount > 0 ? totalAmount - initialAmount : 0)}");
            Console.WriteLine($"Your current balance is: {totalAmount}");
        }
    }
}