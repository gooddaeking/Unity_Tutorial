using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene9 : MonoBehaviour
{
    private Animator ani;
    private Rigidbody rigid;
    private BoxCollider col;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask layerMask;

    private bool isMove;
    private bool isJump;
    private bool isFall;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        TryWalk();
        TryJump();

    }

    private void TryJump()
    {
        if (isJump)
        {
            if (rigid.velocity.y <= -0.1f && !isFall)
            {
                isFall = true;
                isJump = false;
                ani.SetTrigger("Fall");
            
            }
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, -transform.up, out hitInfo, col.bounds.extents.y + 0.1f, layerMask))
            {
                isJump = false;
                isFall = false;
                ani.SetTrigger("Landing");
            }
        }



        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
            //rigid.velocity = new Vector3(0, jumpForce, 0);
            rigid.AddForce(Vector3.up * jumpForce);
            ani.SetTrigger("Jump");


        }
    }

    private void TryWalk()
    {
        float _dirX = Input.GetAxisRaw("Horizontal");
        float _dirZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(_dirX, 0, _dirZ);

        //ani.SetBool("Right", false);
        //ani.SetBool("Left", false);
        //ani.SetBool("Up", false);
        //ani.SetBool("Down", false);

        isMove = false;

        // 노멀라이즈 하는 이유는 대각선속도가 1을 넘지 않도록
        if (direction != Vector3.zero)
        {
            isMove = true;
            this.transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

            //if(direction.x > 0)
            //{
            //    ani.SetBool("Right", true);
            //}
            //else if (direction.x < 0)
            //{
            //    ani.SetBool("Left", true);
            //}
            //else if (direction.z > 0)
            //{
            //    ani.SetBool("Up", true);
            //}
            //else if (direction.z < 0)
            //{
            //    ani.SetBool("Down", true);
            //}
        }

        ani.SetBool("Move", isMove);
        ani.SetFloat("DirX", direction.x);
        ani.SetFloat("DirZ", direction.z);
    }

   
}

