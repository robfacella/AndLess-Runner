using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    public Transform tform;
    GameObject pc;
    Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        tform = GetComponent<Transform>();

        pc = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (pc != null)
            playerTransform = pc.transform;
        else
            Debug.Log("Player object not found");
        //Did not error out.

        if (playerTransform.position.x < (tform.position.x - 10.0))
        {
            Vector3 newV3 = tform.position;
            float xx = playerTransform.position.x;
            xx = xx - (float)18.5;
            newV3.x = xx;
            tform.position = newV3;
        }
    }
}
