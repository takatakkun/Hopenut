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
    private Vector2 firstclickobj;
    private Vector2 lastclickobj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray0;
            // �J��������N���b�N�ʒu�ւ�Ray�𐶐�
            if (Input.GetMouseButtonDown(0))
            {
                ray0 = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray0, out RaycastHit hit0))
                {
                    firstclickobj = Input.mousePosition;
                }
            }
            else
            {
                 ray0 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                // RaycastHit�I�u�W�F�N�g�Ńq�b�g�����i�[
                if (Physics.Raycast(ray0, out RaycastHit hit0))
                {
                    firstclickobj = Input.GetTouch(0).position;
                }
            }
        }
            // �}�E�X�N���b�N�܂��̓^�b�`���s��ꂽ�Ƃ�
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Ray ray;
            // �J��������N���b�N�ʒu�ւ�Ray�𐶐�
            if (Input.GetMouseButtonUp(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                lastclickobj = Input.mousePosition;
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                lastclickobj = Input.GetTouch(0).position;
            }

            // RaycastHit�I�u�W�F�N�g�Ńq�b�g�����i�[
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // �q�b�g�����I�u�W�F�N�g���N�A�b�h�ł��邩�`�F�b�N
                if (hit.collider.gameObject.CompareTag("Quad") && firstclickobj == lastclickobj)
                {
                    // �q�b�g�����I�u�W�F�N�g��Renderer���擾���ă}�e���A���ύX
                    Renderer quadRenderer = hit.collider.gameObject.GetComponent<Renderer>();
                    quadRenderer.GetComponent<Renderer>().material.color = paintColor.color;
                }
            }
                firstclickobj = lastclickobj;
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
