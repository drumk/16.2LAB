using System.IO;
namespace _16._2
{
    public partial class Form1 : Form
    {
        string fname;// ������� ���������� ����������
        TextBox[,] MatrText = null; // ������� ��������� ���� TextBox
        int[,] a = new int[100, 100];
        int m, n, minZn, maxZn;
        private void Form1_Load(object sender, EventArgs e)
        {
            int i;
            for (i = 1; i <= 7; i++)
            { //������� ������� ComboBox1-4
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
            //������� ���������� �������� � ����� �������
            dataGridView1.RowCount = m + 1;
            dataGridView1.ColumnCount = n + 1;
            //���������� ����. � ���. �������� ��������� �������
            minZn = Convert.ToInt32(comboBox3.Text);
            maxZn = Convert.ToInt32(comboBox4.Text);
            /*������� ������ � ������ ����� �� ����� ����� � ��������
            ������� */
            dataGridView1.Width = 140 * (n + 1);
            dataGridView1.Height = 40 * (m + 1);
            //��������� ����� � �������� �������
            for (i = 1; i <= m; i++)
            { dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(i); }
            for (j = 1; j <= n; j++)
            { dataGridView1.Rows[0].Cells[j].Value = Convert.ToString(j); }
            fname = textBox1.Text;
            StreamReader streamReader = new StreamReader(fname);
            //��������� ���� ��� ������
            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value =
                    streamReader.ReadLine();
                    /*� ������� ��������� ���������� ���������� ����� */
                }
            }
            streamReader.Close(); // ��������� ����
        }

        private void button1_Click(object sender, EventArgs e)
        {
                int i, j;
                fname = textBox1.Text;
                m = Convert.ToInt32(comboBox1.Text); //���������� ����������� �������
                n = Convert.ToInt32(comboBox2.Text); //���������� ����������� �������
                minZn = Convert.ToInt32(comboBox3.Text);
                maxZn = Convert.ToInt32(comboBox4.Text);
                Random rnd = new Random();
                //������� ��������� �������
                for (i = 1; i <= m; i++)
                {
                    for (j = 1; j <= n; j++)
                    {
                        a[i, j] = rnd.Next(minZn, maxZn);
                    }
                }
                fname = textBox1.Text;
                StreamWriter write_text; //����� ��� ������ � ����
                FileInfo file = new FileInfo(fname);
                write_text = file.CreateText(); /*���������� ���������� � ����, ���� ����� �� ���������� �� ��������� */
                for (i = 1; i <= m; i++)
                //������ ������� a[i,j] � ����
                {
                    for (j = 1; j <= n; j++)
                    {
                        write_text.WriteLine(a[i, j]); /*���������� � ���� ����� �� ���������� ���� */
                    }
                }
                write_text.Close(); // ��������� ����
            }
        }
    }