using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Camera")]
    public Transform camAxis_Central;
    public Transform cam;
    public float camSpeed;
    float mouseX;
    float mouseY;
    float wheel;

    // Start is called before the first frame update

    [Header("Player")]
    //플레이어의 중심축
    public Transform playerAxis;
    public Transform player;
    //플레이어의 이동속도
    public float playerSpeed;
   //플레이어의 방향
    public Vector3 movement;

    
    void Start()
    {
        //게임시작할때 카메라 값을 고정 시켜줌
        wheel = -10;
        mouseY = 7;

    }

    

    // Update is called once per frame
    void Update()
    {
        CamMove();
        Zoom();
        PlayerMove();                  
    }


    void PlayerMove()
    {
        //방향은 키보드의 화살표 키에 의해 결정됨
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //이동방향있다면
        if (movement != Vector3.zero)
        {
            //플레이어 중심축의 Y값을 카메라 중심축과 함께 회전시킨다.
            playerAxis.rotation = Quaternion.Euler(new Vector3(0, camAxis_Central.transform.position.y + mouseX, 0) * camSpeed);

            //플레이어의 중심 축을 플레이어의 속도 만큼 이동시키고
            playerAxis.Translate(movement * Time.deltaTime * playerSpeed);

            
            //플레이어를 이동방향으로 회전시킨다. 회전속도는 5
            //플레이어의 회전
            player.localRotation = Quaternion.Slerp(player.localRotation, Quaternion.LookRotation(movement), 5 * Time.deltaTime);



            player.GetComponent<Animator>().SetBool("Walk",true);


        }

        if (movement == Vector3.zero)
        {
            player.GetComponent<Animator>().SetBool("Walk", false);
        }
        //카메라 중심축이 플레이어를 따라다니도록 하게 한다.
        camAxis_Central.position = new Vector3(player.position.x, player.position.y + 5, player.position.z);
    }



    void CamMove()
    {
        //마우스의 x좌표는 상관없지만 Y 좌표는 상하반전이 생기지 않도록 하기 위해서 -1을 곱해줌
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y") * -1;

        //카메라가 너무 많이 돌지 않게 위아래로 제한을 검
        if (mouseY > 10)
        {
            mouseY = 10;
        }
        if (mouseY < 0)
        {
            mouseY = 0;
        }

        //중심축을 회전시킴
        //중심축 x에는 y를 더하고 중심축 y에는 x를 더한다. z 축은 회전시키지 않을것이니까 0을 넣었음 // 마지막에는 카메라의 속도를 곱함
        camAxis_Central.rotation = Quaternion.Euler(new Vector3(camAxis_Central.rotation.x + mouseY, camAxis_Central.rotation.y + mouseX, 0) * camSpeed);
    }



    void Zoom()
    {
        wheel += Input.GetAxis("Mouse ScrollWheel") * 10;
        
        //카메라의 확대 및 축소 범위도 제한
        if(wheel >= -10)
            wheel = -10;
        if(wheel < -20)
            wheel = -20;

        cam.localPosition = new Vector3(0,0,wheel);

    }


}
