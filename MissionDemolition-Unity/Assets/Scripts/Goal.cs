/***
 * Created by:Kangjie Ouyang
 * Date Created:2/16/22
 * 
 * Last Edited by: NA
 * Last Edited:  2/16/22
 * 
 * Description: Goal
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;




    void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "Projectile")
        {
            // If so, set goalMet to true
            Goal.goalMet = true;
            // Also set the alpha of the color to higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
