using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilySet : MonoBehaviour
{
    [SerializeField] GameObject[] Cube = new GameObject[27] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};

    public GameObject XPlusParent;
    public GameObject XMinusParent;  
    public GameObject YPlusParent;
    public GameObject YMinusParent;
    public GameObject ZPlusParent;
    public GameObject ZMinusParent;

    public void XPlusClick()
    {
        for (int i = 0; i < Cube.Length; i++)
        {
            Vector3 tmp = Cube[i].transform.position;
            float x = tmp.x;

            if ((x > 1.8) && (x< 2.2))
            {
                Cube[i].transform.parent = XPlusParent.transform;
            }
        }
    }

    public void XMinusClick()
    {
        for (int i = 0; i < Cube.Length; i++)
        {
            Vector3 tmp = Cube[i].transform.position;
            float x = tmp.x;

            if ((x < 0.2) && (x > -0.2))
            {
                Cube[i].transform.parent = XMinusParent.transform;
            }
        }
    }

    public void YPlusClick()
    {
        for (int i = 0; i < Cube.Length; i++)
        {
            Vector3 tmp = Cube[i].transform.position;
            float y = tmp.y;

            if ((y > 1.8) && (y < 2.2))
            {
                Cube[i].transform.parent = YPlusParent.transform;
            }
        }
    }

    public void YMinusClick()
    {
        for (int i = 0; i < Cube.Length; i++)
        {
            Vector3 tmp = Cube[i].transform.position;
            float y = tmp.y;

            if ((y < 0.2) && (y > -0.2))
            {
                Cube[i].transform.parent = YMinusParent.transform;
            }
        }
    }

    public void ZPlusClick()
    {
        for (int i = 0; i < Cube.Length; i++)
        {
            Vector3 tmp = Cube[i].transform.position;
            float z = tmp.z;

            if ((z > 1.8) && (z < 2.2))
            {
                Cube[i].transform.parent = ZPlusParent.transform;
            }
        }
    }

    public void ZMinusClick()
    {
        for (int i = 0; i < Cube.Length; i++)
        {
            Vector3 tmp = Cube[i].transform.position;
            float z = tmp.z;

            if ((z < 0.2) && (z > -0.2))
            {
                Cube[i].transform.parent = ZMinusParent.transform;
            }
        }
    }

    public void GoodBye()
    {
        XPlusParent.transform.DetachChildren();
        XMinusParent.transform.DetachChildren();
        YPlusParent.transform.DetachChildren();
        YMinusParent.transform.DetachChildren();
        ZPlusParent.transform.DetachChildren();
        ZMinusParent.transform.DetachChildren();
    }
}
