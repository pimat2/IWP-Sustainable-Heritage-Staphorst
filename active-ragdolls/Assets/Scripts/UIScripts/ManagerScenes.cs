using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
    public static ManagerScenes Instance;

   private void Awake()
   {
     Instance = this;
   }

   public enum Order
   {
     Main_Menu,
     GreenQuest_Blockout
   }

   public void LoadingGame (Order scene)
   {

    SceneManager.LoadScene(scene.ToString());

   }

   public void LoadGame()
   {
    SceneManager.LoadScene(Order.GreenQuest_Blockout.ToString());
   }
}
