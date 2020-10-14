using Assets.Common;
using Assets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behaviours
{
    class FeedBehaviour : MonoBehaviour
    {
        private Lazy<Transform> _tweetsRoot;
        private HashSet<Tweet> _tweets = new HashSet<Tweet>();

        public FeedBehaviour()
        {
            _tweetsRoot = new Lazy<Transform>(() => transform.Find("TweetList/Viewport/Content"));
        }

        private void Start()
        {
            // Get rid of the example tweets
            foreach (var child in _tweetsRoot.Value.Children())
            {
                Destroy(child.gameObject);
            }
            UpdateTweets();
        }

        private void Update()
        {
            // Do this for now
            UpdateTweets();
        }

        private void UpdateTweets()
        {
            foreach (var tweet in Database.GetAllSentTweets().Where(x => !_tweets.Contains(x)).OrderBy(x => x.SentAtTime))
            {
                var ui = Instantiate(CommonPrefabs.Instance.Tweet, _tweetsRoot.Value);
                ui.GetComponent<TweetBehaviour>().Tweet = tweet;
                ui.transform.SetSiblingIndex(0);
                _tweets.Add(tweet);
            }
        }
    }
}
