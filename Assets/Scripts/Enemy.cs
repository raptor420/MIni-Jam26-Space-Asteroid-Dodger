using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

     float ChosenSpeed;
    // Start is called before the first frame update
    private void OnEnable()
    {
        float r = Random.Range(-speed * .50f, speed * .50f);
        ChosenSpeed = speed + r;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position = Vector3.down * ChosenSpeed *Time.deltaTime + transform.position;
        transform.Rotate(0, 0, Time.deltaTime * ChosenSpeed * ChosenSpeed);
    }


}
