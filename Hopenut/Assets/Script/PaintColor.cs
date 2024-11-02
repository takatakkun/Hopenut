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
            // �J��������N���b�N�ʒu�ւ�Ray�𐶐�
            if (Input.GetMouseButtonDown(0))                                     //�}�E�X����
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
            else                                                                 //�X�}�z����
            {
                 ray0 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                // RaycastHit�I�u�W�F�N�g�Ńq�b�g�����i�[
                if (Physics.Raycast(ray0, out RaycastHit hit0))
                {
                    firstclickpos = Input.GetTouch(0).position;
                    objpos = hit0.collider.transform.position;
                    rotationable = false;
                }
            }
        }
            // �}�E�X�N���b�N�܂��̓^�b�`���s��ꂽ�Ƃ�
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Ray ray;
            // �J��������N���b�N�ʒu�ւ�Ray�𐶐�
            if (Input.GetMouseButtonUp(0))                                       //�}�E�X����
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                lastclickpos = Input.mousePosition;
                rotationable = false;
                familyset.GoodBye();
            }
            else                                                                 //�X�}�z����
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                lastclickpos = Input.GetTouch(0).position;
                rotationable = false;
                familyset.GoodBye();
            }

            // RaycastHit�I�u�W�F�N�g�Ńq�b�g�����i�[
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // �q�b�g�����I�u�W�F�N�g���N�A�b�h�ł��邩�`�F�b�N
                if (hit.collider.gameObject.CompareTag("Quad") && firstclickpos == lastclickpos)
                {
                    // �q�b�g�����I�u�W�F�N�g��Renderer���擾���ă}�e���A���ύX
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
