using System.IO;
namespace _16._2
{
    public partial class Form1 : Form
    {
        string fname;// задание глобальных переменных
        TextBox[,] MatrText = null; // матрица элементов типа TextBox
        int[,] a = new int[100, 100];
        int m, n, minZn, maxZn;
        private void Form1_Load(object sender, EventArgs e)
        {
            int i;
            for (i = 1; i <= 7; i++)
            { //задание списков ComboBox1-4
                comboBox1.Items.Add(Convert.ToString(i + 1));
                comboBox2.Items.Add(Convert.ToString(i + 1));
                comboBox3.Items.Add(Convert.ToString(i - 15));
                comboBox4.Items.Add(Convert.ToString(i + 1));
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i, j;
            m = Convert.ToInt32(comboBox1.Text);
            n = Convert.ToInt32(comboBox2.Text);
            //задание количества столбцов и строк таблицы
            dataGridView1.RowCount = m + 1;
            dataGridView1.ColumnCount = n + 1;
            //считывание макс. и мин. значений элементов массива
            minZn = Convert.ToInt32(comboBox3.Text);
            maxZn = Convert.ToInt32(comboBox4.Text);
            /*задание ширины и высоты сетки от числа строк и столбцов
            массива */
            dataGridView1.Width = 140 * (n + 1);
            dataGridView1.Height = 40 * (m + 1);
            //нумерация строк и столбцов таблицы
            for (i = 1; i <= m; i++)
            { dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(i); }
            for (j = 1; j <= n; j++)
            { dataGridView1.Rows[0].Cells[j].Value = Convert.ToString(j); }
            fname = textBox1.Text;
            StreamReader streamReader = new StreamReader(fname);
            //Открываем файл для чтения
            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value =
                    streamReader.ReadLine();
                    /*в таблицу построчно записываем содержимое файла */
                }
            }
            streamReader.Close(); // Закрываем файл
        }

        private void button1_Click(object sender, EventArgs e)
        {
                int i, j;
                fname = textBox1.Text;
                m = Convert.ToInt32(comboBox1.Text); //считывание размерности массива
                n = Convert.ToInt32(comboBox2.Text); //считывание размерности массива
                minZn = Convert.ToInt32(comboBox3.Text);
                maxZn = Convert.ToInt32(comboBox4.Text);
                Random rnd = new Random();
                //задание элементов массива
                for (i = 1; i <= m; i++)
                {
                    for (j = 1; j <= n; j++)
                    {
                        a[i, j] = rnd.Next(minZn, maxZn);
                    }
                }
                fname = textBox1.Text;
                StreamWriter write_text; //Класс для записи в файл
                FileInfo file = new FileInfo(fname);
                write_text = file.CreateText(); /*дописываем информацию в файл, если файла не существует он создастся */
                for (i = 1; i <= m; i++)
                //запись массива a[i,j] в файл
                {
                    for (j = 1; j <= n; j++)
                    {
                        write_text.WriteLine(a[i, j]); /*Записываем в файл текст из текстового поля */
                    }
                }
                write_text.Close(); // Закрываем файл
            }
        }
    }