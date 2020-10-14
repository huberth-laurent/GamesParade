using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    interface ISendable
    {
        User User { get; }

        string Id { get; }

        float? SentAtTime { get; set; }

        bool IsSent { get; }

        string Requires { get; }

        IReadOnlyList<ISendable> RequiresSendables { get; }
    }
}
