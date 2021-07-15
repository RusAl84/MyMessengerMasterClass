using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MesServT
{
  public class MessageClass
  {
    [Serializable]
    public class Message
    {
      public string userName { get; set; }
      public string messageText { get; set; }
      public DateTime timeStamp { get; set; }

      public Message()
      {
        userName = "System";
        messageText = "Server is running";
        timeStamp = DateTime.UtcNow;
      }

      public Message(string _userName, string _messageText, DateTime _timeStamp)
      {
        userName = _userName;
        messageText = _messageText;
        timeStamp = _timeStamp;
      }

      public override string ToString()
      {
        string output = String.Format("{0} {1} {2}", userName, messageText, timeStamp);
        return output;
      }
    }
  }

}
