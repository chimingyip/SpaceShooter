using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/MultiShot")]
public class MultiShotPowerUp : PowerUpSO
{
    [SerializeField] private ShootBullets.FireMode fireMode;
    [SerializeField] private float duration = 5f;
    
    public override float Duration => duration;

    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<ShootBullets>().currentFireMode = fireMode;
    }

    public override void ResetEffect(GameObject player, GameObject powerUp)
    {
        player.GetComponent<ShootBullets>().currentFireMode = ShootBullets.FireMode.Single;
        Destroy(powerUp);
    }
}
