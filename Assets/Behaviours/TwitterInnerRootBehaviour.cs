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
            _twitterProfileRoot = new Lazy<TwitterProfileBehaviour>(() => transform.Find("Profile").GetComponent<TwitterProfileBehaviour>());
        }

        private Lazy<GameObject> _feedRoot;
        private Lazy<TwitterProfileBehaviour> _twitterProfileRoot;

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
            _twitterProfileRoot.Value.SetUser(user);
            SetActiveChild(_twitterProfileRoot.Value.gameObject);
        }
    }
}
