using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    public Rigidbody body;
    public Transform trans;
    public float rotationSpeed = 2f;
   // bool shift = false;

    public Vector3 move;

   // Animator animations;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        trans = gameObject.GetComponent<Transform>();
        //animations = GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void Update()
    {

        move.x = Input.GetAxisRaw("Horizontal");
        move.z = Input.GetAxisRaw("Vertical");



        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animations.Play("CharacterArmature|Dagger_Attack");
           
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8f;
            shift = true;
        }
        else
        {
            shift = false;
        }

        */
    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal")  != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //if(shift)
           // animations.Play("CharacterArmature|Walk");
            body.MovePosition(body.position + move * speed * Time.fixedDeltaTime);
       
        Quaternion face = Quaternion.LookRotation(move ,Vector3.up);
        trans.rotation = Quaternion.RotateTowards(trans.rotation, face, rotationSpeed * Time.deltaTime);
        }
    }
}


