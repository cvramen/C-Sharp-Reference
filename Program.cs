/*
C# Reference 
by Nick Kirkpatrick http://cvramen.com
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Sedan
    {
        /* Overloading methods */
        public int Year;
        public string Name;
        public decimal Price;

        public Sedan(string thud)
        {
            Name = thud;
        }
        public Sedan(string thud, int y)
        {
            Name = thud;
            Year = y;
        }
        public Sedan(string thud, decimal p, int y)
        {
            Name = thud;
            Price = p;
            Year = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //start
            /* Switch Statements */
            int theVal = 51;
            switch (theVal)
            {
                case 50:
                    Console.WriteLine("The value is 50");
                    break;
                case 51:
                    Console.WriteLine("The value is 51");
                    break;
                case 52:
                    Console.WriteLine("The value is 52");
                    break;
                default:
                    Console.WriteLine("The value is something else");
                    break;
            }

            /* Arithmetic */
            int i = (3 + 4 - 5 * 6 / 7) % 5; //addition, subtraction, multiplication, division, and modulus
            Console.WriteLine(i);

            if (i == 1 || i != 3 || i > 5 ||  i < 2)
            {
                Console.WriteLine("Variable i has qualified");
            }
            else if (!(i == 2))
            {
                Console.WriteLine("Varliable i apparently does meet the first condition, nor does it equal two");
            }
            else
            {
                Console.WriteLine("Varialbe i has not satisfied any of the conditions for the IF statement");
            }

            //increment, add one
            i = i + 1;
            i += 1;
            i++;

            //decrement, subtract one
            i = i - 1;
            i -= 1;
            i--;

            //loops
            /* While loop */
            int flob = 0;
            double puar = 2;
            while (flob < 5) //start a "while" loop
            {
                puar = Math.Pow(puar, 2); //exponent b to the power of 2
                Console.WriteLine("This loop has executed {0} times. Also, the value of puar is {1}", ++flob, puar);
            }

            /* Do loop */
            double hogera = 24;
            do
            {
                hogera *= .72; //multiplies a variable by .72;
                Console.WriteLine("The value of hogera is {0}", hogera);
            } while (hogera > 3);

            /* For loop */
            for (int piyo = 0; piyo < 20; piyo += 5) //sets a new integer "piyo ", keeps on going until it's 20 and adds 5 each time
            {
                Console.WriteLine("piyo is currently {0}", piyo);
            }

            /* For loop with continue and break */
            for (int foo = 128; foo > 0; foo--)
            {
                if (foo == 7)
                    break;
                if (foo % 4 != 0)
                    continue;
                Console.WriteLine("foo is currently {0}", foo);
            }

            /*
            private int someInteger; //private class member can only be accessed within the class itself
            public string myMessage; //public class member can be accessed by any other object
            protected void myFunction(); //protected class member can only be accessed within this class or any subclass (class that inherits from this class)
            */

            /* Hashtables */
            Hashtable cheeses = new Hashtable();
            cheeses.Add("SW", "Swiss");
            cheeses.Add("AM", "American");
            cheeses["PR"] = "Provolone";

            Console.WriteLine("The value for key {0} is {1}", "AM", cheeses["AM"]);
            Console.WriteLine("There are {0} items", cheeses.Count);

            //cheeses.Remove("AM");
            if (cheeses.ContainsKey("AM"))
            {
                Console.WriteLine("Value for key {0} is {1}", "AM", cheeses["AM"]);
            }

            /* Overloading methods */
            Sedan s1 = new Sedan("Avalon"); //These lines work because different parameters are being used.
            Sedan s2 = new Sedan("Mariner", 2005);
            Sedan s3 = new Sedan("Accord", 19995.00m, 2007);

            Console.WriteLine("{0}", s1.Name);
            Console.WriteLine("{0} {1}", s2.Year, s2.Name);
            Console.WriteLine("{0} {1} {2}", s3.Year, s3.Name, s3.Price);

            /* Exception Objects */
            int divZeroTesterOne = 10;
            int divZeroTesterTwo = 0;
            int result;

            try
            {
                result = divZeroTesterOne / divZeroTesterTwo;
                Console.WriteLine("The result is {0}", result);
            }
            catch (System.ArithmeticException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("This always runs, even if the try block yields an error.");
            }

            /* Modify Files */
            string thePath = @"c:\MyFolder\sandbox\mySubDir"; //Establish a directory
            bool dirExists = Directory.Exists(thePath); //Check to see if a directory exists
            if (dirExists)
                Console.WriteLine("The directory exists.");
            else
                Console.WriteLine("The directory does not exist.");
            Console.WriteLine();

            //Write out the names of the files in the directory
            string[] files = Directory.GetFiles(thePath);
            foreach (string grault in files)
            {
                Console.WriteLine("Found file: " + grault);
            }

            //create a path to the My Documents folder and the file name
            string theFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "examplefile.txt";

            //if the file doesn't exist, create it using WriteAllText
            if (!File.Exists(theFile))
            {
                string content = "This is a text file. For great justice." + Environment.NewLine;
                Console.WriteLine("Creating the file...");
                File.WriteAllText(theFile, content);
            }
            Console.WriteLine("It was created on {0}", File.GetCreationTime(theFile));
            Console.WriteLine("It was last accessed on {0}", File.GetLastAccessTime(theFile));
            Console.WriteLine();

            string activeDir = @"c:\MyFolder\sandbox"; //Specify a "currently active folder"
            Console.WriteLine("The value of activeDir is {0}", activeDir);
            string newPath = System.IO.Path.Combine(activeDir, "mySubDir"); //Create a new subfolder under the current active folder
            Console.WriteLine("The value of newPath is {0}", newPath);

            System.IO.Directory.CreateDirectory(newPath); //Create the subfolder

            string newFileName = System.IO.Path.GetRandomFileName(); //Create a new file name. This example generates a random string.
            Console.WriteLine("The value of newFileName is {0}", newFileName);
            newPath = System.IO.Path.Combine(newPath, newFileName); //Combine the new file name with the path
            Console.WriteLine("The value of newPath is {0}", newPath);

            //Create the file and write to it. DANGER: System.IO.File.Create will overwrite the file if it already exists. This can occur even with random file names.
            if (!System.IO.File.Exists(newPath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(newPath))
                {
                    for (byte garply = 0; garply < 100; garply++)
                    {
                        fs.WriteByte(garply);
                    }
                }
            }

            // Establish extra text you'd like to add
            string baz = Environment.NewLine + "This is extra text" + Environment.NewLine;
            File.AppendAllText(newPath, baz); //adds string baz to file newPath

            //Adds text to the file newPath
            using (StreamWriter waldo = File.AppendText(newPath))
            {
                waldo.WriteLine("Yo dawg");
            }

            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(newPath);
                foreach (byte b in readBuffer)
                {
                    //writes the value of b
                    Console.Write("{0}, 5", b);
                }
            }
            catch (System.IO.IOException qux)
            {
                Console.WriteLine(qux.Message);
            }
            //Keep the console window open in debug mode.
            System.Console.WriteLine("That's it for the bytes in {0}!", newPath);

            Console.WriteLine();

            /* Get information about the disk drives */
            foreach (DriveInfo corge in DriveInfo.GetDrives())
            {
                if (corge.DriveType == DriveType.Fixed)
                {
                    Console.WriteLine("Drive Name: {0}", corge.Name);
                    Console.WriteLine("Free Space: {0}", corge.TotalFreeSpace);
                    Console.WriteLine("Drive Type: {0}", corge.DriveType);
                    Console.WriteLine();
                }
            }
            

            Console.ReadLine();
            //end
        }
    }
}
