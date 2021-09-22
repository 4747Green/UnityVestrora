using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MyManagerBehavior
{
    public static UIManager Instance;
    public GameObject userInterface;
    public GameObject dialougeBox;

    public GameObject hotbar;

    public GameObject uiToggles;
    public GameObject playerSheet;
    public NodeParser dialogueHandler;

    public GameObject combatUI;
    public GameObject charactersHolder;


    public GameObject turnOrderScroll;
    public GameObject currentTurnHolder;
    public GameObject turnCounterHolder;
    public GameObject sideBarInnitiveHolder;
    public ScrollRect scrollRect;
    public GameObject prefabInnitive; // This is our prefab object that will be exposed in the inspector

    public GameObject prefabInnitiveLarge;
    public int numberToCreate; // number of objects to create. Exposed in inspector

    public GameObject contentWindow;

    private Sprite defaultSprite;
    private string currentCharacterTurn;
    private List<GameObject> turnOrderQueue = new List<GameObject>();
    public SortedList<int, GameObject> turnOrderUICopy = new SortedList<int, GameObject>();
    public GameObject currentTurnObject;
    public GameObject textMesh;

    private void Awake()
    {
        Instance = this;
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        CombatManager.OnCombatStateChanged += OnCombatStateChanged;
        CombatManager.OnCharacterTurn += OnCharacterTurn;
        CombatManager.OnGameQueueUIReady += OnGameQueueUIReady;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
        CombatManager.OnCombatStateChanged -= OnCombatStateChanged;
        CombatManager.OnCharacterTurn -= OnCharacterTurn;


    }
    private void OnGameQueueUIReady(){
        WipeQueueDrawing();
        UpdateTurnCounter();
        DrawQueue();
        UpdateCurrentTurnUI();
        SetActiveStateOfCombatUI(true);
    }

    private void OnCombatStateChanged(CombatManager.CombatState state)
    {
        if((state == CombatManager.CombatState.Victory)|| (state ==  CombatManager.CombatState.Lose)){
            WipeQueueDrawing();
            SetActiveStateOfCombatUI(false);
        }
        

    }
    private void OnCharacterTurn(GameObject character)
    {

    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        if (state == GameState.Combat)
        {
            SetActiveStateOfCombatUI(true);
        }




    }

    public void UpdateTurnCounter()
    {

        textMesh.GetComponent<TextMeshProUGUI>().text = (combatManagerData.round.ToString());
    }

    public Sprite GetSpriteFromCharacterGameObject(GameObject character)
    {

        Transform[] gameObjectChildren = character.GetComponentsInChildren<Transform>();
        Sprite spriteToBeReturned = defaultSprite;

        foreach (var gameObjItem in gameObjectChildren)
        {
            if (gameObjItem.gameObject.name == "TokenIcon")
            {
                spriteToBeReturned = gameObjItem.GetComponent<SpriteRenderer>().sprite;
            }
        }
        return spriteToBeReturned;

    }
    public void DrawQueue()
    {
    
        GameObject newObj;
        foreach (var item in combatManagerData.GetTurnOrderQueue())
        {
            newObj = (GameObject)Instantiate(prefabInnitive, contentWindow.transform, false);

            newObj.transform.Find("CharacterArt").GetComponent<Image>().sprite = GetSpriteFromCharacterGameObject(item);
            newObj.transform.parent = contentWindow.transform;




        }
    }

    public void UpdateCurrentTurnUI()
    {
        currentTurnObject.transform.Find("CharacterArt").GetComponent<Image>().sprite =
             GetSpriteFromCharacterGameObject(combatManager.currentCharacterTurn);
        currentTurnObject.transform.Find("CharacterName").GetComponent<Text>().text = combatManager.currentCharacterTurn.GetComponent<PlayerClass>().characterName;

    }

    public void WipeQueueDrawing()
    {
        foreach (Transform child in contentWindow.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void SetActiveStateOfCombatUI(bool state)
    {

        combatUI.SetActive(state);
    }

    // old
    public void DrawCurrentTurn()
    {
        if (GameObject.Find(currentTurnObject.name) != null)
        {
            Destroy(currentTurnObject);
        }

        //    currentTurnObject = combatHandler.GetCurrentTurnCharacterGameObject();

        GameObject newObj = (GameObject)Instantiate(prefabInnitiveLarge, currentTurnHolder.transform, false);

        currentCharacterTurn = currentTurnObject.GetComponent<PlayerClass>().characterName;

        newObj.transform.Find("CharacterName").GetComponent<Text>().text = currentCharacterTurn;


    }


    public void DialogueState()
    {
        hotbar.SetActive(false);
        uiToggles.SetActive(false);
        playerSheet.SetActive(false);
        dialogueHandler.StartDialouge();
        dialougeBox.SetActive(true);

    }

    public void FreeRoamState()
    {
        hotbar.SetActive(true);
        uiToggles.SetActive(true);
        playerSheet.SetActive(false);
        dialougeBox.SetActive(false);

    }

    public void UpdateDrawnTurnOrder()
    {

    }
    public void UpdateDrawnTurnCounter()
    {

    }
    public void ClearCombatTurnOrderUI()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
