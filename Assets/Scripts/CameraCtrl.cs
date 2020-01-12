using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public float shakePower;
    public float shakeTime;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Shake.ShakeObject(gameObject, shakePower, shakeTime);
        }
    }

    public void ShakeCheck()
    {

    }
}
