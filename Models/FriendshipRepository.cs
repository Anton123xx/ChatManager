using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ChatManager.Models
{
    public class FriendshipRepository : Repository<Friendship>
    {
        //public Friendship addFriendship(int userId, int friendId)
        //{
        //    try
        //    {
        //        Friendship friendship = new Friendship();
        //        friendship.UserId = userId;
        //        friendship.FriendId = friendId;
        //        friendship.Id = DB.Friendships.Add(friendship);
        //        friendship.TypeAmitie = 1;
        //        return friendship;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"AddLogin failed : Message - {ex.Message}");
        //        return null;
        //    }
        //}





        public Friendship SendFriendshipRequest(int userId, int friendId)

        {

            try

            {

                BeginTransaction();

                Friendship friendship = new Friendship() { UserId = userId, FriendId = friendId };

                friendship.Id = DB.Friendships.Add(friendship);

                EndTransaction();

                return friendship;

            }

            catch (Exception ex)

            {

                EndTransaction();

                System.Diagnostics.Debug.WriteLine($"Add_UnverifiedEmail failed : Message - {ex.Message}");

                return null;

            }

        }



        public void RetirerFriendshipRequest(int userId, int friendId)

        {

            try

            {

                BeginTransaction();

                Friendship friendship = GetFriendship(userId, friendId);

                if (friendship == null)

                {

                    friendship = GetFriendship(friendId, userId);

                }

                DB.Friendships.Delete(friendship.Id);

                EndTransaction();

            }

            catch (Exception ex)

            {

                EndTransaction();

                System.Diagnostics.Debug.WriteLine($"Add_UnverifiedEmail failed : Message - {ex.Message}");

            }

        }



        public Friendship RefuseFriendshipRequest(int userId, int friendId)

        {

            try

            {

                BeginTransaction();

                Friendship friendship = DB.Friendships.ToList().Where(u => (u.UserId == userId) && (u.FriendId == friendId)).FirstOrDefault();

                friendship.TypeAmitie = 2;

                DB.Friendships.Update(friendship);

                EndTransaction();

                return friendship;

            }

            catch (Exception ex)

            {

                EndTransaction();

                System.Diagnostics.Debug.WriteLine($"Add_UnverifiedEmail failed : Message - {ex.Message}");

                return null;

            }

        }







        public Friendship AcceptFriendRequest(int userId, int friendId)

        {

            try

            {

                BeginTransaction();

                Friendship friendship = DB.Friendships.ToList().Where(u => (u.UserId == userId) && (u.FriendId == friendId)).FirstOrDefault();

                friendship.TypeAmitie = 1;

                DB.Friendships.Update(friendship);

                EndTransaction();

                return friendship;

            }

            catch (Exception ex)

            {

                EndTransaction();

                System.Diagnostics.Debug.WriteLine($"Add_UnverifiedEmail failed : Message - {ex.Message}");

                return null;

            }

        }









        public Friendship isFriend(int userId, int friendId)

        {

            return DB.Friendships.ToList().Where(u => ((u.UserId == userId) && (u.FriendId == friendId)) && u.TypeAmitie == 1).FirstOrDefault();

        }



        public Friendship FriendRequestWaiting(int userId, int friendId)

        {

            return DB.Friendships.ToList().Where(u => ((u.UserId == userId) && (u.FriendId == friendId)) && u.TypeAmitie == 0).FirstOrDefault();

        }



        public Friendship HaveFriendRequest(int userId, int friendId)

        {

            return DB.Friendships.ToList().Where(u => ((u.UserId == userId) && (u.FriendId == friendId)) && u.TypeAmitie == 0).FirstOrDefault();

        }

        public Friendship FriendRequestDenied(int userId, int friendId)

        {

            return DB.Friendships.ToList().Where(u => ((u.UserId == userId) && (u.FriendId == friendId)) && u.TypeAmitie == 2).FirstOrDefault();

        }



        public Friendship GetFriendship(int userId, int friendId)

        {

            return DB.Friendships.ToList().Where(u => (u.UserId == userId) && (u.FriendId == friendId)).FirstOrDefault();

        }





    }





}




