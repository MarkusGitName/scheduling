using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMemory
{
    class Page
    {
        int pageSize = 4095;
        int startAddres;
        int pageNumber;
        int used;
        public Page(int sAddres)
        {
            startAddres = sAddres;
            used = 0;
            pageNumber = startAddres / 4095;
        }
        public Page(int sAddres, int use)
        {
            startAddres = sAddres;
            used = use;
            pageNumber = startAddres / 4095;
        }
        public int getPageNumber()
        {
            return pageNumber;
        }
        public int getAddres(int address)
        {
            return startAddres + address;
        }
        public int getStart()
        {
            return startAddres;
        }
        public int getUsed()
        {
            return used;
        }
        public void setUsed()
        {
            used++;
        }
        public String toString()
        {
            return "Page Adrres--" + getStart() + "  to  " + (getStart() + 4095)+ "  used: "+getUsed() ;
        }
    }
}
