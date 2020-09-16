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
    public int extraJumps; //Set from inspector
    private int jumps;
    // Start is called before the first frame update
    void Start()
    {
        rigidBod = GetComponent<Rigidbody2D>();
        jumps = extraJumps;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBod.velocity = new Vector2(-2, rigidBod.velocity.y);
        //Curently order causes grounded to remain true during takeoff, allowing an extra jump even when max is set to 1.
        //can tweak things or test for grounded again immediately after jumping, or leave it as a *cough cough* feature.
        //*Turned into EXTRAJumps and if at 0 jumps does original grounded check
        grounded = Physics2D.OverlapCircle(testGround.position, groundTestingRadius, groundLayer);
        if (Input.GetMouseButtonDown(0) && (jumps > 0))
        {
            rigidBod.velocity = new Vector2(rigidBod.velocity.x, 5);
            jumps = jumps - 1;
        }
        else if (Input.GetMouseButtonDown(0) && grounded)
        {
            rigidBod.velocity = new Vector2(rigidBod.velocity.x, 5);
        }
        if (grounded)
        {
            jumps = extraJumps;
        }
        balance();
    }
    //Used to keep the Player Standing upright, Was tumbling like crazy at the edge of platforms
    void balance()
    {
        rigidBod.SetRotation(0);
    }
}
