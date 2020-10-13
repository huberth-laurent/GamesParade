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
        private Transform _tweetsRoot;

        private void Start()
        {
            _tweetsRoot = transform.Find("Tweets");
            UpdateTweets();
        }

        private void OnEnable()
        {
            if(_tweetsRoot == null)
            {
                return;
            }

            UpdateTweets();
        }

        private void UpdateTweets()
        {
            foreach (var child in _tweetsRoot.Children())
            {
                Destroy(child.gameObject);
            }

            foreach (var tweet in Database.GetAllSentTweets())
            {
                Instantiate(CommonPrefabs.Instance.Tweet, _tweetsRoot).GetComponent<TweetBehaviour>().Tweet = tweet;
            }
        }
    }
}
