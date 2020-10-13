using Assets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Behaviours
{
    class TweetBehaviour : MonoBehaviour
    {
        public Tweet Tweet { get; set; }

        private Lazy<TMP_Text> _usernameText;
        private Lazy<TMP_Text> _messageText;
        private Lazy<Image> _profileImage;
        private Lazy<TwitterProfileLinkBehaviour> _linkBehaviour;

        public TweetBehaviour()
        {
            _linkBehaviour = new Lazy<TwitterProfileLinkBehaviour>(() => transform.Find("ProfileRow").GetComponent<TwitterProfileLinkBehaviour>());
            _usernameText = new Lazy<TMP_Text>(() => _linkBehaviour.Value.transform.Find("ProfileName").GetComponent<TMP_Text>());
            _messageText = new Lazy<TMP_Text>(() => transform.Find("Message").GetComponent<TMP_Text>());
            _profileImage = new Lazy<Image>(() => transform.Find("ProfileRow/ProfileImage").GetComponent<Image>());
        }

        private void Update()
        {
            _messageText.Value.text = Tweet.message;
            _usernameText.Value.text = Tweet.User.username;
            _profileImage.Value.sprite = Tweet.User.ProfileImage;
            _linkBehaviour.Value.User = Tweet.User;
        }
    }
}
