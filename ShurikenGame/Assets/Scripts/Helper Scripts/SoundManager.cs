using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    // Start is called before the first frame update

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioSource shurikenLaunch;

    [SerializeField]
    private AudioClip shurikenHit;

    [SerializeField]
    private AudioClip shurikenLaunchClip;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void shurikenHitSound()
    {
        soundFX.clip = shurikenHit;
        soundFX.Play();
    }
    public void shurikenLaunchSound()
    {
        soundFX.clip = shurikenLaunchClip;
        soundFX.Play();
    }

}
