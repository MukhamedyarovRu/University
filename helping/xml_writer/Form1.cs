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

namespace xml_writer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e) //Добавление данных в форму
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля.", "Ошибка.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e) //сохранение данных из формы в XML
        {
            try
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                        DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных
                        dt.TableName = "Employee"; // название таблицы
                        dt.Columns.Add("Name"); // название колонок
                        dt.Columns.Add("Age");
                        dt.Columns.Add("Programmer");
                        ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                        foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
                        {
                            DataRow row = ds.Tables["Employee"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                            row["Name"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                            row["Age"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                            row["Programmer"] = r.Cells[2].Value; //то же самое с третьими столбцами
                            ds.Tables["Employee"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                        }
                        myStream.Close();
                    }
                }
            }
            /*
            DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
            DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных
            dt.TableName = "Employee"; // название таблицы
            dt.Columns.Add("Name"); // название колонок
            dt.Columns.Add("Age");
            dt.Columns.Add("Programmer");
            ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

            foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
            {
                DataRow row = ds.Tables["Employee"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                row["Name"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                row["Age"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                row["Programmer"] = r.Cells[2].Value; //то же самое с третьими столбцами
                ds.Tables["Employee"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
            }

            MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
        }
         */
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
           
        }
        
        private void button5_Click(object sender, EventArgs e) //загрузка файла XML в форму
        {


            /*if (dataGridView1.Rows.Count > 0) //если в таблице больше нуля строк
            {
                MessageBox.Show("Очистите поле перед загрузкой нового файла.", "Ошибка.");
            }
            else
            {
                if (File.Exists("G:\\Data.xml")) // если существует данный файл
                {
                DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                ds.ReadXml("G:\\Data.xml"); // записываем в него XML-данные из файла
                
                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add(); // добавляем новую сроку в dataGridView1
                        dataGridView1.Rows[n].Cells[0].Value = item["Name"]; // заносим в первый столбец созданной строки данные из первого столбца таблицы ds.
                        dataGridView1.Rows[n].Cells[1].Value = item["Age"]; // то же самое со вторым столбцом
                        dataGridView1.Rows[n].Cells[2].Value = item["Programmer"]; // то же самое с третьим столбцом
                    }
                }
                else
                {
                    MessageBox.Show("XML файл не найден.", "Ошибка.");
                }
            }
        }*/

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\Database\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
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
                            DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                            ds.ReadXml("c:\\Database\\Data.xml"); // записываем в него XML-данные из файла

                            foreach (DataRow item in ds.Tables["Employee"].Rows)
                            {
                                int n = dataGridView1.Rows.Add(); // добавляем новую сроку в dataGridView1
                                dataGridView1.Rows[n].Cells[0].Value = item["Name"]; // заносим в первый столбец созданной строки данные из первого столбца таблицы ds.
                                dataGridView1.Rows[n].Cells[1].Value = item["Age"]; // то же самое со вторым столбцом
                                dataGridView1.Rows[n].Cells[2].Value = item["Programmer"]; // то же самое с третьим столбцом
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e) // выбор нужной строки для редактирования
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //редактирование
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.", "Ошибка.");
            }
        }

        private void button3_Click(object sender, EventArgs e) //удалить выбранную строку
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка.");
            }
        }

        private void button6_Click(object sender, EventArgs e) //очистить таблицу
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблица пустая.", "Ошибка.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
