using Assets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behaviours
{
    class TextConversationsBehaviour : MonoBehaviour
    {
        private readonly Lazy<GameObject> _godConversation;

        public TextConversationsBehaviour()
        {
            _godConversation = new Lazy<GameObject>(() => transform.Find("GodConversation").gameObject);
        }

        private void Update()
        {
            _godConversation.Value.SetActive(Database.GetAllSentTexts().Any());
        }
    }
}
