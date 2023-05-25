using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatManager.Models
{
    public class Chat
    {


        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public int IdSend { get; set; }


        public int IdReceive { get; set; }

        public static int IdSelected { get; set; }

        public static string TempMessage { get; set; } 

        public string Message { get; set; }


        public Chat()
        {
            DateTime = DateTime.Now;
            this.Message = TempMessage;
        }

        
    }
}