using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintColor : MonoBehaviour
{
    private Material paintColor;
    public Material red;
    public Material green;
    public Material blue;
    public Material orange;
    public Material white;

    void Update()
    {
        // マウスクリックまたはタッチが行われたとき
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // カメラからクリック位置へのRayを生成
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // RaycastHitオブジェクトでヒット情報を格納
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // ヒットしたオブジェクトがクアッドであるかチェック
                if (hit.collider.gameObject.CompareTag("Quad"))
                {
                    // ヒットしたオブジェクトのRendererを取得してマテリアル変更
                    Renderer quadRenderer = hit.collider.gameObject.GetComponent<Renderer>();
                    quadRenderer.GetComponent<Renderer>().material.color = paintColor.color;
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
