using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;

    Vector2 targetPosition;
    bool moving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x =  Mathf.Round(targetPosition.x) +0.5f;
                        targetPosition.y =  Mathf.Round(targetPosition.y) +0.5f;

            moving = true;
        }
        if(moving && (Vector2)transform.position != targetPosition) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
            targetPosition,step);
        }else{
            moving = false;
        }
    }
}
