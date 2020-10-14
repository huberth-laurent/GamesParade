using Assets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behaviours
{
    class TwitterInnerRootBehaviour : OneChildActiveBehaviour
    {
        public TwitterInnerRootBehaviour()
        {
            _feedRoot = new Lazy<GameObject>(() => transform.Find("Feed").gameObject);
            _profileRoot = new Lazy<TwitterProfileBehaviour>(() => transform.Find("Profile").GetComponent<TwitterProfileBehaviour>());
            _replyRoot = new Lazy<TwitterReplyScreenBehaviour>(() => transform.Find("Reply").GetComponent<TwitterReplyScreenBehaviour>());
        }

        private Lazy<GameObject> _feedRoot;
        private Lazy<TwitterProfileBehaviour> _profileRoot;
        private Lazy<TwitterReplyScreenBehaviour> _replyRoot;

        /*protected override void Start()
        {
            base.Start();
            _twitterProfileRoot = transform.Find("Profile").GetComponent<TwitterProfileBehaviour>();
        }*/

        public void DisplayFeed()
        {
            SetActiveChild(_feedRoot.Value);
        }

        public void DisplayProfile(User user)
        {
            _profileRoot.Value.SetUser(user);
            SetActiveChild(_profileRoot.Value.gameObject);
        }

        public void DisplayReplyScreen(Tweet tweet)
        {
            _replyRoot.Value.SetTweet(tweet);
            SetActiveChild(_replyRoot.Value.gameObject);
        }
    }
}
