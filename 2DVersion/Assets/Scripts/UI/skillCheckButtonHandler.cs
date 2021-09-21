using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillCheckButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;
    public Text txt;
    public PlayerClass player;

    public int id;
    Checks checkClass;
    Skills sim;


    public void Start()
    {

        checkClass = new Checks(player);

        // SetText(checkClass.listOfSkills[id].skillName);



    }

    public void SetText(string text)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;


    }

    public void rollSkill()
    {
        int roll = checkClass.invoke(id);
        Debug.Log(checkClass.listOfSkills[id].skillName + "roll: " + roll);

    }




}
