using System;
using System.Net.Mail;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("test.licenta2015@gmail.com");
                mailMessage.To.Add("test.licenta2015@gmail.com");
                mailMessage.Subject = txtSubject.Text;
                mailMessage.Body = "<b>Sender name: </b>" + txtName.Text + "<br/>"
                    + "<b>Sender email: </b>" + txtEmail.Text + "<br/>" +
                    "<b>Comments: </b>" + txtComments.Text;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;

                smtpClient.Credentials = new System.Net.NetworkCredential("test.licenta2015@gmail.com", "licenta2015");
                smtpClient.Send(mailMessage);

                Label1.Text = "Iti multumim ca ne-ai contactat!";
                Label1.ForeColor = System.Drawing.Color.Blue;

                txtName.Enabled = false;
                txtEmail.Enabled = false;
                txtComments.Enabled = false;
                txtSubject.Enabled = false;
                Button1.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Label1.ForeColor = System.Drawing.Color.BlueViolet;
            Label1.ForeColor = System.Drawing.Color.Blue;
            Label1.Text = "S-a ivit o problema. Incercati mai tarziu";
        }
    }
}

 
