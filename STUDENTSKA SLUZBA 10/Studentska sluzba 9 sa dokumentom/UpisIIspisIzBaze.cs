using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Studentska_sluzba_9_sa_dokumentom
{
      internal static class UpisIIspisIzBaze
    {
       
        public static void sacuvajUBazu( List<Student> listaStudenata, string lokacijaBaze)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                using (TextWriter writer = new StreamWriter(lokacijaBaze))
                {
                    serializer.Serialize(writer, listaStudenata);
                }
                Console.WriteLine("\nBAZA JE SAČUVANA\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDošlo je do greške prilikom čuvanja baze: " + ex.Message + "\n");
            }
        }
        public static List<Student> ucitajBazu(string lokacijaBaze)
        {
            List<Student> listaStudenata = new List<Student>();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                using (TextReader reader = new StreamReader(lokacijaBaze))
                {
                    listaStudenata = (List<Student>)serializer.Deserialize(reader);
                }
                Console.WriteLine("\n       BAZA JE UČITANA\n");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\n       BAZA NIJE PRONADJENA");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDošlo je do greške tokom učitavanja baze: " + ex.Message + "\n");
            }
            return listaStudenata;
        }

    }
}
