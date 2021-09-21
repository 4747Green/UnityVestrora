using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Linq;
public class PlayerSheetHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject prefab; // This is our prefab object that will be exposed in the inspector

    public int numberToCreate; // number of objects to create. Exposed in inspector
    public PlayerClass player;
    public int statIdToRender;



    void Start()
    {
        switch (statIdToRender)
        {
        case 0:
            PopulateSkills();
            break;

        case 1:
            PopulateSavingThrows();
            break;

        case 2:
           PopulatePrimaryStats();
            break;

            
        case 10:
           PopulateGeneralStats();
            break;

            default:
            Debug.Log("Player Sheet Handler: no case to match ID given to render panel content");
            break;
        }
    }

    void Update()
    {

    }
        void PopulateGeneralStats()
    {
        GameObject newObj; // Create GameObject instance
        Text[] newText;

        List<Stats.GeneralStats> list = player.playerChosenClass.playerStats.playerStats.generalStats;
        

        for (int i = 0; i < list.Count; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
            newObj = (GameObject)Instantiate(prefab, transform);
            newText = newObj.GetComponentsInChildren<Text>();

        
                newText[0].text = list[i].name;
                newText[1].text = list[i].value.ToString();
            


            // Randomize the color of our image

        }

    }


    void PopulateSkills()
    {
        GameObject newObj; // Create GameObject instance
        Text[] newText;

        List<Stats.DndSkills> list = player.playerChosenClass.playerStats.playerStats.dndSkills;


        for (int i = 0; i < list.Count; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
            newObj = (GameObject)Instantiate(prefab, transform);
            newText = newObj.GetComponentsInChildren<Text>();

        
                newText[0].text = list[i].name;
                newText[1].text = list[i].mod.ToString();
            


            // Randomize the color of our image

        }

    }
    void PopulateSavingThrows()

    {
                    Debug.Log("saves");

        GameObject newObj; // Create GameObject instance
        Text[] newText;

        List<Stats.SavingThrows> list = player.playerChosenClass.playerStats.playerStats.savingThrows;


        for (int i = 0; i < list.Count; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
            newObj = (GameObject)Instantiate(prefab, transform);
            newText = newObj.GetComponentsInChildren<Text>();

 
            
                newText[0].text = list[i].name;
                newText[1].text = list[i].mod.ToString();
            


            // Randomize the color of our image

        }

    }

    void PopulatePrimaryStats()
    {
        GameObject newObj; // Create GameObject instance
        Text[] newText;

        List<Stats.PrimaryStats> list = player.playerChosenClass.playerStats.playerStats.primaryStats;


        for (int i = 0; i < list.Count; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
            newObj = (GameObject)Instantiate(prefab, transform);
            newText = newObj.GetComponentsInChildren<Text>();

        
                newText[0].text = list[i].name;
                newText[1].text = list[i].value.ToString();
            


            // Randomize the color of our image

        }

    }


}