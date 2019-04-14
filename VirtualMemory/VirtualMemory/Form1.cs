using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualMemory
{
    public partial class Form1 : Form
    {
        List<SimProgram> programme = new List<SimProgram>();
        VirtualAddresSpace virtualAdd;
        RAM PhysicalMemory;
        public Form1()
        {
            InitializeComponent();
            programme = PermenentMemory.addProgram("paint", "40k", programme);
            programme = PermenentMemory.addProgram("faceBook","65k" , programme);
            programme = PermenentMemory.addProgram("Word", "76k", programme);
            programme = PermenentMemory.addProgram("VLC", "50k", programme);
            programme = PermenentMemory.addProgram("NotePad", "170k", programme);
            int i = 0;
            foreach (SimProgram pr in programme)
            {
                listBox1.Items.Insert(i, pr.toString());
                i++;
            }
            virtualAdd = new VirtualAddresSpace(programme);
            PhysicalMemory = new RAM(virtualAdd.getPages());
        }
     
        
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text!="")
            {
                try
                {                    
                    textBox2.Text += PhysicalMemory.run(Convert.ToInt32(textBox3.Text));
                    listBox4.Items.Clear();
                   // listBox3.Items.Clear();
                    int y = 0;
                    foreach (Page pFrame in PhysicalMemory.getPages())
                    {
                        listBox4.Items.Insert(y, pFrame.toString());
                        y++;
                    }
                    int c = 0;
                    foreach (Page pFrame in virtualAdd.getPages())
                    {
                        listBox3.Items.Insert(c, pFrame.toString());
                        c++;
                    }
                    pageTable();
                }
                catch
                {
                    MessageBox.Show("Please enter a valid integer.\n\n You can select from the list boxes. ");
                }
               
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  listBox2.Items.Clear();
            textBox1.Text =listBox1.SelectedIndex.ToString()+"\n\r\n\r";
            textBox1.Text += programme.ElementAt(listBox1.SelectedIndex).getProcess();
            List<int> processes = new List<int>();
            processes = programme.ElementAt(listBox1.SelectedIndex).ProcesReturn();
            int i = 0;
            foreach(int p in processes)
            {
                listBox2.Items.Insert(i, p);
                i++;
            }*/
        }
        private void pageTable()
        {
            textBox1.Text = "";
            int i = 0;
            foreach(Page p in PhysicalMemory.getPages())
            {
                textBox1.Text += "Phisical frame number is: " + i + "  Virtual frame number is: " + p.getPageNumber()+"\n\r\n\r";
                i ++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            int i = 0;
            foreach (Page page in virtualAdd.getPages())
            {
                listBox3.Items.Insert(i, page.toString());
                i++;
            }
            int y = 0;
            foreach (Page pFrame in PhysicalMemory.getPages())
            {
                listBox4.Items.Insert(y, pFrame.toString());
                y++;
            }
            pageTable();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page s = virtualAdd.getPages().ElementAt(listBox3.SelectedIndex);
            //MessageBox.Show(s.getStart().ToString());
            textBox3.Text = s.getStart().ToString();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                Page s = virtualAdd.getPages().ElementAt(listBox4.SelectedIndex);
                //MessageBox.Show(s.getStart().ToString());
                textBox3.Text = s.getStart().ToString();
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int VirtualSpaceUsed = 0;
            foreach(SimProgram sp in programme)
            {
                VirtualSpaceUsed += sp.getSize();
            }
           
            listBox4.Items.Clear();          
            Random addres = new Random();
            textBox3.Text = addres.Next(VirtualSpaceUsed).ToString();
            textBox2.Text += PhysicalMemory.run(Convert.ToInt32(textBox3.Text));
            int y = 0;
            foreach (Page pFrame in PhysicalMemory.getPages())
            {
                listBox4.Items.Insert(y, pFrame.toString());
                y++;
            }
            listBox3.Items.Clear();
            int c = 0;
            foreach (Page pFrame in virtualAdd.getPages())
            {
                listBox3.Items.Insert(c, pFrame.toString());
                c++;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pageTable();
        }
    }
}
