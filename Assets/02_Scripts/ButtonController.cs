using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftButton()
    {
        if(ButtonMovement.inputCount > 0)
        {
            ButtonMovement.inputCount--;
        }
    }
    public void RightButton() {
        if (ButtonMovement.inputCount < 1)
        {
            ButtonMovement.inputCount++;
        }
    }
}
