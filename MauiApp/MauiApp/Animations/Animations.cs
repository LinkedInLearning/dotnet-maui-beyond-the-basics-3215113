using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Animations
{
    public static class Animations
    {
        public static Task<bool> PopAnimation(this VisualElement self, uint duration = 1500, Easing easing = null)
        {
            var tcs = new TaskCompletionSource<bool>();
            var startHeight = self.Height;
            var startWidth = self.Width;

            if (easing == null) easing = Easing.Linear;


            return tcs.Task;

        }
    }
}
