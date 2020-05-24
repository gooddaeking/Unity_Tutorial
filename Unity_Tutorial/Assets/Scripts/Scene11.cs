using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene11 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text txt_name;
    [SerializeField]
    private Image img_name;
    [SerializeField]
    private Sprite sprite;

    private bool isCoolTime = false;
    private float currentTime = 1f;
    private float delayTime = 5f;

    void Update()
    {
        //img_name.sprite =
        //img_name.color = Color.red;
        //Color color = img_name.color;
        //color.a = 0f;
        //img_name.color = color;

        if(isCoolTime)
        {
            currentTime -= Time.deltaTime / delayTime;
            img_name.fillAmount = currentTime ;

            if(currentTime <= 0)
            {
                isCoolTime = false;
                currentTime = 1f;
                img_name.fillAmount = currentTime;
            }
        }
    }

    public void Change()
    {
        txt_name.text = "변경됨";
        isCoolTime = true;
    }


}

