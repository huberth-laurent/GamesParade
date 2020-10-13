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

        private AppsRootBehaviour _appsRoot;

        private void Start()
        {
            _appsRoot = GetComponentInParent<AppsRootBehaviour>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _appsRoot.DisplayTwitterProfile(User);
        }
    }
}
