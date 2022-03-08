using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float speed = 8f;
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
    }
}
