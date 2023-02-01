using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    public Rigidbody body;
    public Transform trans;
    public float rotationSpeed = 2f;

    public Vector3 move;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        trans = gameObject.GetComponent<Transform>();
        
    }


    // Update is called once per frame
    void Update()
    {

        move.x = Input.GetAxisRaw("Horizontal");
        move.z = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal")  != 0 || Input.GetAxisRaw("Vertical") != 0)
        { 
        body.MovePosition(body.position + move * speed * Time.fixedDeltaTime);
        Quaternion face = Quaternion.LookRotation(move ,Vector3.up);
        trans.rotation = Quaternion.RotateTowards(trans.rotation, face, rotationSpeed * Time.deltaTime);
        }
    }
}


