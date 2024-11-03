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
    //bool rot = true;
    //float speed = 1f;
    private Vector3 firsthitpos;
    private Vector3 hittingpos;
    public GameObject RotationCollider;
    private Vector3 Distance;
    private Vector3 firstRCpos;
    public PaintColor paintcolor;

    private void Start()
    {
        paintcolor = GetComponent<PaintColor>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray;
            firstRCpos = RotationCollider.transform.position;

            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 15, 1 << 2)) //レーザーの距離15、レイヤーが2のやつだけに当たる
                {
                    Debug.Log(hit.collider.gameObject.name);
                    firsthitpos = hit.point;
                    Distance = RotationCollider.transform.position - firsthitpos;
                }

            }
            else
            {

            }
        }

        if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary))
        {
            Ray ray1;
            if (Input.GetMouseButton(0))
            {
                ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray1, out RaycastHit hit1, 15, 1 << 2))
                {
                    hittingpos = hit1.point;
                    RotationCollider.transform.position = Distance + hittingpos;
                    //Debug.Log(paintcolor.rotationable);
/*                    if (paintcolor.rotationable == true)
                    {
                        float r = paintcolor.rotatedirection;
                        XPlusParent.transform.Rotate(r, 0, 0);
                        XMinusParent.transform.Rotate(r, 0, 0);
                        YPlusParent.transform.Rotate(0, r, 0);
                        YMinusParent.transform.Rotate(0, r, 0);
                        ZPlusParent.transform.Rotate(0, 0, r);
                        ZMinusParent.transform.Rotate(0, 0, r);
                    }*/
                }
            }
            else
            {

            }
        }
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            if (Input.GetMouseButtonUp(0))                                       
            {
                RotationCollider.transform.position = firstRCpos;
            }
            else
            {

            }
        }
    }
    /*
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
    }*/
}