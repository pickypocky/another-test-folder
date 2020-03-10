using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_script : MonoBehaviour
{
    // Start is called before the first frame update
    int timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // make the explosion grow and shrink, then switch itself off   

        timer++;

        if( timer == 20 )
        {
            transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        }
        if (timer == 40)
        {
            Destroy(gameObject);
        }


    }
}
