using System;

namespace Task_8
{
    class MyComplex
    {
        private double Re;
        private double Im;

        public MyComplex(Double InitRe = 0, Double InitIm = 0)
        {
            Re = InitRe;
            Im = InitIm;
        }
        public double this[string type]
        {
            get
            {
                if (type == "realValue")
                {
                    return Re;
                }
                else { return Im; }
            }
            set
            {

            }
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re + b.Re;
            res.Im = a.Im + b.Im;
            return res;
        }

        public static MyComplex operator +(MyComplex a, double b)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re + b;
            res.Im = a.Im;
            return res;
        }
        public static MyComplex operator +(double b, MyComplex a)
        {
            MyComplex res = new MyComplex
            {
                Re = a.Re + b,
                Im = a.Im
            };
            return res;
        }

        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            MyComplex res = new MyComplex
            {
                Re = a.Re - b.Re,
                Im = a.Im - b.Im
            };
            return res;
        }
        public static MyComplex operator -(MyComplex a)
        {
            MyComplex res = new MyComplex
            {
                Re = a.Re * -1,
                Im = a.Im
            };
            return res;
        }
        public static MyComplex operator *(MyComplex a, int i)
        {
            MyComplex res = new MyComplex();
            res.Re = a.Re * i;
            res.Im = a.Im;
            return res;
        }

        public void InputFromTerminal()
        {
            Re = IfValid("Real part");
            Im = IfValid("Image part");
        }
        private double IfValid(string text)
        {
            while (true)
            {
                Console.Write($"Input {text} your number: ");
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public override string ToString()
        {
            if (Im > 0)
            {
                return $"{Re}+{Im}i";
            }

            return $"{Re}{Im}i";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyComplex A = new MyComplex(1, 1);
            MyComplex B = new MyComplex();
            MyComplex C = new MyComplex(1);
            MyComplex D = new MyComplex();

            C = A + B;
            C = A + 10.5;
            C = 10.5 + A;
            D = -C;
            C = A + B + C + D;
            C = A = B = C;

            D.InputFromTerminal();

            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");

            Console.WriteLine($"Re(A) = {A["realValue"]}, Im(A) = {A["imaginaryValue"]}");
            Console.WriteLine($"Re(B) = {B["realValue"]}, Im(B) = {B["imaginaryValue"]}");
            Console.WriteLine($"Re(C) = {C["realValue"]}, Im(C) = {C["imaginaryValue"]}");
            Console.WriteLine($"Re(D) = {D["realValue"]}, Im(D) = {D["imaginaryValue"]}");
        }
    }
}
