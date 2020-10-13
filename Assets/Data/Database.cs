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
        private const float TweetDelaySeconds = 5;

        private void Start()
        {
            _tweetsById = JsonUtility.FromJson<Tweets>(Resources.Load<TextAsset>("tweets").text).tweets.ToDictionary(x => x.id);

            _usersById = JsonUtility.FromJson<Users>(Resources.Load<TextAsset>("users").text).users.ToDictionary(x => x.id);

            TweetsById = new ReadOnlyDictionary<string, Tweet>(_tweetsById);
            UsersById = new ReadOnlyDictionary<string, User>(_usersById);
        }

        private void Update()
        {
            UpdateSentTweets();
        }

        public static IEnumerable<Tweet> GetAllSentTweets() => _tweetsById.Values
            .Where(x => x.IsSent)
            .ToList();

        public static IEnumerable<Tweet> GetAllUserSentTweets(User user) => GetAllUserSentTweets(user.id);
        public static IEnumerable<Tweet> GetAllUserSentTweets(string userId) => GetAllSentTweets()
            .Where(x => x.userId == userId)
            .ToList();

        public static IReadOnlyDictionary<string, User> UsersById { get; private set; }
        public static IReadOnlyDictionary<string, Tweet> TweetsById { get; private set; }

        private static IDictionary<string, Tweet> _tweetsById;
        private static IDictionary<string, User> _usersById;

        private void UpdateSentTweets()
        {
            bool changed = true;
            while (changed)
            {
                changed = false;
                foreach (var tweet in TweetsById.Values.Where(x => x.SentAtTime == null))
                {
                    if (tweet.RequiresTweets.All(x => x.IsSent))
                    {
                        tweet.SentAtTime = Time.time + TweetDelaySeconds;
                        changed = true;
                    }
                }
            }
        }
    }
}
