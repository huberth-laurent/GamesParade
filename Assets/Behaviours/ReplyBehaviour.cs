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
    class ReplyBehaviour : MonoBehaviour, IPointerClickHandler
    {
        private Lazy<TMP_Text> _text;
        private Lazy<TwitterInnerRootBehaviour> _twitterRoot;

        public ReplyBehaviour()
        {
            _text = new Lazy<TMP_Text>(() => transform.Find("Message")
                .GetComponent<TMP_Text>());
            _twitterRoot = new Lazy<TwitterInnerRootBehaviour>(() => GetComponentInParent<TwitterInnerRootBehaviour>());
        }

        public Tweet Reply { get; set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            Reply.SentAtTime = Time.time;
            _twitterRoot.Value.DisplayFeed();
        }

        private void Update()
        {
            _text.Value.text = Reply.message;
        }
    }
}
