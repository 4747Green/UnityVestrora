using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ElementalObjectHolder : MonoBehaviour
{
    public enum SurfaceStates { None, Normal, Cloud }
    public enum SurfaceStatesTypes { None, Fire, Water, Blood, Poison, Oil, Ice }
    public enum SurfaceStatesModifiers { None, Cursed, Blessed, Electrified, Frozen }



    public ElementalObjectTemplate element;
    public List<ElementalObjectTemplate> elementalObjectList = new List<ElementalObjectTemplate>(new ElementalObjectTemplate[]{


        }
   );


    public ElementalObjectTemplate OnReact(ElementalObjectTemplate elementToBeReactedWith)
    {
        if (element.reactionList.Contains(elementToBeReactedWith.type))
        {
            foreach (var item in elementalObjectList)
            {
                if (item == elementToBeReactedWith)
                {
                    return item.React();
                }
            }
            return element;
        }
        return element;
    }


}

public class ElementalObjectTemplate
{
    public List<ElementalObjectTemplate> elementalObjectList;

    public ElementalObjectHolder.SurfaceStatesTypes type;

    public virtual ElementalObjectTemplate React()
    {
        return this;
    }
     public List<ElementalObjectHolder.SurfaceStatesTypes> reactionList;


}

[System.Serializable]
public class Fire : ElementalObjectTemplate
{
    public bool active;
    public bool cloudable;
    public bool normal;

    public bool isCloud;

    public List<ElementalObjectHolder.SurfaceStatesTypes> reactionList = new List<ElementalObjectHolder.SurfaceStatesTypes>(new ElementalObjectHolder.SurfaceStatesTypes[]{
         ElementalObjectHolder.SurfaceStatesTypes.Oil,
         ElementalObjectHolder.SurfaceStatesTypes.Water,
        ElementalObjectHolder.SurfaceStatesTypes.Ice,
        ElementalObjectHolder.SurfaceStatesTypes.Poison

        }
   );

    public Smoke OnExpired()
    {
        active = false;
        return new Smoke();
    }


}

[System.Serializable]
public class Steam : ElementalObjectTemplate
{

}

[System.Serializable]
public class Smoke : ElementalObjectTemplate
{

}

[System.Serializable]
public class Water : ElementalObjectTemplate
{

}
