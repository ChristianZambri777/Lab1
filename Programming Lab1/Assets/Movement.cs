using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IDataPersistence
{
    [SerializeField] public float speed = 5f;
    public Rigidbody body;
    public Transform trans;
    public float rotationSpeed = 2f;
    // bool shift = false;
    public float timeSent = 5f;
    public int amount = 10;
    //public int setVal = 20;
    public Vector3 move;
    public int health = 10;
    public int deaths = 2;

   // Animator animations;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        trans = gameObject.GetComponent<Transform>();
        //animations = GetComponent<Animator>();
        StartCoroutine(myMethod());

        Debug.Log($"Getting the value using a property is {GetSetValue}");
        GetSetValue = 20;
        Debug.Log($"After setting value using property, the value is {GetSetValue}");
    }


    // Update is called once per frame
    void Update()
    {

        move.x = Input.GetAxisRaw("Horizontal");
        move.z = Input.GetAxisRaw("Vertical");


      
    }


    private IEnumerator myMethod()
    {

        Debug.Log("Testing coroutine, this message should print now");

        yield return new WaitForSeconds(timeSent);

        Debug.Log("This mesaage should print after 5 seconds");
       
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


    public int GetSetValue
    {
        get { return amount; }
        set
        {
            amount = value;
        }
    }

    public void LoadData(PlayerSaveData data)
    {
        this.health = data.health;
        transform.position = data.position;
    }

    public void SaveData(ref PlayerSaveData data)
    {
        data.health = this.health;
        data.position = transform.position;
    }
}


