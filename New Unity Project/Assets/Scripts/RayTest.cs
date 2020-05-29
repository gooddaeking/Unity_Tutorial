using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public float rayDistance = 2.0f;
    Ray ray;            //레이 구조체
    RaycastHit hitInfo;  //레이캐스트 힛(레이랑 충돌된 오브젝트의 정보를 담아두는 구조체)
    //RaycastHit[] rayHit;  //레이캐스트 힛(레이랑 충돌된 오브젝트의 정보를 담아두는 구조체)

    void Start()
    {
        //레이 구조체 생성 후 값 초기화
        ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;

        //레이캐스트힛 구조체 초기화
        hitInfo = new RaycastHit();
        //rayHit = Physics.RaycastAll(ray, rayDistance);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        if (Physics.Raycast(transform.position, transform.forward - transform.right, rayDistance))
        {
            transform.eulerAngles += new Vector3(0, 15, 0);
            print("발사한 오브젝트가 충돌됨");
        }
        if(Physics.Raycast(transform.position, transform.forward + transform.right, rayDistance))
        {
            transform.eulerAngles += new Vector3(0, -15, 0);
            print("발사한 오브젝트가 충돌됨");
        }
        Debug.DrawRay(transform.position, (transform.forward - transform.right) * rayDistance, Color.green, 2.0f);
        Debug.DrawRay(transform.position, (transform.forward + transform.right) * rayDistance, Color.green, 2.0f);
        
        //기본 레이캐스트
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("레이 발싸!!!!!!!!!!");
            

            //Raycast는 물리컴포넌트의 함수이기 때문에 Physics.Raycast로 함수를 호출해야 한다
            if (Physics.Raycast(ray.origin, ray.direction, rayDistance))
            {
                print("발사한 오브젝트가 충돌됨");
            }
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo,rayDistance))
            {
                print(hitInfo.collider.name);
            }
        }
    }
}
