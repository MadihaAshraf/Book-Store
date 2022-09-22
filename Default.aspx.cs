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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BookBLL bookBLL = new BookBLL();
                DataTable dataTable = bookBLL.BookGetAllBLL();
                DataListProducts.DataSource = dataTable;
                DataListProducts.DataBind();
            }
        }

        protected void btnAddtoCart_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Book book = new Book();
            book.Id = id;
            BookBLL bookBLL = new BookBLL();
            DataTable dataTable = bookBLL.BookSearchBLL(book);
            book.Name = dataTable.Rows[0]["Name"].ToString();
            book.Genre = dataTable.Rows[0]["Genre"].ToString();
            book.Author = dataTable.Rows[0]["Author"].ToString();
            book.Description = dataTable.Rows[0]["Description"].ToString();
            book.Price = float.Parse(dataTable.Rows[0]["Price"].ToString());
            book.Image = dataTable.Rows[0]["Image"].ToString();

            // if there is some value in cart beforehand, 
            // intialize the newCart object with previous state
            Cart cart = null;
            if (Session["cart"] != null)
            {
                cart = (Cart)Session["cart"];
            }
            Cart newCart = new Cart(cart);
            if (newCart.AddToCart(book, 1))
            {
                Session["cart"] = newCart;
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Item not Added');</script>");
            }

        }
    }
}