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
            _usersById = JsonUtility.FromJson<Users>(Resources.Load<TextAsset>("users").text).users.ToDictionary(x => x.id);
            _tweetsById = JsonUtility.FromJson<Tweets>(Resources.Load<TextAsset>("tweets").text).tweets.ToDictionary(x => x.id);
            _textsById = JsonUtility.FromJson<Texts>(Resources.Load<TextAsset>("texts").text).texts.ToDictionary(x => x.id);
            _sendablesById = _tweetsById.Values.OfType<ISendable>().Concat(_textsById.Values.OfType<ISendable>()).ToDictionary(x => x.Id);

            UsersById = new ReadOnlyDictionary<string, User>(_usersById);
            SendablesById = new ReadOnlyDictionary<string, ISendable>(_sendablesById);
            TweetsById = new ReadOnlyDictionary<string, Tweet>(_tweetsById);
            TextsById = new ReadOnlyDictionary<string, Text>(_textsById);

            God = UsersById["god"];
            Death = UsersById["death"];
        }

        private void Update()
        {
            UpdateSentSendables();
        }

        public static IReadOnlyList<ISendable> GetRequiredSendables(ISendable sendable)
        {
            var list = new List<ISendable>();

            if (!string.IsNullOrWhiteSpace(sendable.Requires))
            {
                foreach (var requireId in string.Concat(sendable.Requires.Where(x => !char.IsWhiteSpace(x))).Split(','))
                {
                    if (!SendablesById.TryGetValue(requireId, out var required))
                    {
                        Debug.LogError($"The tweet with id {sendable.Id} requires the tweet with id {requireId}, but no such tweet exists");
                    }
                    list.Add(required);
                }
            }
            return new ReadOnlyCollection<ISendable>(list);
        }

        public static User God;
        public static User Death;

        public static IEnumerable<Tweet> GetAllSentTweets() => _tweetsById.Values
            .Where(x => x.IsSent)
            .ToList();

        public static IEnumerable<Tweet> GetAllUserSentTweets(User user) => GetAllUserSentTweets(user.id);
        public static IEnumerable<Tweet> GetAllUserSentTweets(string userId) => GetAllSentTweets()
            .Where(x => x.userId == userId)
            .ToList();

        public static IEnumerable<Text> GetAllSentTexts() => _textsById.Values
            .Where(x => x.IsSent)
            .ToList();

        public static IReadOnlyDictionary<string, User> UsersById { get; private set; }
        public static IReadOnlyDictionary<string, ISendable> SendablesById { get; private set; }
        public static IReadOnlyDictionary<string, Tweet> TweetsById { get; private set; }
        public static IReadOnlyDictionary<string, Text> TextsById { get; private set; }

        private static IDictionary<string, User> _usersById;
        private static IDictionary<string, ISendable> _sendablesById;
        private static IDictionary<string, Tweet> _tweetsById;
        private static IDictionary<string, Text> _textsById;

        private void UpdateSentSendables()
        {
            bool changed = true;
            while (changed)
            {
                changed = false;
                foreach (var sendable in SendablesById.Values.Where(x => x.SentAtTime == null && (x.User != Death || x is Text)))
                {
                    if (sendable.RequiresSendables.All(x => x.IsSent))
                    {
                        sendable.SentAtTime = Time.time + TweetDelaySeconds;
                        changed = true;
                    }
                }
            }
        }
    }
}
