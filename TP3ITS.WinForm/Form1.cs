using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace TP3ITS.WinForm
{
    public partial class Form1 : Form
    {
        List<string> todos = new List<string>();
        XmlSerializer xs;
        List<TodoList> ls;
public Form1()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\fondo.jpg");
            this.BackgroundImage = img;
            ls = new List<TodoList>();
            xs = new XmlSerializer(typeof(List<TodoList>));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            submitBtn.Enabled = false;
        }
        private void todoBox_TextChanged(object sender, EventArgs e)
        {
            string currentTodo = todoBox.Text;
            if (currentTodo.Length > 3)
            {
                submitBtn.Enabled = true;
                label1.Hide();
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\todoList.xml", FileMode.Create, FileAccess.Write);
            TodoList tl = new TodoList();
            tl.TodoName = todoBox.Text;
            ls.Add(tl);
            xs.Serialize(fs, ls);
            fs.Close();
            todoBox.Clear();
            {
                MessageBox.Show("Tarea creada");
            }
        }

        private void ListBtn_Click_1(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\todoList.xml", FileMode.Open, FileAccess.Read);
            ls = (List<TodoList>)xs.Deserialize(fs);
            TodoList s = ls[0];
            dataGridView1.DataSource = ls;
            fs.Close();

        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
