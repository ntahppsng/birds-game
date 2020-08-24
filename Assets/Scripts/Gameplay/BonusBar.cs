using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BonusBar : MonoBehaviour {

	BonusBarCompleted bonusBarCompleted;

	[SerializeField]
	GameObject[] bonusBarSegments;

	int stage = 0;
	int maxStage = 3;

	// Use this for initialization
	void Start () {

		bonusBarCompleted = new BonusBarCompleted();
		EventManager.AddBonusBarCompletedInvoker(this);

		EventManager.AddBonusBarStageChangedListener(ChangeStage);
		EventManager.AddBonusBarRestartedListener(Restart);
	}
	


	public void AddBonusBarCompletedListener(UnityAction listener)
	{
		bonusBarCompleted.AddListener(listener);
	}

	#region Private methods

	void ChangeStage(int additionalStep)
    {
		int temp = stage + additionalStep;
        if (temp <= maxStage)
        {
			stage = temp;
			bonusBarSegments[temp - 1].SetActive(true);
        }
        else
        {
			this.Complete();
        }
	}
	void Restart()
	{
		stage = 0;
		foreach (var item in bonusBarSegments)
		{
			item.SetActive(false);
		}
	}

	void Complete()
	{
		this.Restart();
		bonusBarCompleted.Invoke();

	}

	#endregion

}
