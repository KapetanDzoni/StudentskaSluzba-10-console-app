using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace Studentska_sluzba_9_sa_dokumentom
{
    internal class Fajl_metoda_koje_rade_sa_studentom
    {


        //List<Student> listaUpisanihStudenata = new List<Student>();

        public Student upisiStudenta()
        {
            Student s1 = new Student();

            Console.WriteLine("\nDobrodošli na upis\n");

            Console.WriteLine("\nImajte u vidu da ćete imati po 3 puta priliku da unesete prihvatljiv odgovor");
            Console.WriteLine("Ako u jednom momentu više od 3 puta pogrešite, biće Vam ponudjeno da se vratite u početni meni\n\n");

            {
                string imeStudenta = unosImena();
                if (Validacije_podataka.proveraImenaIPrezimena(imeStudenta))
                {
                    s1.ImeIPrezime = imeStudenta;
                    Console.WriteLine("\n       Ime studenta je prihvaćeno i upisano kao:" + s1.ImeIPrezime);
                }
                else
                {
                    throw new Exception("\n       Uneto ime nije prihvaćeno");

                }
            }  //1. unos imena studenta                  // RADI

            {
                string imeRoditelja = unosImenaRoditelja();
                if (Validacije_podataka.proveraImenaRoditelja(imeRoditelja))
                {
                    s1.ImeRoditelja = imeRoditelja;
                    Console.WriteLine("\n       Ime roditelja je prihvaćeno i sačuvano kao:" + s1.ImeRoditelja);
                }
                else
                {
                    throw new Exception("\n     Ime roditelja NIJE prihaćeno");

                }
            }  //2. unos imena jednog roditelja          //RADI

            {
                string opstinaRodjenja = unosOpstineRodjenja();
                if (Validacije_podataka.proveraMesta(opstinaRodjenja))
                {
                    s1.OpstinaRodjenja = opstinaRodjenja;
                    Console.WriteLine("\nMesto rodjenja je prihvaćeno i sačuvano kao: " + s1.OpstinaRodjenja);
                }
                else
                {
                    throw new Exception("\n     Opština rodjenja NIJE prihvaćena");

                }

            }  //3. unos grada rodjenja                  //RADI

            {
                DateOnly datumRodjenja;

                datumRodjenja = unosDatumaRodjenja();
                if (Validacije_podataka.daLiJeDatumRodjenjaPrihvatljiv(datumRodjenja))
                {
                    s1.DatumRodjenja = datumRodjenja;
                    Console.WriteLine("\n       Datum rodjenja je prihvaćen. Upisana vrednost je:" + s1.DatumRodjenja);
                }
                else
                {
                    throw new Exception("\n       Datum rodjenja NIJE prihvaćen");

                }
            }  //4. unos datuma rodjenja                 //RADI  

            {
                string drzavaRodjenja = unosDrzaveRodjenja();

                if (Validacije_podataka.proveraDrzaveRodjenja(drzavaRodjenja))
                {
                    s1.DrzavaRodjenja = drzavaRodjenja;
                    Console.WriteLine("\n       Država rodjenja je prihvaćena i upisana kao:" + s1.DrzavaRodjenja);
                }
                else
                {
                    throw new Exception("\n       Država rodjenja NIJE prihvaćena");

                }

            }  //5. unos drzave rodjenja                //RADI!!!!        

            {
                //Console.WriteLine("\n5. Unesite svoj JMBG:");

                string unos = unosJMBG();
                if (Validacije_podataka.proveraUnosJMBG(unos))
                {
                    s1.Jmbg = unos;
                    Console.WriteLine("\n       Unos JMBG je uspeo, sačuvan podatak je :" + s1.Jmbg);
                }
                else
                {
                    throw new Exception("\n       Unos JMBG NIJE uspeo");

                }

            }  //6. unos JMBG                           //RADI!!!   

            {
                string drzavljanstvo = unosDrzavljanstva();

                if (Validacije_podataka.proveraDrzavljanstva(drzavljanstvo))
                {
                    s1.Drzavljanstvo = drzavljanstvo;
                    Console.WriteLine("\n       Državljanstvo je prihvaćeno i sačuvano kao:" + s1.Drzavljanstvo);
                }

                else
                {
                    throw new Exception("\n       Unos državljanstva NIJE uspeo");

                }


            }  //7. unos drzavljanstva                  //RADI!!!

            {
                string vrstaStudija = odabirVrsteStudija();

                if (Validacije_podataka.proveraOdabiraVrsteStudija(vrstaStudija))
                {
                    s1.VrstaStudija = vrstaStudija;
                    Console.WriteLine("\n       Vrsta studija je prihvaćena. Upisali ste :" + s1.VrstaStudija);
                }
                else
                {
                    throw new Exception("     Vrsta studija NIJE odabrana");

                }

            }  // 8. odabir vrste studija               //RADI

            {
                string smer = odabirSmera();
                if (Validacije_podataka.proveraOdabiraSmera(smer))
                {
                    s1.Smer = smer;
                    Console.WriteLine("\n       Odabrani smer je :" + s1.Smer);
                }
                else
                {
                    throw new Exception("\n       Smer NIJE odabran");

                }

            }  //9. odabir smera                        //RADI                

            {
                string indeks = unosBrojaIndeksa();

                if (Validacije_podataka.proveraFormataIndeksa(indeks) && 
                    Validacije_podataka.daLiSmeDaSeKoristiTajBrojIndeksa(indeks))
                {
                    s1.BrojIndeksa = indeks;
                    Console.WriteLine("\n       Broj indeksa je prihvaćen i upisan kao:" + s1.BrojIndeksa);
                }
                else
                {
                    throw new Exception("\n       Broj indeksa NIJE prihvaćen");

                }

            } //10. dodela broja indeksa
              //
            {
                DateOnly danasnjiDatum = DateOnly.FromDateTime(DateTime.Today);
                s1.DatumUpisa = danasnjiDatum;
                Console.WriteLine("\n       Datum upisa je :" + s1.DatumUpisa);



            } //11. dodela datuma upisa             




            return s1; //AKO JE STUDENT POPUNIO SVE PODATKE ISPRAVNO, ZADNJA


        } 
     
        public string odabirVrsteStudija() 
        {

            int brojacPokusajaVrsteStudija = 0;
            string odgovor;
            string vracam = "Nista";
            do
            {
                Console.WriteLine("\nUnesite broj pored vrste studija koje želite da upišete:");
                Console.WriteLine("\n1. Osnovne akademske studije\n2. Master studije\n3. Doktorske studije\n4. Specijalističke studije\n");
                odgovor = Console.ReadLine();
                brojacPokusajaVrsteStudija++;

            } while ((odgovor != "1" && odgovor != "2" && odgovor != "3" && odgovor != "4") && brojacPokusajaVrsteStudija < 3);
            if (odgovor == "1")
            {
                vracam = "Osnovne akademske studije";
            }
            if (odgovor == "2")
            {
                vracam = "Master studije";
            }
            if (odgovor == "3")
            {
                vracam = "Doktorske studije";
            }
            if (odgovor == "4")
            {
                vracam = "Specijalističke studije";
            }
            if (brojacPokusajaVrsteStudija >= 3)
            {
                Console.WriteLine("Ovo vam je treći put da pokušavate, stvarno nije ok, vraćam vas u početni meni");
                return vracam;
            }
            
            
            return vracam;
        } // RADI, ako 3 puta ne odabers sta treba izbacuje te

        public string unosImena()
        {
            int brojac = 0;
            string imeStudenta;
            string[] delovi;
            do
            {
                Console.WriteLine("\nUnesite svoje ime i prezime\n");
                Console.WriteLine("Imajte u vidu da prihvatamo samo jedno ime i jedno prezime i da ni jedno ni drugo ne može sadržati brojeve\n");
                imeStudenta = Console.ReadLine();
                brojac++;
                delovi = imeStudenta.Split(' ');
            } while (!Validacije_podataka.proveraImenaIPrezimena(imeStudenta) && brojac<3 );
            
            if (brojac==3)
            {
                Console.WriteLine("\n Ako iz 3 puta ne možete da ubodete da unesete svoje ime da li bi trebali da studirate?");
            }
            
            
            return promeniPrvoMaloSlovoUVeliko(imeStudenta);
        } 

        public string unosImenaRoditelja()
        {
            int brojac = 0;
            string unos = " ";
            do
            {
                Console.WriteLine("\nUnesite ime jednog roditelja. Ime roditelja mora biti jedna reč, sastavljena samo od slova");
                unos = Console.ReadLine();
               // unos = promeniPrvoMaloSlovoUVeliko(unos);
                brojac++;
            } while (!Validacije_podataka.proveraImenaRoditelja(unos) && brojac < 3);
            if (brojac == 3)
            {
                Console.WriteLine("\nAko iz 3 pokušaja ne možete da pravilno unesete ime jednog roditelja... Da li bi trebalo da studirate?");
            }
            return promeniPrvoMaloSlovoUVeliko(unos);
        }

        public string promeniPrvoMaloSlovoUVeliko(string uneto) 
        {
            string[] delovi = uneto.Split(' ');
            char prvoSlovo = delovi[0][0];
            

            if (char.IsLower(prvoSlovo)) {
                prvoSlovo = char.ToUpper(prvoSlovo);
            }
            string vrati = prvoSlovo+delovi[0].Substring(1);

            for (int i = 1;i<delovi.Length; i++)
            {
                vrati = vrati + " ";

                 prvoSlovo = delovi[i][0];
                if (char.IsLower(prvoSlovo))
                {
                    Console.WriteLine("Prvo slovo treba da bude veliko. Promenili smo ga ... da se ne sramotite ");
                    prvoSlovo = char.ToUpper(prvoSlovo);
                }
                vrati = vrati+ prvoSlovo + delovi[i].Substring(1);
                 

            }
            return vrati;
           
        } // sada menja samo prvo slovo u veliko, trebalo bi da menja svako malo slovo nakon spejsa u veliko

        public string unosOpstineRodjenja()
        {
            string uneto;
            int brojac = 0;
            do
            {
                Console.WriteLine("\nUnesite opštinu rodjenja");
                uneto = Console.ReadLine();
                
                brojac++;
            }while (!Validacije_podataka.proveraMesta(uneto) && brojac < 3);
            if (brojac == 3) { Console.WriteLine("\nOpet niste uspeli iz treće"); }
           
            return promeniPrvoMaloSlovoUVeliko(uneto);
        }

        public DateOnly unosDatumaRodjenja ()
        {
            int brojac = 0;
            string unos = "";
            DateOnly datum = default;
            do
            {
                Console.WriteLine("\nUnesite svoj datum rodjenja u formatu : dd.mm.gggg.");
                Console.WriteLine("gggg je godina rodjenja, 4 cifre, mm je mesec 2 cifre, dd je dan 2 cifre, izmedju je tačka");

                unos = Console.ReadLine();
                if (Validacije_podataka.unesiDatumRodjenjaDDMMGGG(unos))
                {
                    datum= napraviDatumOdString(unos);
                    
                }

                brojac++;
            } while (!Validacije_podataka.daLiJeDatumRodjenjaPrihvatljiv(datum) && brojac<3); 

            if (brojac == 3)
            {
                Console.WriteLine("\nImali ste svoja 3 pokušaja da unesete datum kako treba");
                
            }
            return datum;

        }

        public DateOnly napraviDatumOdString(string unos)
        {
            DateOnly datum = default;
            DateOnly datum2 = default;
            

            DateOnly.TryParseExact(unos, "dd.MM.yyyy.", null, System.Globalization.DateTimeStyles.None, out datum);
            
            if (datum==datum2)
            {
                Console.WriteLine("\nDatum koji ste uneli nikada nije postojao u novoj eri");
            }
            return datum;
        }

        public string unosDrzaveRodjenja ()
        {
            string unos = "";
            int brojac = 0;
            do
            {
                Console.WriteLine("\nUnesite državu rodjenja:");
                unos = Console.ReadLine();
                brojac++;
                unos = promeniPrvoMaloSlovoUVeliko(unos);
                if (!Validacije_podataka.proveraDrzaveRodjenja(unos))
                {
                    Console.WriteLine("\nNije prihvaćena");
                }
            } while (!Validacije_podataka.proveraDrzaveRodjenja(unos) && brojac < 3);

            if(brojac == 3) { Console.WriteLine("\nImali ste 3 pokušaja"); }


            return unos;
        } // ako uneses malim slovom srbija nece prihvatiti, mora velikim

        public string unosJMBG()
        {
            string jmbg = "";
            int brojac = 0;
            do
            {
                Console.WriteLine("\nUnesite svoj JMBG:");
                Console.WriteLine("JMBG je pozitivan broj ima 13 cifara i mora biti tačan");
                 jmbg = Console.ReadLine();
             
                if (!Validacije_podataka.proveraUnosJMBG(jmbg))
                {
                    Console.WriteLine("\nJMBG nije prošao kontrolu");
                }
                brojac++;
            } while (!Validacije_podataka.proveraUnosJMBG(jmbg) && 
                      brojac<3 &&
                      !Validacije_podataka.daLiSmeDaSeKoristiTajJMBG(jmbg));
           
            return jmbg;
        }

        public string unosDrzavljanstva()
        {
            int brojac = 0;
            string unos = "";

            do
            {
                Console.WriteLine("\nUnesite svoje državljanstvo. Molim vas bez brojeva...");
                unos = Console.ReadLine();
                brojac++;
            } while (!Validacije_podataka.proveraDrzavljanstva(unos) && brojac<3);

            string vrati = promeniPrvoMaloSlovoUVeliko(unos);
            return vrati;
        }

        public string odabirSmera() 
        {

            string izbor = "";
            int brojac = 0;
            do
            {
                Console.WriteLine("\nKoji smer želite da odaberete:");
                Console.WriteLine("\n1. Informacioni sistemi i tehnologije\n2. Menadžment\n3. Kontrola kvaliteta \n4. Operacioni menadžment");
                izbor = Console.ReadLine();
                brojac++;
            } while (izbor != "1" && izbor != "2" && izbor != "3" && izbor != "4" && (brojac < 3));
            
            
            if (brojac == 3)
            {
                Console.WriteLine("\nImali ste 3 pokušaja");
            }
            
            string vracam = "Nista";
            if (izbor == "1")
            {
                vracam = "Informacioni sistemi i tehnologije";
            }
            if (izbor == "2")
            {
                vracam = "Menadžment";
            }
            if (izbor == "3")
            {
                vracam = "Kontrola kvaliteta";
            }
            if (izbor == "4")
            {
                vracam = "Operacioni menadžment";
            }
            return vracam;
        }

        public string unosBrojaIndeksa ()
        {
            string unos = "";
            int brojac = 0;
            do
            {
                Console.WriteLine("\nUnesite svoj broj indeksa, recimo 0004/1999 gde je broj posle / godina upisa");
                unos = Console.ReadLine();

                brojac++;
            } while (!Validacije_podataka.proveraFormataIndeksa(unos) && 
                    brojac < 3 && 
                    !Validacije_podataka.daLiSmeDaSeKoristiTajBrojIndeksa(unos) );

            if (brojac == 3)
            {
                Console.WriteLine("\nImali ste 3 pokušaja");
            }
            return unos;
        }

        public void prikaziPodatkeStudenta(Student s) // SLJAKA
        {
            Console.WriteLine("\nPodaci studenta \n\n");
            Console.WriteLine("1. Vrsta studija:" + s.VrstaStudija);
            Console.WriteLine("2. Smer:" + s.Smer);
            Console.WriteLine("3. Broj indeksa:" + s.BrojIndeksa);
            Console.WriteLine("4. Ime i prezime:" + s.ImeIPrezime);
            Console.WriteLine("5. Ime jednog roditelja:" + s.ImeRoditelja);
            Console.WriteLine("6. JMBG:" + s.Jmbg);
            Console.WriteLine("7. Mesto rodjenja:" + s.OpstinaRodjenja);
            Console.WriteLine("8. Država rodjenja:" + s.DrzavaRodjenja);
            Console.WriteLine("9. Državljanstvo:" + s.Drzavljanstvo);
            Console.WriteLine("10. Datum rodjenja :" + s.DatumRodjenja);
            Console.WriteLine("11. Datum upisa:" + s.DatumUpisa);
        }

        public Student pronadjiStudenta(string indeks) //RADI
        {
            foreach (Student tekuci in StudentskaSluzba.listaUpisanihStudenata)
            {
                if (tekuci.BrojIndeksa == indeks)
                {
                    return tekuci;
                }
            }
            return null;
        }
        public void zelimDaVidimPodatkeStudenta() //RADI
        {
           // Console.WriteLine("\nZelite da vidite podatke upisanog studenta");
            string indeks = "";
            
                Console.WriteLine("\nImate 3 pokušaja da unesete indeks u formatu 0005/2023");
                 indeks = unosBrojaIndeksa();
                if (!Validacije_podataka.proveraFormataIndeksa(indeks))
            {
                return;
            }

            Student temp = pronadjiStudenta(indeks);

            if (Validacije_podataka.daLiJeStudentPronadjen(temp))
            {
                prikaziPodatkeStudenta(temp);
            };

        }

        public void prikaziIndekseSvihUpisanihStudenata()
        {
            if (StudentskaSluzba.listaUpisanihStudenata.Count == 0)
            {
                Console.WriteLine("\nTrenutno nema upisanih studenata na fakultet");
            }
            else
            {
                Console.WriteLine("\nIspod su indeksi svih upisanih studenata\n");
                int brojac = 1;
                foreach (Student student in StudentskaSluzba.listaUpisanihStudenata)
                {
                    Console.WriteLine(brojac + ". " + student.BrojIndeksa);
                    brojac++;
                }
            }

        } //RADI

        public void ispisiStudenta()
        {
            Console.WriteLine("\nIspisivanje studenta:\n");

            string indeks = unosBrojaIndeksa();
            if (Validacije_podataka.proveraFormataIndeksa(indeks))
            {
                Student temp = pronadjiStudenta(indeks);
                if (Validacije_podataka.daLiJeStudentPronadjen(temp))
                {
                    StudentskaSluzba.listaUpisanihStudenata.Remove(temp);
                    Console.WriteLine("\n       Student je ispisan\n");
                }
            }
            
        } //RADI

        public void izmeniPodatkeStudenta()
        {
            Console.WriteLine("\nUnesite broj indeksa studenta čije podatke želite da promenite\n");
            string indeks = unosBrojaIndeksa();
            if (Validacije_podataka.proveraFormataIndeksa(indeks))
            {
                Student trazeni = pronadjiStudenta(indeks);
                if (Validacije_podataka.daLiJeStudentPronadjen(trazeni))
                {
                    string odgovorcic = "";

                    do
                    {
                        prikaziPodatkeStudenta(trazeni);
                        Console.WriteLine("\nUnesite da ako želite da izmenite neki od podataka");
                        odgovorcic = Console.ReadLine();
                        if (odgovorcic == "da") zapocniIzmenuPodatakaStudenta(trazeni);
                    } while (odgovorcic == "da");
                }
            }
        } //RADI

        public void zapocniIzmenuPodatakaStudenta(Student s)
        {
            int brojac = 0;
            string odgovor = "";
            do
            {
                Console.WriteLine("\nUnesite broj pored podatka koji želite da promenite\n");
                odgovor = Console.ReadLine();
                brojac++;
            } while (odgovor != "1" && odgovor != "2" && odgovor != "3" && odgovor != "4" && odgovor != "5" &&
             odgovor != "6" && odgovor != "7" && odgovor != "8" && odgovor != "9" && odgovor != "10" &&
             odgovor != "11" && brojac < 3);
           
             if (brojac == 3)
            {
                Console.WriteLine("\n Imali ste 3 pokušaja, to je to");
                return;
            }
  
            if (odgovor == "1")
            {
                string NovaodabranaVrstaStudija = odabirVrsteStudija();
                
                if (Validacije_podataka.proveraOdabiraVrsteStudija(NovaodabranaVrstaStudija))
                { 
                    s.VrstaStudija = NovaodabranaVrstaStudija;
                    Console.WriteLine("Nova vrsta studija je :" + s.VrstaStudija);
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške tokom odabira vrste studija");
                    return;
                }
            }   //promena vrste studija
            if (odgovor == "2")
            {
                string smer = odabirSmera();
                if (Validacije_podataka.proveraOdabiraSmera(smer))
                {
                    s.Smer = smer;
                    Console.WriteLine("\nUpisani smer je promenjen u :" + s.Smer + "\n");
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške u odabiru smera");
                    return;
                }
            }   //promena smera
            if (odgovor == "3")
            {
                string noviIndeks = unosBrojaIndeksa();
                if (Validacije_podataka.proveraFormataIndeksa(noviIndeks) &&
                    Validacije_podataka.daLiSmeDaSeKoristiTajBrojIndeksa(noviIndeks))
                {
                
                    s.BrojIndeksa = noviIndeks;
                    Console.WriteLine("\nBroj indeksa je promenjen. Novi broj indeksa je :" + s.BrojIndeksa);
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške tokom promene broja indeksa");
                    return;
                }

            }   //promena broja indeksa
            if (odgovor == "4")
            {
                string novoImePrezime = unosImena();

                if (Validacije_podataka.proveraImenaIPrezimena(novoImePrezime))
                {
                    s.ImeIPrezime = novoImePrezime;
                    Console.WriteLine("\nIme i prezime studenta je promenjeno u :" + s.ImeIPrezime); 
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške prilikom promene imena");
                    return;
                }
            }   //promena imena i prezimena
            if (odgovor == "5")
            {
                string novoImeRoditelja = unosImenaRoditelja();
                if (Validacije_podataka.proveraImenaRoditelja(novoImeRoditelja))
                {
                    s.ImeRoditelja = novoImeRoditelja;
                    Console.WriteLine("\nIme roditelja je promenjeno u :"+s.ImeRoditelja);

                }
                else
                {
                     Console.WriteLine("\nDošlo je do greške prilikom promene imena roditelja");
                    return;
                    
                } 
            }   //promena imena jednog roditelja
            if (odgovor == "6")
            {
                string noviJMBG = unosJMBG();
                if (Validacije_podataka.proveraUnosJMBG(noviJMBG) &&
                    Validacije_podataka.daLiSmeDaSeKoristiTajJMBG(noviJMBG))
                {
                    s.Jmbg = noviJMBG;
                    Console.WriteLine("\nJMBG je prihvaćen i zamenjen sa :"+s.Jmbg);
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške prilikom promene JMBG");
                    return;
                }
            }   //promena JMBG
            if (odgovor == "7")
            {
                string novoMestoRodjenja = unosOpstineRodjenja();
                if (Validacije_podataka.proveraMesta(novoMestoRodjenja))
                {
                    s.OpstinaRodjenja = novoMestoRodjenja;
                    Console.WriteLine("\nOpština rodjenja je promenjena u :"+s.OpstinaRodjenja);
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške prilikom promene opštine rodjenja");
                    return;
                }
            }   //promena mesta rodjenja
            if (odgovor == "8")
            {
                string novaDrzava = unosDrzaveRodjenja();
                if (Validacije_podataka.proveraDrzaveRodjenja(novaDrzava))
                {
                    s.DrzavaRodjenja = novaDrzava;
                    Console.WriteLine("\nDrzava rodjenja je promenjena u :" + s.DrzavaRodjenja);
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške prilikom promene države rodjenja");
                    return;
                }  
            }   //promena drzave rodjenja
            if (odgovor == "9")
            {
                string novoDrzavljanstvo = unosDrzavljanstva();
                if (Validacije_podataka.proveraDrzavljanstva(novoDrzavljanstvo))
                {
                    s.Drzavljanstvo = novoDrzavljanstvo;
                    Console.WriteLine("Državljanstvo je promenjeno u :" + s.Drzavljanstvo);
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške prilikom promene državljanstva");
                    return;
                }
               
            }   //promena drzavljanstva
            if (odgovor == "10")
            {
                DateOnly datumRodjenja = unosDatumaRodjenja();
                if (Validacije_podataka.daLiJeDatumRodjenjaPrihvatljiv(datumRodjenja))
                {
                    s.DatumRodjenja = datumRodjenja;
                    Console.WriteLine("\nDatum rodjenja je promenjen. Upisana vrednost je:" + s.DatumRodjenja);
                }
                else
                {
                    Console.WriteLine("\nDošlo je do greške prilikom promene datuma rodjenja");
                    return ;
                }
                
            }  //promena datuma rodjenja
            if (odgovor == "11")
            {

                Console.WriteLine("\nDatum upisa ne može biti promenjen\n");
            }  //datum upisa ne moze biti promenjen




        }// RADI

        

        }
    }

