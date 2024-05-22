using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPiece : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float amplifier; 
    [Range(0.0f, 10.0f)]
    public float frequency;
    [SerializeField]
    Vector3 objectRotation;
    Vector3 initialPosition;
    [SerializeField]
    bool moveSideways;

    private void Start() {
        initialPosition = transform.position;
    }
        // Update is called once per frame
    void Update()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        if(moveSideways == true){
            transform.position = new Vector3(Mathf.Sin(Time.time * frequency) * amplifier + initialPosition.x,initialPosition.y,initialPosition.z);
        }
        else{
             transform.position = new Vector3(initialPosition.x,Mathf.Sin(Time.time * frequency) * amplifier + initialPosition.y,initialPosition.z);
        }
        gameObject.transform.Rotate(objectRotation * Time.deltaTime);
    }
}
