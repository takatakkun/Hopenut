using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PaintColor : MonoBehaviour
{
    private Material paintColor;
    public Material red;
    public Material green;
    public Material blue;
    public Material orange;
    public Material white;
    private Vector2 firstclickpos;
    private Vector2 lastclickpos;
    private Vector3 firsthitpos;
    public static bool rotationable = false;
    private Vector3 hittingpos;
    public FamilySet familyset;
    private Vector3 objpos;
    public static float rotatedirection;
    public static int parentnum;
    public static int directionnum;
    public static bool pinx = false;
    public static bool piny = false;
    public static bool pinz = false;
    public static bool bigx = false;
    public static bool bigy = false;
    public static bool bigz = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray0;
            // カメラからクリック位置へのRayを生成
            if (Input.GetMouseButtonDown(0))                                     //マウス操作
            {
                ray0 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray0, out RaycastHit hit0))
                {
                    firstclickpos = Input.mousePosition;
                    firsthitpos = hit0.point;
                    objpos = hit0.collider.transform.position;
                    rotationable = false;
                    //Debug.Log(firsthitpos);
                    //   Debug.Log(hit0.point);
                    //   Debug.Log(objpos);
                }
            }
            else                                                                 //スマホ操作
            {
                 ray0 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                // RaycastHitオブジェクトでヒット情報を格納
                if (Physics.Raycast(ray0, out RaycastHit hit0))
                {
                    firstclickpos = Input.GetTouch(0).position;
                    firsthitpos = hit0.point;
                    rotationable = false;
                }
            }
        }
            // マウスクリックまたはタッチが行われたとき
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Ray ray;
            // カメラからクリック位置へのRayを生成
            if (Input.GetMouseButtonUp(0))                                       //マウス操作
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                lastclickpos = Input.mousePosition;
                rotationable = false;
            }
            else                                                                 //スマホ操作
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                lastclickpos = Input.GetTouch(0).position;
                rotationable = false;
            }

            // RaycastHitオブジェクトでヒット情報を格納
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // ヒットしたオブジェクトがクアッドであるかチェック
                if (hit.collider.gameObject.CompareTag("Quad") && firstclickpos == lastclickpos)
                {
                    // ヒットしたオブジェクトのRendererを取得してマテリアル変更
                    Renderer quadRenderer = hit.collider.gameObject.GetComponent<Renderer>();
                    quadRenderer.GetComponent<Renderer>().material.color = paintColor.color;
                }
            }
                firstclickpos = lastclickpos;
            pinx = false;
            piny = false;
            pinz = false;
            bigx = false;
            bigy = false;
            bigz = false;
        }
        
        if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && rotationable == false)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray1, out RaycastHit hit1))
                {
                    hittingpos = hit1.point;
                    Vector3 dpos = hittingpos - firsthitpos;
                    if (((dpos.y > -dpos.z && dpos.y < dpos.z) || (dpos.y < -dpos.z && dpos.y > dpos.z)) && ((objpos.x > -0.5 && objpos.x < -0.46) || (objpos.x > 2.46 && objpos.x < 2.5))) //x+-面で横方向が大きい入力
                    {
                        directionnum = 2;
                        bigy = true;
                        bigz = true;
                        if ((objpos.y > 1.7 && objpos.y < 2.3))
                        {
                            familyset.YPlusClick();
                            parentnum = 2;
                            if (objpos.x > 2.46 && objpos.x < 2.5)
                            {
                                rotatedirection = -1;
                                pinx = true;
                                piny = true;
                            }
                            else
                            {
                                rotatedirection = 1;
                                pinx = true;
                                piny = true;
                            }
                        }
                        else if (objpos.y > -0.3 && objpos.y < 0.3)
                        {
                            familyset.YMinusClick();
                            parentnum = 3;
                            if (objpos.x > 2.46 && objpos.x < 2.5)
                            {
                                rotatedirection = -1;
                                pinx = true;
                                piny = true;
                            }
                            else
                            {
                                rotatedirection = 1;
                                pinx = true;
                                piny = true;
                            }
                        }
                        rotationable = true;
                        //Debug.Log("x+-y");
                    }
                    else if (((dpos.y > -dpos.x && dpos.y < dpos.x) || (dpos.y < -dpos.x && dpos.y > dpos.x)) && ((objpos.z > -0.5 && objpos.z < -0.46) || (objpos.z > 2.46 && objpos.z < 2.5))) //z+-面で横方向が大きい入力
                    {
                        directionnum = 0;
                        bigx = true;
                        bigy = true;
                        if ((objpos.y > 1.7 && objpos.y < 2.3))
                        {
                            familyset.YPlusClick();
                            parentnum = 2;
                            if (objpos.z > 2.46 && objpos.z < 2.5)
                            {
                                rotatedirection = 1;
                                pinz = true;
                                piny = true;
                            }
                            else
                            {
                                rotatedirection= -1;
                                pinz = true;
                                piny = true;
                            }
                        }
                        else if (objpos.y > -0.3 && objpos.y < 0.3)
                        {
                            familyset.YMinusClick();
                            parentnum = 3;
                            if (objpos.z > 2.46 && objpos.z < 2.5)
                            {
                                rotatedirection = 1;
                                pinz = true;
                                piny = true;
                            }
                            else
                            {
                                rotatedirection = -1;
                                pinz = true;
                                piny = true;
                            }
                        }
                        rotationable = true;
                       // Debug.Log("z+-y");
                    }
                    else if (((dpos.z > -dpos.x && dpos.z < dpos.x) || (dpos.z < -dpos.x && dpos.z > dpos.x)) && ((objpos.y > -0.5 && objpos.y < -0.46) || (objpos.y > 2.46 && objpos.y < 2.5))) //y+-面で横方向が大きい入力
                    {
                        directionnum = 0;
                        bigx = true;
                        bigz = true;
                        if (objpos.z > 1.7 && objpos.z < 2.3)
                        {
                            familyset.ZPlusClick();
                            parentnum = 4;
                            if (objpos.y > 2.46 && objpos.y < 2.5)
                            {
                                rotatedirection = -1;
                                pinz = true;
                                piny = true;
                            }
                            else
                            {
                                rotatedirection= 1;
                                pinz = true;
                                piny = true;
                            }
                        }
                        else if (objpos.z > -0.3 && objpos.z < 0.3)
                        {
                            familyset.ZMinusClick();
                            parentnum = 5;
                            if (objpos.y > 2.46 && objpos.y < 2.5)
                            {
                                rotatedirection = -1;
                                pinz = true;
                                piny = true;
                            }
                            else
                            {
                                rotatedirection = 1;
                                pinz = true;
                                piny = true;
                            }
                        }
                        rotationable = true;
                        //Debug.Log("y+-y");
                    }
                    else if (((dpos.y > dpos.z && dpos.y > -dpos.z) || (dpos.y < dpos.z && dpos.y < -dpos.z)) && ((objpos.x > -0.5 && objpos.x < -0.46) || (objpos.x > 2.46 && objpos.x < 2.5))) //x+-縦方向のほうが大きい入力
                    {
                        directionnum = 1;
                        bigy = true;
                        bigz = true;
                        if (objpos.z > 1.7 && objpos.z < 2.3)
                        {
                            familyset.ZPlusClick();
                            parentnum = 4;
                            if (objpos.x > 2.46 && objpos.x < 2.5)
                            {
                                rotatedirection = 1;
                                pinx = true;
                                pinz = true;
                            }
                            else
                            {
                                rotatedirection = -1;
                                pinx = true;
                                pinz = true;
                            }
                        }
                        else if (objpos.z > -0.3 && objpos.z < 0.3)
                        {
                            familyset.ZMinusClick();
                            parentnum = 5;
                            if (objpos.x > 2.46 && objpos.x < 2.5)
                            {
                                rotatedirection= 1;
                                pinx = true;
                                pinz = true;
                            }
                            else
                            {
                                rotatedirection = -1;
                                pinx = true;
                                pinz = true;
                            }
                        }
                        rotationable = true;
                        //Debug.Log("x+-t");
                    }
                    else if (((dpos.y > dpos.x && dpos.y > -dpos.x) || (dpos.y < dpos.x && dpos.y < -dpos.x)) && ((objpos.z > -0.5 && objpos.z < -0.46) || (objpos.z > 2.46 && objpos.z < 2.5))) //z+-縦方向のほうが大きい入力
                    {
                        directionnum = 1;
                        bigx = true;
                        bigy = true;
                        if (objpos.x > 1.7 && objpos.x < 2.3)
                        {
                            familyset.XPlusClick();
                            parentnum = 0;
                            if (objpos.z > 2.46 && objpos.z < 2.5)
                            {
                                pinx = true;
                                pinz = true;
                                rotatedirection = -1;
                            }
                            else
                            {
                                rotatedirection = 1;
                                pinx = true;
                                pinz = true;
                            }
                        }
                        else if (objpos.x > -0.3 && objpos.x < 0.3)
                        {
                            familyset.XMinusClick();
                            parentnum = 1;
                            if (objpos.z > 2.46 && objpos.z < 2.5)
                            {
                                rotatedirection = -1;
                                pinx = true;
                                pinz = true;
                            }
                            else
                            {
                                rotatedirection= 1;
                                pinx = true;
                                pinz = true;
                            }
                        }
                        rotationable = true;
                        //Debug.Log("z+-t");
                    }
                    else if (((dpos.z > dpos.x && dpos.z > -dpos.x) || (dpos.z < dpos.x && dpos.z < -dpos.x)) && ((objpos.y > -0.5 && objpos.y < -0.46) || (objpos.y > 2.46 && objpos.y < 2.5))) //y+-縦方向のほうが大きい入力
                    {
                        directionnum = 2;
                        bigx = true;
                        bigz = true;
                        if (objpos.x > 1.7 && objpos.x < 2.3)
                        {
                            familyset.XPlusClick();
                            parentnum = 0;
                            if (objpos.y > 2.46 && objpos.y < 2.5)
                            {
                                rotatedirection = 1;
                                pinx = true;
                                piny = true;
                            }
                            else
                            {
                                rotatedirection = -1;
                                pinx = true;
                                piny = true;
                            }
                        }
                        else if (objpos.x > -0.3 && objpos.x < 0.3)
                        {
                            familyset.XMinusClick();
                            parentnum = 1;
                            if (objpos.y > 2.46 && objpos.y < 2.5)
                            {
                                rotatedirection = 1;
                                pinx = true;
                                piny = true;
                            }
                            else
                            {
                                rotatedirection = -1;
                                pinx = true;
                                piny = true;
                            }
                        }
                        rotationable = true;
                        //Debug.Log("y+-t");
                    }
                }
            }
            else
            {
                hittingpos = Input.GetTouch(0).position;

            }
        }
    }


    public void RedTurn()
    {
        paintColor = red;
    }

    public void GreenTurn()
    {
        paintColor = green;
    }

    public void BlueTurn()
    {
        paintColor = blue;
    }

    public void OrangeTurn()
    {
        paintColor = orange;
    }

    public void WhiteTurn()
    {
        paintColor = white;
    }

}
