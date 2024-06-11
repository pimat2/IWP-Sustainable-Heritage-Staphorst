using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachingLever : MonoBehaviour
{
    [Tooltip("The static MillLever game object inside the house that gets activated on Trigger Enter")]
    public GameObject millLever;
    [Tooltip("The Mill Lever piece that is outside the water mill, which players need to bring in the collider")]
    public GameObject missingLever;
    void OnTriggerEnter(Collider col){
    if(col.CompareTag("MissingLever"))
    {
        Destroy(missingLever);
        millLever.SetActive(true);
        gameObject.SetActive(false);
    }
   }
}
