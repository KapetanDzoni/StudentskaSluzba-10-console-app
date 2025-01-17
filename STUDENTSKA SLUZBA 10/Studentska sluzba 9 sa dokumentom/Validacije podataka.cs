using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Studentska_sluzba_9_sa_dokumentom
{
    // ovde se nalaze metode koje proveravaju da li su uneseni podaci validni
    internal static class Validacije_podataka
    {

        private static string[] drzaveSveta = {
    "Afganistan",
    "Albanija",
    "Alžir",
    "Andora",
    "Angola",
    "Antigva i Barbuda",
    "Argentina",
    "Armenija",
    "Australija",
    "Austrija",
    "Azerbejdžan",
    "Bahami",
    "Bahrein",
    "Bangladeš",
    "Barbados",
    "Belgija",
    "Beliz",
    "Belorusija",
    "Benin",
    "Bocvana",
    "Bolivija",
    "Bosna i Hercegovina",
    "Brazil",
    "Brunej",
    "Bugarska",
    "Burkina Faso",
    "Burundi",
    "Crna Gora",
    "Centralnoafrička Republika",
    "Čad",
    "Češka",
    "Čile",
    "Danska",
    "Dominika",
    "Dominikanska Republika",
    "Džibuti",
    "Egipat",
    "Ekvador",
    "Ekvatorska Gvineja",
    "Eritreja",
    "Estonija",
    "Esvatini",
    "Etiopija",
    "Fidži",
    "Filipini",
    "Finska",
    "Francuska",
    "Gabon",
    "Gambija",
    "Gana",
    "Grčka",
    "Grenada",
    "Gruzija",
    "Gvajana",
    "Gvatemala",
    "Gvineja",
    "Gvineja Bisao",
    "Haiti",
    "Holandija",
    "Honduras",
    "Hrvatska",
    "Indija",
    "Indonezija",
    "Irak",
    "Iran",
    "Irska",
    "Island",
    "Italija",
    "Istočni Timor",
    "Izrael",
    "Jamajka",
    "Japan",
    "Jemen",
    "Jordan",
    "Južna Koreja",
    "Južni Sudan",
    "Južnoafrička Republika",
    "Kambodža",
    "Kamerun",
    "Kanada",
    "Katar",
    "Kazahstan",
    "Kenija",
    "Kirgistan",
    "Kiribati",
    "Kolumbija",
    "Komori",
    "Kongo",
    "Kostarika",
    "Kuba",
    "Kuvajt",
    "Laos",
    "Lesoto",
    "Letonija",
    "Liban",
    "Liberija",
    "Libija",
    "Lihtenštajn",
    "Litvanija",
    "Luksemburg",
    "Madagaskar",
    "Mađarska",
    "Makedonija",
    "Malavi",
    "Maldivi",
    "Malezija",
    "Mali",
    "Malta",
    "Maroko",
    "Maršalska Ostrva",
    "Mauricijus",
    "Mauritanija",
    "Meksiko",
    "Mianmar",
    "Mikronezija",
    "Moldavija",
    "Monako",
    "Mongolija",
    "Mozambik",
    "Namibija",
    "Nauru",
    "Nemačka",
    "Nepal",
    "Niger",
    "Nigerija",
    "Nikaragva",
    "Niue",
    "Norveška",
    "Nova Gvineja",
    "Novi Zeland",
    "Obala Slonovače",
    "Oman",
    "Pakistan",
    "Palau",
    "Panama",
    "Papua Nova Gvineja",
    "Paragvaj",
    "Peru",
    "Poljska",
    "Portugal",
    "Ruanda",
    "Rumunija",
    "Rusija",
    "Saint Kitts i Nevis",
    "Saint Lucia",
    "Saint Vincent i Grenadini",
    "Salvador",
    "Samoa",
    "San Marino",
    "Sao Tome i Principe",
    "Saudijska Arabija",
    "Sejšeli",
    "Senegal",
    "Severna Koreja",
    "Severna Makedonija",
    "Sijera Leone",
    "Singapur",
    "Sirija",
    "Sjedinjene Američke Države",
    "Slovačka",
    "Slovenija",
    "Solomonova Ostrva",
    "Somalija",
    "Srbija",
    "Srednjoafrička Republika",
    "Sudan",
    "Surinam",
    "Svazilend",
    "Španija",
    "Šri Lanka",
    "Švedska",
    "Švajcarska",
    "Tadžikistan",
    "Tajland",
    "Tanzanija",
    "Togo",
    "Tonga",
    "Trinidad i Tobago",
    "Tunis",
    "Turkmenistan",
    "Turska",
    "Tuvalu",
    "Uganda",
    "Ujedinjeni Arapski Emirati",
    "Ukrajina",
    "Urugvaj",
    "Uzbekistan",
    "Vanuatu",
    "Vatikan",
    "Venecuela",
    "Velika Britanija",
    "Vijetnam",
    "Zambija",
    "Zimbabve",
    "Crna Gora",
    "Jugoslavija",
    "Palestina",
    "Sovjetski Savez",
    "Čehoslovačka",
    "Jugoslavija",
    "SFRJ",
    "Zair",
    "Zapadna Nemačka",
    "Istočna Nemačka",
    "Rodezija",
    "Republika Kongo",
    "Sijera Leone",
    "Tanganjika",
    "Južnoafrička Republika",
    "Sudan",
    "Nikaragva",
    "Srednjeafrička Republika"
        };
        
                
        public static bool proveraOdabiraVrsteStudija(string odabranaVrstaStudija)
        {
            if (odabranaVrstaStudija == "Nista") return false;
            return true;

        }

        public static bool proveraImenaIPrezimena(string ime)
        {
            string[] deli = ime.Split(' ');
            if (deli.Length != 2)
            {
                Console.WriteLine("\nMorate uneti i ime i prezime, znači samo jedno ime i prihvatamo samo jedno prezime");

                return false;
            }
            string imeStudenta = deli[0];
            if (imeStudenta.Length<=2)
            {
                Console.WriteLine("\nIme mora imati makar 3 slova");
                return false;
            }

            foreach (char karakter in imeStudenta)
            {
                if (!char.IsLetter(karakter) )
                {
                    Console.WriteLine("\nVaše ime mora imati samo slova, molim vas bez zajebancije");
                    return false;
                }
            }
            string prezimeStudenta = deli[1];
            if ((prezimeStudenta.Length <= 2))
            {
                Console.WriteLine("\nPrezime mora imati makar 3 slova");
                return false;
            }
            foreach (char karakter2 in prezimeStudenta)
            {
                if (!char.IsLetter(karakter2) )
                {   
                    
                    Console.WriteLine("\nVaše prezime mora imati samo slova, molim vas bez zajebancije");
                    return false;
                }
            }
            // Console.WriteLine("\nVaše ime je prihvaćeno");
           // Console.WriteLine("Duzina strina deli[0] =" + deli[0].Length+" deli[1]=" + deli[1].Length);
            return true;
        } // RADI

        public static bool proveraImenaRoditelja(string ime)
        {
            if(ime ==" ")
            {
                Console.WriteLine("\nUneli ste prazno polje za ime roditelja, neprihvatljivo");
                return false;
            }
            string[] delovi = ime.Split(' ');
            if (delovi.Length > 1)
            {
                Console.WriteLine("Prihvatamo samo jednu reč kao ime roditelja");
                return false;
            }
            string text = delovi[0];
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Ime mora biti sastavljeno samo od slova");
                    return false;
                }
            }
            if (char.IsLower(ime[0]))
            {
                Console.WriteLine("Sramota što ne znate da se prvo slovo imena  piše velikim slovom");
                //Console.WriteLine("Smartaćemo da ste pogrešili zbog treme, i ispravićemo sami tu grešku");

            }
            //Console.WriteLine("Uspešno ste uneli ime jednog roditelja " + ime);
            return true;
        } //RADI 

        public static bool proveraMesta(string mesto) //RADI 
        {
            if (string.IsNullOrEmpty(mesto))
            {
                Console.WriteLine("\nNiste upisali mesto rodjenja;");
                return false;
            }
            if (mesto == " ")
            {
                Console.WriteLine("\nMudro, ali ipak ne");
                return false;
            }

            string[] delovi = mesto.Split(' ');
            for (int i = 0; i < delovi.Length; i++)
            {
                foreach (char c in delovi[i])
                {
                    if (!char.IsLetter(c))
                    {
                        Console.WriteLine("\nNe prihvatamo mesta rodjenja koja imaju brojeve u sebi");
                        return false;
                    }
                }
            }
            return true;
        }
   
        public static bool daLiJeDatumUnesenUFormatu(string unos)
        {
            DateOnly datum;

            if (DateOnly.TryParse(unos, out datum))
            {
                return true;
            }
            
            return false;
        }

        public static bool daLiJeDatumRodjenjaUProslosti(DateOnly unos)
        {
          
            
                return unos <= DateOnly.FromDateTime(DateTime.Now);
            
        }

        public static bool daLiJeDatumRodjenjaPrihvatljiv(DateOnly unos)
        {
            DateOnly neprihvatljiv = default;
            DateOnly danas = DateOnly.FromDateTime(DateTime.Now);

            // za buducnost i maloletne
            if (unos == neprihvatljiv) return false;
              
                if (danas.Year-unos.Year<0)
                {
                    Console.WriteLine("\nDecu iz buducnosti ne primamo");
                    return false;
                }
                
            

            if (daLiJeDatumRodjenjaUProslosti(unos)) // datum rodjenja je u proslosti
            {
                if (danas.Year - unos.Year < 18)
                {
                    Console.WriteLine("\nNe primamo maloletne");
                    return false;
                }
                if (danas.Year- unos.Year >=70) Console.WriteLine("\nIako imate preko 70 godina, svaka čast na odluci");
                if (danas.Year - unos.Year >= 110)
                {
                    Console.WriteLine("\nNa fakultet ne primamo drekavce, karakondžule, vampire i ostala mitska bića");
                    return false;
                }
                return true;
            }
            return false;
        } // u formatu, u proslosti, <=100 godina starosti

        public static bool proveraDrzaveRodjenja(string drzava)
        {
            if (string.IsNullOrEmpty(drzava))
            {
                Console.WriteLine("Niste upisali naziv drzave u kojoj ste rodjeni;");
                return false;
            }
          ///  string normalizovanaDrzava = NormalizujString3(drzava);

            foreach (string drzavica in drzaveSveta)
            {
               // Console.WriteLine("Uporedjuju se "+drzava+" sa :"+drzavica);
               // string normalizovanaDrzavica = NormalizujString3(drzavica);

               // if (NormalizujString(drzavica).Equals(NormalizujString(drzava), StringComparison.OrdinalIgnoreCase))
                {
                    //Console.WriteLine("Nadjena 1.");
                  //  return true;
                }
                if (drzavica.Equals(drzava)) {
                    
                    return true;
                }

               /* if (drzavica.Equals(drzava))
                {
                    Console.WriteLine("Nadjena 2.");
                    return true;
                }

                if (Regex.IsMatch(drzavica, @"\b" + Regex.Escape(drzava) + @"\b", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Nadjena 3.");
                    return true;
                }

                if (NormalizujString(drzavica).Contains(NormalizujString(drzava), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nadjena 4.");
                    return true;
                }

                if (NormalizujString(drzavica).Contains(NormalizujSpecijalnaSlova(drzava), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nadjena 5.");
                    return true;
                }

                if (drzavica.Equals(drzava, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nadjena 6.");
                    return true;
                }

                if (Regex.IsMatch(drzavica, @"\b" + Regex.Escape(drzava) + @"\b", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Nadjena 7.");
                    return true;
                }

                if (drzavica.Contains(drzava, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nadjena 8.");
                    return true;
                }
                if (NormalizujSpecijalnaSlova2(drzavica).Equals(NormalizujSpecijalnaSlova2(drzava), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nadjena 9.");
                    return true;
                }
                if (NormalizujString3(drzavica).Equals(NormalizujString3(drzava), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nadjena 10.");
                    return true;
                }

                if (normalizovanaDrzavica.Equals(normalizovanaDrzava, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nadjena 11.");
                    return true;
                }

                // Provera jednakosti bez normalizacije, ali uz ignorisanje veličine slova
                if (drzavica.Equals(drzava, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nadjena 12.");
                    return true;
                }

                // Provera korišćenjem regularnog izraza
                if (Regex.IsMatch(drzavica, @"\b" + Regex.Escape(drzava) + @"\b", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Nadjena 13.");
                    return true;
                } */

            }
            
            return false;

            
        } // RADI

        public static bool proveraUnosJMBG(string broj)
        {
            if (broj == "")
            {
                return false;
            }
            
            
            if (broj.ToString().Length != 13)
            {
                Console.WriteLine("\nUneseni broj nema 13 cifara");
                return false;
            }

            int a = int.Parse(broj[0].ToString());
            int b = int.Parse(broj[1].ToString());
            int v = int.Parse(broj[2].ToString());
            int g = int.Parse(broj[3].ToString());
            int d = int.Parse(broj[4].ToString());
            int đ = int.Parse(broj[5].ToString());
            int e = int.Parse(broj[6].ToString());
            int ž = int.Parse(broj[7].ToString());
            int z = int.Parse(broj[8].ToString());
            int i = int.Parse(broj[9].ToString());
            int j = int.Parse(broj[10].ToString());
            int k = int.Parse(broj[11].ToString());
            int l = int.Parse(broj[12].ToString());



            int kontrolna = 11 - ((7 * (a + e) + 6 * (b + ž) + 5 * (v + z) + 4 * (g + i) + 3 * (d + j) + 2 * (đ + k)) % 11);

            if (l==kontrolna)
            {
                return true;
            }

            return false;
        }

        public static bool proveraDrzavljanstva (string unos)
        {

            if (unos == " ")
            {
                Console.WriteLine("\nUneli ste ništa");
                return false;
            }
            if (unos.Length<3)
            {
                Console.WriteLine("\nPrekratko");
                return false;
            }
            foreach(char c in unos)
            {
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("\nLepo smo rekli bez brojeva a nadam se i bez zajebancija");
                    return false;
                }
            }

            return true;
        }

        public static  bool unesiDatumRodjenjaDDMMGGG(string unos)
        {

            //  10.08.1988.
            if (unos.Length != 11)
            {
                Console.WriteLine("\nNiste uneli dovoljan broj karaktera");
                return false;
            }
            if (unos[2] != '.' || unos[5] != '.' || unos[10] != '.')
            {
                Console.WriteLine("\nUneseni datum mora biti razdvojen sa tačkama");
                return false;
            }
            string[] delovi = unos.Split('.');
            int dan;
            if (!int.TryParse(delovi[0], out dan))
            {
                Console.WriteLine("\nUneta vrednost za dan nije broj");
                return false;
            }
            if (int.TryParse(delovi[0], out dan))
            {
                if (dan <= 0 || dan >= 32)
                {
                    Console.WriteLine("\nDan mora biti izmedju 1 i 31");
                    return false;
                }
            }
            int mesec;
            if (!int.TryParse(delovi[1], out mesec))
            {
                Console.WriteLine("\nUneta vrednost za mesec nije broj");
                return false;
            }
            if (int.TryParse(delovi[1], out mesec))
            {
                if (mesec <= 0 || mesec >= 13)
                {
                    Console.WriteLine("\nMesec mora biti izmedju 1 i 12");
                    return false;
                }
            }
            int godina;
            if (!int.TryParse(delovi[2], out godina))
            {
                Console.WriteLine("\nUneta vrednost za godinu nije broj");
                return false;
            }
            if (int.TryParse(delovi[2], out godina))
            {
                if (godina < 0)
                {
                    Console.WriteLine("\nGodina mora biti pozitivna vrednost");
                    return false;
                }
            }
            return true;

        }

        public static bool proveraOdabiraSmera(string odabraniSmer)
        {
            if (odabraniSmer == "Nista")
            {
                return false;
            }
            return true;
        } //RADI

        public static bool proveraFormataIndeksa(string brojIndeksa)
        {
            int trenutnaGodina = DateTime.Now.Year;
            string[] delovi = brojIndeksa.Split('/');
            if (delovi.Length != 2)
            {
                Console.WriteLine("\nIndeks mora biti u odgovarajucem formatu,recimo 0009/2017");
                return false;
            }
            if (!int.TryParse(delovi[0], out var cetvorocifreniBroj) || cetvorocifreniBroj < 0 || cetvorocifreniBroj > 9999)
            {
                Console.WriteLine("\nPrvi deo mora biti pozitivan četvorocifreni broj");
                return false;
            }
            if (!int.TryParse(delovi[1], out var godina) || godina < 1999 || godina > trenutnaGodina)
            {
                Console.WriteLine("\nTrenutna godina je :" + trenutnaGodina);
                Console.WriteLine("Godina upisa mora biti izmedju od 1999. i tekuce godine");
                return false;
            }
            // Console.WriteLine("Uspešno ste uneli broj indeksa!\nBroj vašeg indeksa je :" + brojIndeksa);
            return true;
        } //RADI

        public static bool daLiJeStudentPronadjen(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Nismo pronašli takvog studenta");
                return false;
            }
            else
            {
                Console.WriteLine("\nStudent je pronadjen\n");
            }
            return true;
        }//RADI
        
        public static bool proveraDaLiSuSviPodaciStudentaPopunjeni (Student student)
        {
            {
               
                if (string.IsNullOrEmpty(student.ImeIPrezime) ||
                    string.IsNullOrEmpty(student.ImeRoditelja) ||
                    string.IsNullOrEmpty(student.OpstinaRodjenja) ||
                    student.DatumRodjenja == default ||
                    string.IsNullOrEmpty(student.DrzavaRodjenja) ||
                    string.IsNullOrEmpty(student.Jmbg) ||
                    string.IsNullOrEmpty(student.Drzavljanstvo) ||
                    string.IsNullOrEmpty(student.VrstaStudija) ||
                    string.IsNullOrEmpty(student.Smer) ||
                    string.IsNullOrEmpty(student.BrojIndeksa) ||
                    student.DatumUpisa == default)
                {
                    
                    return false;
                }

                
                return true;
            }
        }

        public static bool daLiSmeDaSeKoristiTajBrojIndeksa(string noviIndeks)
        {
            foreach(Student student in StudentskaSluzba.listaUpisanihStudenata)
            {
                if (student.BrojIndeksa == noviIndeks)
                {
                    Console.WriteLine("\nOvaj broj indeksa je zauzet");
                    return false;
                }
            }

            return true;
        } 

        public static bool daLiSmeDaSeKoristiTajJMBG (string jmbg)
        {
           
            foreach (Student student in StudentskaSluzba.listaUpisanihStudenata)
            {
                if (jmbg==student.Jmbg)
                {
                    return false;
                }
            }
            return true;

        }
        
    }
}
