using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Transform playerTransform;
    private float playerX;

    // Update is called once per frame
    void Update()
    {
        playerX = playerTransform.transform.position.x;
        gameObject.transform.position = new Vector3(playerX, transform.position.y, transform.position.z);


    }
}
