using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@".\luke.jpg");

            //comienza pipe y filters

            

            PipeNull pNull = new PipeNull(); //3
            FilterNegative fNegative = new FilterNegative();
            PipeSerial pSerial = new PipeSerial(fNegative, pNull); //2
            FilterGreyscale fGreyscale = new FilterGreyscale();
            PipeSerial p2Serial = new PipeSerial(fGreyscale, pSerial); //1
            


            IPicture final= p2Serial.Send(picture);

            
            // En caso d eque haya problemas con el acceso al path, desabilitar antivirus.
            //parte 2 - Al usar los filtros Negative y Greyscale, se guarda la img. Código en esas clases.
            provider.SavePicture(final, @".\saved.jpg");


        }
    }
}
