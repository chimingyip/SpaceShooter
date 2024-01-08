using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Play the animation
        animator.SetTrigger("Explode");
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
