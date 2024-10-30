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
        // �}�E�X�N���b�N�܂��̓^�b�`���s��ꂽ�Ƃ�
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // �J��������N���b�N�ʒu�ւ�Ray�𐶐�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // RaycastHit�I�u�W�F�N�g�Ńq�b�g�����i�[
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // �q�b�g�����I�u�W�F�N�g���N�A�b�h�ł��邩�`�F�b�N
                if (hit.collider.gameObject.CompareTag("Quad"))
                {
                    // �q�b�g�����I�u�W�F�N�g��Renderer���擾���ă}�e���A���ύX
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
