using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A MonoBehavior that has caches of the important managers used in the game
/// </summary>

public class MyManagerBehavior : MonoBehaviour
{

    // just an extension that allows easy caching for 1 component 
    // comes from https://github.com/dracolytch/DracoSoftwareExtensionsForUnity/tree/master/Assets/EditorExtensionExamples/Managers



    protected CachedComponent<UIManager> _UIManager = new CachedComponent<UIManager>();
    protected UIManager UIManager
    {
        get
        {
            return _UIManager.instance(this);
        }
    }







    protected CachedComponent<CombatManager> _combatManager = new CachedComponent<CombatManager>();
    public CombatManager combatManager
    {
        get
        {
            return _combatManager.instance(this);
        }
    }
    
    protected CachedComponent<CombatManagerData> _combatManagerData = new CachedComponent<CombatManagerData>();
    public CombatManagerData combatManagerData
    {
        get
        {
            return _combatManagerData.instance(this);
        }
    }












    // Clears references when new scene loaded
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {

        _UIManager.clear();
        _combatManager.clear();

    }









}