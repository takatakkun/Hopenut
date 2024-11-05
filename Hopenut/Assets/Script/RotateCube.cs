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
    private Vector3 firsthitrpos;
    private Vector3 lasthitrpos;
    private Vector3 hittingrpos;
    public GameObject RotationCollider;
    private Vector3 Distance;
    private Vector3 firstRCpos;
    private float Rotation = 0;
    [SerializeField] GameObject[] Parents = new GameObject[6] { null, null, null, null, null, null };
    List<float> RotateValue = new List<float> { 0, 0, 0 };
    private bool takkun;
    public FamilySet familySet;
    public float rotationspeed;

    private void Start()
    {
        firstRCpos = RotationCollider.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
           // takkun = true;

            Ray ray;

            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 15, 1 << 2)) //レーザーの距離15、レイヤーが2のやつだけに当たる
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    firsthitrpos = hit.point;
                    Distance = RotationCollider.transform.position - firsthitrpos;
                    lasthitrpos = hit.point;
                }

            }
            else
            {

            }
        }

        if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && PaintColor.rotationable)
        {
            Ray ray1;
            if (Input.GetMouseButton(0))
            {
                ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray1, out RaycastHit hit1, 15, 1 << 2))
                {
                    hittingrpos = hit1.point;

                    Vector3 drpos = hittingrpos - lasthitrpos;
                    lasthitrpos = hittingrpos;
                    /*var maxdrpos = Mathf.Max(drpos.x, drpos.y, drpos.z);
                    var mindrpos = Mathf.Min(drpos.x, drpos.y, drpos.z);
                    if (Mathf.Abs(maxdrpos) > Mathf.Abs(mindrpos))
                    {
                        rotationspeed = maxdrpos;
                    }
                    else
                    {
                        rotationspeed = mindrpos;
                    }*/
                    var hitdirection = drpos.x;
                    switch(PaintColor.directionnum)
                    {
                        case 0:
                            hitdirection = drpos.x;
                            break;
                        case 1:
                            hitdirection = drpos.y;
                            break;
                        case 2:
                            hitdirection = drpos.z;
                            break;
                    }

                    float r = PaintColor.rotatedirection;
                    Rotation = r * hitdirection * rotationspeed * Time.deltaTime;

                    RotationCollider.transform.position = Distance + hittingrpos;
                    
                    switch(PaintColor.parentnum)
                    {
                        case 0:
                            XPlusParent.transform.Rotate(new Vector3(1, 0, 0), Rotation);
                            break;
                        case 1:
                            XMinusParent.transform.Rotate(new Vector3(1, 0, 0), Rotation);
                            break;
                        case 2:
                            YPlusParent.transform.Rotate(new Vector3(0, 1, 0), Rotation);
                            break;
                        case 3:
                            YMinusParent.transform.Rotate(new Vector3(0, 1, 0), Rotation);
                            break;
                        case 4:
                            ZPlusParent.transform.Rotate(new Vector3(0, 0, 1), Rotation);
                            break;
                        case 5:
                            ZMinusParent.transform.Rotate(new Vector3(0, 0, 1), Rotation);
                            break;
                    }
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
                Rotation = 0;
                for (int i = 0; i < Parents.Length; i++)
                {
                    /*if (takkun)
                    {*/
                        float xRotation = Parents[i].transform.localEulerAngles.x;
                        float yRotation = Parents[i].transform.localEulerAngles.y;
                        float zRotation = Parents[i].transform.localEulerAngles.z;
                        RotateValue[0] = xRotation;
                        RotateValue[1] = yRotation;
                        RotateValue[2] = zRotation;

                        if (xRotation % 90 != 0 || yRotation % 90 != 0 || zRotation % 90 != 0)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                while (RotateValue[j] < 0)
                                {
                                    RotateValue[j] += 360;
                                }
                                while (RotateValue[j] >= 360)
                                {
                                    RotateValue[j] -= 360;
                                }
                                if (RotateValue[j] >= 0 && RotateValue[j] < 45)
                                {
                                    RotateValue[j] = 0;
                                }
                                if (RotateValue[j] >= 45 && RotateValue[j] < 135)
                                {
                                    RotateValue[j] = 90;
                                }
                                if (RotateValue[j] >= 135 && RotateValue[j] < 225)
                                {
                                    RotateValue[j] = 180;
                                }
                                if (RotateValue[j] >= 225 && RotateValue[j] < 315)
                                {
                                    RotateValue[j] = 270;
                                }
                                if (RotateValue[j] >= 315 && RotateValue[j] <= 360)
                                {
                                    RotateValue[j] = 0;
                                }
                            }
                           /* takkun = false;
                        }*/
                    }
                    Parents[i].transform.rotation = Quaternion.Euler(RotateValue[0], RotateValue[1], RotateValue[2]);
                }
            }
            else
            {

            }
            familySet.GoodBye();
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