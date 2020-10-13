using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    [Serializable]
    class Tweet
    {
        public Tweet()
        {
            _user = new Lazy<User>(() => Database.UsersById[userId]);
        }

        public User User => _user.Value;
        [NonSerialized]
        private readonly Lazy<User> _user;

        public string id;
        public string userId;
        public string message;
        public string requires;
    }
}
