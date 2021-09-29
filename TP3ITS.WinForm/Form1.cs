using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3ITS.WinForm
{
    public partial class Form1 : Form
    {
        List<string> todos = new List<string>();
public Form1()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\fondo.jpg");
            this.BackgroundImage = img;
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
            string currentTodo = todoBox.Text;
            todos.Add(currentTodo);
            todoBox.Clear();
        }

        private void ListBtn_Click_1(object sender, EventArgs e)
        {
            string allTodos = string.Join("\n", todos);
            if (allTodos == "") 
            {
               MessageBox.Show("No hay tareas pendientes por hacer"); 
            }  else 
                { 
                    MessageBox.Show(allTodos); 
                }
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
