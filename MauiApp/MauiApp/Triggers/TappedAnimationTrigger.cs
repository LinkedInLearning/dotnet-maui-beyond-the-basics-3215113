using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Triggers
{
    public class TappedAnimationTrigger : TriggerAction<Button>
    {
        protected override async void Invoke(Button sender)
        {
            using (var downAnimation = new Animation(v => sender.Shadow.Offset = new Point(5 - (10 * v), 5 - (10 * v)), 0, 1, Easing.Linear))
            {
                var tcs1 = new TaskCompletionSource<bool>();

                downAnimation.Commit(sender, "down", 10, 200, null, (a, b) => tcs1.SetResult(true));

                await Task.WhenAll(
                    sender.TranslateTo(10, 10, 200),
                    tcs1.Task
                    );
            }

            using (var upAnimation = new Animation(v => sender.Shadow.Offset = new Point(5 + (10 * v), 5 + (10 * v)), 0, 1, Easing.Linear))
            {
                var tcs2 = new TaskCompletionSource<bool>();

                upAnimation.Commit(sender, "up", 10, 200, null, (a, b) => tcs2.SetResult(true));

                await Task.WhenAll(
                    sender.TranslateTo(0, 0, 200),
                    tcs2.Task
                    );
            }
        }
    }
}
