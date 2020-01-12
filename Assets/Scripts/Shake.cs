using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public static IEnumerator ShakeObject(GameObject obj, float shakePower,float time)
    {
        Vector3 originPos = obj.transform.localPosition;
        float curTime = 0;

        while(curTime <= time)
        {
            obj.transform.localPosition = (Vector3)Random.insideUnitCircle * shakePower + originPos;
            curTime += Time.deltaTime;
        }

        obj.transform.localPosition = originPos;
        yield return 0;


    }
}
