using Mobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobComponents
{
    public class AnimationControllerCharacter : AnimationController
    {

        private void OnDestroy()
        {
            UnSub();
        }

        
        internal override void SetMob(Mob input)
        {
            base.SetMob(input);

            Sub();
        }
        internal override void Sub()
        {
            _mob._movement.idle += PlayAnimIdle;
            _mob._movement.move += PlayAnimMove;
            _mob._movement.dash += PlayAnimDash;
        }

        internal override void UnSub()
        {
            _mob._movement.idle -= PlayAnimIdle;
            _mob._movement.move -= PlayAnimMove;
            _mob._movement.dash -= PlayAnimDash;
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

        private void StartDash()
        {
            _mob.inDash(true);
            _mob.invulnerability(true);
        }

        private void EndDash()
        {
            _mob.inDash(false);
            _mob.invulnerability(false);
        }
    }
}
