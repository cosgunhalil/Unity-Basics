using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class JumpingAbility : Ability
{
    private float m_JumpForce = 600f;// Amount of force added when the player jumps.

    public JumpingAbility(PlatformerCharacter2D platformerCharacter2D) : base(platformerCharacter2D)
    {
        this.character = platformerCharacter2D;
    }

    public override void AbilityFixedUpdate()
    {
        // If the player should jump...
        if (character.IsGrounded() && character.IsJump() && character.IsAnimatorGroundState())
        {
            // Add a vertical force to the player.
            character.SetGrounded(false); 
            character.SetAnimatorGroundState(false);
            character.AddJumpForce(m_JumpForce);
        }
    }
}
