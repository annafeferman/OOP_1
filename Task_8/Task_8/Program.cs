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
                if (type == "realPart")
                {
                    return Re;
                }
                else { return Im; }
            }
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            MyComplex res = new MyComplex(a.Re + b.Re, a.Im + b.Im);
            return res;
        }

        public static MyComplex operator +(MyComplex a, double b)
        {
            MyComplex res = new MyComplex(a.Re + b, a.Im);
            return res;
        }
        public static MyComplex operator +(double b, MyComplex a)
        {
            {
                MyComplex res = new MyComplex(b + a.Re, a.Im);
                return res;
            }
        }
        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            {
                MyComplex res = new MyComplex(a.Re - b.Re, a.Im - b.Im);
                return res;
            }
        }
        public static MyComplex operator -(MyComplex a)
        {
            
            {
                MyComplex res = new MyComplex(a.Re * -1, a.Im * -1);
                return res;
            }
        }
        public static MyComplex operator *(MyComplex a, int i)
        {
            MyComplex res = new MyComplex(a.Re * i, a.Im);
            return res;
        }

        public void InputFromTerminal()
        {
            Re = IfValid("real part");
            Im = IfValid("image part");
        }
        private double IfValid(string text)
        {
            while (true)
            {
                Console.Write($"Input the {text} of your number: ");
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
            else
            {
                if(Im == 0)
                {
                    return $"{Re}";
                }
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

            Console.WriteLine($"Re(A) = {A["realPart"]}, Im(A) = {A["imaginaryPart"]}");
            Console.WriteLine($"Re(B) = {B["realPart"]}, Im(B) = {B["imaginaryPart"]}");
            Console.WriteLine($"Re(C) = {C["realPart"]}, Im(C) = {C["imaginaryPart"]}");
            Console.WriteLine($"Re(D) = {D["realPart"]}, Im(D) = {D["imaginaryPart"]}");
        }
    }
}
