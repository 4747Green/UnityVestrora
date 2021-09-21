using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node
{
	public  bool endNode = false;
    public virtual string GetString()
    {
		return null;
    }


	
    public virtual Sprite GetSprite()
    {
		return null;
    }

	public virtual bool IsEndNode(){
		return endNode;
	}
}