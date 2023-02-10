using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform cam;
    public float speed = 0.1f;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        cam.position = new Vector3(player.transform.position.x, cam.position.y, player.transform.position.z - 14);
    }
}
