using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/MultiShot")]
public class MultiShotPowerUp : PowerUpSO
{
    [SerializeField] private ShootBullets.FireMode fireMode;
    public override void ApplyEffect(GameObject target)
    {
        Debug.Log(target);
        target.GetComponent<ShootBullets>().currentFireMode = fireMode;
        Debug.Log("Applying " + fireMode);
    }
}
