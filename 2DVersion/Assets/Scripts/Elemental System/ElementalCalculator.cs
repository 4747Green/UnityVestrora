using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ElementalCalculator : Node
{

    // Use this for initialization

    [Output] public BaseElementalNode.Surfaces output;
    [Output] public BaseElementalNode.SurfaceModifiers surfaceMod;

    [Input] public BaseElementalNode.ElementalType elementalInput;
    [Input] public BaseElementalNode.ElementalType elementalInput2;



    protected override void Init()
    {
        base.Init();

    }

    // Return the correct value of an output port when requested
    public override object GetValue(NodePort port)
    {
        switch (elementalInput)
        {
            case BaseElementalNode.ElementalType.None:
            default:
                // case nothing n nothing
                if (elementalInput2 == BaseElementalNode.ElementalType.None)
                {
                    output = BaseElementalNode.Surfaces.None;
                    surfaceMod = BaseElementalNode.SurfaceModifiers.None;

                }

                break;
            // case fire n water steam cloud
            case BaseElementalNode.ElementalType.Fire:

                if (elementalInput2 == BaseElementalNode.ElementalType.Water)
                {
                    output = BaseElementalNode.Surfaces.WaterSurface;
                    surfaceMod = BaseElementalNode.SurfaceModifiers.Cloud;


                }

                break;

            case BaseElementalNode.ElementalType.Water:

                if (elementalInput2 == BaseElementalNode.ElementalType.Water)
                {
                    output = BaseElementalNode.Surfaces.WaterSurface;
                    surfaceMod = BaseElementalNode.SurfaceModifiers.Cloud;


                }

                break;

            case BaseElementalNode.ElementalType.Air:

                if (elementalInput2 == BaseElementalNode.ElementalType.Water)
                {
                    output = BaseElementalNode.Surfaces.WaterSurface;
                    surfaceMod = BaseElementalNode.SurfaceModifiers.Cloud;


                }

                break;
        }



        return output;
    }
}