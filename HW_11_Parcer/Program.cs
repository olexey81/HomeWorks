using HW_11_Generator;

namespace HW_11_Parcer
{
    internal class Program
    {
        static void Main()
        {

            var fr = new FileReader();
            fr.OpenFile();

            var js = new Serializer(fr.Cities);
            js.JSFileCreator();

            //Console.WriteLine(fc.Cities.Equals(js.JSFileReader()));
        }
    }
} 