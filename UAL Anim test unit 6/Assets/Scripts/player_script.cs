using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class player_script : MonoBehaviour
{

    private Animator anim;

    // this is the bullet prefab
    public GameObject bullet;
    float speed = 10.0f;

    private int moveDirection = 1;
    // Start is called before the first frame update
    void Start()
    {

        // get the animator component
        anim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        shootBullets();

        animatePlayer();

        movePlayer();

    }


    void shootBullets()
    {
        // Ctrl or mouse button was pressed, launch a bullet
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(bullet, transform.position, transform.rotation);

            // get the rigidbody component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            // set the velocity
            rb.velocity = new Vector3(15 * moveDirection, 0, 0);

            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 1);

            // TO DO - set the bullet rotation,based on which way the player is facing
            rb.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void animatePlayer()
    {
        // reset the player's rotation
        transform.rotation = Quaternion.identity;

        //Debug.Log(moveDirection);
        if (Input.GetKey("left"))
        {
            //Send the message to the Animator to activate the trigger parameter named "Jump"
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
            moveDirection = -1;
        }
        else
        {
            if (Input.GetKey("right"))
            {
                anim.SetBool("walk", true);
                anim.SetBool("idle", false);
                moveDirection = 1;
            }
            else
            {
                // neither left or right pressed, return to idle
                anim.SetBool("idle", true);
                anim.SetBool("walk", false);

            }
        }
    }


    void movePlayer()
    {

        // make the player face left or right depending on the direction he is facing
        if (moveDirection == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (moveDirection == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


        // move the player in the direction of the joystick
        float axis = Input.GetAxis("Horizontal");
        var move = new Vector3(axis, 0, 0);
        transform.position += move * speed * Time.deltaTime;

    }

}