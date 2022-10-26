using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Col_PlayerAtk : MonoBehaviour
{
    //플레이어의 콤보 스텝을 확인하기 위한 콤보 컴퍼넌트
    public Combo combo;

    //Collider 의 공격 타입
    public string type_Atk;

    //콤보 진행단계
    int comboStep;
    //데미지 표시
    public string dmg;
    //데미지 텍스트. UI상에서 사용하는 UI데미지
    public TextMeshProUGUI dmgText;


    //Collider가 활성화되면 콤보 스텝을 가져옴
    private void OnEnable()
    {
        comboStep = combo.ComboStep;
    }

    //Collider가 다른 trigger collider와 충돌하면 작동하는 기능
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HitBox")
        {
            //데미지에 콜리어더의 공격 타입과 콤보 단계를 넣어준다.
            dmg = string.Format("{0} + {1}", type_Atk, comboStep);
            dmgText.text = dmg;
            //데미지 텍스트를 활성화
            dmgText.gameObject.SetActive(true);
        }
    }
}
