using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;

    public enum SurfaceStates { None, Normal, Cloud }
    public enum SurfaceStatesTypes { None, Fire, Water, Blood, Poison, Oil, Ice }
    public enum SurfaceStatesModifiers { None, Cursed, Blessed, Electrified, Frozen }

    public SurfaceStates surfaceState;
    public SurfaceStatesTypes surfaceStateType;
    public SurfaceStatesModifiers surfaceStateMod;

    private SurfaceStates previousSurfaceState;
    private SurfaceStatesTypes previousStateType;
    private SurfaceStatesModifiers previousStateMod;

    public int timer;
    Coroutine ElementalSurfaceUpdaterCoroutine;

    void Start()
    {
        previousSurfaceState = surfaceState;
        previousStateType = surfaceStateType;
        previousStateMod = surfaceStateMod;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            ElementalSurfaceUpdaterCoroutine = StartCoroutine(ElementalSurfaceUpdater());

        }

    }
    //   public enum SurfaceStatesTypes { None, Fire, Water, Blood, Poison, Oil, Ice }
    void updateSurface()
    {
        // if past state is same as new state further that state
        if (surfaceStateType == previousStateType)
        {
            ProgressCurrentState();
        }
        else
        {
            // if previous state was none add new state
            if (previousStateType == SurfaceStatesTypes.None)
            {
                UpdateNewState();
                // if previous state wasnt none, reaction
            }
            else
            {
                UpdateStateReaction();
            }




        }

    }

    IEnumerator ElementalSurfaceUpdater()
    {



        yield return new WaitForSeconds(2f);

    }

    void ProgressCurrentState()
    {

    }

    void UpdateNewState()
    {

    }

    void UpdateStateReaction()
    {
        
    }

}
