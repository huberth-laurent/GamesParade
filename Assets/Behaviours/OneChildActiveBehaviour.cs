using Assets.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Behaviours
{
    public class OneChildActiveBehaviour : MonoBehaviour
    {
        private Lazy<List<GameObject>> _children;

        public OneChildActiveBehaviour()
        {
            _children = new Lazy<List<GameObject>>(() => transform.Children().Select(x => x.gameObject)
                .ToList());
        }

        public void SetActiveChild(GameObject root)
        {
            foreach(var child in _children.Value)
            {
                child.SetActive(false);
            }

            root.SetActive(true);
        }
    }
}
