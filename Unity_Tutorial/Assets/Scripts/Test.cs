using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.gameObject.layer = 4;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.gameObject.layer = 0;
        }

    }
}
