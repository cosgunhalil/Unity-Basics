using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class MovementAbility : Ability
{
    public MovementAbility(PlatformerCharacter2D platformerCharacter2D) : base(platformerCharacter2D)
    {
        this.character = platformerCharacter2D;
    }

    public override void AbilityFixedUpdate()
    {
        //only control the player if grounded or airControl is turned on
        if (character.IsGrounded() || character.IsAirControlerActive())
        {
            var move = character.GetMove();

            character.SetSpeedValueToAnimator(Mathf.Abs(move));

            Vector2 characterVelocity = character.GetVelocity();

            character.SetVelocity(new Vector2(move * character.GetMaxSpeed(), characterVelocity.y));

            HandleFacing();
        }
    }

    private void HandleFacing()
    {
        // If the input is moving the player right and the player is facing left...
        if (character.GetMove() > 0 && !character.GetIsFacingRight())
        {
            // ... flip the player.
            character.Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (character.GetMove() < 0 && character.GetIsFacingRight())
        {
            // ... flip the player.
            character.Flip();
        }
    }
}
