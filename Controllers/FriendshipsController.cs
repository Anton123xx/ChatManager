using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatManager.Controllers
{
    public class FriendshipsController : Controller
    {


        public string SearchValue

        {

            get

            {

                if (Session["SearchValue"] == null)

                {

                    SearchValue = string.Empty;

                }

                return (string)Session["SearchValue"];



            }

            set { Session["SearchValue"] = value; }

        }

        public bool FilterNotFriend
        {

            get

            {

                if (Session["FilterNotFriend"] == null)

                {

                    Session["FilterNotFriend"] = true;

                }

                return (bool)Session["FilterNotFriend"];

            }

            set { Session["FilterNotFriend"] = value; }

        }

        public bool FilterRequest
        {

            get

            {

                if (Session["FilterRequest"] == null)

                {

                    Session["FilterRequest"] = true;

                }

                return (bool)Session["FilterRequest"];

            }

            set { Session["FilterRequest"] = value; }

        }

        public bool FilterPending
        {

            get

            {

                if (Session["FilterPending"] == null)

                {

                    Session["FilterPending"] = true;

                }

                return (bool)Session["FilterPending"];

            }

            set { Session["FilterPending"] = value; }

        }

        public bool FilterFriend
        {

            get

            {

                if (Session["FilterFriend"] == null)

                {

                    Session["FilterFriend"] = true;

                }

                return (bool)Session["FilterFriend"];

            }

            set { Session["FilterFriend"] = value; }

        }

        public bool FilterRefused
        {

            get

            {

                if (Session["FilterRefused"] == null)

                {

                    Session["FilterRefused"] = true;

                }

                return (bool)Session["FilterRefused"];

            }

            set { Session["FilterRefused"] = value; }

        }

        public bool FilterBlocked
        {

            get

            {

                if (Session["FilterBlocked"] == null)

                {

                    Session["FilterBlocked"] = true;

                }

                return (bool)Session["FilterBlocked"];

            }

            set { Session["FilterBlocked"] = value; }

        }

        public ActionResult Index()
        {
            return View();

        }

        [HttpGet]

        public ActionResult SendFriendRequest(int friendId)

        {

            Models.DB.Friendships.SendFriendshipRequest(Models.OnlineUsers.GetSessionUser().Id, friendId);

            return RedirectToAction("Index");

        }



        [HttpGet]

        public ActionResult RefuseFriendshipRequest(int friendId)

        {

            Models.DB.Friendships.RefuseFriendshipRequest(friendId, Models.OnlineUsers.GetSessionUser().Id);

            return RedirectToAction("Index");

        }



        [HttpGet]

        public ActionResult AcceptFriendRequest(int friendId)

        {

            Models.DB.Friendships.AcceptFriendRequest(friendId, Models.OnlineUsers.GetSessionUser().Id);

            return RedirectToAction("Index");



        }



        [HttpGet]

        public ActionResult RetirerFriendShipRequest(int friendId)

        {

            Models.DB.Friendships.RetirerFriendshipRequest(Models.OnlineUsers.GetSessionUser().Id, friendId);

            return View();

        }



        [HttpGet]

        public ActionResult Search(string text)

        {

            SearchValue = text;

            return PartialView();

        }

        [HttpGet]

        public ActionResult GetFriendshipStatus()

        {

            ViewBag.FilterNotFriend = FilterNotFriend;

            ViewBag.FilterRequest = FilterRequest;

            ViewBag.FilterPending = FilterPending;



            ViewBag.FilterFriend = FilterFriend;

            ViewBag.FilterRefused = FilterRefused;

            ViewBag.FilterBlocked = FilterBlocked;



            ViewBag.SearchValue = SearchValue;

            return PartialView();

        }



        [HttpGet]

        public ActionResult SetFilterRequest(bool check)

        {

            FilterRequest = check;

            return PartialView();

        }

        [HttpGet]

        public ActionResult SetFilterNotFriend(bool check)

        {

            FilterNotFriend = check;

            return PartialView();

        }

        [HttpGet]

        public ActionResult SetFilterPending(bool check)

        {

            FilterPending = check;

            return PartialView();

        }



        [HttpGet]

        public ActionResult SetFilterFriend(bool check)

        {

            FilterFriend = check;

            return PartialView();

        }



        [HttpGet]

        public ActionResult SetFilterRefused(bool check)

        {

            FilterRefused = check;

            return PartialView();

        }

        [HttpGet]

        public ActionResult SetFilterBlocked(bool check)

        {

            FilterBlocked = check;

            return PartialView();

        }

    }

}









