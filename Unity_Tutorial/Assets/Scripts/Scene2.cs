using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : MonoBehaviour
{
    UnityEngine.Vector3 rotation;
    [SerializeField]
    private GameObject go_camera;

    void Start()
    {
        rotation = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.W))
        //{
        //    this.transform.position = this.transform.position + new Vector3(0, 0, 5) * Time.deltaTime; // 60분의 1
        //}
        // 앞으로 이동
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new UnityEngine.Vector3(0, 0, 3) * Time.deltaTime);
        }
        // 부드러운 무한 회전
        if (Input.GetKey(KeyCode.D))
        {
            rotation = rotation + new UnityEngine.Vector3(90, 0, 0) * Time.deltaTime;
            this.transform.eulerAngles = rotation;
            Debug.Log(transform.eulerAngles);
        }
        // 부자연스럽게 멈추는 회전
        if (Input.GetKey(KeyCode.F))
        {
            this.transform.eulerAngles = this.transform.eulerAngles + new UnityEngine.Vector3(90, 0, 0) * Time.deltaTime;
            Debug.Log(transform.eulerAngles);
        }
        // 메서드를 사용한 회전, 가장 권정하는 방법
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new UnityEngine.Vector3(90, 0, 0) * Time.deltaTime);
        }

        // 쿼터니온을 활용하면 짐벌락 현상이 안생긴다
        if (Input.GetKey(KeyCode.G))
        {
            //this.transform.rotation = Quaternion.Euler(this.transform.eulerAngles + new Vector3(90, 0, 0) * Time.deltaTime);
            rotation = rotation + new Vector3(90, 0, 0) * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(rotation);
        }

        if(Input.GetKey(KeyCode.U))
        {
            this.transform.localScale = this.transform.localScale + new Vector3(2, 2, 2) * Time.deltaTime;
        }

        // forward 앞만 알려주는 정규화 벡터, up 위만 알려주는 정규화 벡터, right 오른쪽만 알려주는 정규화 벡터
        if(Input.GetKey(KeyCode.I))
        {
            this.transform.position += this.transform.forward * Time.deltaTime * 3;
        }
        if (Input.GetKey(KeyCode.O))
        {
            this.transform.LookAt(go_camera.transform.position);
        }

        transform.RotateAround(go_camera.transform.position, Vector3.forward, 90 * Time.deltaTime);

    }
}
