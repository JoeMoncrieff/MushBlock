using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClick : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i< Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

        }
    }
}
