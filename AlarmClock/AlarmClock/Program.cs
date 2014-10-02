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
                    ViewTestHeader("Test av konstruktor med två parametrar, (9,42)");
            
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
                ViewErrorMessage("Nåt gick snätt med Test 2!");
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
             ViewTestHeader("Test 6.");
             ViewTestHeader("Testar egenskaperna så att dom kastar ut undantag när ogiltiga värden ställs");
             myAlarm = new AlarmClock();
            //test av timmen
             try
             {
                 myAlarm.Hour = 27;
                 ViewErrorMessage("Undantag kastades inte då timmen blev satt till 27!");
                 return;
             }
             catch
             {
                 ViewTestHeader("Undantag kastades då timmen blev satt till 27...");
             }

            //test av minuten
             try
             {
                 myAlarm.Minute = 66;
                 ViewErrorMessage("Undantag kastades inte då minuten sattes till 66!");
                 return;
             }
             catch 
             {
                 ViewTestHeader("Undantag kastades då minuten sattes till 66...");
             }

            //test av alarmtimmen
            try 	
            {	
                myAlarm.AlarmHour = 27;
    	        ViewErrorMessage("Undantag kastades inte då alarmtimmen sattes till 27!");
                return;
            }
            catch 
            {	
                ViewTestHeader("Undantagkastades då alarmtimmen sattes till 27...");
	        }

            //test av alarmminuten
            try 
	        {	        
		        myAlarm.AlarmMinute = 80;
                ViewErrorMessage("Undantag kastades inte då alarmminuten sattes till 80!");
                return;
	        }
	        catch 
	        {
		        ViewTestHeader("Undantag kastades då alarmminuten sattes till 80...");
		           
	        }
            //Skriv linje
            Console.WriteLine(theLine.HorizontalLine);
            
            //Test av konstruktorerna så undantag kastas då fel värden tilldelas
            try 
            {	        
		        myAlarm = new AlarmClock(24, 60, -1, -1);
                if (myAlarm.Hour < 0 || myAlarm.Hour > 23){
                    ViewErrorMessage("Timmen är utanför intervallet 0-23!");
                }
                else if (myAlarm.AlarmHour < 0 || myAlarm.AlarmHour > 23)
                {
                    ViewErrorMessage("AlarmTimmen är utanför intervallet 0-23!");
                }
                else if (myAlarm.Minute < 0 || myAlarm.Minute > 23)
                {
                    ViewErrorMessage("Minuten är utanför intervallet 0-23!");
                }
                else if (myAlarm.AlarmMinute < 0 || myAlarm.AlarmMinute > 23)
                {
                    ViewErrorMessage("AlarmMinuten är utanför intervallet 0-23!");
                }
                else
                {
                    ViewErrorMessage("Det är något konstigt med konstruktorn med fyra parametrar!");
                }
                return;

            }
            catch (Exception)
            {
		
	            ViewTestHeader("Ett undantag kastas då olika fält tilldelas fel värden");
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
