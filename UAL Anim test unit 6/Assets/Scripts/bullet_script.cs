using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject explosion;

    private int timer = 0;
    public int rotation = 180;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        // destroy object after 300 updates
        timer += 1;
        if( timer > 300 )
        {
            Destroy(gameObject);
        }

        // get the rigitbody component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // get the velocity of the projectile
        if (rb.velocity.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hello");
        //Destroy(gameObject);

        string tag = collision.gameObject.tag;
        if( tag == "floor" )
        {
            GameObject clone = Instantiate(explosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        //Debug.Log(collider);









    }













}
