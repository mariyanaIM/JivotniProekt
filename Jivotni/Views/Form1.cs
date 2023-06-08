using Jivotni.Controllers;
using Jivotni.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jivotni.Views
{
    public partial class Form1 : Form
    {
        AnimalLogic animalController = new AnimalLogic();
        BreedLogic breadController = new BreedLogic();
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadRecord(Animal animal)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = animal.Id.ToString();
            textBox2.Text = animal.Name;
            textBox3.Text = animal.Age.ToString();
            comboBox1.Text = animal.Breads.Name;
        }
        private void ClearScreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Bread> allBreads = breadController.GetAllBreeds();
            comboBox1.DataSource = allBreads;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            btnSelectAll_Click(sender, e);

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Animal> allAnimals = animalController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allAnimals)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name} - Age:{item.Age} Bread:{item.BreadId}");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                textBox2.Focus();
                return;
            }
            Animal newAnimal= new Animal();
            newAnimal.Age= int.Parse(textBox3.Text);
            newAnimal.Name = textBox2.Text;
            newAnimal.BreadId = (int)comboBox1.SelectedValue;
            animalController.Create(newAnimal);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            btnSelectAll_Click(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox4.Text);
            }
            Animal findedAnimal = animalController.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedAnimal);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(textBox4.Text) || !textBox4.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox4.Text);
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                Animal findedAnimal = animalController.Get(findId);
                if (findedAnimal == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    textBox1.BackColor = Color.Red;
                    textBox1.Focus();
                    return;
                }
                LoadRecord(findedAnimal);
            }
            else
            {
                Animal updatedAnimal = new Animal();
                updatedAnimal.Name = textBox2.Text;
                updatedAnimal.Age = int.Parse(textBox3.Text);
                updatedAnimal.BreadId = (int)comboBox1.SelectedValue;
                animalController.Update(findId, updatedAnimal);
            }
            btnSelectAll_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (textBox4.Text==null)
            {
                MessageBox.Show("Въведете Id за търсене!");
                textBox1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(textBox1.Text);
            }
            Animal findedAnimal = animalController.Get(findId);
            if (findedAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                textBox1.BackColor = Color.Red;
                textBox1.Focus();
                return;
            }
            LoadRecord(findedAnimal);
            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис No " + findId + " ?","PROMPT", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                animalController.Delete(findId);
            }
            btnSelectAll_Click(sender, e);
        }
    }
}
