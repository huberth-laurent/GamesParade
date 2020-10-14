using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Behaviours
{
    class QuitButtonBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                if (Application.isEditor)
                {
                    Debug.Log("Quitting is ignored in the Unity Editor");
                }
                Application.Quit();
            });
        }
    }
}
