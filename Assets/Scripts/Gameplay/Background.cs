using Assets.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Background : MonoBehaviour, PointsChanger {

    #region Fields

    //Scoring control
    PointsChanged pointsChanged;
	const int PointsPerMissClick = -1;

	//Bonus streak control
	BonusBarRestarted bonusBarRestarted;
	#endregion

	// Use this for initialization
	void Start () {
		// Scoring support
		pointsChanged = new PointsChanged();
		EventManager.AddPointsChangedInvoker(this);

		//Bonus streak support
		bonusBarRestarted = new BonusBarRestarted();
		EventManager.AddBonusBarRestartedInvoker(this);
	}

	void OnMouseDown()
	{
		pointsChanged.Invoke(PointsPerMissClick);
		bonusBarRestarted.Invoke();
	}

	public void AddPointsChangedListener(UnityAction<int> listener)
	{
		pointsChanged.AddListener(listener);
	}
	public void AddBonusBarRestartedListener(UnityAction listener)
	{
		bonusBarRestarted.AddListener(listener);
	}
}
