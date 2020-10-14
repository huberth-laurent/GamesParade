using Assets.Common;
using Assets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Behaviours
{
    class GodConversationLinkBehaviour : MonoBehaviour, IPointerClickHandler
    {
        private readonly Lazy<MessagesInnerRootBehaviour> _messagesInnerRoot;
        private readonly Lazy<TMP_Text> _messageText;

        public GodConversationLinkBehaviour()
        {
            _messagesInnerRoot = new Lazy<MessagesInnerRootBehaviour>(() => GetComponentInParent<MessagesInnerRootBehaviour>());
            _messageText = new Lazy<TMP_Text>(() => transform.Find("Message").GetComponent<TMP_Text>());
        }

        private void Update()
        {
            var texts = Database.GetAllSentTexts();
            if(!texts.Any())
            {
                return;
            }
            _messageText.Value.text = texts.MaxBy(x => x.SentAtTime.Value).message;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _messagesInnerRoot.Value.DisplayGodMessages();
        }
    }
}
