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
    private GameObject firstclickobj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (Input.GetMouseButtonDown(0)) //スマホの時の処理がない
            {
                // カメラからクリック位置へのRayを生成
                Ray ray0 = Camera.main.ScreenPointToRay(Input.mousePosition);

                // RaycastHitオブジェクトでヒット情報を格納
                if (Physics.Raycast(ray0, out RaycastHit hit0))
                {
                    firstclickobj = hit0.collider.gameObject;
                }
            }
        }
            // マウスクリックまたはタッチが行われたとき
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                if (Input.GetMouseButtonUp(0)) //スマホの時の処理がない
                {
                    // カメラからクリック位置へのRayを生成
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    // RaycastHitオブジェクトでヒット情報を格納
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        // ヒットしたオブジェクトがクアッドであるかチェック
                        if (hit.collider.gameObject.CompareTag("Quad") && firstclickobj == hit.collider.gameObject)
                        {
                            // ヒットしたオブジェクトのRendererを取得してマテリアル変更
                            Renderer quadRenderer = hit.collider.gameObject.GetComponent<Renderer>();
                            quadRenderer.GetComponent<Renderer>().material.color = paintColor.color;
                        }
                    }
                }
                firstclickobj = null;
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
