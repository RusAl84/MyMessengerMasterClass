using MyMessanger_Stepik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{
  public partial class Form1 : Form
  {
    private static int MessageID = 0;
    private static string UserName;
    private static MessangerClientAPI API = new MessangerClientAPI();

    public Form1()
    {
      InitializeComponent();
    }

    private void SendButton_Click(object sender, EventArgs e)
    {
      string UserName = UserNameTB.Text;
      string Message = MessageTB.Text;
      if ((UserName.Length > 1) && (UserName.Length > 1))
      {
        MyMessanger_Stepik.Message msg = new MyMessanger_Stepik.Message(UserName, Message, DateTime.Now);
        API.SendMessageRestSharp(msg);
      }

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      var getMessage = new Func<Task>(async () =>
      {
        MyMessanger_Stepik.Message msg = await API.GetMessageHTTPAsync(MessageID);
        while (msg != null)
        {
          MessagesLB.Items.Add(msg);
          MessageID++;
          msg = await API.GetMessageHTTPAsync(MessageID);
        }
      });
      getMessage.Invoke();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }
}
