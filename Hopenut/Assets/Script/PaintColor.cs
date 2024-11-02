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
    private Vector3 objpos;
    public bool rotationable;
    private Vector2 clickingpos;
    public FamilySet familyset;

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
                    objpos = hit0.collider.transform.position;
                    rotationable = false;
                    Debug.Log(objpos);
                }
            }
            else                                                                 //スマホ操作
            {
                 ray0 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                // RaycastHitオブジェクトでヒット情報を格納
                if (Physics.Raycast(ray0, out RaycastHit hit0))
                {
                    firstclickpos = Input.GetTouch(0).position;
                    objpos = hit0.collider.transform.position;
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
                familyset.GoodBye();
            }
            else                                                                 //スマホ操作
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                lastclickpos = Input.GetTouch(0).position;
                rotationable = false;
                familyset.GoodBye();
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
        }

        if ((Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)) && rotationable == false)
        {
            if (Input.GetMouseButton(0))
            {
                clickingpos = Input.mousePosition;
                Vector2 dpos = clickingpos - firstclickpos;

                if ((dpos.y > -dpos.x && dpos.y < dpos.x) || (dpos.y < -dpos.x && dpos.y > dpos.x))
                {
                    if (objpos.y > 1.7 && objpos.y < 2.3)
                    {
                        familyset.YPlusClick();
                        rotationable = true;
                    }
                    if (objpos.y > -0.7 && objpos.y < 0.3)
                    {
                        familyset.YMinusClick();
                        rotationable = true;
                    }
                }
                if((dpos.y > dpos.x && dpos.y > -dpos.x) || (dpos.y < dpos.x && dpos.y < -dpos.x))
                {
                    if (objpos.x > 1.7 && objpos.x < 2.3)
                    {
                        familyset.XPlusClick();
                        rotationable = true;
                    }
                    if (objpos.x > -0.7 && objpos.x < 0.3)
                    {
                        familyset.XMinusClick();
                        rotationable = true;
                    }
                    if (objpos.z > 1.7 && objpos.z < 2.3)
                    {
                        familyset.ZPlusClick();
                        rotationable = true;
                    }
                    if (objpos.z > -0.7 && objpos.z < 0.3)
                    {
                        familyset.ZMinusClick();
                        rotationable = true;
                    }
                }
            }
            else
            {
                clickingpos = Input.GetTouch(0).position;
                if (firstclickpos.x != clickingpos.x)
                {

                }
                if (firstclickpos.y != clickingpos.y)
                {

                }
            }
        }
    }


    public void RedTurn()
    {
        paintColor = red;
        Debug.Log("RED");
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
