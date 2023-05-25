using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ChatManager.Models;

namespace ChatManager.Controllers
{
    public class ChatController : Controller
    {

        public int IdSelected
        {
            get
            {
                if (Session["IdSelected"] == null)
                {
                    Session["IdSelected"] = 0;
                }
                return (int)Session["IdSelected"];
            }
            set
            {
                Session["IdSelected"] = value;
            }
        }

        private List<Chat> Chats(int userId)
        {
            return DB.Chat.ToList().OrderBy(c => c.DateTime).Where(c => c.IdSend == OnlineUsers.GetSessionUser().Id || c.IdReceive == OnlineUsers.GetSessionUser().Id && c.IdReceive == userId || c.IdSend == userId).ToList();
        }
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFriendsList(bool forceRefresh = false)
        {
            if (forceRefresh || DB.Friendships.HasChanged)
            {
                List<Friendship> friendships = DB.Friendships.ToList().OrderBy(c => c.Id).Where(m => m.TypeAmitie == 1
                && m.UserId == OnlineUsers.GetSessionUser().Id || m.FriendId == OnlineUsers.GetSessionUser().Id).ToList();
                List<User> users = new List<User>();
                foreach (var friendship in friendships)
                {
                    if (friendship.UserId == OnlineUsers.GetSessionUser().Id)
                        users.Add(DB.Users.Get(friendship.FriendId));
                    if (friendship.FriendId == OnlineUsers.GetSessionUser().Id)
                        users.Add(DB.Users.Get(friendship.UserId));
                }
                return PartialView(users);
            }
            return null;
        }


        public ActionResult GetMessages(bool forceRefresh = false)
        {
            if (forceRefresh || DB.Chat.HasChanged)
            {
                ViewBag.IDSelected = IdSelected;
                return PartialView(Chats(ViewBag.IDSelected));
            }

            return null;
        }


        public ActionResult SetCurrentTarget(int id)
        {

            IdSelected = id;
            return null;
        }

        public ActionResult Send(string message)
        {
            if (IdSelected != 0)
            {
                Chat.IdSelected = OnlineUsers.GetSessionUser().Id;
                Chat.TempMessage = message;
                Chat chat = new Chat();
                chat.IdSend = OnlineUsers.GetSessionUser().Id;
                chat.IdReceive = IdSelected;
                DB.Chat.Add(chat);
                OnlineUsers.AddNotification((int)Session["IdSelected"], $"Bonjour, vous avez reçu un nouveau message de {OnlineUsers.GetSessionUser().Id}");


            }

            return null;
        }


        public ActionResult IsTyping()
        {
            return null;
        }

        public ActionResult StopTyping()
        {
            return null;
        }


        public ActionResult Delete(int id)
        {
            DB.Chat.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id, string message)
        {
            Chat chat = DB.Chat.Get(id);
            chat.Message = message;/////////3
            DB.Chat.Update(chat);
            return RedirectToAction("Index");
        }

        public ActionResult IsTargetTyping()
        {
            return null;
        }

        ////CONVERSATIONS, LOGS, GETCHATLOGS 
        ///
        ///conversations utilise chat logs


        public ActionResult Conversations()
        {
            return View();
        }

        public List<Chat> Logs()
        {
            return DB.Chat.ToList().OrderBy(c => c.DateTime).ToList();
        }

        public ActionResult GetChatLogs(bool forceRefresh = false)
        {
            if (forceRefresh || DB.Chat.HasChanged)
            {

                return PartialView(Logs());
            }
            return null;
        }

        public ActionResult SupprimerChatLog(int id)
        {
            DB.Chat.Delete(id);
            return RedirectToAction("Conversations");
        }
    }
}