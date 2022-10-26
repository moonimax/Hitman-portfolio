using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    //애니메이션을 제어하기 위한 플레이어의 애니메이션
    Animator playerAnim;

    //콤보 입력가능
    bool comboPossible;
    //콤보 진행 단계
    public int ComboStep;
    bool inputSmash;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NormalAttack();
        }
        if(Input.GetMouseButtonDown(1))
        {
            SmashAttack();
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    void NormalAttack()
    {
        if(ComboStep == 0)
        {
            playerAnim.Play("Knight_NormalAtk_A");
            ComboStep = 1;
            return;
        }

        if(ComboStep != 0)
        {
            if (comboPossible)
            {   //무차별 콤보를 방지한다.
                comboPossible = false;
                ComboStep += 1;
            }
        }

    }


    void SmashAttack()
    {
        if(comboPossible)
        {
            comboPossible = false;
            inputSmash = true;
        }
    }
    
    public void NextAtk()
    {
        if (!inputSmash)
        {
            if (ComboStep == 2)
            {
                playerAnim.Play("Knight_NormalAtk_B");
            }
            if (ComboStep == 3)
            {
                playerAnim.Play("Knight_NormalAtk_C");
            }

        }


        if (inputSmash)
        {
            if (ComboStep == 1)
            {
                playerAnim.Play("Knight_SmashAtk_A");
            }
            if (ComboStep == 2)
            {
                playerAnim.Play("Knight_SmashAtk_B");
            }
            if (ComboStep == 3)
            {
                playerAnim.Play("Knight_SmashAtk_C");
            }


        }

      

    }

    public void ResetCombo()
    {
        comboPossible = false;
        inputSmash = false;
        ComboStep = 0;
    }
}

