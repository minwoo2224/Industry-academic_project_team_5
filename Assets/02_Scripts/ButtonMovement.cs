using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonMovement : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 nextPosition;
    float screenWidth = 1074.5f;
    public static int inputCount = 0;
    int beforeInput;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        nextPosition = startPosition;
        beforeInput = inputCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeInput > inputCount)
        {
            nextPosition = new Vector3(nextPosition.x + screenWidth, startPosition.y);
            beforeInput = inputCount;
        }
        else if (beforeInput < inputCount)
        {
            nextPosition = new Vector3(nextPosition.x - screenWidth, startPosition.y);
            beforeInput = inputCount;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, 10f);
    }
}
