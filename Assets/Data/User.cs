using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Data
{
    [Serializable]
    class User
    {
        public User()
        {
            _profileImage = new Lazy<Sprite>(() => Resources.Load<Sprite>("Images/" + id));
        }

        public Sprite ProfileImage => _profileImage.Value;
        [NonSerialized]
        private Lazy<Sprite> _profileImage;

#pragma warning disable 0649
        public string id;
        public string username;
        public string fullName;
        public string bio;
#pragma warning restore 0649
    }
}
