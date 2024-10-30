using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public GameObject XPlusParent;
    public GameObject XMinusParent;
    public GameObject YPlusParent;
    public GameObject YMinusParent;
    public GameObject ZPlusParent;
    public GameObject ZMinusParent;
    bool rot = true;
    float speed = 1f;

    public void PlusRotation()
    {
        if (rot == true)
        {
            rot = false;
            StartCoroutine(RtP());
        }
    }

    IEnumerator RtP()
    {
        int i = 0;
        while (i < 90)
        {
            i++;
            XPlusParent.transform.Rotate(speed, 0, 0);
            XMinusParent.transform.Rotate(speed, 0, 0);
            YPlusParent.transform.Rotate(0, speed, 0);
            YMinusParent.transform.Rotate(0, speed, 0);
            ZPlusParent.transform.Rotate(0, 0, speed);
            ZMinusParent.transform.Rotate(0, 0, speed);
            yield return null;
        }
        rot = true;
    }

    public void MinusRotation()
    {
        if (rot == true)
        {
            rot = false;
            StartCoroutine(RtM());
        }
    }

    IEnumerator RtM()
    {
        int i = 0;
        while (i < 90)
        {
            i++;
            XPlusParent.transform.Rotate(-speed, 0, 0);
            XMinusParent.transform.Rotate(-speed, 0, 0);
            YPlusParent.transform.Rotate(0, -speed, 0);
            YMinusParent.transform.Rotate(0, -speed, 0);
            ZPlusParent.transform.Rotate(0, 0, -speed);
            ZMinusParent.transform.Rotate(0, 0, -speed);
            yield return null;
        }
        rot = true;
    }
}