using System;
using System.IO;

namespace L04_Merge_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputOne = Path.Combine("Input1.txt");
            string inputTwo = Path.Combine("Input2.txt");
            string output = Path.Combine("Output.txt");

            using (StreamReader firstInput = new StreamReader(inputOne))
            {

                using (StreamReader secondInput = new StreamReader (inputTwo))
                {

                    string [] arr1 = firstInput.ReadToEnd ().Split(new[] { '\n','\r'}, StringSplitOptions.RemoveEmptyEntries);
                    string [] arr2 = secondInput.ReadToEnd().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    

                    using (StreamWriter outputfile = new StreamWriter(output))
                    {
                        for (int i = 0; i < arr1.Length; i++)
                        {
                            outputfile.WriteLine(arr1[i]);
                            outputfile.WriteLine(arr2[i]);

                        }
                    }

                }

            }


        }

    }
}
