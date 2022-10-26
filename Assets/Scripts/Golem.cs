using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    Animator golemAni;
    public Transform target;
    public float golemSpeed;
    bool enableAct;
    int atkStep = 0;

    void Start()
    {
        golemAni = GetComponent<Animator>();
        enableAct = false;
    }

    void RotateGolem()
    {
        Vector3 dir = target.position - transform.position;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }


    void MoveGolem()
    {
        if ((target.position - transform.position).magnitude >= 10)
        {
            golemAni.SetBool("Walk", true);
            transform.Translate(Vector3.forward * golemSpeed * Time.deltaTime, Space.Self);
        }

        if ((target.position - transform.position).magnitude < 10)
        {
            golemAni.SetBool("Walk", false);
        }
    }


    void Update()
    {
        if (enableAct)
        {
            RotateGolem();
            MoveGolem();
        }
    }


    void GolemAtk()
    {
        if((target.position - transform.position).magnitude <= 10)
        
        {
           // golemAni.SetBool("Walk", false); ;
            switch (atkStep)
            {
                case 0:
                    if(atkStep == 0)
                    atkStep += 1;
                    golemAni.Play("Golem_AtkA");
                    break;

                case 1:
                    
                    if (atkStep == 1)
                    {
                        golemAni.Play("Golem_AtkB");
                    }
                    atkStep += 1;
                    break;

                case 2:
                    
                    if(atkStep == 2)
                    golemAni.Play("Golem_AtkC");
                    atkStep -= 2;
                    break;

            }

        }
        if((target.position - transform.position).magnitude > 10)
        {
            golemAni.SetBool("Walk", true);
        }
    }

    void FreezeGolem()
    {
        enableAct = false;
    }

    void UnFreezeGolem()
    {
        enableAct = true;
    }
}
