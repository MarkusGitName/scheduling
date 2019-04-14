using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualMemory
{
    class RAM
    {
        int max= 40000;
        int Addres;
        List<Page> allPages = new List<Page>();
        Page[] pages = new Page[40000/400];
        public RAM()
        {
         
        }
        public RAM(List<Page> p)
        {
            setInitialPages(p);
            allPages = p;
        }
        public void setInitialPages(List<Page> p)
        {
            int i = 0;
            int addres = 0;
            Page[] temp = new Page[max/400];
            while(addres < max)
            {
                foreach(Page page in p)
                {
                    try
                    {
                        temp[i] = page;
                        addres = addres + 400;
                        i++;
                    }
                    catch
                    {
                        break;
                    }
                    
                }
             
            }
            pages = temp;
        }
        public String run(int addres)
        {
            String msge = "";
            Boolean found = false;
         
                while (found == false)
                {

                    for (int i = 0; i < pages.Length; i++)
                    {
                        if (addres >= pages[i].getStart() && addres < pages[i].getStart() + 4095)
                        {
                            int addresAdd = addres - pages[i].getStart();
                          //  MessageBox.Show("Address accesed- " + (pages[i].getStart() + addresAdd).ToString() + "from virtual memory space: " + addres.ToString());
                            pages[i].setUsed();
                            found = true;
                            msge = "\n\r\n\rPhysical Address accesed- " + ((i*4095)+addresAdd).ToString() + "from virtual memory space: " + addres.ToString()+"\n\r\n\r"+pages[i].toString();

                        }

                    }
                    if(found == false)
                    {
                        Swop(addres);

                    }                 
                }
           
           

            return msge;
        }
        public void Swop(int addres)
        {
            Boolean swoped = false;
            int i = 0;
            while (swoped == false)
            {
                foreach (Page p in allPages)
                {
                    if (addres >= p.getStart() && addres < (p.getStart() + 4095))
                    {
                        for (int c = 0; c < pages.Length; c++)
                        {
                            if (pages[c].getUsed() == i)
                            {
                                pages[c] = p;
                                swoped = true;
                                break;
                            }
                        }
                    }
                }
                i++;
            }
           /* Boolean ran = false;
            int i = 0;
            //  MessageBox.Show("hy swop");
          
                while (ran == false)
                {
                    for (int x = 0; i < pages.Length; x++)
                    {
                        // MessageBox.Show("eerste");
                        if (pages[i].getUsed() == i)
                        {
                            // MessageBox.Show("tweede");
                            foreach (Page pp in allPages)
                            {
                                if (pp.getStart() - addres < 400)
                                {
                                    //        MessageBox.Show("derde");
                                   
                                        pages[i] = pp;                                      
                                        ran = true;
                                        return true;

                                }
                            }
                        }
                    }
                    i++;
                }
         
             
            return true;*/
        }

        public Page[] getPages()
        {
            return pages;
        }
    }
}
