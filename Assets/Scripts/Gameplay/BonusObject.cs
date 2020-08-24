using Assets.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusObject : MonoBehaviour, PointsChanger {

	PointsChanged pointsChanged;
	const int PointsPerBonusObject = 4;

	void Start()
	{
		// scoring support
		pointsChanged = new PointsChanged();
		EventManager.AddPointsChangedInvoker(this);
	}

	public void AddPointsChangedListener(UnityAction<int> listener)
	{
		pointsChanged.AddListener(listener);
	}

	void OnMouseDown()
	{
		Destroy(gameObject);
		pointsChanged.Invoke(PointsPerBonusObject);
	}

}
