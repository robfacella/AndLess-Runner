using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rigidBod;
    //Grounded Testing Vars:
    public Transform testGround;
    public float groundTestingRadius;
    public LayerMask groundLayer;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rigidBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBod.velocity = new Vector2(-2, rigidBod.velocity.y);
        grounded = Physics2D.OverlapCircle(testGround.position, groundTestingRadius, groundLayer);
        if (Input.GetMouseButtonDown(0) && grounded)
        {
            rigidBod.velocity = new Vector2(rigidBod.velocity.x, 5);
        }
    }
}
