using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProximityTrigger : MonoBehaviour
{   /* This script handles the proximity trigger for the tree of life pieces that appear troughout the level.
    When the player is near a collider it deactivates the moving code for the tree of life piece and enables a trigger with a material outline used as signifier for the players*/

    [Tooltip("The trigger object that is used as a signifier for the players")]
    [SerializeField]
    GameObject triggerToActivate;
    [Tooltip("The moving and rotating tree of life piece")]
    [SerializeField]
    GameObject movingObject;
    private MovingPiece scriptComponent;
    private Rigidbody rigidbodyComponent;

    private void Start() {
        scriptComponent = movingObject.GetComponent<MovingPiece>(); 
        rigidbodyComponent = movingObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PlayerFoot")){
            if(scriptComponent != null){
                scriptComponent.enabled = false; //disables the script which disables the movement and rotation of the tree of life puzzle
            }
            else{
                return;
            }
            if(rigidbodyComponent != null){
                rigidbodyComponent.isKinematic = false;//Makes the rigidbody of the tree of life puzzle piece non kinematic so players can grab it 
            }
            if(triggerToActivate.activeSelf == false){
                triggerToActivate.SetActive(true);//enables the trigger object to which players should bring the tree of life part
            }
        }
    }
}
