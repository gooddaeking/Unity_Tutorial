using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5 : MonoBehaviour
{
    [SerializeField]
    private Material yellow_Mat;
    [SerializeField]
    private Material purple_Mat;

    private MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0))
        {
            mesh.material = yellow_Mat;
        }
        else
        {
            mesh.material = purple_Mat;
        }

    }
}
