using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //레이는 2개 필요함
    Ray leftRay = new Ray();
    Ray rightRay = new Ray();
    public float rayAngle = 45.0f;      //레이각도
    public float rayDistance = 10.0f;   //레이길이
    public Transform rayTransform;      //레이위치
    //Transform rayPosition;           //레이위치
    //GameObject rayPosition;          //레이위치
    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //레이 위치를 프라이빗으로 선언한 경우
        //rayPosition = GameObject.Find("rayPositon").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //전진해라
        Accelate();

        //전방 앞으로 45도 레이 준비
        float leftRad = (90.0f + rayAngle) * Mathf.Deg2Rad;
        float rightRad = (90.0f - rayAngle) * Mathf.Deg2Rad;
        Vector3 leftDir = new Vector3(Mathf.Cos(leftRad), 0.0f, Mathf.Sin(leftRad));
        Vector3 rightDir = new Vector3(Mathf.Cos(rightRad), 0.0f, Mathf.Sin(rightRad));

        leftDir = rayTransform.TransformDirection(leftDir);
        rightDir = rayTransform.TransformDirection(rightDir);

        leftRay.origin = rayTransform.position;
        leftRay.direction = leftDir;
        rightRay.origin = rayTransform.position;
        rightRay.direction = rightDir;

        //좌우 레이 충돌처리
        RaycastHit hit;
        float leftHitDistance = rayDistance;
        float rightHitDistance = rayDistance;
        if(Physics.Raycast(leftRay, out hit, rayDistance))
        {
            //레이와 충돌된 거리
            leftHitDistance = hit.distance;
        }
        if (Physics.Raycast(rightRay, out hit, rayDistance))
        {
            //레이와 충돌된 거리
            rightHitDistance = hit.distance;
        }
        //충돌되고 잇는 거리비율만큼 회전처리하기
        float steerAngle = (rightHitDistance - leftHitDistance) / rayDistance;
        Steering(steerAngle);
    }

    //전진해라
    void Accelate()
    {
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
    //회전처리해라
    void Steering(float value)
    {
        //transform.Rotate(Vector3.up * value * 90 * Time.deltaTime);
        transform.Rotate(0, value * 90 * Time.deltaTime, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(leftRay.origin, leftRay.direction * rayDistance);
        Gizmos.DrawRay(rightRay.origin, rightRay.direction * rayDistance);
    }
}
