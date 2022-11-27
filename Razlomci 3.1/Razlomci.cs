using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razlomci_3._1
{
    public class Razlomci
    {

        int br, im; // atributi brojilac i imenilac 

        #region konstruktori
        public Razlomci() //podrazumevani konstruktor 
        {
            br = 0;
            im = 1;
        }
        public Razlomci(int a)
        {
            br = a;
            im = 1;
        }
        public Razlomci(int a, int b)
        {
            br = a;
            im = b;
            if (im == 0) im = 1;
            else if (im < 0) { br = -br; im = -im; }
            skrati();
        }
        public Razlomci(string s)
        {
            int poz = s.IndexOf('/');

            if (poz != -1)
            {
                br = int.Parse(s.Substring(0, poz));
                im = int.Parse(s.Substring(poz + 1));
                skrati();
            }
            else
            {
                br = int.Parse(s);
                im = 1;
            }
        }
        #endregion
        #region metode za skracivanje i ispis razlomka
        public void skrati()
        {
            int d = 2;
            while (Math.Abs(br) >= d && Math.Abs(im) >= d)
            {
                if (br % d == 0 && im % d == 0)
                {
                    br /= d;
                    im /= d;
                }
                else
                    d++;
            }
        }
        public void skrati2()
        {
            int a, b, pom;
            a = Math.Abs(br);
            b = Math.Abs(im);
            while (b != 0)
            {
                pom = b;
                b = a % b;
                a = pom;
            }
            br /= a;// a=nzd(a,b) 
            im /= a;
        }
        public string ispis()
        {
            if (br == 0) return "0";
            if (im == 1) return br + "";
            if (br > 0) return br + "/" + im;
            else return "(" + br + "/" + im + ")";
        }
        #endregion
        #region operacije sa razlomcima
        public Razlomci reciprocni()
        {
            if (br > 0) return new Razlomci(im, br);
            else return new Razlomci(-im, -br);
        }
        public Razlomci saberi(Razlomci B)
        { return new Razlomci(this.br * B.im + this.im * B.br, this.im * B.im); }
        public Razlomci oduzmi(Razlomci B)
        { return new Razlomci(this.br * B.im - this.im * B.br, this.im * B.im); }
        public Razlomci pomnozi(Razlomci B)
        { return new Razlomci(this.br * B.br, this.im * B.im); }
        public Razlomci podeli(Razlomci B)
        {
            return this.pomnozi(B.reciprocni());
        }
        #endregion
        #region Operatori
        public static Razlomci operator +(Razlomci a, Razlomci b)
        {
            return new Razlomci(a.br * b.im + b.br * a.im, a.im * b.im);
        }
        public static Razlomci operator +(Razlomci a, int b)
        {
            return new Razlomci(a.br + b * a.im, a.im);
        }
        public static Razlomci operator +(int b, Razlomci a)
        {
            return new Razlomci(a.br + b * a.im, a.im);
        }
        public static Razlomci operator -(Razlomci a, int b)
        {
            return new Razlomci(a.br - b * a.im, a.im);
        }
        public static Razlomci operator -(int b, Razlomci a)
        {
            return new Razlomci(a.br - b * a.im, a.im);
        }
        public static Razlomci operator -(Razlomci a, Razlomci b)
        {
            return new Razlomci(a.br * b.im - b.br * a.im, a.im * b.im);
        }
        public static Razlomci operator ~(Razlomci a)
        {
            return new Razlomci(a.im, a.br);
        }
        public static Razlomci operator * (Razlomci a, Razlomci b)
        {
            return new Razlomci(a.br*b.br, a.im*b.im);
        }
        public static Razlomci operator * (Razlomci a, int b)
        {
            return new Razlomci(a.br * b, a.im);
        }
        public static Razlomci operator *(int a, Razlomci b)
        {
            return new Razlomci(b.br * a, b.im);
        }
        public static Razlomci operator /(Razlomci a, Razlomci b)
        {
            return a * ~b;
        }
        public static Razlomci operator /(int a, Razlomci b)
        {
            return new Razlomci(b.br, b.im * a);
        }
        public static Razlomci operator /(Razlomci a, int b)
        {
            return new Razlomci(a.br, a.im * b);
        }
        public static implicit operator Razlomci(int i)
        {
            return new Razlomci(i, 1);
        }
        public static explicit operator double(Razlomci r)
        {
            return (double)r.br / r.im;
        }
        public static bool operator >(Razlomci a,Razlomci b)
        { return a.br*b.im > b.br*a.im;}
        public static bool operator <(Razlomci a, Razlomci b)
        { return a.br * b.im < b.br * a.im; }
        #endregion
    }
}
