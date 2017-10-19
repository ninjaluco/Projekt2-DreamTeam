using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Index
{
	public partial class Admin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void addButton_Click(object sender, EventArgs e)
		{
				int amount = int.Parse(amountTextBox.Text);
				this.Master.buttonBuyThings_Click(sender, e, amount);
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			int amount = int.Parse(amountTextBox.Text);
			this.Master.buttonBuyThings_Click(sender, e, amount);
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			int amount = int.Parse(amountTextBox.Text);
			this.Master.buttonBuyThings_Click(sender, e, amount);
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			int amount = int.Parse(amountTextBox.Text);
			this.Master.buttonBuyThings_Click(sender, e, amount);
		}

	}
}