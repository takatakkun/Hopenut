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
    public bool rotationable;
    private Vector3 hittingpos;
    public FamilySet familyset;
    private Vector3 objpos;

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
                    firsthitpos = hit0.point;
                    objpos = hit0.collider.transform.position;
                    rotationable = false;
                    Debug.Log(firsthitpos);
                    //   Debug.Log(hit0.point);
                    //   Debug.Log(objpos);
                }
            }
            else                                                                 //�X�}�z����
            {
                 ray0 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                // RaycastHit�I�u�W�F�N�g�Ńq�b�g�����i�[
                if (Physics.Raycast(ray0, out RaycastHit hit0))
                {
                    firstclickpos = Input.GetTouch(0).position;
                    firsthitpos = hit0.point;
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
                Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray1, out RaycastHit hit1))
                {
                    hittingpos = hit1.point;
                    Vector3 dpos = hittingpos - firsthitpos;
                    if (((dpos.y > -dpos.z && dpos.y < dpos.z) || (dpos.y < -dpos.z && dpos.y > dpos.z)) && ((objpos.x > -0.5 && objpos.x < -0.46) || (objpos.x > 2.46 && objpos.x < 2.5))) //x+-�ʂŉ��������傫������
                    {
                        if ((objpos.y > 1.7 && objpos.y < 2.3))
                        {
                            familyset.YPlusClick();
                        }
                        if (objpos.y > -0.7 && objpos.y < 0.3)
                        {
                            familyset.YMinusClick();
                        }
                        rotationable = true;
                        Debug.Log("x+-y");
                    }
                    if (((dpos.y > -dpos.x && dpos.y < dpos.x) || (dpos.y < -dpos.x && dpos.y > dpos.x)) && ((objpos.z > -0.5 && objpos.z < -0.46) || (objpos.z > 2.46 && objpos.z < 2.5))) //z+-�ʂŉ��������傫������
                    {
                        if ((objpos.y > 1.7 && objpos.y < 2.3))
                        {
                            familyset.YPlusClick();
                        }
                        if (objpos.y > -0.7 && objpos.y < 0.3)
                        {
                            familyset.YMinusClick();
                        }
                        rotationable = true;
                        Debug.Log("z+-y");
                    }
                    if (((dpos.z > -dpos.x && dpos.z < dpos.x) || (dpos.z < -dpos.x && dpos.z > dpos.x)) && ((objpos.y > -0.5 && objpos.y < -0.46) || (objpos.y > 2.46 && objpos.y < 2.5))) //y+-�ʂŉ��������傫������
                    {
                        if (objpos.z > 1.7 && objpos.z < 2.3)
                        {
                            familyset.ZPlusClick();
                        }
                        if (objpos.z > -0.7 && objpos.z < 0.3)
                        {
                            familyset.ZMinusClick();
                        }
                        rotationable = true;
                        Debug.Log("y+-y");
                    }
                    if (((dpos.y > dpos.z && dpos.y > -dpos.z) || (dpos.y < dpos.z && dpos.y < -dpos.z)) && ((objpos.x > -0.5 && objpos.x < -0.46) || (objpos.x > 2.46 && objpos.x < 2.5))) //x+-�c�����̂ق����傫������
                    {
                        if (objpos.z > 1.7 && objpos.z < 2.3)
                        {
                            familyset.ZPlusClick();
                        }
                        if (objpos.z > -0.7 && objpos.z < 0.3)
                        {
                            familyset.ZMinusClick();
                        }
                        rotationable = true;
                        Debug.Log("x+-t");
                    }
                    if (((dpos.y > dpos.x && dpos.y > -dpos.x) || (dpos.y < dpos.x && dpos.y < -dpos.x)) && ((objpos.z > -0.5 && objpos.z < -0.46) || (objpos.z > 2.46 && objpos.z < 2.5))) //z+-�c�����̂ق����傫������
                    {
                        if (objpos.x > 1.7 && objpos.x < 2.3)
                        {
                            familyset.XPlusClick();
                        }
                        if (objpos.x > -0.7 && objpos.x < 0.3)
                        {
                            familyset.XMinusClick();
                        }
                        rotationable = true;
                        Debug.Log("z+-t");
                    }
                    if (((dpos.z > dpos.x && dpos.z > -dpos.x) || (dpos.z < dpos.x && dpos.z < -dpos.x)) && ((objpos.y > -0.5 && objpos.y < -0.46) || (objpos.y > 2.46 && objpos.y < 2.5))) //y+-�c�����̂ق����傫������
                    {
                        if (objpos.x > 1.7 && objpos.x < 2.3)
                        {
                            familyset.XPlusClick();
                        }
                        if (objpos.x > -0.7 && objpos.x < 0.3)
                        {
                            familyset.XMinusClick();
                        }
                        rotationable = true;
                        Debug.Log("y+-t");
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
