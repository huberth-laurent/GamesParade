using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Data
{
    [Serializable]
    class Tweet
    {
        public Tweet()
        {
            _user = new Lazy<User>(() => Database.UsersById[userId]);
            _requiresTweets = new Lazy<IReadOnlyList<Tweet>>(GetSentAfter);
        }

        public User User => _user.Value;
        [NonSerialized]
        private readonly Lazy<User> _user;

#pragma warning disable 0649
        public string id;
        public string userId;
        public string message;
        public string requires;
#pragma warning restore 0649

        public float? SentAtTime { get; set; } = null;

        public bool IsSent => SentAtTime <= Time.time;

        public IReadOnlyList<Tweet> RequiresTweets => _requiresTweets.Value;
        [NonSerialized]
        private readonly Lazy<IReadOnlyList<Tweet>> _requiresTweets;

        private IReadOnlyList<Tweet> GetSentAfter()
        {
            var list = new List<Tweet>();

            if (!string.IsNullOrEmpty(requires))
            {
                foreach (var requireId in requires.Split(','))
                {
                    if (!Database.TweetsById.TryGetValue(requireId, out var tweet))
                    {
                        Debug.LogError($"The tweet with id {id} requires the tweet with id {requireId}, but no such tweet exists");
                    }
                    list.Add(tweet);
                }
            }
            return new ReadOnlyCollection<Tweet>(list);
        }
    }
}
