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

        private TMP_Text _usernameText;
        private TMP_Text _messageText;
        private Image _profileImage;

        private void Start()
        {
            _usernameText = transform.Find("ProfileRow/ProfileName").GetComponent<TMP_Text>();
            _messageText = transform.Find("Message").GetComponent<TMP_Text>();
            _profileImage = transform.Find("ProfileRow/ProfileImage").GetComponent<Image>();
        }

        private void Update()
        {
            _messageText.text = Tweet.message;
            _usernameText.text = Tweet.User.username;
            _profileImage.sprite = Tweet.User.ProfileImage;
        }
    }
}
