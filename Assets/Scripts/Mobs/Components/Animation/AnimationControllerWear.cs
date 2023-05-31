using Mobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobComponents
{
    public class AnimationControllerWear : AnimationController
    {
        private void OnDestroy()
        {
            UnSub();
        }

        internal override void UnSub()
        {
            if (_mob == null) return;
            _mob._movement.idle -= PlayAnimIdle;
            _mob._movement.move -= PlayAnimMove;
            _mob._movement.dash -= PlayAnimDash;
        }

        internal override void Sub()
        {
            if (_mob == null) return;
            _mob._movement.idle += PlayAnimIdle;
            _mob._movement.move += PlayAnimMove;
            _mob._movement.dash += PlayAnimDash;
        }

        private void PlayAnimIdle()
        {
            StartAnimation("Idle");
        }

        private void PlayAnimMove()
        {
            StartAnimation("Move");
        }

        private void PlayAnimDash()
        {
            StartAnimation("Dash");
        }
    }
}
