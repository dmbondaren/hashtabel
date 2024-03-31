using System.Collections;
using System.Windows.Forms;
using System;

namespace hashtabel
{
    public partial class Form1 : Form
    {
        private Hashtable studentsHashtable = new Hashtable();
        private ArrayList arrayList = new ArrayList();

        public Form1()
        {
            InitializeComponent();

        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (DictionaryEntry entry in studentsHashtable)
            {
                Student student = (Student)entry.Value;
                listBox1.Items.Add($"{entry.Key}: {student.Name}, {student.Grade}");
            }
        }

        private void button1_Click(object sender, EventArgs e) // Додати
        {
            string roomNumber = textBox1.Text;
            string name = textBox2.Text;
            int grade;
            if (!int.TryParse(textBox3.Text, out grade))
            {
                MessageBox.Show("Оцінка має бути числом.");
                return;
            }

            if (studentsHashtable.ContainsKey(roomNumber))
            {
                MessageBox.Show("Кімната вже містить студента.");
                return;
            }

            studentsHashtable.Add(roomNumber, new Student(name, grade));
            UpdateListBox();
        }

        private void button2_Click(object sender, EventArgs e) // Видалити
        {
            string roomNumber = textBox1.Text;

            if (!studentsHashtable.ContainsKey(roomNumber))
            {
                MessageBox.Show("Кімната не містить студента.");
                return;
            }

            studentsHashtable.Remove(roomNumber);
            UpdateListBox();
        }

        private void button3_Click(object sender, EventArgs e) // Редагувати
        {
            string roomNumber = textBox1.Text;
            string name = textBox2.Text;
            int grade;
            if (!int.TryParse(textBox3.Text, out grade))
            {
                MessageBox.Show("Оцінка має бути числом.");
                return;
            }

            if (studentsHashtable.ContainsKey(roomNumber))
            {
                // Отримуємо існуючого студента за номером кімнати
                Student existingStudent = (Student)studentsHashtable[roomNumber];

                // Оновлюємо дані студента
                existingStudent.Name = name;
                existingStudent.Grade = grade;

                // Оновлюємо відображення списку
                UpdateListBox();
            }
            else
            {
                MessageBox.Show("Кімната не містить студента.");
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // При виборі об'єкта в ListBox
        {
            if (listBox1.SelectedIndex != -1)
            {
                string[] selectedStudent = listBox1.SelectedItem.ToString().Split(':');
                textBox1.Text = selectedStudent[0].Trim();
                string[] studentInfo = selectedStudent[1].Trim().Split(',');
                textBox2.Text = studentInfo[0].Trim();
                textBox3.Text = studentInfo[1].Trim();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Очистити дані при зміні тексту в TextBox1
        {
            textBox2.Clear();
            textBox3.Clear();
            listBox1.ClearSelected();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // Очистити дані при зміні тексту в TextBox2
        {
            listBox1.ClearSelected();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) // Очистити дані при зміні тексту в TextBox3
        {
            listBox1.ClearSelected();
        }

        private void button4_Click(object sender, EventArgs e) // Пошук співпадінь за прізвищем
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button6.Click += button6_Click;
            button7.Click += button7_Click;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            bool found = false;

            foreach (DictionaryEntry entry in studentsHashtable)
            {
                if (((Student)entry.Value).Name.Equals(name))
                {
                    MessageBox.Show($"Знайдено студента в кімнаті {entry.Key}: {((Student)entry.Value).Name}, {((Student)entry.Value).Grade}");

                }
            }

            if (!found)
            {
                MessageBox.Show("Студент не знайдений.");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string input = textBox4.Text;
            int number;

            if (int.TryParse(input, out number))
            {
                arrayList.Add(number);
            }
            else
            {
                arrayList.Add(input);
            }

            UpdateListBox2();
        }

        private void UpdateListBox2()
        {
            listBox2.Items.Clear();

            // Вивід всієї колекції
            foreach (var item in arrayList)
            {
                listBox2.Items.Add(item.ToString());
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // Вивід окремо рядків
            listBox2.Items.Clear();
            foreach (var item in arrayList)
            {
                if (item is string)
                {
                    listBox2.Items.Add(item.ToString());
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Вивід чисел із рядків
            listBox2.Items.Clear();
            foreach (var item in arrayList)
            {
                if (item is int)
                {
                    listBox2.Items.Add(item.ToString());
                }
                else if (item is string)
                {
                    int number;
                    if (int.TryParse((string)item, out number))
                    {
                        listBox2.Items.Add(number.ToString());
                    }
                }
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }
    }
}