using System;

namespace Inlämningsuppgift1
{

    class Program
    {
        //Member variables
        private static int[] currencies = new int[7] { 500, 100, 50, 20, 10, 5, 1 };    //An array containing the currencies in a decreasing order
        private static string[] nameOfValuesPlur = new string[7] { "femhundralappar", "hundralappar", "femtiolappar", "tjugolappar", "tiokronor", "femkronor", "enkronor" };     //Names for the currencies in plural
        private static string[] nameOfValuesSing = new string[7] { "femhundralapp", "hundralapp", "femtiolapp", "tjugolapp", "tiokrona", "femkrona", "enkrona" };          //Names for the currencies in singular
        


        static void Main(string[] args)                            //The main function
        {
            procedure();                                           //A call to the procedure function
        }

        private static int askPrice()
        {
            Console.WriteLine("Ange pris: ");
            String strPrice = Console.ReadLine();                   //Asking for the price
            int price;                                              //max size for price is 2^31 -1
            try
            {                                                   //Testing that the user actually gives some amount of money
                price = Int32.Parse(strPrice);                      //Converting the input string to an int
            }
            catch (Exception e)
            {
                Console.WriteLine("Det är en ogiltig summa med pengar");
                return askPrice();
            }

            if (price == 0)                                         //If the item is free, they  shouldn't have to pay anything
            {
                Console.WriteLine("Ta det, det är gratis");

            }
            else if (price < 0)                                     //If the item has a negative cost, the buyer receives money for taking it
            {
                Console.WriteLine("Ta det, det är gratis. Och ta också " + -price + " kr");
            }
            return price;                                           //Returns the price
        }

        private static int askPayment()
        {
            Console.WriteLine("Betalt: ");                          //Asks for the payment
            String strPaid = Console.ReadLine();

            int paid;                                           //max size for paid is 2^31 -1
            try
            {                                                   //Checks that the input is valid
                paid = Int32.Parse(strPaid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Det är en ogiltig summa med pengar");
                return askPayment();
            }

            return paid;                                            //Returns the payment

        }

        private static void procedure()                             //I know that this is a bad name for the function, but i couldn't come up with a better one
        {
            int price = askPrice();
            if (price == 0 || price < 0) return;                    //The program shouldn't continue if the item is free of charge
            int paid = askPayment();
            if (paid < price)                                        //If the given payment is too low, tell customer that
            {
                Console.WriteLine("Ledsen, men du har inte tillräckligt med pengar");
                return;
            }

            int difference = paid - price;
            int[] resultingAmount = new int[7];                     //store the amount of each value in a new array
            Console.WriteLine("Växel tillbaka: ");
            for (int i = 0; i < resultingAmount.Length; i++)        //Loop through each of the currencies and remove as many as possible of those from the difference
            {                                                       //Add the amount of removed currencies to the resultingAmount array
                while (difference - currencies[i] >= 0)
                {
                    resultingAmount[i]++;
                    difference -= currencies[i];
                }
                if (resultingAmount[i] == 0) continue;              //If the amount of a certain value is 0, it is not printed out

                //Print out the resulting amount of currencies with the correct grammar
                if (resultingAmount[i] > 1) Console.WriteLine(resultingAmount[i] + " " + nameOfValuesPlur[i]);
                else Console.WriteLine(resultingAmount[i] + " " + nameOfValuesSing[i]);

            }




        }


    }
}
