using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public abstract class Ability
{
    protected PlatformerCharacter2D character;

    public Ability(PlatformerCharacter2D platformerCharacter2D)
    {
        this.character = platformerCharacter2D;
    }

    public abstract void AbilityFixedUpdate();
}
