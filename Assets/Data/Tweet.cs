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
    class Tweet : ISendable
    {
        public Tweet()
        {
            _user = new Lazy<User>(() => Database.UsersById[userId]);
            _requiresSendables = new Lazy<IReadOnlyList<ISendable>>(() => Database.GetRequiredSendables(this));
            _possibleReplies = new Lazy<IReadOnlyList<Tweet>>(() => Database.GetPossibleReplies(this));
        }

#pragma warning disable 0649
        public string id;
        public string userId;
        public string message;
        public string requires;
        public string replyTo;
#pragma warning restore 0649

        public int Likes { get; set; } = 0;

        public bool PlayerLikes { get; set; }

        public User User => _user.Value;
        [NonSerialized]
        private readonly Lazy<User> _user;

        string ISendable.Id => id;

        string ISendable.Requires => requires;

        public float? SentAtTime { get; set; } = null;

        public bool IsSent => SentAtTime <= Time.time;

        public IReadOnlyList<Tweet> PossibleReplies => _possibleReplies.Value;
        [NonSerialized]
        private readonly Lazy<IReadOnlyList<Tweet>> _possibleReplies;

        public IReadOnlyList<ISendable> RequiresSendables => _requiresSendables.Value;
        [NonSerialized]
        private readonly Lazy<IReadOnlyList<ISendable>> _requiresSendables;
    }
}
