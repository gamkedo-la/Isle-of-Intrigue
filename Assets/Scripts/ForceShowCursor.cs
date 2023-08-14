using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceShowCursor : MonoBehaviour
{
    public bool forceShow = false;

    void Update()
    {
    	if(Cursor.visible != forceShow) {
    		Cursor.visible = forceShow;
    	}        
    }
}
