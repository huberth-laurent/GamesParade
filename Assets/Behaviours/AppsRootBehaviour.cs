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
        private Lazy<GameObject> _settingsRoot;
        private Lazy<GameObject> _messagesRoot;
        private Lazy<MessagesInnerRootBehaviour> _messagesInnerRoot;
        private Lazy<GameObject> _twitterRoot;
        private Lazy<TwitterInnerRootBehaviour> _twitterInnerRoot;

        public AppsRootBehaviour()
        {
            _homeRoot = new Lazy<GameObject>(() => transform.Find("Homescreen").gameObject);
            _settingsRoot = new Lazy<GameObject>(() => transform.Find("SettingsApp").gameObject);
            _messagesRoot = new Lazy<GameObject>(() => transform.Find("MessagesApp").gameObject);
            _messagesInnerRoot = new Lazy<MessagesInnerRootBehaviour>(() => _messagesRoot.Value.transform.Find("InnerAppArea")
                .GetComponent<MessagesInnerRootBehaviour>());
            _twitterRoot = new Lazy<GameObject>(() => transform.Find("TwitterApp").gameObject);
            _twitterInnerRoot = new Lazy<TwitterInnerRootBehaviour>(() => _twitterRoot.Value.transform.Find("InnerAppArea")
                .GetComponent<TwitterInnerRootBehaviour>());
        }

        public void DisplayHome() => SetActiveChild(_homeRoot.Value);

        public void DisplaySettings() => SetActiveChild(_settingsRoot.Value);

        public void DisplayMessages()
        {
            _messagesInnerRoot.Value.DisplayConversations();
            SetActiveChild(_messagesRoot.Value);
        }

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
