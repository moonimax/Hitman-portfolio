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
    //�÷��̾��� �߽���
    public Transform playerAxis;
    public Transform player;
    //�÷��̾��� �̵��ӵ�
    public float playerSpeed;
   //�÷��̾��� ����
    public Vector3 movement;

    
    void Start()
    {
        //���ӽ����Ҷ� ī�޶� ���� ���� ������
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
        //������ Ű������ ȭ��ǥ Ű�� ���� ������
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //�̵������ִٸ�
        if (movement != Vector3.zero)
        {
            //�÷��̾� �߽����� Y���� ī�޶� �߽���� �Բ� ȸ����Ų��.
            playerAxis.rotation = Quaternion.Euler(new Vector3(0, camAxis_Central.transform.position.y + mouseX, 0) * camSpeed);

            //�÷��̾��� �߽� ���� �÷��̾��� �ӵ� ��ŭ �̵���Ű��
            playerAxis.Translate(movement * Time.deltaTime * playerSpeed);

            
            //�÷��̾ �̵��������� ȸ����Ų��. ȸ���ӵ��� 5
            //�÷��̾��� ȸ��
            player.localRotation = Quaternion.Slerp(player.localRotation, Quaternion.LookRotation(movement), 5 * Time.deltaTime);



            player.GetComponent<Animator>().SetBool("Walk",true);


        }

        if (movement == Vector3.zero)
        {
            player.GetComponent<Animator>().SetBool("Walk", false);
        }
        //ī�޶� �߽����� �÷��̾ ����ٴϵ��� �ϰ� �Ѵ�.
        camAxis_Central.position = new Vector3(player.position.x, player.position.y + 5, player.position.z);
    }



    void CamMove()
    {
        //���콺�� x��ǥ�� ��������� Y ��ǥ�� ���Ϲ����� ������ �ʵ��� �ϱ� ���ؼ� -1�� ������
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y") * -1;

        //ī�޶� �ʹ� ���� ���� �ʰ� ���Ʒ��� ������ ��
        if (mouseY > 10)
        {
            mouseY = 10;
        }
        if (mouseY < 0)
        {
            mouseY = 0;
        }

        //�߽����� ȸ����Ŵ
        //�߽��� x���� y�� ���ϰ� �߽��� y���� x�� ���Ѵ�. z ���� ȸ����Ű�� �������̴ϱ� 0�� �־��� // ���������� ī�޶��� �ӵ��� ����
        camAxis_Central.rotation = Quaternion.Euler(new Vector3(camAxis_Central.rotation.x + mouseY, camAxis_Central.rotation.y + mouseX, 0) * camSpeed);
    }



    void Zoom()
    {
        wheel += Input.GetAxis("Mouse ScrollWheel") * 10;
        
        //ī�޶��� Ȯ�� �� ��� ������ ����
        if(wheel >= -10)
            wheel = -10;
        if(wheel < -20)
            wheel = -20;

        cam.localPosition = new Vector3(0,0,wheel);

    }


}
