using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMemory
{
    class SimProgram
    {
        String name;
        int AddresStart;
        int AddresEnd;
        List<int> proces = new List<int>();
        int programSize;
        public SimProgram(String n, int start ,int size)
        {
            setName(n);
            setStart(start);
            setProgramSize(size);
            setProcesses(size);            
            setEnd();
        }
        public void setName(String n)
        {
            name = n;
        }
        public void setStart(int start)
        {
            AddresStart = start;
        }
        public void setProcesses(int size)
        {
            int temp = size;
            int i = 0;
            while(temp > 0)
            {
                proces.Add(AddresStart + i);
                i += 100;
                temp -= 100;
            }
            
        }
        public void setProgramSize(int size)
        {
            programSize = size;
        }
        public void setEnd()
        {
            AddresEnd = AddresStart + programSize;
        }
        public int getLast()
        {
            return AddresEnd;
        }
        public int getStart()
        {
            return AddresStart;
        }  public String getName()
        {
            return name;
        }public int getSize()
        {
            return programSize;
        }
        public int getEnd()
        {
            return AddresEnd;
        }
        public String getProcess()
        {
            String pMessage = "";
            int i = 0;
            foreach(int p in proces)
            {
                pMessage += "process- " + i + "Adress Range " + p.ToString()+" to "+(p+100).ToString()+"\n\r\n\r";                   
                i++;
            }
            return pMessage;
        }
        public List<int> ProcesReturn()
        {
            return proces;
        }
        public String toString()
        {
            return getName() + " Starts at: " + getStart()+" Size: "+getSize()+" ends at"+ getEnd()+"\n\r\n\r";
        }
    }
}
