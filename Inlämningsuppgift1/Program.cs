using System;

namespace Inlämningsuppgift1
{

    class Program
    {
        //Member variables
        private static int[] currencies = new int[7] { 500, 100, 50, 20, 10, 5, 1 };    //An array containing the currencies in a decreasing order



        static void Main(string[] args)
        {


            procedure();
        }

        private static int askPrice()
        {
            Console.WriteLine("Ange pris: ");
            String strPrice = Console.ReadLine();                   //Asking for the price
            int price;
            try {                                                   //Testing that the user actually gives some amount of money
                price = Int32.Parse(strPrice);                      //Converting the input string to an int
            }
            catch(Exception e)
            {
                Console.WriteLine("That's an invalid amount of money");
                return askPrice();
            }
            
            if (price == 0)                                         //If the item is free, they  shouldn't have to pay anything
            {
                Console.WriteLine("It's free, take it");
                
            }
            else if (price < 0)                                     //If the item has a negative cost, the buyer receives money for taking it
            {
                Console.WriteLine("Take it, and also take " + -price + " kr");
            }
            return price;                                           //Returns the price
        }

        private static int askPayment()
        {
            Console.WriteLine("Betalt: ");                          //Asks for the payment
            String strPaid = Console.ReadLine();

            int paid;
            try {                                                   //Checks that the input is valid
                paid = Int32.Parse(strPaid);
            }
            catch(Exception e)
            {
                Console.WriteLine("That's an invalid amount of money");
                return askPayment();
            }
            
            return paid;                                            //Returns the payment

        }

        private static void procedure()
        {
            int price = askPrice();
            if (price == 0 || price < 0) return;                    //The program shouldn't continue if the item is free of charge
            int paid = askPayment();
            if(paid < price)                                        //If the given payment is too low, tell customer that
            {
                Console.WriteLine("I'm sorry, but your funds are insufficient");
            }
            
            int difference = paid - price;
            int[] resultingAmount = new int[7];                     //store the amount of each value in a new array
            string[] nameOfValuesPlur = new string[7] {"femhundralappar", "hundralappar", "femtiolappar","tjugolappar","tiokronor","femkronor","enkronor"};     //Names for the currencies in plural
            string[] nameOfValuesSing = new string[7] { "femhundralapp", "hundralapp", "femtiolapp", "tjugolapp", "tiokrona", "femkrona", "enkrona" };          //Names for the currencies in singular
            Console.WriteLine("Växel tillbaka: ");
            for (int i = 0; i < resultingAmount.Length; i++)
            {
                

                while (difference - currencies[i] >= 0)
                {
                    resultingAmount[i]++;
                    difference -= currencies[i];
                }
                if (resultingAmount[i] == 0) continue;              //If the amount of a certain value is 0, it is not printed out
                if (resultingAmount[i]>1) Console.WriteLine(resultingAmount[i] + " " + nameOfValuesPlur[i]);
                else Console.WriteLine(resultingAmount[i] + " " + nameOfValuesSing[i]);

            }


            

        }


    }
}
