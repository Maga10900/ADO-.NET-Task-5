using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public List<string> comboBoxItems = new();
        public List<string> comboBoxNames = new() { "Authors", "Themes", "Categories" };
        private SqlConnection con;
        private DataSet dataSet;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmd;
        string cs = @"Server = (localdb)\MSSQLLocalDB; 
Integrated Security = SSPI; 
Database = Library";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = comboBoxNames;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                using LibraryContext db = new LibraryContext();


                comboBox2.DataSource = db.Authors.ToList();



            }

            else if (comboBox1.SelectedIndex == 1)
            {
                using LibraryContext db = new LibraryContext();


                comboBox2.DataSource = db.Themes.ToList();

            }

            else if (comboBox1.SelectedIndex == 2)
            {
                using LibraryContext db = new LibraryContext();


                comboBox2.DataSource = db.Categories.ToList();

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using LibraryContext db = new LibraryContext();

            int index = comboBox1.SelectedIndex;
            int index2 = comboBox2.SelectedIndex;

            if (index == 0)
            {
                Author author = comboBox2.SelectedItem as Author;
                var list = db.Books.Where(a => a.IdAuthor == author.Id).ToList();
                dataGridView1.DataSource = list;
            }
            else if(index == 1)
            {
                Theme theme = comboBox2.SelectedItem as Theme;
                var list = db.Books.Where(a => a.IdThemes == theme.Id).ToList();
                dataGridView1.DataSource = list;
            }
            else if(index == 2)
            {
                Category category = comboBox2.SelectedItem as Category;
                var list = db.Books.Where(a => a.IdCategory == category.Id).ToList();
                dataGridView1.DataSource = list;
            }
        }
    }
}
