using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObj : MonoBehaviour
{
    //오브젝트가 비활성화되기까지의 시간
    public float dTime;


    //오브젝트가 활성화될때 아래 disable 기능을 dTime 뒤에 실행
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Disable", dTime);

    }

    //오브젝트를 비활성화시키는 기능
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
