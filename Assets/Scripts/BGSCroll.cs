using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSCroll : MonoBehaviour
{ public float Scrollspeed;
    public float tile;
    Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float newpos = Mathf.Repeat(Time.time * Scrollspeed, tile);

        transform.position = Vector3.up * newpos + startpos;
    }
}
