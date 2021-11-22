using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start() {
        // delete bullet after 10 secs if it isn't already destroyed (there is a bug in this, tries to access bullet even though it's deleted)
        //Destroy(gameObject, 10f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // delete bullet on collision 
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * .25f;
    }
}
