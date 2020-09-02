using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "CollisionData/TagData", order = 1)]
public class PLayerCollisionData : ScriptableObject
{
    public string[] CollisionDataArray;
}
