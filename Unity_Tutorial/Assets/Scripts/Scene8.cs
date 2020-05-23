using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene8 : MonoBehaviour
{
    private Animation ani;

    // 애니메이션 파일 지정
    private AnimationClip clip;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           // // 바로 재생
           // ani.Play("Cube_2");
           // // 이전 애니메이션이 끝나고 재생
           // ani.PlayQueued("Cube_2");
            // 같이 재생
            ani.Blend("Cube_2");
            // 자연스럽게 이전동작에서 연결
           // ani.CrossFade("Cube_2");
           // // 조건문
           // if (!ani.IsPlaying("Cube_2")) ani.Play("Cube_2");

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            // 모든 애니를 멈춤
            //ani.Stop();

            // 애니메이션 모드 설정
            //ani.wrapMode = WrapMode.

            //ani.clip = 
            ani.animatePhysics = false;
        }

    }
}
