using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Data
{
    class Database : MonoBehaviour
    {
        private void Start()
        {
            _tweets = JsonUtility.FromJson<Tweets>(Resources.Load<TextAsset>("tweets").text).tweets;
        }

        public static IEnumerable<Tweet> GetAllSentTweets() => _tweets.ToList();

        private static IList<Tweet> _tweets;
    }
}
