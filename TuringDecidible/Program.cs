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
        const char V = 'v';
        static string pattern = @"^([0]*˽)|x˽$";
        static string input;
        static string originalInput;
        static string output;
        static string downArrowString;
        static int pointer;
        static char[] inputTocharArray;
        static char[] downArrowArray;


        static void Main(string[] arg)
        {
            dataInput();
        }

        private static void dataInput()
        {
            do
            {
                Console.WriteLine("Enter a string of zeros (0^(2^n); n >= 0): ");
                originalInput = Console.ReadLine();
                input = originalInput;
                input = input + "˽";
            } while (!Regex.IsMatch(input, pattern));
            start();
        }

        private static void start()
        {
            pointer = 0;
            inputTocharArray = input.ToCharArray();
            q1();
            
        }

        private static void q1() 
        {
            createBlankArray();
            if (inputTocharArray[pointer] == ZERO)
            {
                inputTocharArray[pointer] = BLANK_SPACE;
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                q2();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE || inputTocharArray[pointer] == MARK)
            {
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                qRejection();
            }
        }

        private static void q2() 
        {
            createBlankArray();
            if (inputTocharArray[pointer] == ZERO)
            {
                inputTocharArray[pointer] = MARK;
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                q3();
            }
            else if (inputTocharArray[pointer] == MARK)
            {
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                q2();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE)
            {
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                qAccenptance();
            }
        }

        private static void q3() 
        {
            createBlankArray();
            if (inputTocharArray[pointer] == ZERO)
            {
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                q4();
            }
            else if (inputTocharArray[pointer] == MARK)
            {
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                q3();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE)
            {
                downArrowArray[pointer] = V;
                pointer--;
                printDownArrowString();
                printString();
                q5();
            }
        }

        private static void q4() 
        {
            createBlankArray();
            if (inputTocharArray[pointer] == ZERO)
            {
                inputTocharArray[pointer] = MARK;
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                q3();
            }
            else if (inputTocharArray[pointer] == MARK)
            {
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                q4();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE)
            {
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                qRejection();
            }
        }

        private static void q5()
        {
            createBlankArray();
            if (inputTocharArray[pointer] == ZERO || inputTocharArray[pointer] == MARK)
            {
                downArrowArray[pointer] = V;
                pointer--;
                printDownArrowString();
                printString();
                q5();
            }
            else if (inputTocharArray[pointer] == BLANK_SPACE)
            {
                downArrowArray[pointer] = V;
                pointer++;
                printDownArrowString();
                printString();
                q2();
            }
        }

        private static void qAccenptance() 
        {
            Console.WriteLine("\nString accepted!!!");
            Console.WriteLine(originalInput);
            Console.ReadKey();
        }

        private static void qRejection() 
        {
            Console.WriteLine("\nString rejected!!!");
            Console.WriteLine(originalInput);
            Console.ReadKey();
        }

        private static void printString()
        {
            output = "";
            for(int i = 0; i < (inputTocharArray.Length); i++)
            {
                output = output + inputTocharArray[i];
            }
            Console.WriteLine(output);
        }

        private static void printDownArrowString()
        {
            downArrowString = "";
            for (int i = 0; i < (downArrowArray.Length); i++)
            {
                downArrowString = downArrowString + downArrowArray[i];
            }
            Console.WriteLine("\n" + downArrowString);
        }

        private static void createBlankArray()
        {
            downArrowArray = new char[input.Length];
        }
    }
}
