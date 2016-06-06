using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace лаб3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
                InitializeComponent();
        }
        List<Lib> Datalist = new List<Lib>();

        private void   Addd ()
        {
            Form2 f2 = new Form2();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                Datalist.Add(f2.Lib);
            }
            RefreshData(Datalist);
        }

private string filename;
        private bool showdialog = true;
        void SaveAs()
        {
            if (showdialog || filename.Length == 0)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.FileName = listView2.Text;
                SFD.FileName = "MyTXT";
                SFD.Filter = "TXT (*.txt)|*.txt|RTF (*.rtf)|*.rtf";

                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    filename = SFD.FileName;
                    showdialog = false;
                }
                else
                    return;
            }
            SaveTo(filename);
        }

        

        private void ReadFrom(string path)
        {
            using (StreamReader R = new StreamReader(path))
            {
                while (!R.EndOfStream)
                {
                    Datalist.Add(new Lib(Convert.ToInt32(R.ReadLine()), R.ReadLine(), R.ReadLine(), Convert.ToDateTime(R.ReadLine()), R.ReadLine()));
                }

            }
        }
        private void RefreshData(List<Lib> Datalist)
        {
            listView2.Items.Clear();
            foreach (var d in Datalist)
            {
                ListViewItem item = new ListViewItem(new string[]{d.Id.ToString(),d.Brand,d.Color,d.Year.ToString(),d.Condition.ToString()});
                listView2.Items.Add(item);
            }
        }
        
        private void SaveTo(string path)
        {
            using (StreamWriter W = new StreamWriter(path))
            {
                foreach (var i in Datalist)
                {
                    W.WriteLine(i.Id);
                    W.WriteLine(i.Brand);
                    W.WriteLine(i.Color);
                    W.WriteLine(i.Year);
                    W.WriteLine(i.Condition);
                 }
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

            ReadFrom("data.txt");
            RefreshData(Datalist);
            
        }

        private void Opener()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            ReadFrom(openFileDialog1.FileName);
                            RefreshData(Datalist);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Addd();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Open()
        {

        }

        private void Edit()
        {

            int id = int.Parse(listView2.SelectedItems[0].Text);
            int index = Datalist.FindIndex(d => d.Id == id);
            Lib lib = Datalist[index];
            Form2 f2 = new Form2(lib);
            if (f2.ShowDialog() == DialogResult.OK)
            {
                Datalist[index] = f2.Lib;
            }
            RefreshData(Datalist);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            if (listView2.SelectedItems.Count > 0)
            {
                int id = int.Parse(listView2.SelectedItems[0].Text);
                int index = Datalist.FindIndex(d => d.Id == id);
                Datalist.RemoveAt(index);
                RefreshData(Datalist);
            }
        }

       
       
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                удалитьToolStripMenuItem.Enabled = false;
                изменитьToolStripMenuItem.Enabled = false;
            }
            else
            {
                удалитьToolStripMenuItem.Enabled = true;
                изменитьToolStripMenuItem.Enabled = true;
            }
        }

       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTo(filename);
        }

       

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void создатьНовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            Datalist.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Addd();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveTo(filename);
            Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opener();
        }
    }
}
