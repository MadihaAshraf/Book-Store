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
    public partial class BookHandle : System.Web.UI.Page
    {
        string guid = Guid.NewGuid().ToString();
        BookBLL bookBLL = new BookBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            // check if file is uploaded or selected in file upload control
            if (fileUpload.HasFiles)
            {
                // to get extension
                string extension = System.IO.Path.GetExtension(fileUpload.FileName);

                if (extension == ".jpg" || extension == ".png")
                {
                    // get Images folder path
                    string path = Server.MapPath("Images\\");

                    // get unique name
                    string imageName = guid + fileUpload.FileName;
                    book.Image = imageName;

                    // save image in folder
                    fileUpload.SaveAs(path + imageName);
                }
                else
                {
                    lblResult.Text = "Please upload image with jpg or png extension";
                }
            }
            else
            {
                lblResult.Text = "Please select a file";
            }

            

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

            if (fileUpload.HasFiles)
            {
                // to get extension
                string extension = System.IO.Path.GetExtension(fileUpload.FileName);

                if (extension == ".jpg" || extension == ".png")
                {
                    // get Images folder path
                    string path = Server.MapPath("Images\\");

                    // get unique name
                    string imageName = guid + fileUpload.FileName;
                    book.Image = imageName;

                    // save image in folder
                    fileUpload.SaveAs(path + imageName);

                    book.Image = imageName;
                }
                else
                {
                    lblResult.Text = "Please upload image with jpg or png extension";
                }
            }

            book.Id = int.Parse(txtId.Text);
            book.Name = txtName.Text;
            book.Genre = txtGenre.Text;
            book.Author = txtAuthor.Text;
            book.Description = txtDescription.Text;
            book.Price = float.Parse(txtPrice.Text);
            Console.WriteLine(lbl.Text); 
            if (book.Image == null)
            {
                book.Image = lbl.Text;
            }

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
                    lbl.Text = dataTable.Rows[0]["Image"].ToString();

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
            gridViewProduct.DataSource = bookBLL.BookGetAllBLL();
            gridViewProduct.DataBind();
        }

    }
}