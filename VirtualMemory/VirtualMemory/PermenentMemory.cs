using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VirtualMemory
{
    static class PermenentMemory
    {
        static SimProgram lastP;
        static List<SimProgram> programs = new List<SimProgram>();
       
        public static List<SimProgram> addProgram(String name, String s, List<SimProgram> pro)
        {

            int size = (Convert.ToInt32((s.Substring(0, s.Length - 1)))*4095);
            int tel = 0;
            if (pro.Count == 0)
            {
                lastP = new SimProgram(name, 0, size);
               // MessageBox.Show(lastP.toString() + "   eerste program in lys.");
                pro.Add(lastP);
            }
            else
            {
                SimProgram temp =null;
                foreach (SimProgram pr in pro)
                {
                    
                   /* if (tel == 0)
                    {
                        tel = pr.getLast();
                        MessageBox.Show(lastP.toString());
                    }*/
                    if ( temp!=null && (temp.getLast() - pr.getStart()) > size )
                    {
                        lastP = new SimProgram(name, tel, size);                        
                        break;
                    }
                    else
                    {                   
                        lastP = new SimProgram(name, pr.getLast(), size);                        
                    }
                    temp = pr;
                }
                pro.Add(lastP);
               // MessageBox.Show(lastP.toString()+"  Plaas in lys");
            }         
           return pro;
        }
    }
}
