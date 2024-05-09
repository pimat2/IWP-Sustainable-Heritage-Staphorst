using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachingLever : MonoBehaviour
{
    public GameObject millLever;
   public GameObject missingLever;
   void OnTriggerEnter(Collider col){
    if(col.CompareTag("MissingLever"))
    {
        Destroy(missingLever);
        millLever.SetActive(true);
    }
   }
}
