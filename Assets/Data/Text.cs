using System;
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

        public bool isOutgoing = false;

        public string id;

        public string requires;

        public string message;

        public float? SentAtTime { get; set; } = null;

        public bool IsSent => SentAtTime <= Time.time;

        string ISendable.Id => id;

        string ISendable.Requires => requires;

        public IReadOnlyList<ISendable> RequiresSendables => _requiresSendables.Value;
        [NonSerialized]
        private readonly Lazy<IReadOnlyList<ISendable>> _requiresSendables;

        
    }
}
