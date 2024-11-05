using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

public class JudgementScript : MonoBehaviour
{
    public Material Red;
    public Material Blue;
    public Material Green;
    public Material Orange;
    [SerializeField] GameObject[] Quad = new GameObject[54] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,  null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
    List<Material> XPlist = new List<Material> { null, null, null, null, null, null, null, null, null };
    List<Material> XMlist = new List<Material> { null, null, null, null, null, null, null, null, null };
    List<Material> YPlist = new List<Material> { null, null, null, null, null, null, null, null, null };
    List<Material> YMlist = new List<Material> { null, null, null, null, null, null, null, null, null };
    List<Material> ZPlist = new List<Material> { null, null, null, null, null, null, null, null, null };
    List<Material> ZMlist = new List<Material> { null, null, null, null, null, null, null, null, null };

    private void Start()
    {
        var a = Red.color;
        var b = Blue.color;
        var c = Orange.color;
        var d = Green.color;
    }

    public void Judgement()
    {
        for (int i = 0; i < Quad.Length; i++)
        {
            Vector3 tmp = Quad[i].transform.position;
            float x = tmp.x;
            float y = tmp.y;
            float z = tmp.z;
            int mx = Mathf.RoundToInt(tmp.x);
            int my = Mathf.RoundToInt(tmp.y);
            int mz = Mathf.RoundToInt(tmp.z);
            if ( x > 2.3f && x < 2.7f)
            {
                int idx = mz + my * 3;

                XPlist.Insert(idx, Quad[i].GetComponent<Renderer>().material);
                XPlist.RemoveAt(idx+1);  
            }
            if (x > -0.7f && x < -0.3f)
            {
                int idx = my + mz * 3;

                XMlist.Insert(idx, Quad[i].GetComponent<Renderer>().material);
                XMlist.RemoveAt(idx + 1);
            }
            if (y > 2.3f && y < 2.7f)
            {
                int idx = mx + mz * 3;

                YPlist.Insert(idx, Quad[i].GetComponent<Renderer>().material);
                YPlist.RemoveAt(idx + 1);
            }
            if (y > -0.7f && y < -0.3f)
            {
                int idx = mz + mx * 3;

                YMlist.Insert(idx, Quad[i].GetComponent<Renderer>().material);
                YMlist.RemoveAt(idx + 1);
            }
            if (z > 2.3f && z < 2.7f)
            {
                int idx = my + mx * 3;

                ZPlist.Insert(idx, Quad[i].GetComponent<Renderer>().material);
                ZPlist.RemoveAt(idx + 1);
            }
            if (z > -0.7f && z < -0.3f)
            {
                int idx = mx + my * 3;

                ZMlist.Insert(idx, Quad[i].GetComponent<Renderer>().material);
                ZMlist.RemoveAt(idx + 1);
            }
            /*else
            {
                Debug.Log("ŽG‹›‰³");
            }*/
        }
        List<List<Material>> net = new List<List<Material>> { XPlist, XMlist, YPlist, YMlist, ZPlist, ZMlist };
        List<Material> materiallist = new List<Material> { Red, Blue, Orange, Green };
        List<int> countlist = new List<int> { 0, 0, 0, 0 };

        List<int[]> lines = new List<int[]>();
        lines.Add(new int[] { 0, 1, 2 });
        lines.Add(new int[] { 3, 4, 5 });
        lines.Add(new int[] { 6, 7, 8 });
        lines.Add(new int[] { 0, 3, 6 });
        lines.Add(new int[] { 1, 4, 7 });
        lines.Add(new int[] { 2, 5, 8 });
        lines.Add(new int[] { 0, 4, 8 });
        lines.Add(new int[] { 2, 4, 6 });

        for (int i = 0; i < net.Count; i++)
        {
            List<Material> netelement = net[i];

            foreach (var v in lines)
            {
                int idx0 = v[0];
                int idx1 = v[1];
                int idx2 = v[2];
                if (netelement[idx0] == netelement[idx1] && netelement[idx1] == netelement[idx2] && netelement[idx0] != null)
                {
                    for (int j = 0; j < materiallist.Count; j++)
                    {
                        if (netelement[idx0] == materiallist[j])
                        {
                            countlist[j] += 1;
                        }
                    }
                }
            }
        }

    }
}
