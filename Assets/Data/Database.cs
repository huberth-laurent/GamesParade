using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Data
{
    class Database : MonoBehaviour
    {
        private void Start()
        {
            _tweets = JsonUtility.FromJson<Tweets>(Resources.Load<TextAsset>("tweets").text).tweets;
            _usersById = JsonUtility.FromJson<Users>(Resources.Load<TextAsset>("users").text).users.ToDictionary(x => x.id);
            UsersById = new ReadOnlyDictionary<string, User>(_usersById);
        }

        public static IEnumerable<Tweet> GetAllSentTweets() => _tweets.ToList();

        public static IReadOnlyDictionary<string, User> UsersById { get; private set; }

        private static IList<Tweet> _tweets;
        private static IDictionary<string, User> _usersById;
    }
}
