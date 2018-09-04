﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Web.Enums;
using Lab1.Web.Models;

namespace Lab1.Web.Helpers
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

        public static VariantModel GetVariantModel(int variandId)
        {
            switch (variandId)
            {
                case 1:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow2to5),
                        C = GetValueC(ValuesC.val0),
                        M = GetValueM(ValuesM.Pow10),
                        X0 = GetValueX0(ValuesX0.val2),
                        Caption = "1) a = 2⁵; c = 0; m = 2¹⁰ - 1; X₀ = 2"
                    };
                }
                case 2:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow3to5),
                        C = GetValueC(ValuesC.val1),
                        M = GetValueM(ValuesM.Pow11),
                        X0 = GetValueX0(ValuesX0.val4),
                        Caption = "2) a = 3⁵; c = 1; m = 2¹¹ - 1; X₀ = 4"
                    };
                }
                case 3:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow4to5),
                        C = GetValueC(ValuesC.val2),
                        M = GetValueM(ValuesM.Pow12),
                        X0 = GetValueX0(ValuesX0.val8),
                        Caption = "3) a = 4⁵; c = 2; m = 2¹² - 1; X₀ = 8"
                    };
                }
                case 4:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow5to5),
                        C = GetValueC(ValuesC.val3),
                        M = GetValueM(ValuesM.Pow13),
                        X0 = GetValueX0(ValuesX0.val16),
                        Caption = "4) a = 5⁵; c = 3; m = 2¹³ - 1; X₀ = 16"
                    };
                }
                case 5:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow6to5),
                        C = GetValueC(ValuesC.val5),
                        M = GetValueM(ValuesM.Pow14),
                        X0 = GetValueX0(ValuesX0.val32),
                        Caption = "5) a = 6⁵; c = 5; m = 2¹⁴ - 1; X₀ = 32"
                    };
                }
                case 6:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow7to5),
                        C = GetValueC(ValuesC.val8),
                        M = GetValueM(ValuesM.Pow15),
                        X0 = GetValueX0(ValuesX0.val64),
                        Caption = "6) a = 7⁵; c = 8; m = 2¹⁵ - 1; X₀ = 64"
                    };
                }
                case 7:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow3to3),
                        C = GetValueC(ValuesC.val13),
                        M = GetValueM(ValuesM.Pow16),
                        X0 = GetValueX0(ValuesX0.val128),
                        Caption = "7) a = 3³; c = 13; m = 2¹⁶ - 1; X₀ = 128"
                    };
                }
                case 8:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow4to3),
                        C = GetValueC(ValuesC.val21),
                        M = GetValueM(ValuesM.Pow17),
                        X0 = GetValueX0(ValuesX0.val256),
                        Caption = "8) a = 4³; c = 21; m = 2¹⁷ - 1; X₀ = 256"
                    };
                }
                case 9:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow5to3),
                        C = GetValueC(ValuesC.val34),
                        M = GetValueM(ValuesM.Pow18),
                        X0 = GetValueX0(ValuesX0.val512),
                        Caption = "9) a = 5³; c = 34; m = 2¹⁸ - 1; X₀ = 512"
                    };
                }
                case 10:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow6to3),
                        C = GetValueC(ValuesC.val55),
                        M = GetValueM(ValuesM.Pow19),
                        X0 = GetValueX0(ValuesX0.val1024),
                        Caption = "10) a = 6³; c = 55; m = 2¹⁹ - 1; X₀ = 1024"
                    };
                }
                case 11:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow7to3),
                        C = GetValueC(ValuesC.val89),
                        M = GetValueM(ValuesM.Pow20),
                        X0 = GetValueX0(ValuesX0.val1),
                        Caption = "11) a = 7³; c = 89; m = 2²⁰ - 1; X₀ = 1"
                    };
                }
                case 12:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow8to3),
                        C = GetValueC(ValuesC.val144),
                        M = GetValueM(ValuesM.Pow21),
                        X0 = GetValueX0(ValuesX0.val3),
                        Caption = "12) a = 8³; c = 144; m = 2²¹ - 1; X₀ = 3"
                    };
                }
                case 13:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow9to3),
                        C = GetValueC(ValuesC.val233),
                        M = GetValueM(ValuesM.Pow22),
                        X0 = GetValueX0(ValuesX0.val5),
                        Caption = "13) a = 9³; c = 233; m = 2²² - 1; X₀ = 5"
                    };
                }
                case 14:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow10to3),
                        C = GetValueC(ValuesC.val377),
                        M = GetValueM(ValuesM.Pow23),
                        X0 = GetValueX0(ValuesX0.val7),
                        Caption = "14) a = 10³; c = 377; m = 2²³ - 1; X₀ = 7"
                    };
                }
                case 15:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow11to3),
                        C = GetValueC(ValuesC.val610),
                        M = GetValueM(ValuesM.Pow24),
                        X0 = GetValueX0(ValuesX0.val9),
                        Caption = "15) a = 11³; c = 610; m = 2²⁴ - 1; X₀ = 9"
                    };
                }
                case 16:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow12to3),
                        C = GetValueC(ValuesC.val987),
                        M = GetValueM(ValuesM.Pow25),
                        X0 = GetValueX0(ValuesX0.val11),
                        Caption = "16) a = 12³; c = 987; m = 2²⁵ - 1; X₀ = 11"
                    };
                }
                case 17:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow13to3),
                        C = GetValueC(ValuesC.val1597),
                        M = GetValueM(ValuesM.Pow26),
                        X0 = GetValueX0(ValuesX0.val13),
                        Caption = "17) a = 13³; c = 1597; m = 2²⁶ - 1; X₀ = 13"
                    };
                }
                case 18:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow14to3),
                        C = GetValueC(ValuesC.val2584),
                        M = GetValueM(ValuesM.Pow27),
                        X0 = GetValueX0(ValuesX0.val17),
                        Caption = "18) a = 14³; c = 2584; m = 2²⁷ - 1; X₀ = 17"
                    };
                }
                case 19:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow15to3),
                        C = GetValueC(ValuesC.val4181),
                        M = GetValueM(ValuesM.Pow28),
                        X0 = GetValueX0(ValuesX0.val19),
                        Caption = "19) a = 15³; c = 4181; m = 2²⁸ - 1; X₀ = 19"
                    };
                }
                case 20:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow16to3),
                        C = GetValueC(ValuesC.val6765),
                        M = GetValueM(ValuesM.Pow29),
                        X0 = GetValueX0(ValuesX0.val23),
                        Caption = "20) a = 16³; c = 6765; m = 2²⁹ - 1; X₀ = 23"
                    };
                }
                case 21:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow17to3),
                        C = GetValueC(ValuesC.val10946),
                        M = GetValueM(ValuesM.Pow30),
                        X0 = GetValueX0(ValuesX0.val29),
                        Caption = "21) a = 17³; c = 10946; m = 2³⁰ - 1; X₀ = 29"
                    };
                }
                case 22:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow7to5),
                        C = GetValueC(ValuesC.val17711),
                        M = GetValueM(ValuesM.Pow31Minus1),
                        X0 = GetValueX0(ValuesX0.val31),
                        Caption = "22) a = 7⁵; c = 17711; m = 2³¹ - 1; X₀ = 31"
                    };
                }
                case 23:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow2to16),
                        C = GetValueC(ValuesC.val28657),
                        M = GetValueM(ValuesM.Pow31),
                        X0 = GetValueX0(ValuesX0.val33),
                        Caption = "23) a = 2¹⁶; c = 28657; m = 2³¹; X₀ = 33"
                    };
                }
                case 24:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow2to15),
                        C = GetValueC(ValuesC.val46368),
                        M = GetValueM(ValuesM.Pow31Minus3),
                        X0 = GetValueX0(ValuesX0.val37),
                        Caption = "24) a = 2¹⁵; c = 46368; m = 2³¹ - 3; X₀ = 37"
                    };
                }
                case 25:
                {
                    return new VariantModel
                    {
                        A = GetValueA(ValuesA.Pow2to14),
                        C = GetValueC(ValuesC.val75025),
                        M = GetValueM(ValuesM.Pow31Minus7),
                        X0 = GetValueX0(ValuesX0.val41),
                        Caption = "25) a = 2¹⁴; c = 75025; m = 2³¹ - 7; X₀ = 41"
                    };
                }
                default: throw new Exception("Unknown variant.");
            }
        }
    }
}
