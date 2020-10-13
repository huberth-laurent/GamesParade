using Assets.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Behaviours
{
    class TwitterProfileLinkBehaviour : MonoBehaviour, IPointerClickHandler
    {
        public User User { get; set; }

        private Lazy<AppsRootBehaviour> _appsRoot;

        public TwitterProfileLinkBehaviour()
        {
            _appsRoot = new Lazy<AppsRootBehaviour>(() => GetComponentInParent<AppsRootBehaviour>());
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _appsRoot.Value.DisplayTwitterProfile(User);
        }
    }
}
