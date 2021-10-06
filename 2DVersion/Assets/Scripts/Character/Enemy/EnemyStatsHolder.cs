using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyStatsHolder : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject contentWindow;

    private void Awake()
    {


    }
    public void Test()
    {
     //   Debug.Log(EnemyType.EnemyTypes[0]._attackList[0].Attack());
     //   Debug.Log(EnemyType.EnemyTypes[0]._ablityList[0].Attack());

        //   Damage[] damageRolls = {
        //        new Damage(1,8,2,"Bludgeoning"),
        //        new Damage(3,6,0,"Acid")
        //    };
        //  Debug.Log(AttackFactory.CreateAttack("Pseudopod",5,5,1,damageRolls).Attack()); 


        EnemyInfoTest enemyInfo = new EnemyInfoTest(57, 11, 25);
        EnemyType.AddToEnemyType(enemyInfo);
        Debug.Log(EnemyType.EnemyTypes[3].EnemyInfoTest.hp.ToString());

        NewEnemy(EnemyType.EnemyTypes[3]);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Test();
        }
    }

    public void NewEnemy(EnemyType enemyType)
    {
        GameObject newObj;

        newObj = (GameObject)Instantiate(enemyPrefab, contentWindow.transform, false);


        newObj.transform.parent = contentWindow.transform;
        newObj.GetComponent<EnemyClass>().CreateCharacter(enemyType);

    }
}
