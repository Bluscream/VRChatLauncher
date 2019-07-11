using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChatApi.Classes;

namespace VRChatLauncher
{
    public class FriendsBackup
    {
        public Friend Account { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<Friend> Friends = new List<Friend>();
        public class Friend
        {
            // public enum Changed { Nothing, Name, Everything }
            public string id { get; set; }
            public string displayName { get; set; }
            public string username { get; set; }
            public Friend(UserBriefResponse friend)
            {
                id = friend.id; displayName = friend.displayName; username = friend.username;
            }
            /*public Changed Difference(Friend other)
            {
                if (id != other.id) return Changed.Everything;
                if (displayName != other.displayName) return Changed.Name;
                return Changed.Nothing;
            }*/
            /*public override bool Equals(object obj) {
               if (!(obj is Friend)) return false;
               var other = obj as Friend;
               if (id != other.id) return false;
               return true;
            }
            public static bool operator ==(Friend x, Friend y) { return x.Equals(y); }
            public static bool operator !=(Friend x, Friend y) { return !(x == y); }*/
        }
        public FriendsBackup(UserResponse account, List<UserBriefResponse> friends)
        {
            TimeStamp = DateTime.Now;
            Account = new Friend(account);
            foreach (var friend in friends)
            {
                Friends.Add(new Friend(friend));
            }
        }
    }
    /*public class ChangedFriend
    {
        [JsonIgnore]
        public FriendsBackup.Friend.Changed Change { get; set; }
        [JsonIgnore]
        public FriendsBackup.Friend Old;
        [JsonIgnore]
        public FriendsBackup.Friend New;
        public ChangedFriend(FriendsBackup.Friend oldFriend, FriendsBackup.Friend newFriend)
        {
            Old = oldFriend; New = newFriend; Change = oldFriend.Difference(newFriend);
        }
    }
    public class FriendsBackupDifference
    {
        [JsonIgnore]
        public List<FriendsBackup.Friend> AddedFriends { get; set; }
        [JsonIgnore]
        public List<FriendsBackup.Friend> RemovedFriends { get; set; }
        [JsonIgnore]
        public List<ChangedFriend> ChangedNames { get; set; }
        public FriendsBackupDifference(FriendsBackup one, FriendsBackup other)
        {
            var firstListOlder = one.TimeStamp < other.TimeStamp;
            var oldList = (firstListOlder) ? one : other;
            var newList = (firstListOlder) ? other : one;
            foreach (var oldFriend in oldList.Friends)
            {
                foreach (var newFriend in newList.Friends)
                {
                    var changed = new ChangedFriend(oldFriend, newFriend);
                }
            }
        }
    }*/
}
