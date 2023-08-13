using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpSO : ScriptableObject
{
    public abstract float Duration { get; }
    public abstract void ApplyEffect(GameObject player);
    public abstract void ResetEffect(GameObject player, GameObject powerUp);
}
