using Assets.Common;
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
    class TwitterProfileBehaviour : MonoBehaviour
    {
        public TwitterProfileBehaviour()
        {
            _tweetsRoot = new Lazy<Transform>(() => transform.Find("Tweets"));
            _profileImage = new Lazy<Image>(() => transform.Find("ProfileImage").GetComponent<Image>());
            _nameText = new Lazy<TMP_Text>(() => transform.Find("ProfileName").GetComponent<TMP_Text>());
        }

        private Lazy<Transform> _tweetsRoot;
        private Lazy<Image> _profileImage;
        private Lazy<TMP_Text> _nameText;
        private User _user;

        public void SetUser(User user)
        {
            _user = user;
            UpdateData();
        }

        /*private void Start()
        {
            _tweetsRoot = transform.Find("Tweets");
            if (enabled)
            {
                UpdateTweets();
            }
        }*/

        private void OnEnable()
        {
            /*if(_tweetsRoot == null)
            {
                return;
            }*/

            UpdateData();
        }

        private void UpdateData()
        {
            foreach (var child in _tweetsRoot.Value.Children())
            {
                Destroy(child.gameObject);
            }

            if (_user == null)
            {
                return;
            }

            _nameText.Value.text = _user.username;
            _profileImage.Value.sprite = _user.ProfileImage;

            foreach (var tweet in Database.GetAllUserSentTweets(_user))
            {
                Instantiate(CommonPrefabs.Instance.Tweet, _tweetsRoot.Value).GetComponent<TweetBehaviour>().Tweet = tweet;
            }
        }
    }
}
