using Assets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behaviours
{
    class AppsRootBehaviour : OneChildActiveBehaviour
    {
        private Lazy<GameObject> _homeRoot;
        private Lazy<GameObject> _twitterRoot;
        private Lazy<TwitterInnerRootBehaviour> _twitterInnerRoot;

        public AppsRootBehaviour()
        {
            _homeRoot = new Lazy<GameObject>(() => transform.Find("Homescreen").gameObject);
            _twitterRoot = new Lazy<GameObject>(() => transform.Find("TwitterApp").gameObject);
            _twitterInnerRoot = new Lazy<TwitterInnerRootBehaviour>(() => _twitterRoot.Value.transform.Find("InnerAppArea")
                .GetComponent<TwitterInnerRootBehaviour>());
        }

        public void DisplayHome() => SetActiveChild(_homeRoot.Value);

        public void DisplayTwitter()
        {
            _twitterInnerRoot.Value.DisplayFeed();
            SetActiveChild(_twitterRoot.Value);
        }

        public void DisplayTwitterProfile(User user)
        {
            DisplayTwitter();
            _twitterInnerRoot.Value.DisplayProfile(user);
        }
    }
}
