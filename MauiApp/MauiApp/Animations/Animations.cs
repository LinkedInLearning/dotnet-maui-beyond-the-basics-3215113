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

            var popAnimation = new Animation((v) => PerformPopAnimation(self, v, startHeight, startWidth), 0, 1, easing, () => tcs.SetResult(false));

            popAnimation.Commit(self, "popAnimation", 16, duration);

            return tcs.Task;
        }

        private static double PerformPopAnimation(VisualElement element, double v, double startHeight, double startWidth) 
        {
            double newWidth = 0;
            double newHeight = 0;
            if (v < .3)
            {
                newWidth = (((v - 0) * .5 / .3) + 1) * startWidth;
                newHeight = (((v - 0) * .5 / .3) + 1) * startHeight;
            }
            else
            {
                newWidth = (1.5 - ((v - .3) * 1.5 / .7)) * startWidth;
                newHeight = (1.5 - ((v - .3) * 1.5 / .7)) * startHeight;
            }

            element.HeightRequest = newHeight < 0 ? 0 : newHeight;
            element.WidthRequest = newWidth < 0 ? 0 : newWidth;

            return 0;
        }
    }
}
