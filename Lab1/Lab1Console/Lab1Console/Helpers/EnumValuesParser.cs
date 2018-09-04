using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Console.Helpers
{
    internal static class EnumValuesParser
    {
        public static long GetValueA(ValuesA val)
        {
            switch (val)
            {
                case ValuesA.Pow2to5:
                {
                    return (long) Math.Pow(2, 5);
                }
                case ValuesA.Pow3to5:
                {
                    return (long) Math.Pow(3, 5);
                }
                case ValuesA.Pow4to5:
                {
                    return (long) Math.Pow(4, 5);
                }
                case ValuesA.Pow5to5:
                {
                    return (long) Math.Pow(5, 5);
                }
                case ValuesA.Pow6to5:
                {
                    return (long) Math.Pow(6, 5);
                }
                case ValuesA.Pow2to3:
                {
                    return (long) Math.Pow(2, 3);
                }
                case ValuesA.Pow3to3:
                {
                    return (long) Math.Pow(3, 3);
                }
                case ValuesA.Pow4to3:
                {
                    return (long) Math.Pow(4, 3);
                }
                case ValuesA.Pow5to3:
                {
                    return (long) Math.Pow(5, 3);
                }
                case ValuesA.Pow6to3:
                {
                    return (long) Math.Pow(6, 3);
                }
                case ValuesA.Pow7to3:
                {
                    return (long) Math.Pow(7, 3);
                }
                case ValuesA.Pow8to3:
                {
                    return (long) Math.Pow(8, 3);
                }
                case ValuesA.Pow9to3:
                {
                    return (long) Math.Pow(9, 3);
                }
                case ValuesA.Pow10to3:
                {
                    return (long) Math.Pow(10, 3);
                }
                case ValuesA.Pow11to3:
                {
                    return (long) Math.Pow(11, 3);
                }
                case ValuesA.Pow12to3:
                {
                    return (long) Math.Pow(12, 3);
                }
                case ValuesA.Pow13to3:
                {
                    return (long) Math.Pow(13, 3);
                }
                case ValuesA.Pow14to3:
                {
                    return (long) Math.Pow(14, 3);
                }
                case ValuesA.Pow15to3:
                {
                    return (long) Math.Pow(15, 3);
                }
                case ValuesA.Pow16to3:
                {
                    return (long) Math.Pow(16, 3);
                }
                case ValuesA.Pow17to3:
                {
                    return (long) Math.Pow(17, 3);
                }
                case ValuesA.Pow7to5:
                {
                    return (long) Math.Pow(7, 5);
                }
                case ValuesA.Pow2to16:
                {
                    return (long) Math.Pow(2, 16);
                }
                case ValuesA.Pow2to15:
                {
                    return (long) Math.Pow(2, 15);
                }
                case ValuesA.Pow2to14:
                {
                    return (long) Math.Pow(2, 14);
                }
                default: throw new Exception("Unknown value");
            }
        }

        public static long GetValueC(ValuesC val)
        {
            switch (val)
            {
                case ValuesC.val0:
                {
                    return 0;
                }
                case ValuesC.val1:
                {
                    return 1;
                }
                case ValuesC.val2:
                {
                    return 2;
                }
                case ValuesC.val3:
                {
                    return 3;
                }
                case ValuesC.val5:
                {
                    return 5;
                }
                case ValuesC.val8:
                {
                    return 8;
                }
                case ValuesC.val13:
                {
                    return 13;
                }
                case ValuesC.val21:
                {
                    return 21;
                }
                case ValuesC.val34:
                {
                    return 34;
                }
                case ValuesC.val55:
                {
                    return 55;
                }
                case ValuesC.val89:
                {
                    return 89;
                }
                case ValuesC.val144:
                {
                    return 144;
                }
                case ValuesC.val233:
                {
                    return 233;
                }
                case ValuesC.val377:
                {
                    return 377;
                }
                case ValuesC.val610:
                {
                    return 610;
                }
                case ValuesC.val987:
                {
                    return 987;
                }
                case ValuesC.val1597:
                {
                    return 1597;
                }
                case ValuesC.val2584:
                {
                    return 2584;
                }
                case ValuesC.val4181:
                {
                    return 4181;
                }
                case ValuesC.val6765:
                {
                    return 6765;
                }
                case ValuesC.val10946:
                {
                    return 10946;
                }
                case ValuesC.val17711:
                {
                    return 17711;
                }
                case ValuesC.val28657:
                {
                    return 28657;
                }
                case ValuesC.val46368:
                {
                    return 46368;
                }
                case ValuesC.val75025:
                {
                    return 75025;
                }
                default: throw new Exception("Unknown value");
            }
        }

        public static long GetValueM(ValuesM val)
        {
            switch (val)
            {
                case ValuesM.Pow10:
                {
                    return (long) Math.Pow(2, 10) - 1;
                }
                case ValuesM.Pow11:
                {
                    return (long) Math.Pow(2, 11) - 1;
                }
                case ValuesM.Pow12:
                {
                    return (long) Math.Pow(2, 12) - 1;
                }
                case ValuesM.Pow13:
                {
                    return (long) Math.Pow(2, 13) - 1;
                }
                case ValuesM.Pow14:
                {
                    return (long) Math.Pow(2, 14) - 1;
                }
                case ValuesM.Pow15:
                {
                    return (long) Math.Pow(2, 15) - 1;
                }
                case ValuesM.Pow16:
                {
                    return (long) Math.Pow(2, 16) - 1;
                }
                case ValuesM.Pow17:
                {
                    return (long) Math.Pow(2, 17) - 1;
                }
                case ValuesM.Pow18:
                {
                    return (long) Math.Pow(2, 18) - 1;
                }
                case ValuesM.Pow19:
                {
                    return(long) Math.Pow(2, 19) - 1;
                }
                case ValuesM.Pow20:
                {
                    return(long) Math.Pow(2, 20) - 1;
                }
                case ValuesM.Pow21:
                {
                    return(long) Math.Pow(2, 21) - 1;
                }
                case ValuesM.Pow22:
                {
                    return(long) Math.Pow(2, 22) - 1;
                }
                case ValuesM.Pow23:
                {
                    return(long) Math.Pow(2, 23) - 1;
                }
                case ValuesM.Pow24:
                {
                    return(long) Math.Pow(2, 24) - 1;
                }
                case ValuesM.Pow25:
                {
                    return(long) Math.Pow(2, 25) - 1;
                }
                case ValuesM.Pow26:
                {
                    return(long) Math.Pow(2, 26) - 1;
                }
                case ValuesM.Pow27:
                {
                    return(long) Math.Pow(2, 27) - 1;
                }
                case ValuesM.Pow28:
                {
                    return(long) Math.Pow(2, 28) - 1;
                }
                case ValuesM.Pow29:
                {
                    return(long) Math.Pow(2, 29) - 1;
                }
                case ValuesM.Pow30:
                {
                    return (long) Math.Pow(2, 30) - 1;
                }
                case ValuesM.Pow31:
                {
                    return (long) Math.Pow(2, 31);
                }
                case ValuesM.Pow31Minus1:
                {
                    return (long) Math.Pow(2, 31) - 1;
                }
                case ValuesM.Pow31Minus3:
                {
                    return (long) Math.Pow(2, 31) - 3;
                }
                case ValuesM.Pow31Minus7:
                {
                    return (long) Math.Pow(2, 31) - 7;
                }
                default: throw new Exception("Unknown value");
            }
        }

        public static long GetValueX0(ValuesX0 val)
        {
            switch (val)
            {
                case ValuesX0.val2:
                {
                    return 2;
                }
                case ValuesX0.val4:
                {
                    return 4;
                }
                case ValuesX0.val8:
                {
                    return 8;
                }
                case ValuesX0.val16:
                {
                    return 16;
                }
                case ValuesX0.val32:
                {
                    return 32;
                }
                case ValuesX0.val64:
                {
                    return 64;
                }
                case ValuesX0.val128:
                {
                    return 128;
                }
                case ValuesX0.val256:
                {
                    return 256;
                }
                case ValuesX0.val512:
                {
                    return 512;
                }
                case ValuesX0.val1024:
                {
                    return 1024;
                }
                case ValuesX0.val1:
                {
                    return 1;
                }
                case ValuesX0.val3:
                {
                    return 3;
                }
                case ValuesX0.val5:
                {
                    return 5;
                }
                case ValuesX0.val7:
                {
                    return 7;
                }
                case ValuesX0.val9:
                {
                    return 9;
                }
                case ValuesX0.val11:
                {
                    return 11;
                }
                case ValuesX0.val13:
                {
                    return 13;
                }
                case ValuesX0.val17:
                {
                    return 17;
                }
                case ValuesX0.val19:
                {
                    return 19;
                }
                case ValuesX0.val23:
                {
                    return 23;
                }
                case ValuesX0.val29:
                {
                    return 29;
                }
                case ValuesX0.val31:
                {
                    return 31;
                }
                case ValuesX0.val33:
                {
                    return 33;
                }
                case ValuesX0.val37:
                {
                    return 37;
                }
                case ValuesX0.val41:
                {
                    return 41;
                }
                default: throw new Exception("Unknown value");
            }
        }
    }
}
