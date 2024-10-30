using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting;

public class AI : MonoBehaviour
{
    [SerializeField] GameObject[] Quad = new GameObject[54] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,  null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
    List<GameObject> XPlist = new List<GameObject> { null, null, null, null, null, null, null, null, null};

    public void AIPlayer()
    {

    }

    public void Judgement()
    {
        for (int i = 0; i < Quad.Length; i++)
        {
            Vector3 tmp = Quad[i].transform.position;
            int x = Mathf.RoundToInt(tmp.x);
            int y = Mathf.RoundToInt(tmp.y);
            int z = Mathf.RoundToInt(tmp.z);
            if ( x > 1.3f && x < 1.7f)
            {
                int idx = z + y * 3;

                XPlist.Insert(idx, Quad[i]);

                XPlist.RemoveAt(idx+1);
            }
            /*else
            {
                Debug.Log("ŽG‹›‰³");
            }*/
        }
    }
}
