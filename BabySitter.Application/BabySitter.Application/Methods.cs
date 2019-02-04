using System;
using System.Linq;

namespace BabySitter.Application
{
    public class Methods
    {
        public static bool Verifyfamily(string family)
        {
            string[] families = new string[] { "A", "B", "C" };

            if (!families.Contains(family.ToUpper()))
            {
                Console.WriteLine("This family is not listed as an approved family for which you can babysit!");
                return false;
            }
            else
            {
                Console.WriteLine("OK, Lets enter the hours worked for Family (" + family.ToUpper() + ")!");
                return true;
            }

        }
        public static bool VerifyStartTime(string startTime)
        {
            DateTime st;
            if (DateTime.TryParse(startTime, out st))
            {
                DateTime time5PM = new DateTime(st.Year, st.Month, st.Day, 17, 0, 0);
                bool lateShift = (st >= time5PM) ? true : false;

                DateTime adjustMinStartTime = st.AddDays(lateShift ? 0 : 1);
                DateTime adjustMaxStartTime = st.AddDays(lateShift ? 1 : 0);

                DateTime minStartTime = new DateTime(adjustMinStartTime.Year, adjustMinStartTime.Month, adjustMinStartTime.Day, 17, 0, 0);
                DateTime maxStartTime = new DateTime(adjustMaxStartTime.Year, adjustMaxStartTime.Month, adjustMaxStartTime.Day, 4, 0, 0);

                if ((minStartTime <= st) || (maxStartTime >= st))
                {
                    Console.WriteLine("Is this the correct start time for your shift? -> " + st);
                    Console.WriteLine("Please enter Yes(Y) or No(N):");
                    return true;
                }
                else
                {
                    Console.WriteLine("You are not allowed to start your shift before 5PM.");
                }
            }
            else
            {
                Console.WriteLine("Unable to verify your shift start time.");
            }
            return false;
        }

        public static bool VerifyEndTime(string startTime, string endTime)
        {
            DateTime et;
            DateTime st = Convert.ToDateTime(startTime);
            DateTime time5PM = new DateTime(st.Year, st.Month, st.Day, 17, 0, 0);

            bool lateShift = (st >= time5PM) ? true : false;

            if (DateTime.TryParse(endTime, out et))
            {
                if (st < et && st.AddHours(12) > et)
                {
                    DateTime adjustMinStartTime = st.AddDays(lateShift ? 0 : 1);
                    DateTime adjustMaxStartTime = st.AddDays(lateShift ? 1 : 0);

                    DateTime minEndTime = new DateTime(adjustMinStartTime.Year, adjustMinStartTime.Month, adjustMinStartTime.Day, 17, 0, 0);
                    DateTime maxEndTime = new DateTime(adjustMaxStartTime.Year, adjustMaxStartTime.Month, adjustMaxStartTime.Day, 4, 0, 0);


                    if ((minEndTime <= et) || (maxEndTime >= et))
                    {
                        Console.WriteLine("Is this the correct end time for your shift? -> " + et);
                        Console.WriteLine("Please enter Yes(Y) or No(N):");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("You can not end your shift after 4PM.");
                    }

                }
                else
                {
                    Console.WriteLine("End Time can not be before the Start Time or more than 12 hours after the Start Time.");
                }
            }
            else
            {
                Console.WriteLine("Unable to verify your shift End Time.");
            }
            return false;
        }

        public static int TotalPay(string startTime, string endTime, string family)
        {
            bool Lateshift = false;
            int pay = 0;
            family = family.ToUpper();
            DateTime st = Convert.ToDateTime(startTime);
            DateTime et = Convert.ToDateTime(endTime);

            //Timespoints for pay change
            DateTime time5PM = new DateTime(st.Year, st.Month, st.Day, 17, 0, 0);
            DateTime time9PM = new DateTime(st.Year, st.Month, st.Day, 21, 0, 0);
            DateTime time10PM = new DateTime(st.Year, st.Month, st.Day, 22, 0, 0);
            DateTime time11PM = new DateTime(st.Year, st.Month, st.Day, 23, 0, 0);
            DateTime time12PM = new DateTime(st.Year, st.Month, st.Day + 1, 0, 0, 0);

            if (st >= time5PM)
            {
                Lateshift = true;
            }

            while (et != st)
            {
                st = st.AddHours(1);
                switch (family)
                {
                    case "A":
                        {
                            if (Lateshift)
                            {
                                if (st <= time11PM)
                                {
                                    pay += 15;
                                }
                                else
                                {
                                    pay += 20;
                                }

                            }
                            else
                            {
                                pay += 20;
                            }
                            break;
                        }
                    case "B":
                        {
                            if (Lateshift)
                            {
                                if (st <= time10PM)
                                {
                                    pay += 12;
                                }
                                else if (st <= time12PM)
                                {
                                    pay += 8;
                                }
                                else
                                {
                                    pay += 16;
                                }
                            }
                            else
                            {
                                pay += 16;
                            }
                            break;
                        }
                    case "C":
                        {
                            if (Lateshift)
                            {
                                if (st <= time9PM)
                                {
                                    pay += 21;
                                }
                                else
                                {
                                    pay += 15;
                                }

                            }
                            else
                            {
                                pay += 15;
                            }

                            break;
                        }
                }

            }

            return pay;
        }

    }

    public static class Extentions
    {
        public static bool ToBool(this string anwser)
        {
            return ((anwser.ToUpper() == "Y" || anwser.ToUpper() == "Yes") ? true : false);
        }
    }
}

