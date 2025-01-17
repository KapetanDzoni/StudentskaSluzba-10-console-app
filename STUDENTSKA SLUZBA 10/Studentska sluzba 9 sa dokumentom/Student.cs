using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_sluzba_9_sa_dokumentom
{
    public  class Student
    {
        // Properties
        private string imeIPrezime;
        public string ImeIPrezime
        {
            get { return imeIPrezime; }
            set { imeIPrezime = value; }
        }  //1.



        private string imeRoditelja;
        public string ImeRoditelja 
        {
            get { return imeRoditelja; }
            set { imeRoditelja = value; }
        } //2.


        private string opstinaRodjenja;
        public string OpstinaRodjenja //3.
        {
            get { return opstinaRodjenja; }
            set { opstinaRodjenja = value; }
        }


        private DateOnly datumRodjenja; 
        public DateOnly DatumRodjenja //4.
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }
        private string drzavaRodjenja;

        public string DrzavaRodjenja //5.
        {
            get { return drzavaRodjenja; }
            set { drzavaRodjenja = value; }
        }
        private string jmbg;
        public string Jmbg //6.
        {
            get { return jmbg; }
            set { jmbg = value; }
        }
        

        private string drzavljanstvo;

        public string Drzavljanstvo //7.
        {
            get { return drzavljanstvo; }
            set { drzavljanstvo = value; }
        }

        private string vrstaStudija;
        public string VrstaStudija //8.
        {
            get { return vrstaStudija;  }
            set { vrstaStudija = value; }

        }

        private string smer;
        public string Smer //9.
        {
            get { return smer; }
            set { smer = value; }
        }
        private string brojIndeksa;

        public string BrojIndeksa //10.
        {
            get { return brojIndeksa; }
            set { brojIndeksa = value; }
        }

        private DateOnly datumUpisa;
        
        public DateOnly DatumUpisa //11.
        {
            get { return datumUpisa; }
            set { datumUpisa = value; }
        }

        // Parametrizovani konstruktor
        public Student(string vrstaStudija, string smer, string brojIndeksa, string imeIPrezime,
                       string imeRoditelja, string jmbg1, string opstinaRodjenja, string drzavaRodjenja,
                       string drzavljanstvo, DateOnly datumRodjenja, DateOnly datumUpisa)
        {
            VrstaStudija = vrstaStudija;
            Smer = smer;
            BrojIndeksa = brojIndeksa;
            ImeIPrezime = imeIPrezime;
            ImeRoditelja = imeRoditelja;
            Jmbg = jmbg1;
            OpstinaRodjenja = opstinaRodjenja;
            DrzavaRodjenja = drzavaRodjenja;
            Drzavljanstvo = drzavljanstvo;
            DatumRodjenja = datumRodjenja;
            DatumUpisa = datumUpisa;
           
        }
        public Student() { } // neparametrizovani konstrutor
       
    }

}

