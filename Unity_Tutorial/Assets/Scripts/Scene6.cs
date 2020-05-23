using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6 : MonoBehaviour
{
    [SerializeField]
    private GameObject go_Target;

    [SerializeField]
    private float speed;

    // 카메라 속성을 바꿀 수 있다.
    private Camera theCam;

    private Vector3 difValue;

    // Start is called before the first frame update
    void Start()
    {
        difValue = this.transform.position - go_Target.transform.position;
        difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y), Mathf.Abs(difValue.z));

        //theCam.fieldOfView = 시야
        //theCam.clearFlags = 백그라운드설정
        //theCam.nearClipPlane =
        //theCam.farClipPlane =
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, go_Target.transform.position + difValue, speed);
    }
}
