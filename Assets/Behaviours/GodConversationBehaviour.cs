﻿using Assets.Common;
using Assets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Behaviours
{
    class GodConversationBehaviour : MonoBehaviour
    {
        private HashSet<Text> _texts = new HashSet<Text>();
        private Lazy<GameObject> _listRoot;

        public GodConversationBehaviour()
        {
            _listRoot = new Lazy<GameObject>(() => transform.Find("MessageList/Viewport/Content").gameObject);
        }

        private void Start()
        {
            // Get rid of the example texts
            foreach (var child in _listRoot.Value.transform.Children())
            {
                Destroy(child.gameObject);
            }
            UpdateData();
        }

        private void Update()
        {
            UpdateData();
        }

        private void UpdateData()
        {
            foreach (var text in Database.GetAllSentTexts().Where(x => !_texts.Contains(x)).OrderBy(x => x.SentAtTime))
            {
                var ui = Instantiate(text.isOutgoing ? CommonPrefabs.Instance.SentText : CommonPrefabs.Instance.ReceivedText, _listRoot.Value.transform);
                ui.GetComponentInChildren<TMP_Text>().text = text.message;
                _texts.Add(text);
            }
        }
    }
}
