using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public void PlayButtonClickSound()
    {
        if (SoundEffectsManager.instance != null)
        {
            SoundEffectsManager.instance.PlayButtonPressSound();
        }
    }
}
