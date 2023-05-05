using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "FSM/Actions/Set Position")]
public class SetPosition : ActionBase
{
	public GenericReference<string> targetKey;
	
	public override void Execute(CachedObjectWrapper cachedObjects)
	{
		
	}	
}
