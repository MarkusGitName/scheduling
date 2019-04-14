using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualMemory
{
    class VirtualAddresSpace
    {
        List<Page> pages = new List<Page>();
        public VirtualAddresSpace(List<SimProgram> p)
        {
            setPage(p);
        }
        public void setPage(List<SimProgram> simP)
        {
            List<Page> p = new List<Page>();
            foreach(SimProgram s in simP)
            {
                
                int size = s.getSize();
                for(int i = 0; i<size/4095; i++)
                {
                    p.Add(new Page(s.getStart()+(i*4095)));
                   // MessageBox.Show("hy hardloop "+i+" de keer.");
                }
            }
            pages = p;
            
        }
        public List<Page> getPages()
        {
            return pages;
        }

    }
}
