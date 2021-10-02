using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.EnumOptions
{
    public enum GameOrderBy
    {
        [Description("created")]
        Created,
        [Description("name.int")]
        InternationalName,
        [Description("name.jap")]
        JapaneseName,
        [Description("released")]
        YearReleased,
        [Description("abbreviation")]
        Abbreviation,
        [Description("similarity")]
        Similarity
    }
}
