using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisible : MonoBehaviour
{
	bool hideCursor = true;

	public void StopHidingCursor() {
		hideCursor = false;
	}

    void Update()
    {
        Cursor.visible = hideCursor;
    }
}
