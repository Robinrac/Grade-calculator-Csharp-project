using System;

namespace gradeCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //inled med välkomstmeddelande samt förklaring till vad programmet är
            Console.WriteLine("--------------------");
            Console.WriteLine("Hej och välkommen!");
            Console.WriteLine("--------------------");
            Console.WriteLine("Det här är ett program som kan spara dina poäng som du har i alla skolämnen.");
            Console.WriteLine("--------------------");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Var snäll och mata in dom poängen som du har i respektive ämne");

            //lagra världen med hjälp av arrays
            //lagra olika typer av värden i olika arrays
            //ämnen som strings då de endast är ord
            //poäng som integers då de endast lagras som heltal och inte decimaler
            //betyg som character för att betygen endast ska lagras som en bokstav
            //gradeTotal som integers då de endast behöver lagras som heltal och inte decimaler
            string[] subjects = { "Matematik", "Svenska", "Engelska", "Historia", "Fysik" };
            int[] points = new int[5];
            char[] grade = new char[5];
            int [] gradeTotal = new int[6];

            //referera till respektive method för att utföra kod
            //Respektive metod ska även ha en eller flera arrays i sig för att bestämma vilka värden som ska skickas till methoden
            ReadPoints(subjects, points);
            ConvertGrade(subjects, grade, points);
            WriteGrade(subjects, grade);
            Statistics(points, gradeTotal);

            //efter användaren fått sin information behöver den trycka på en knapp för att koma vidare till hejdå meddelandet
            Console.WriteLine(" ");
            Console.WriteLine("Tryck på vilken knapp som helst för att avsluta...");
            Console.ReadLine();

            //hejdå meddelande
            Console.WriteLine("--------------------");
            Console.WriteLine("Tack för att du använde min BetygStatistik simulator!");
            Console.WriteLine("--------------------");
            Console.WriteLine("Hejdå!");
            Console.WriteLine(" ");
            Console.WriteLine("Av: Robin Raczkiewicz");

            Console.ReadLine();
        }

        //första methoden som kommer att läsa och ta in värderna till "points" eller poäng
        //här skickas och används värderna "subjects" och "points"
        static void ReadPoints(string[] subjects, int[] points)
        {

            //här ska jag skriva vad poängen är i de olika ämnerna
            //validNumber används för att se till att värden är mellan 0-100 och kan därmed starta om do-while-loopen om false
            bool validNumber = true;
            int points2;

            //gör en do-while loop för att koden inom loopen ska utföras innan den kollar ifall den ska avslutas
            do
            {
                //gör en foor loop som ber användaren mata in x antal nummer
                //x antal nummer = så många olika "subjects" eller ämnen som finns
                for (int i = 0; i < subjects.Length; i++)
                {
                    //ämnena ska även uppdateras varje gång som användaren slår in ett nummer
                    Console.WriteLine("Skriv in hur många poäng du har i " + subjects[i] + " (0-100)");
                    points2 = Convert.ToInt32(Console.ReadLine());
                    points[i] = points2;

                    //om användaren skriver in ett ogiltigt nummer så kommer ett felmeddelande
                    //om points värde > 100 eller < 0 så kommer ett "break" kommand som tar användaren ut ur for-loopen
                    if (points[i] < 0 || points[i] > 100)
                    {
                        Console.WriteLine("Var vänlig och skriv in ett giltigt nummer (0-100)");
                        validNumber = false;
                        break;
                    }
                    else
                    {
                        validNumber = true;
                    }
                }
                //om det inmatade värdet är fel och utför "break;" kommandot startas do-while-loopen om
            } while (!validNumber);
        }

        //den andra methoden kommer att placera ut poäng värderna och ge dom ett betyg
        //här skickas och används värderna "subjects", "grade" och "points"
        static void ConvertGrade(string[] subjects, char[] grade, int[] points)
        {
            //utskrift av betyg
            //här placeras värderna in och ger betyg till respektive poäng
            for (int i = 0; i < subjects.Length; i++)
            {
                if (points[i] == 100)
                    grade[i] = 'A';
                else if (points[i] >= 87.5)
                    grade[i] = 'B';
                else if (points[i] >= 75)
                    grade[i] = 'C';
                else if (points[i] >= 62.5)
                    grade[i] = 'D';
                else if (points[i] >= 50)
                    grade[i] = 'E';
                else if (points[i] < 50)
                    grade[i] = 'F';
            }
        }

        //tredje methoden kommer att läsa upp och visa betyg för respektive ämne baserat på tidigare information
        //här skickas och används värderna "subjects" och "grade"
        static void WriteGrade(string[] subjects, char[] grade)
        {
            //betygstatistiken ska skrivas ut
            //för varje gång loopen skrivs ut så kommer den med hjälp av "i" att updatera subject och grade värderna
            for (int i = 0; i < subjects.Length; i++)
                Console.WriteLine("I " + subjects[i] + " Har du betyget: " + grade[i]);
        }

        //sista methoden kommer att visa användaren hur många av varje betyg som den har samt den totala summan av poäng hen har.
        //här skickas och används värderna "points" och "gradeTotal"
        static void Statistics(int[] points, int[] gradeTotal)
        {
            //Det här integern kommer samla ihop det totala poäng värdet genom att plussa till poängen till den
            int pointsTotal = 0;

            //utskrift av antal av specifikt betyg
            //här räknas antal av varje varje betyg ihop.
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == 100)
                    gradeTotal[0]++;
                else if (points[i] >= 87.5)
                    gradeTotal[1]++;
                else if (points[i] >= 75)
                    gradeTotal[2]++;
                else if (points[i] >= 62.5)
                    gradeTotal[3]++;
                else if (points[i] >= 50)
                    gradeTotal[4]++;
                else if (points[i] < 50)
                    gradeTotal[5]++;

                //här räknas det totala värdet av poäng ihop
                pointsTotal = pointsTotal + points[i];
            }

            //läs upp antal A-F betyg beroende på tidigare given information
            Console.WriteLine("Antal betyg A: " + gradeTotal[0]);
            Console.WriteLine("Antal betyg B: " + gradeTotal[1]);
            Console.WriteLine("Antal betyg C: " + gradeTotal[2]);
            Console.WriteLine("Antal betyg D: " + gradeTotal[3]);
            Console.WriteLine("Antal betyg E: " + gradeTotal[4]);
            Console.WriteLine("Antal betyg F: " + gradeTotal[5]);

            //läs upp antal totala poäng
            Console.WriteLine("Dina totala poäng är: " + pointsTotal);
        }

    }
}