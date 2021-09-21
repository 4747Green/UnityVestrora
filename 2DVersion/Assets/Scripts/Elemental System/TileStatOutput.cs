using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class TileStatOutput : Node
{

        [Input] public BaseElementalNode.ElementalType entry;

		public string value;

		     public override object GetValue(XNode.NodePort port) {
       
         
                value = entry.ToString();
				return value;

        }
		public void OnEnter() {
                value = entry.ToString();
		}
		
}