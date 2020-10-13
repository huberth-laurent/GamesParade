using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behaviours
{
    class MessagesInnerRootBehaviour : OneChildActiveBehaviour
    {
        private Lazy<GameObject> _conversationsRoot;
        private Lazy<GameObject> _godMessagesRoot;

        public MessagesInnerRootBehaviour()
        {
            _conversationsRoot = new Lazy<GameObject>(() => transform.Find("Conversations").gameObject);
            _godMessagesRoot = new Lazy<GameObject>(() => transform.Find("GodConversation").gameObject);
        }

        public void DisplayConversations()
        {
            SetActiveChild(_conversationsRoot.Value);
        }

        public void DisplayGodMessages()
        {
            SetActiveChild(_godMessagesRoot.Value);
        }
    }
}
