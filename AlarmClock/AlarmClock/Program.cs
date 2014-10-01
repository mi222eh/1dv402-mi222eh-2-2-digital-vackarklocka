using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    class Program
    {
        private string HorizontalLine = "----------------------------------------------------------";
        static void Main(string[] args)
        {
            //Skapa referenser
            AlarmClock myAlarm;
            Program theLine = new Program();

            //skapa variabler
            string showTestTime = "";
            bool testAlarm = false;

            try
            {
                //Visa meddelande
                ViewTestHeader("Test 1.");
                ViewTestHeader("Test av standardkonstruktorn");

                //test 1! med inga parametrar...
                myAlarm = new AlarmClock();

                //Hämta strängen...
                showTestTime = myAlarm.ToString();

                //skriv strängen
                Console.WriteLine(showTestTime);

                //Skriv en lång linje
                Console.WriteLine(theLine.HorizontalLine);

            }
            catch
            {
                ViewErrorMessage("Nåt skick snätt med Test 1!");
                return;
            }
             try 
	          {	        
		            //Skriv meddelande
                    ViewTestHeader("Test 2.");
                    ViewTestHeader("Test av konstruktor med två parametrar, /(9,42/)");
            
                    //TEST 2! med två parametrar insället...
                    myAlarm = new AlarmClock(9, 42);

                    //hämta strängen...
                    showTestTime = myAlarm.ToString();

                    //Sriv strängen som kom
                    Console.WriteLine(showTestTime);

                    //Skriv linje
                    Console.WriteLine(theLine.HorizontalLine);
	        }
	        catch
	        {
                ViewErrorMessage("Nåt gick snätt med Test 2");
		        return;
	        }

             try
             {
                 //meddela
                 ViewTestHeader("Test 3.");
                 ViewTestHeader("Test av konstruktor med fyra parametrar, /(13, 24, 7, 35");

                 //test 3! med fyra parametrar...
                 myAlarm = new AlarmClock(13, 24, 7, 35);

                 //hämta strängen
                 showTestTime = myAlarm.ToString();

                 //skriv strängen
                 Console.WriteLine(showTestTime);

                 //skriv linje
                 Console.WriteLine(theLine.HorizontalLine);
             }
             catch 
             {
                 ViewErrorMessage("Nåt gick snätt med Test 3!");
                 return;
             }

            //Nu ska TickTock()testas
             try
             {
                 //Meddela!
                 ViewTestHeader("Test 4.");
                 ViewTestHeader("Ställer AlarmClock-object till 23:58 och låter den gå 13 minuter");

                 //sätt klockan till 23:58 och alarmet sätts där den inte stör
                 myAlarm = new AlarmClock(23, 58, 7, 30);

                 //Anropa TickTock() 13 gånger

                 for (int i = 0; i < 13; i++)
                 {
                     //TickTock ska öka minuten med en
                     myAlarm.TickTock();

                     //för att få strängen anropas ToString som lagras i variabel
                     showTestTime = myAlarm.ToString();

                     //Varje gång ska strängen med tiden skrivas ut...
                     Console.WriteLine(showTestTime);
                 }

                 //skriv linje
                 Console.WriteLine(theLine.HorizontalLine);
             }
             catch 
             {
                 ViewErrorMessage("Nåt gick fel med Test 4!");
                 return;
             }

            //Testar larmet...
             try
             {
                 //Meddela!
                
                 ViewTestHeader("Test 5.");
                
                 ViewTestHeader("Ställer klockan till 6:12 och alarmet vid 6:15... Klockan kommer att gå i sex minuter");
               
                 //Sätter klockan till 6:12 och larmet 6:15
                 myAlarm = new AlarmClock( 6, 12, 6, 15);

                 //Anropar TickTock 6 gånger...
                 for (int i = 0; i < 6; i++)
               
                 {
                     testAlarm = myAlarm.TickTock();
                     showTestTime = myAlarm.ToString();
                     if (testAlarm == true)
                     {
                         Console.BackgroundColor = Console.BackgroundColor;
                         Console.WriteLine("      {0}     Beep! Beep! Beep!", showTestTime);
                         Console.ResetColor();
                     }
                     else
                     {
                         Console.WriteLine("      {0}", showTestTime);
                     }
               
                 }

                 //skriv linje
                 Console.WriteLine(theLine.HorizontalLine);
             }
             catch 
             {
                 ViewErrorMessage("Nåt gick fel med Test 5!");
                 return;
             }

            //Testar egenskaperna...

             try
             {
                 myAlarm = new AlarmClock();
                 myAlarm.Hour = 27;
             }
             catch
             {
                 
                 throw;
             }

        }
        private static void ViewErrorMessage(string message)
    {

        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();


    }
        private static void ViewTestHeader(string message)
        {
            Console.WriteLine(message);
        }
    }
}
