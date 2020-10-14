using Assets.Common;
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
    class TwitterReplyScreenBehaviour : MonoBehaviour
    {
        private Lazy<TweetBehaviour> _tweet;
        private Lazy<GameObject> _repliesList;

        public TwitterReplyScreenBehaviour()
        {
            _tweet = new Lazy<TweetBehaviour>(() => transform.Find("Tweet").GetComponent<TweetBehaviour>());
            _repliesList = new Lazy<GameObject>(() => transform.Find("ReplyList").gameObject);
        }

        public void SetTweet(Tweet tweet)
        {
            _tweet.Value.Tweet = tweet;
            foreach(var child in _repliesList.Value.transform.Children())
            {
                Destroy(child.gameObject);
            }

            foreach(var reply in tweet.PossibleReplies)
            {
                Instantiate(CommonPrefabs.Instance.Reply, _repliesList.Value.transform).transform
                    .GetComponent<ReplyBehaviour>().Reply = reply;
            }
        }
    }
}
