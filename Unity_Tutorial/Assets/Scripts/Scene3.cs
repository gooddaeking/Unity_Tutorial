using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3 : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myRigid;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        rotation = this.transform.eulerAngles;
    }

    // Add 시리즈는 물리학이 적용된다.
    // Move 시리지는 물리법칙이 소용이없다.

    // Update is called once per frame
    void Update()
    {
        //mass , drag, angularDrag
        if(Input.GetKey(KeyCode.W))
        {
            myRigid.velocity = new Vector3(0, 0, 1);
            //myRigid.velocity = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigid.angularVelocity = -Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRigid.maxAngularVelocity = 100;
            myRigid.angularVelocity = Vector3.right * 100;
        }
        if (Input.GetKey(KeyCode.K))
        {
            myRigid.isKinematic = true;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            myRigid.isKinematic = false;
        }
        if (Input.GetKey(KeyCode.G))
        {
            myRigid.useGravity = false;
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            myRigid.useGravity = true;
        }

        if (Input.GetKey(KeyCode.M))
        {
            myRigid.MovePosition(transform.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.N))
        {
            rotation += new Vector3(90, 0, 0) * Time.deltaTime;
            myRigid.MoveRotation(Quaternion.Euler(rotation));
        }
        //AddForce 관성과 질량의 영향을 받는 이동
        if (Input.GetKey(KeyCode.B))
        {
            myRigid.AddForce(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.V))
        {
            myRigid.AddForce(-Vector3.forward);
        }
        //AddTorque 관성과 질량의 영향을 받는 회전
        if (Input.GetKey(KeyCode.C))
        {
            myRigid.AddTorque(Vector3.up);
        }
        if (Input.GetKey(KeyCode.X))
        {
            myRigid.AddTorque(-Vector3.up);
        }
        //AddExplosionForce 관성과 질량의 영향을 받는 폭발효과
        if (Input.GetKey(KeyCode.R))
        {
            myRigid.AddExplosionForce(10,-this.transform.up,10);
        }

    }
}
