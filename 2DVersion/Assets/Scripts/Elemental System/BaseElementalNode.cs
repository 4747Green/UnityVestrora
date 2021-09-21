using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System;


public class BaseElementalNode : Node
{


    [Input] public int entry;



    public ElementalType elementalType = ElementalType.None;
    public enum ElementalType { None, Fire, Water, Air }
    [Output] public ElementalType output;

    public enum Surfaces { None, FireSurface, WaterSurface, BloodSurface,
    PoisonSurface, OilSurface, IceSurface }
    public enum SurfaceModifiers{None,Frozen, Cloud,Electrified}
    public bool cloud;

     public override object GetValue(XNode.NodePort port) {
       
         
                switch (elementalType) {
                    case ElementalType.None: default: output =  ElementalType.None; break;
                    case ElementalType.Fire: output = ElementalType.Fire; break;
                    case ElementalType.Water: output = ElementalType.Water; break;
                    case ElementalType.Air: output = ElementalType.Air; break;
                }
            return output;

        }



}