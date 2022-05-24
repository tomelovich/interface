using System;

namespace Z_1
{
    interface Ix
    {
        void IxF0(int xKey);
        void IxF1();
    }
    interface Iy
    {
        void F0(int xKey);
        void F1();
    }
    interface Iz
    {
        void F0(int xKey);
        void F1();
    }
    interface Iw
    {
        void F0(int xKey);
        void F1();
    }
    class TestClass: Ix, Iy, Iz, Iw
    {
        public int xVal;
        public TestClass()
        {
            xVal = 125;
        }
        public TestClass(int key)
        {
            xVal = key;
        }
        public void IxF0(int key)
        {
            xVal = key * 10;
            Console.WriteLine("IxF0({0})...",xVal);
        }
        public void IxF1()
        {
            xVal = xVal * 10;
            Console.WriteLine("IxF0({0})...", xVal);
        }
        public void F0 (int xKey)
        {
            xVal = (int)xKey - 10;
            Console.WriteLine("(Iy/ Iz)F0({0})...", xVal);
        }
        public void F1()
        {
            xVal = xVal - 10;
            Console.WriteLine("(Iy/ Iz)F0({0})...", xVal);
        }
        void Iw.F0(int xKey)
        {
            xVal = xKey / 10;
            Console.WriteLine("Iw.F0({0})...", xVal);
        }
        void Iw.F1()
        {
            xVal = xVal / 10;
            Console.WriteLine("Iw.F1({0})...", xVal);
        }
        public void bF0()
        {
            Console.WriteLine("bF0()...");
        }
    }
    class Class1
    {
        static void Main(string[] args)
        {
            TestClass x0 = new TestClass();
            TestClass x1 = new TestClass(5);
            x0.bF0();
            x0.IxF0(10);
            x1.IxF1();
            x0.F0(5);
            x1.F1();
            (x0 as Iy).F0(7);
            (x1 as Iz).F1();
            Console.WriteLine("==========Prism test==========");
            Console.WriteLine("==========Ix==========");
            Ix ix = x1;
            ix.IxF0(5);
            ix.IxF1();
            Console.WriteLine("==========Iy==========");
            Iy iy = x1;
            iy.F0(5);
            iy.F1();
            Console.WriteLine("==========Iz==========");
            Iz iz = x1;
            iz.F0(5);
            iz.F1();
            Console.WriteLine("==========Iw==========");
            Iw iw = (Iw)x1;
            iw.F0(10);
            iw.F1();
        }
    }
}
