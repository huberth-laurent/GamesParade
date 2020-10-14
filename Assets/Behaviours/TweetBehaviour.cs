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
        private Lazy<TMP_Text> _likesText;
        private Lazy<Image> _profileImage;
        private Lazy<TwitterProfileLinkBehaviour> _linkBehaviour;
        private Lazy<Button> _replyButton;
        private Lazy<Button> _likeButton;
        private Lazy<TwitterInnerRootBehaviour> _twitterRoot;

        public TweetBehaviour()
        {
            _linkBehaviour = new Lazy<TwitterProfileLinkBehaviour>(() => transform.Find("ProfileRow").GetComponent<TwitterProfileLinkBehaviour>());
            _usernameText = new Lazy<TMP_Text>(() => _linkBehaviour.Value.transform.Find("ProfileName").GetComponent<TMP_Text>());
            _messageText = new Lazy<TMP_Text>(() => transform.Find("Message").GetComponent<TMP_Text>());
            _profileImage = new Lazy<Image>(() => transform.Find("ProfileRow/ProfileImage").GetComponent<Image>());
            _replyButton = new Lazy<Button>(() => transform.Find("ButtonsRow/ReplyButton").GetComponent<Button>());
            _likeButton = new Lazy<Button>(() => transform.Find("ButtonsRow/LikeButton").GetComponent<Button>());
            _likesText = new Lazy<TMP_Text>(() => _likeButton.Value.transform.Find("Text").GetComponent<TMP_Text>());
            _twitterRoot = new Lazy<TwitterInnerRootBehaviour>(() => GetComponentInParent<TwitterInnerRootBehaviour>());
        }

        private void Start()
        {
            _replyButton.Value.onClick.AddListener(() => _twitterRoot.Value.DisplayReplyScreen(Tweet));
            _likeButton.Value.onClick.AddListener(() =>
            {
                Tweet.Likes += Tweet.PlayerLikes ? -1 : 1;
                Tweet.PlayerLikes = !Tweet.PlayerLikes;
            });
        }

        private void Update()
        {
            _messageText.Value.text = Tweet.message;
            _usernameText.Value.text = Tweet.User.fullName + $" ({Tweet.User.username})";
            _profileImage.Value.sprite = Tweet.User.ProfileImage;
            _linkBehaviour.Value.User = Tweet.User;
            _replyButton.Value.interactable = Tweet.PossibleReplies.Any() && Tweet.PossibleReplies.All(x => !x.IsSent);
            _likesText.Value.text = (Tweet.PlayerLikes ? "Liked!" : "Like") + $" ({Tweet.Likes})";
        }
    }
}
