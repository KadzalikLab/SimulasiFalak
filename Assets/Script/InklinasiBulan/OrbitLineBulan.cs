using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitLineBulan : MonoBehaviour
{



    public int segments;
    public float zradius;
    public float xradius;
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
    line = gameObject.GetComponent<LineRenderer>();

    line.SetVertexCount (segments + 1);
    line.useWorldSpace = false;
    CreatePoints ();
        
        
    }

    // Update is called once per frame
    void CreatePoints()
    {
    float x;
    float y = 0f;
    float z;

    float angle = 20f;

    for (int i = 0; i < (segments + 1); i++)
    {
        x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
        z = Mathf.Cos (Mathf.Deg2Rad * angle) * zradius;

        line.SetPosition (i,new Vector3(x,y,z) );

        angle += (360f / segments);
    }

        
    }
}
