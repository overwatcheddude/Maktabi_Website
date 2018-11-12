using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookLoan
/// </summary>
public class BookLoan
{
    public int BookID { get; set; }
    public string UserName { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
	public BookLoan()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}