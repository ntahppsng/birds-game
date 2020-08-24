using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	// Transport on the other side of the screen
	void OnBecameInvisible ()
    {
		Vector3 position = transform.position;
		int crossedHorizontalPlanes = ((position.y >= ScreenUtils.ScreenTop) ||
			(position.y <= ScreenUtils.ScreenBottom)) ? -1 : 1;
		int crossedVerticalPlanes = ((position.x >= ScreenUtils.ScreenRight) ||
			(position.x <= ScreenUtils.ScreenLeft)) ? -1 : 1;
		transform.position = new Vector3(crossedVerticalPlanes * position.x, 
			crossedHorizontalPlanes * position.y, position.z);
    }
}
