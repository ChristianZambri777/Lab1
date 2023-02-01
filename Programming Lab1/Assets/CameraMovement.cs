using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform cam;
    public float speed = 0.01f;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        cam.position += new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
    }
}
