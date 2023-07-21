using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCooldownTimer : MonoBehaviour
{
  private float m_cooldownCompleteTime;
  public bool CooldownComplete => Time.time > m_cooldownCompleteTime;

  public void StartCooldown(float cooldownAmount) {
    m_cooldownCompleteTime = Time.time + cooldownAmount;
  }
}
