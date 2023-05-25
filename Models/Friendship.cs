using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ChatManager.Models
{
    public class Friendship
    {
        public int Id { get; set; }
        public int UserId { get; set; } /// LUI QUI A ENVOYER LA DEMANDE
       
        
        public int FriendId { get; set; } /// LUI QUI A RECU DEMANDE

        
        public int TypeAmitie { get; set; } = 0;

        public Friendship()
        {
           
            //TypeAmitie = 0; 
        }
        public Friendship Clone()
        {
            return JsonConvert.DeserializeObject<Friendship>(JsonConvert.SerializeObject(this));
        }
    }
}
