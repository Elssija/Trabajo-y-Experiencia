using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Tarea1._2_JairoAguilera.Ejc4
{
    public class Rectangulo
    {
        public float Xinicial { get; set; }
        public float Yinicial { get; set; }
        public float Xfinal { get; set; }
        public float Yfinal { get; set; }
        public Rectangulo()
        { 
            this.Xfinal = 0;
            this.Yfinal = 0;
            this.Xinicial = 0;
            this.Yinicial = 0;
        }

        public Rectangulo(float xinicial, float yinicial, float xfinal, float yfinal)
        {
            this.Xinicial = xinicial;
            this.Yinicial= yinicial;
            this.Xfinal = xfinal;
            this.Yfinal = yfinal;
        }

        public void Area ()
        {
            float area = (this.Xfinal-this.Xinicial)*(this.Yfinal-this.Yinicial);
            Console.WriteLine($"El area del rectangulo es: {area}");
        }
        public void Perimetro ()
        {
            float perimetro = 2 * ((this.Xfinal - this.Xinicial) + (this.Yfinal - this.Yinicial));
            Console.WriteLine($"El perimetro es: {perimetro}");
        }
        public void Diagonal ()
        {
            float diagonal =  MathF.Sqrt(MathF.Pow((this.Xfinal - this.Xinicial),2) + MathF.Pow((this.Yfinal - this.Yinicial),2));
            Console.WriteLine($"La diagonal del rectangulo es: {diagonal}");
        }
    }
}
