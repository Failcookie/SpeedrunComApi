using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.EnumOptions
{
    public enum SortDirection
    {
        [Description("desc")]
        Desc,
        [Description("asc")]
        Asc
    }
}
