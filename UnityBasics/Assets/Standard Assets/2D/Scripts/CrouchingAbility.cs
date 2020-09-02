using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class CrouchingAbility : Ability
{
    public CrouchingAbility(PlatformerCharacter2D platformerCharacter2D) : base(platformerCharacter2D)
    {
        this.character = platformerCharacter2D;
    }

    public override void AbilityFixedUpdate()
    {
        // If crouching, check to see if the character can stand up
        if ( !character.IsCrouch() && character.IsAnimatorStateCrouch())
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (CheckIsThereAnyFloor())
            {
                character.SetIsCrouch(true);
            }
        }

        character.SetCrouchStateOfAnimator();
    }

    private bool CheckIsThereAnyFloor()
    {
        return Physics2D.OverlapCircle(
            character.GetCeilingCheckTransformPosition(),
            character.GetCeilingRadius(),
            character.GetWhatIsGround());
    }
}
