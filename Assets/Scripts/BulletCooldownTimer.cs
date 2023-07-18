using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCooldownTimer : MonoBehaviour
{
  public float cooldownAmount = 0.2f;
  private float m_cooldownCompleteTime;
  public bool CooldownComplete => Time.time > m_cooldownCompleteTime;

  public void StartCooldown() {
    m_cooldownCompleteTime = Time.time + cooldownAmount;
  }
}
