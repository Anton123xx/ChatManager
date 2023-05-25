using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatManager.Models
{
    public class ChatRepository : Repository<Chat>
    {


        public override bool Update(Chat chat)
        {
            BeginTransaction();
            var result = base.Update(chat);
            EndTransaction();
            return result;
        }


        public Chat GetChat(int messageId)
        {
            Chat chat = ToList().Where(u => (u.Id == messageId)).FirstOrDefault();

            return chat;
        }


        public override bool Delete(int Id)
        {
            Chat chat = DB.Chat.Get(Id);
            if(chat != null)
            {
                BeginTransaction();
                var result = base.Delete(Id);
                EndTransaction();
                return result;
            }
            return false;
            
        }


    }
}