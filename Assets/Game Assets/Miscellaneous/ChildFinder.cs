using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChildFinder {
	public static Transform FindChildByName(Transform root, string childName){
		//Look through our children and check their children for the name
		foreach(Transform myTransform in root){
			if(myTransform.name == childName)
				return myTransform;

			//Check if there are more children to search
			if(myTransform.childCount > 0){
				return FindChildByName(myTransform, childName);
			}
		}

		//NOthing was left, return nothingness
		return null;
	}
}
