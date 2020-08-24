using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyInvisible : MonoBehaviour {

    PointsChanged pointsChanged;

    public void Start()
    {
        pointsChanged = new PointsChanged();
        //EventManager.AddPointsChangedInvoker(this);
    }

    public void AddPointsChangedListener(UnityAction<int> listener)
    {
        pointsChanged.AddListener(listener);
    }

	// Destroy objects outside of the screen
	void OnBecameInvisible()
    {
        Destroy(gameObject);
        pointsChanged.Invoke(-1);
    }
}
