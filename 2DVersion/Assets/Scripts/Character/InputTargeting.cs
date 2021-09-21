using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputTargeting : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject selectedHero;
    public bool heroPlayer;
    RaycastHit2D hit;
    public Camera cam;
    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


            if (hit.collider.GetComponent<Targetable>() != null)
            {

                if (hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Enemy)
                {

                    selectedHero.GetComponent<PlayerCombat>().targetedEnemy = hit.collider.gameObject;
                }

                  if (hit.collider.gameObject.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Self)
                {

                    selectedHero.GetComponent<PlayerCombat>().targetedEnemy = hit.collider.gameObject;
                }


            }
            else if (hit.collider.gameObject.GetComponent<Targetable>() == null)
            {
                selectedHero.GetComponent<PlayerCombat>().targetedEnemy = null;
            }











        }
    }
}
