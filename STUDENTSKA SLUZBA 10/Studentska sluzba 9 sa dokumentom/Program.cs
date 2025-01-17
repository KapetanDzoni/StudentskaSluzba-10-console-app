using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Studentska_sluzba_9_sa_dokumentom
{

   


    public class Test
    {
        public static string gdeJeBaza = @"E:\Visual studio repository\Studentska sluzba 9 sa dokumentom\baza.xml";
        public static void Main(string[] args)
        {

            Console.InputEncoding = System.Text.Encoding.Unicode; // ako hoću da unosim i čitam č mora ovo dvoje
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            StudentskaSluzba SS = new StudentskaSluzba();
           
            SS.kontrolniPanel();
            //UI.sacuvajUBazuUI();
            
            
            
        }
        
    }


}
