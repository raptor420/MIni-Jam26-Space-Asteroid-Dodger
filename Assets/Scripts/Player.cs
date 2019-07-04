using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{
    public event Action deathevent;
    Animator anim;
    [System.Serializable]
    public struct  bounds {

      public   float maxX;
        public float MinX;
        public float MaxY;
        public float MinY;


    }

    public float speed;
    public Vector3 target;
    public bounds Bounds;
   public  bool playerAlive;


    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        playerAlive = true;
    }
 
    void FixedUpdate()
    {

        if (playerAlive)
        {
          

            Vector3 mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            target = Camera.main.ScreenToWorldPoint(mousepos);


            if (Vector2.Distance(transform.position, target) > 0.1f)
            {

                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            }
            
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, Bounds.MinX, Bounds.maxX), Mathf.Clamp(transform.position.y, Bounds.MinY, Bounds.MaxY), 0);

        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            anim.SetTrigger("Die");
            playerAlive = false;
            Destroy(other.gameObject);
             PlayerDie();
            Debug.Log("hit");
        }

    }
    void PlayerDie()
    {
      
        if (deathevent != null)
        {
            deathevent();
            Invoke("SetPlayerInactive", 0.5f);

        }

    }

    void SetPlayerInactive()
    {
        this.gameObject.SetActive(false);
    }

 


}
