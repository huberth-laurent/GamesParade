﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Data
{
    [Serializable]
    class Text : ISendable
    {
        public Text()
        {
            _requiresSendables = new Lazy<IReadOnlyList<ISendable>>(() => Database.GetRequiredSendables(this));
        }

#pragma warning disable 0649
        public string id;

        public string requires;

        public string message;
#pragma warning restore 0649

        public User User => isOutgoing ? Database.Death : Database.God;
        [NonSerialized]
        private readonly Lazy<User> _user;

        public bool isOutgoing = false;

        public float? SentAtTime { get; set; } = null;

        public bool IsSent => SentAtTime <= Time.time;

        string ISendable.Id => id;

        string ISendable.Requires => requires;

        public IReadOnlyList<ISendable> RequiresSendables => _requiresSendables.Value;
        [NonSerialized]
        private readonly Lazy<IReadOnlyList<ISendable>> _requiresSendables;

        
    }
}
