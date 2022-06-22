using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Platforms.Android
{
    public class AnimatedLabelHandler : LabelHandler
    {
        public AnimatedLabelHandler() : base(Mapper)
        {
        }

        public AnimatedLabelHandler(IPropertyMapper? mapper = null) : base(mapper ?? Mapper)
        {
        }
    }
}
