using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Behaviours
{
    class CommonPrefabs : MonoBehaviour
    {
        public static CommonPrefabs Instance { get; private set; }

        private void Start()
        {
            if(Instance != null)
            {
                throw new Exception();
            }
            Instance = this;
        }

#pragma warning disable 0649

        public GameObject Tweet;

#pragma warning restore 0649
    }
}
