using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundeffectsplayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2;


    public void Button1()
    {
        src.clip= sfx1;
        src.Play();
    }

    public void Button2()
    {
        src.clip = sfx2;
        src.Play();
    }

}
