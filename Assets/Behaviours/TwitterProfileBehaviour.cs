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
            _tweetsRoot = new Lazy<Transform>(() => transform.Find("TweetList"));
            _profileImage = new Lazy<Image>(() => transform.Find("ProfileImage").GetComponent<Image>());
            _nameText = new Lazy<TMP_Text>(() => transform.Find("ProfileName").GetComponent<TMP_Text>());
            _bioText = new Lazy<TMP_Text>(() => transform.Find("Bio").GetComponent<TMP_Text>());
        }

        private Lazy<Transform> _tweetsRoot;
        private Lazy<Image> _profileImage;
        private Lazy<TMP_Text> _nameText;
        private Lazy<TMP_Text> _bioText;
        private User _user;
        private HashSet<Tweet> _tweets = new HashSet<Tweet>();

        public void SetUser(User user)
        {
            _user = user;
            _tweets = new HashSet<Tweet>();
            foreach (var child in _tweetsRoot.Value.Children())
            {
                Destroy(child.gameObject);
            }

            _nameText.Value.text = _user.username;
            _bioText.Value.text = _user.bio;
            _profileImage.Value.sprite = _user.ProfileImage;
            UpdateData();
        }

        private void Update()
        {
            // Do this for now
            UpdateData();
        }

        private void UpdateData()
        {
            if (_user == null)
            {
                return;
            }

            foreach (var tweet in Database.GetAllUserSentTweets(_user).Where(x => !_tweets.Contains(x)).OrderBy(x => x.SentAtTime))
            {
                var ui = Instantiate(CommonPrefabs.Instance.Tweet, _tweetsRoot.Value);
                ui.GetComponent<TweetBehaviour>().Tweet = tweet;
                ui.transform.SetSiblingIndex(0);
                _tweets.Add(tweet);
            }
        }
    }
}
