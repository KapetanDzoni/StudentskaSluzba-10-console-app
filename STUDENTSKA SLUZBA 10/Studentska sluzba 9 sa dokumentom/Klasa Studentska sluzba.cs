using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//DJOLE: napraviti posebnu klasu koja radi sa validacijama unosnih podataka, moja interpretacija njegovih reci
//DJOLE:poseban fajl sa metodama koje rade sa studentom
//DJOLE:posebna klasa i fajl koji rade sa skladistem podataka (baza, fajl, itd.)
//DJOLE:srediti validacije, ne rade na prvi pokusaj!

namespace Studentska_sluzba_9_sa_dokumentom
{
    public class StudentskaSluzba
    {

        
       static string nazivBaze = "baza.xml";
       static string relativnaLokacijaBaze = Path.Combine(Directory.GetCurrentDirectory(), nazivBaze);
       

        Fajl_metoda_koje_rade_sa_studentom fmkrss = new Fajl_metoda_koje_rade_sa_studentom();


        public static List<Student> listaUpisanihStudenata =UpisIIspisIzBaze.ucitajBazu(relativnaLokacijaBaze) ;
            
        
       

        public void kontrolniPanel()
        {
            Console.WriteLine("\nDobrodošli u studentsku službu!\n");
            Console.WriteLine("Odaberite jednu od opcija");
            Console.WriteLine("\n1. Želim da se upišem na fakultet");
            Console.WriteLine("2. Želim da vidim podatke upisanog studenta");
            Console.WriteLine("3. Želim da vidim brojeve indeksa svih upisanih studenata");
            Console.WriteLine("4. Želim da se ispišem sa fakulteta");
            Console.WriteLine("5. Želim da promenim podatke upisanog studenta");
            Console.WriteLine("\n15. Kraj rada");

            int odgovor = -1;

            do
            {
                while (!int.TryParse(Console.ReadLine(), out odgovor))
                {
                    Console.WriteLine("Morate uneti jedan od ponudjenih brojeva pored opcija a ne nešto random");
                }
                switch (odgovor)
                {
                    case 1:
                        {
                            //Console.WriteLine("UPIS");
                            Student s = fmkrss.upisiStudenta();
                            if (Validacije_podataka.proveraDaLiSuSviPodaciStudentaPopunjeni(s))
                            {
                                listaUpisanihStudenata.Add(s);
                                Console.WriteLine("\n\n       ČESTITAMO NA UPISU!\n");
                            }

                            else Console.WriteLine("\n\n     UPIS studenta nije uspeo");

                            daLiZeliteJosNesto();
                            break;
                        }
                    case 2:
                        {
                            fmkrss.zelimDaVidimPodatkeStudenta();
                            daLiZeliteJosNesto();
                            break;
                        }
                    case 3:
                        {
                            fmkrss.prikaziIndekseSvihUpisanihStudenata();
                            daLiZeliteJosNesto();
                            break;
                        }
                    case 4:
                        {
                            fmkrss.ispisiStudenta();
                            daLiZeliteJosNesto();
                            break;
                        }
                    case 5:
                        {
                            fmkrss.izmeniPodatkeStudenta();
                            daLiZeliteJosNesto();
                            break;
                        }
                    case 15:
                        {
                            Console.WriteLine("\nStudentska služba Vas pozdravlja\n");
                            UpisIIspisIzBaze.sacuvajUBazu(listaUpisanihStudenata, relativnaLokacijaBaze);
                            return;
                        }
                    case 10:
                        {
                            Console.WriteLine("\n     Lokacija foldera je "+ Directory.GetCurrentDirectory());
                            Console.WriteLine("\n     Lokacija baze je "+relativnaLokacijaBaze);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unesite jedan od ponudjenih brojeva a ne jedan od onih koji nisu ponudjeni\n ");
                            Console.WriteLine("1 2 3 4 5 ili 15\n");
                            break;
                        }

                }
            }while (odgovor!=1 && odgovor != 2 && odgovor != 3 && odgovor != 4 && odgovor!=5 && odgovor !=15);

            
            
            
        } // RADI
       
        public void daLiZeliteJosNesto()
        {
            Console.WriteLine("\n\n\n       Unesite da ako želite da se vratite u početni meni?");
            bool odg = daIliNe();
            if (odg) kontrolniPanel();
            else
            {
                Console.WriteLine("\n\n\n          Studentska služba Vas pozdravlja!\n");
                UpisIIspisIzBaze.sacuvajUBazu(listaUpisanihStudenata, relativnaLokacijaBaze);
            }

        }

        public bool daIliNe()
        {
           // Console.WriteLine("\nUnesite da ako želite\n");
            string odgovor = Console.ReadLine();
            if (odgovor == "Da"|| odgovor == "da" || odgovor == "dA" || odgovor=="DA") return true;
            else
            {
                 return false;
            }
        }

        


    }
}
