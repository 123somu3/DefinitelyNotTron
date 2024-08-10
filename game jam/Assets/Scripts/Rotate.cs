using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float Speed = 10f;

    private bool isRotating=false;

    private float StartMouseposition;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            StartMouseposition = Input.mousePosition.x;
        }

        else if(Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        if(isRotating)
        {
            float currentmouseposition=Input.mousePosition.x;
            float mousemovement = currentmouseposition - StartMouseposition;

            transform.Rotate(UnityEngine.Vector3.up, -mousemovement * Speed * Time.deltaTime);
            StartMouseposition=currentmouseposition;    

        }
    }
}
