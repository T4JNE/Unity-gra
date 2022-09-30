using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static bool isNight;
    public static float Volume = 0.5f;

    public Light light;

    private void Start()
    {
        if(isNight)
            light.color = Color.black;
        else
            light.color = Color.white;
    }
}
