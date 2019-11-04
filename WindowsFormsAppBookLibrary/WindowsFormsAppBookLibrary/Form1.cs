using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppBookLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            { Name = textBoxName.Text,
            Author=textBoxAuthor.Text,
            Declare=textBoxDeclare.Text,
            Page=textBoxPage.Text
            };

            listBoxBooks.Items.Add(book);

            textBoxName.Text =
            textBoxAuthor.Text =
            textBoxDeclare.Text =
            textBoxPage.Text ="";
            
        }
        string FileName = "books.dat";
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Book> books = new List<Book>();

            foreach (Book item in listBoxBooks.Items)
            {
                books.Add(item);
            }

            using (Stream stream=File.Open(FileName,FileMode.OpenOrCreate,FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, books);

            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            using (Stream stream=File.Open(FileName,FileMode.Open,FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                List<Book> books = (List<Book>)formatter.Deserialize(stream);
                listBoxBooks.Items.AddRange(books.ToArray());
            }
        }

        private void listBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxBooks.SelectedIndex;
            object selected = listBoxBooks.Items[index];

            Book book = (Book)selected;

            propertyGrid1.SelectedObject=book;

            textBoxName.Text = book.Name;
            textBoxAuthor.Text = book.Author;
            textBoxDeclare.Text = book.Declare;
            textBoxPage.Text = book.Page;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBoxBooks.Items.Clear();
        }
    }
}
