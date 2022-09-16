using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontAudio : MonoBehaviour
{
    public static DontAudio instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(instance == null)
        {
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
}
