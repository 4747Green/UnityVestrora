using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Linq;
public class CombatUIHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject prefab; // This is our prefab object that will be exposed in the inspector

    public int numberToCreate; // number of objects to create. Exposed in inspector
    public GameObject contentWindow;


    void Start()
    {
        PopulateInnitive();
    }

    void Update()
    {

    }


    void PopulateInnitive()
    {
        GameObject newObj; // Create GameObject instance
     



        for (int i = 0; i < numberToCreate; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
            newObj = (GameObject)Instantiate(prefab, contentWindow.transform,false);
          

            // Randomize the color of our image

        }

    }


}