using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    Vector2 targetPosition;
    public GameObject host;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = host.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
          if(Input.GetMouseButtonDown(0)){
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x =  Mathf.Round(targetPosition.x)+0.5f;
                        targetPosition.y =  Mathf.Round(targetPosition.y)+0.5f;

           
        }
        if((Vector2)transform.position != targetPosition) {
            
            transform.position = 
            targetPosition;
        }else{
        }
    }
}
