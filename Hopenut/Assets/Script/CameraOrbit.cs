using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  // UIイベントシステムを使用

public class CameraOrbit : MonoBehaviour
{
    public Transform target;  // 中心となるCube
    public float distance = 10.0f;  // Cubeからカメラまでの距離
    public float rotationSpeed = 150.0f;  // 回転速度

    private float rotationX = 0.0f;  // X軸の回転
    private float rotationY = 0.0f;  // Y軸の回転
    private Vector2 lastTouchPosition;  // 前回のタッチ位置（スマホ用）
    private Vector2 lastMousePosition;  // 前回のマウス位置（PC用）
    private bool isTouchingUI = false;  // 最初のタッチがUI上かどうかを記録
    private bool isClickingUI = false;  // 最初のクリックがUI上かどうかを記録

    void Start()
    {
        // 初期のカメラの角度を設定
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;

        // Cubeからの距離を設定
        transform.position = target.position - transform.forward * distance;
    }

    void Update()
    {
        // スマホでのタッチ操作
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // 最初のタッチがUI上かどうかを確認
                isTouchingUI = IsPointerOverUIObject(touch.position);
                if (!isTouchingUI)
                {
                    lastTouchPosition = touch.position;  // タッチ開始位置を記録
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // 最初のタッチがUI上でなければ回転させる
                if (!isTouchingUI)
                {
                    Vector2 delta = touch.position - lastTouchPosition;  // タッチの移動量を計算
                    rotationX += delta.x * rotationSpeed * Time.deltaTime;
                    rotationY -= delta.y * rotationSpeed * Time.deltaTime;

                    // 上下の視点移動を制限
                    rotationY = Mathf.Clamp(rotationY, -80f, 80f);

                    lastTouchPosition = touch.position;  // 現在のタッチ位置を記録
                }
            }
        }
        // PCでのマウス操作
        else if (Input.GetMouseButtonDown(1))
        {
            // 最初の右クリックがUI上かどうかを確認
            isClickingUI = IsPointerOverUIObject(Input.mousePosition);
            if (!isClickingUI)
            {
                lastMousePosition = Input.mousePosition;  // マウスの位置を記録
            }
        }
        else if (Input.GetMouseButton(1))
        {
            // 最初のクリックがUI上でなければ回転させる
            if (!isClickingUI)
            {
                Vector2 delta = (Vector2)Input.mousePosition - lastMousePosition;  // マウスの移動量を計算
                rotationX += delta.x * rotationSpeed * Time.deltaTime;
                rotationY -= delta.y * rotationSpeed * Time.deltaTime;

                // 上下の視点移動を制限
                rotationY = Mathf.Clamp(rotationY, -80f, 80f);

                lastMousePosition = Input.mousePosition;  // 現在のマウス位置を記録
            }
        }

        // カメラの位置を更新
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        Vector3 direction = new Vector3(0, 0, -distance);
        transform.position = target.position + rotation * direction;

        // Cubeを常に向く
        transform.LookAt(target);
    }

    // UI上でのタッチやクリックを無視するためのヘルパー関数
    private bool IsPointerOverUIObject(Vector2 screenPosition)
    {
        // マウスやタッチ位置にあるUIオブジェクトを確認
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = screenPosition
        };

        // レイキャストを行って、UIオブジェクトがあるかを確認
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}

