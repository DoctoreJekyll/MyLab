using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxEffect : MonoBehaviour
{

    private Transform cameraTransform;
    private Vector3 previousCameraPos;
    public float parrallaxMultiply;

    private float spriteWidth;
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPos = cameraTransform.position;

        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPos.x) * parrallaxMultiply;
        float moveAmount = cameraTransform.position.x * (1 - parrallaxMultiply);
        transform.Translate(new Vector3(deltaX, 0f, 0f));
        previousCameraPos = cameraTransform.position;

        if (moveAmount > startPos + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPos += spriteWidth;
        }else if (moveAmount < startPos - spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPos -= spriteWidth;
        }


    }
}
