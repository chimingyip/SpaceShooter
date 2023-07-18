using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    private bool isFiring = false;

    void FixedUpdate() {
        Debug.Log(isFiring);
    }
    
    void OnFire() {
        isFiring = !isFiring;
    }
}
