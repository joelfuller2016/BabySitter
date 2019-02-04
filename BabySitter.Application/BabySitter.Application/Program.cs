using System;

namespace BabySitter.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string startTime = "";
            string endTime = "";
            string family = "";
            bool continueStartTime = false;
            bool continueEndTime = false;
            bool continueFamily = false;
            bool StartProgram = true;

            while (StartProgram)
            {
                startTime = "";
                endTime = "";
                family = "";
                continueStartTime = false;
                continueEndTime = false;
                continueFamily = false;
                StartProgram = true;
                Console.Clear();
                Console.WriteLine("Hello, Babysitter!");
                Console.WriteLine("Lets Calculate your fee for your hours worked.");

                while (!continueFamily)
                {
                    Console.WriteLine("Please Select the Family for which you babysat.");
                    Console.WriteLine("Please select Family (A) , (B) or (C).");
                    family = Console.ReadLine();
                    continueFamily = Methods.Verifyfamily(family);
                }
                while (!continueStartTime)
                {

                    Console.WriteLine("Please enter the Date you Started your shift (MM/DD/YYYY):");
                    var startDay = Console.ReadLine();
                    Console.WriteLine("Please enter the Time you Started your shift.");
                    Console.WriteLine("Please round to the nearest Hour (include AM or PM):");
                    startTime = Console.ReadLine();
                    startTime = startDay + " " + startTime;

                    if (Methods.VerifyStartTime(startTime)) {
                        continueStartTime = Console.ReadLine().ToBool();
                    }
                    
                }

                while (!continueEndTime)
                {

                    Console.WriteLine("Please enter the Date you Ended your shift (MM/DD/YYYY):");
                    var EndDay = Console.ReadLine();
                    Console.WriteLine("Please enter the Time you Ended your shift.");
                    Console.WriteLine("Please round to the nearest Hour (include AM or PM):");
                    endTime = Console.ReadLine();
                    endTime = EndDay + " " + endTime;

                    if (Methods.VerifyEndTime(startTime, endTime))
                    {
                        continueEndTime = Console.ReadLine().ToBool();
                    }
                }

                Console.WriteLine("Your Total Pay is: $" + Methods.TotalPay(startTime, endTime, family));
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Do you want to calculate pay for another shift?");
                Console.WriteLine("Please enter Yes(Y) or No(N):");
                StartProgram = Console.ReadLine().ToBool();
            }


        }
    }
}
