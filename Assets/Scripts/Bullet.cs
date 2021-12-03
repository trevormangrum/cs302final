using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credit to ZeveonHD for a helpful tutorial to write this script
public class Bullet : MonoBehaviour
{

    private void Start() {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // delete bullet on collision 
        Destroy(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * .025f;
    }
}
