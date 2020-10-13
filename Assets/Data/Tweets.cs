using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    [Serializable]
    class Tweets
    {
#pragma warning disable 0649
        public List<Tweet> tweets;
#pragma warning restore 0649
    }
}
