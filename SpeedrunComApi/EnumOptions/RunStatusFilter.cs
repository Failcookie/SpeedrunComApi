using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.EnumOptions
{
    public enum RunStatusFilter
    {
        [Description("all")]
        All,
        [Description("new")]
        New,
        [Description("verified")]
        Verified,
        [Description("reject")]
        Reject
    }
}
