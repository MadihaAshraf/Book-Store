using AppProps;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Semester_Project_BookStore
{
    public partial class BookForm : System.Web.UI.Page
    {
        BookBLL bookBLL = new BookBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            book.Id = int.Parse(txtId.Text);
            book.Name = txtName.Text;
            book.Genre = txtGenre.Text;
            book.Author = txtAuthor.Text;
            book.Description = txtDescription.Text;
            book.Price = float.Parse(txtPrice.Text); 


            if (bookBLL.BookInsertBLL(book))
            {
                lblResult.Text = "Data Added!";
            }
            else
            {
                lblResult.Text = "Failed to Add Data";
            }
            LoadGridView();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            book.Id = int.Parse(txtId.Text);

            if (bookBLL.BookDeleteBLL(book))
            {
                lblResult.Text = "Data Deleted!";
            }
            else
            {
                lblResult.Text = "Failed to Delete Data";
            }
            LoadGridView();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            book.Id = int.Parse(txtId.Text);
            book.Name = txtName.Text;
            book.Genre = txtGenre.Text;
            book.Author = txtAuthor.Text;
            book.Description = txtDescription.Text;
            book.Price = float.Parse(txtPrice.Text);

            if (bookBLL.BookUpdateBLL(book))
            {
                lblResult.Text = "Data Updated!";
            }
            else
            {
                lblResult.Text = "Failed to Update Data";
            }
            LoadGridView();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            book.Id = int.Parse(txtId.Text);

            if (bookBLL.BookSearchBLL(book) != null)
            {
                DataTable dataTable = bookBLL.BookSearchBLL(book);

                if (dataTable.Rows.Count > 0)
                {
                    txtName.Text = dataTable.Rows[0]["Name"].ToString();
                    txtGenre.Text = dataTable.Rows[0]["Genre"].ToString();
                    txtAuthor.Text = dataTable.Rows[0]["Author"].ToString();
                    txtDescription.Text = dataTable.Rows[0]["Description"].ToString();
                    txtPrice.Text = dataTable.Rows[0]["Price"].ToString();

                    lblResult.Text = "Data Found!";
                }
            }
            else
            {
                lblResult.Text = "Failed to Search Data";
            }

            LoadGridView();
        }

        private void LoadGridView()
        {
            gridViewUser.DataSource = bookBLL.BookGetAllBLL();
            gridViewUser.DataBind();
        }
    }
}