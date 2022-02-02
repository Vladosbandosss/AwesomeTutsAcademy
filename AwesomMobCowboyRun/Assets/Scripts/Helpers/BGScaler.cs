using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
   
   private void Start()
   {
       var height = Camera.main.orthographicSize * 2f;
       var width = height * Screen.width / Screen.height;

       if (gameObject.CompareTag("BG"))
       {
           transform.localScale = new Vector3(width, height, 0);
       }
       else
       {
           transform.localScale = new Vector3(width+10f, 5f, 0);
       }
   }

  
}
