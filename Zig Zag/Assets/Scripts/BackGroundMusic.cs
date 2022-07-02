using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    private static BackGroundMusic backgroundmusic;

    void Awake()
    {
if (backgroundmusic==null)
{
     backgroundmusic=this;
     DontDestroyOnLoad(backgroundmusic);

}
    else
    {
        Destroy(gameObject);
    }
    }
    }


