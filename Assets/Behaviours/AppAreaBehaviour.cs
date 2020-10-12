using Assets.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Behaviours
{
    public class AppAreaBehaviour : MonoBehaviour
    {
        private List<GameObject> _children;

        private void Start()
        {
            _children = transform.Children().Select(x => x.gameObject)
                .ToList();
        }

        public void SetActiveApp(GameObject root)
        {
            foreach(var child in _children)
            {
                child.SetActive(false);
            }

            root.SetActive(true);
        }
    }
}
