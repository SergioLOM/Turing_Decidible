using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TuringDecidible
{
    class Program
    {
        const char BLANK_SPACE = '˽';
        const char MARK = 'x';
        const char ZERO = '0';
        public static string pattern = @"^[0]*˽$";
        static string input;
        static string output;
        static int pointer;
        static char[] inputTocharArray;
        static void Main(string[] arg)
        {
            dataInput();
        }

        private static void dataInput()
        {
            do
            {
                Console.WriteLine("Enter a string of zeros: ");
                input = Console.ReadLine();
                input = input + "˽";
                if (input.Equals(""))
                {
                    dataInput();
                }
            } while (!Regex.IsMatch(input, pattern));
            start(input);
        }

        private static void start(string cadena)
        {
            pointer = 0;
            inputTocharArray = input.ToCharArray();
            q1();
            
        }

        private static void q1() 
        {
            if (inputTocharArray[pointer] == ZERO)
            {
                inputTocharArray[pointer] = BLANK_SPACE;
                pointer++;
                q2();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE || inputTocharArray[pointer] == MARK)
            {
                pointer++;
                qRejection();
            }
        }

        private static void q2() 
        {
            if (inputTocharArray[pointer] == ZERO)
            {
                inputTocharArray[pointer] = MARK;
                pointer++;
                q3();
            }
            else if (inputTocharArray[pointer] == MARK)
            {
                pointer++;
                q2();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE)
            {
                pointer++;
                qAccenptance();
            }
        }

        private static void q3() 
        {
            if (inputTocharArray[pointer] == ZERO)
            {
                pointer++;
                q4();
            }
            else if (inputTocharArray[pointer] == MARK)
            {
                pointer++;
                q3();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE)
            {
                pointer--;
                q5();
            }
        }

        private static void q4() 
        {
            if (inputTocharArray[pointer] == ZERO)
            {
                inputTocharArray[pointer] = MARK;
                pointer++;
                q3();
            }
            else if (inputTocharArray[pointer] == MARK)
            {
                pointer++;
                q4();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE)
            {
                pointer++;
                qRejection();
            }
        }

        private static void q5()
        {
            if (inputTocharArray[pointer] == ZERO || inputTocharArray[pointer] == MARK)
            {
                pointer--;
                q5();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE)
            {
                pointer++;
                q2();
            }
        }

        private static void qAccenptance() 
        {
            Console.WriteLine("String accepted!!!");
            printString();
            Console.WriteLine("\n" + output);
            Console.ReadKey();
        }

        private static void qRejection() 
        {
            Console.WriteLine("String rejected!!!");
            printString();
            Console.WriteLine("\n" + output);
            Console.ReadKey();
        }

        private static void printString()
        {
            output = "";
            for(int i = 0; i < inputTocharArray.Length; i++)
            {
                output = output + inputTocharArray[i];
            }
        }

 

    }
}
