using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOperators
{
    class Program
    {
        public class Complex
        {
            public int UNum, DNum; //UNum - числит., DNum - знамен. 
            //Конструктор
            public Complex(int _UNum, int _DNum)
            {
                this.UNum = _UNum;
                this.DNum = _DNum;
            }
            //Новый оператор


            // оператор + _________________________________________________________________________________________
            public static Complex operator +(Complex FirstComplex, Complex SecondComplex)
            {
                if (FirstComplex.DNum != SecondComplex.DNum)
                {
                    int Temp;
                    Temp = FirstComplex.DNum;
                    FirstComplex.UNum *= SecondComplex.DNum;
                    FirstComplex.DNum *= SecondComplex.DNum;
                    SecondComplex.DNum *= Temp;
                    SecondComplex.UNum *= Temp;
                    Complex TEMP = new Complex(FirstComplex.UNum + SecondComplex.UNum, FirstComplex.DNum);
                    while (TEMP.DNum != 0 && TEMP.UNum != 0)
                    {
                        if (TEMP.DNum > TEMP.UNum)
                            TEMP.DNum %= TEMP.UNum;
                        else
                            TEMP.UNum %= TEMP.DNum;
                    }
                    Complex Result = new Complex((FirstComplex.UNum + SecondComplex.UNum) / (TEMP.DNum + TEMP.UNum), FirstComplex.DNum / (TEMP.DNum + TEMP.UNum));
                    return Result;
                }
                Complex ResultElse = new Complex(FirstComplex.UNum + SecondComplex.UNum, FirstComplex.DNum);
                return ResultElse;
            }
            // оператор + ____________________________________________________________________________________________



            // оператор - ____________________________________________________________________________________________
            public static Complex operator -(Complex FirstComplex, Complex SecondComplex)
            {
                if (FirstComplex.DNum != SecondComplex.DNum)
                {
                    int Temp;
                    Temp = FirstComplex.DNum;
                    FirstComplex.UNum *= SecondComplex.DNum;
                    FirstComplex.DNum *= SecondComplex.DNum;
                    SecondComplex.DNum *= Temp;
                    SecondComplex.UNum *= Temp;
                    Complex TEMP = new Complex(FirstComplex.UNum - SecondComplex.UNum, FirstComplex.DNum);
                    Console.WriteLine(FirstComplex.UNum);
                    Console.WriteLine(SecondComplex.UNum);
                    while (TEMP.DNum != 0 && TEMP.UNum != 0)
                    {
                        if (TEMP.DNum > TEMP.UNum)
                            TEMP.DNum %= TEMP.UNum;
                        else
                            TEMP.UNum %= TEMP.DNum;
                    }
                    Complex Result = new Complex((FirstComplex.UNum - SecondComplex.UNum) / Math.Abs(TEMP.DNum + TEMP.UNum), FirstComplex.DNum / Math.Abs(TEMP.DNum + TEMP.UNum));
                    return Result;
                }
                Complex ResultElse = new Complex(FirstComplex.UNum - SecondComplex.UNum, FirstComplex.DNum);
                return ResultElse;
            }
            // оператор - ____________________________________________________________________________________________



            // оператор / ____________________________________________________________________________________________
            public static Complex operator /(Complex FirstComplex, Complex SecondComplex)
            {
                Complex TEMP = new Complex(FirstComplex.UNum * SecondComplex.DNum, FirstComplex.DNum * SecondComplex.UNum);
                while (TEMP.DNum != 0 && TEMP.UNum != 0)
                {
                    if (TEMP.DNum > TEMP.UNum)
                        TEMP.DNum %= TEMP.UNum;
                    else
                        TEMP.UNum %= TEMP.DNum;
                }
                Complex Result = new Complex(((FirstComplex.UNum * SecondComplex.DNum) / Math.Abs(TEMP.DNum + TEMP.UNum)), (FirstComplex.DNum * SecondComplex.UNum) / Math.Abs(TEMP.DNum + TEMP.UNum));
                return Result;
            }

            // оператор / ____________________________________________________________________________________________


            public static Complex operator *(Complex FirstComplex, Complex SecondComplex)
            {
                Complex Result = new Complex(FirstComplex.UNum * SecondComplex.UNum, FirstComplex.DNum * SecondComplex.DNum);
                Complex Temp = new Complex(FirstComplex.UNum * SecondComplex.UNum, FirstComplex.DNum * SecondComplex.DNum);
                while (Temp.DNum != 0 && Temp.UNum != 0)
                {
                    if (Temp.DNum > Temp.UNum)
                        Temp.DNum %= Temp.UNum;
                    else
                        Temp.UNum %= Temp.DNum;
                }
                Complex res = new Complex(Result.DNum / (Temp.UNum + Temp.DNum), Result.UNum / (Temp.UNum + Temp.DNum));
                return res;
            }





            //Перегрузка для вывода Класса Complex
            public override string ToString()
            {
                if (DNum == 1)
                    return UNum + "";
                return UNum + "/" + DNum;
            }
        }
        static void Main(string[] args)
        {
            Complex FirstPair = new Complex(1, 2);
            Complex SecondPair = new Complex(1, 4);
            Complex Res = FirstPair * SecondPair;
            Console.WriteLine(Res);
            Console.ReadKey();
        }
    }
}
