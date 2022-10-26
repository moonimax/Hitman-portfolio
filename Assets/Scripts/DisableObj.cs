using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    //������Ʈ�� ��Ȱ��ȭ�Ǳ������ �ð�
    public float dTime;


    //������Ʈ�� Ȱ��ȭ�ɶ� �Ʒ� disable ����� dTime �ڿ� ����
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Disable", dTime);

    }

    //������Ʈ�� ��Ȱ��ȭ��Ű�� ���
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
