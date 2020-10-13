using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    [Serializable]
    class Tweet
    {
        public string id;
        public string userId;
        public string message;
        public string requires;
    }
}
