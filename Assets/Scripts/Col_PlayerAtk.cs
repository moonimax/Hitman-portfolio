using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Col_PlayerAtk : MonoBehaviour
{
    //�÷��̾��� �޺� ������ Ȯ���ϱ� ���� �޺� ���۳�Ʈ
    public Combo combo;

    //Collider �� ���� Ÿ��
    public string type_Atk;

    //�޺� ����ܰ�
    int comboStep;
    //������ ǥ��
    public string dmg;
    //������ �ؽ�Ʈ. UI�󿡼� ����ϴ� UI������
    public TextMeshProUGUI dmgText;


    //Collider�� Ȱ��ȭ�Ǹ� �޺� ������ ������
    private void OnEnable()
    {
        comboStep = combo.ComboStep;
    }

    //Collider�� �ٸ� trigger collider�� �浹�ϸ� �۵��ϴ� ���
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HitBox")
        {
            //�������� �ݸ������ ���� Ÿ�԰� �޺� �ܰ踦 �־��ش�.
            dmg = string.Format("{0} + {1}", type_Atk, comboStep);
            dmgText.text = dmg;
            //������ �ؽ�Ʈ�� Ȱ��ȭ
            dmgText.gameObject.SetActive(true);
        }
    }
}
