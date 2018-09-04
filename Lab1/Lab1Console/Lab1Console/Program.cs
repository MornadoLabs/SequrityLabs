using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Lab1Console;
using Lab1Console.Helpers;

namespace Lab1Console
{
    class Program
    {
        private const string filePath = @"D:\Learning\4 курс\1 семестр\Squrity\Sequence.txt";

        private static int count = 1;

        static void Main(string[] args)
        {
            /*GetPeriod(ValuesA.Pow2to5, ValuesC.val0, ValuesM.Pow10, ValuesX0.val2);
            GetPeriod(ValuesA.Pow3to5, ValuesC.val1, ValuesM.Pow11, ValuesX0.val4);
            GetPeriod(ValuesA.Pow4to5, ValuesC.val2, ValuesM.Pow12, ValuesX0.val8);
            GetPeriod(ValuesA.Pow5to5, ValuesC.val3, ValuesM.Pow13, ValuesX0.val16);
            GetPeriod(ValuesA.Pow6to5, ValuesC.val5, ValuesM.Pow14, ValuesX0.val32);
            GetPeriod(ValuesA.Pow2to3, ValuesC.val8, ValuesM.Pow15, ValuesX0.val64);
            /*GetPeriod(ValuesA.Pow3to3, ValuesC.val13, ValuesM.Pow16, ValuesX0.val128);*//*count++;
            GetPeriod(ValuesA.Pow4to3, ValuesC.val21, ValuesM.Pow17, ValuesX0.val256);
            GetPeriod(ValuesA.Pow5to3, ValuesC.val34, ValuesM.Pow18, ValuesX0.val512);
            GetPeriod(ValuesA.Pow6to3, ValuesC.val55, ValuesM.Pow19, ValuesX0.val1024);
            GetPeriod(ValuesA.Pow7to3, ValuesC.val89, ValuesM.Pow20, ValuesX0.val1);
            GetPeriod(ValuesA.Pow8to3, ValuesC.val144, ValuesM.Pow21, ValuesX0.val3);
            GetPeriod(ValuesA.Pow9to3, ValuesC.val233, ValuesM.Pow22, ValuesX0.val5);
            GetPeriod(ValuesA.Pow10to3, ValuesC.val377, ValuesM.Pow23, ValuesX0.val7);
            GetPeriod(ValuesA.Pow11to3, ValuesC.val610, ValuesM.Pow24, ValuesX0.val9);
            GetPeriod(ValuesA.Pow12to3, ValuesC.val987, ValuesM.Pow25, ValuesX0.val11);
            GetPeriod(ValuesA.Pow13to3, ValuesC.val1597, ValuesM.Pow26, ValuesX0.val13);
            GetPeriod(ValuesA.Pow14to3, ValuesC.val2584, ValuesM.Pow27, ValuesX0.val17);
            GetPeriod(ValuesA.Pow15to3, ValuesC.val4181, ValuesM.Pow28, ValuesX0.val19);
            GetPeriod(ValuesA.Pow16to3, ValuesC.val6765, ValuesM.Pow29, ValuesX0.val23);
            GetPeriod(ValuesA.Pow17to3, ValuesC.val10946, ValuesM.Pow30, ValuesX0.val29);*/
            GetPeriod(ValuesA.Pow7to5, ValuesC.val17711, ValuesM.Pow31Minus1, ValuesX0.val31);/*
            GetPeriod(ValuesA.Pow2to16, ValuesC.val28657, ValuesM.Pow31, ValuesX0.val33);
            GetPeriod(ValuesA.Pow2to15, ValuesC.val46368, ValuesM.Pow31Minus3, ValuesX0.val37);
            GetPeriod(ValuesA.Pow2to14, ValuesC.val75025, ValuesM.Pow31Minus7, ValuesX0.val41);*/
            Console.ReadKey();
        }

        static void GetPeriod(ValuesA a, ValuesC c, ValuesM m, ValuesX0 x0)
        {
            var generator = new RandomSequenceGenerator
            (
                EnumValuesParser.GetValueA(a),
                EnumValuesParser.GetValueC(c),
                EnumValuesParser.GetValueM(m),
                EnumValuesParser.GetValueX0(x0)
            );

            //FileWriter.WritePartOfSequenceToFile(filePath, generator.GetNextSequencePart());

            while (!generator.IsEnded)
            {
                generator.GetNextSequencePart();
            }

            Console.WriteLine($"{count++}) Period: {generator.Period}");
            Console.WriteLine();
        }
    }
}
