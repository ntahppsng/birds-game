using Assets.Scripts.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPEntity : MonoBehaviour, PointsChanger
{
    #region Fields

    //Direction of the flight. Set to -1 for left and to 1 for right.
    [SerializeField]
	protected int flyDirection;

	//Death animation
	[SerializeField]
	protected GameObject deathAnimation;

	//Scoring control
	protected PointsChanged pointsChanged;
	protected const int PointsPerNPEntity = 1;

	//Bonus streak control
	protected BonusBarStageChanged bonusBarStageChanged;
	protected const int StagesPerNPEntity = 1;
	#endregion

	protected void Start()
	{
		// Scoring support
		pointsChanged = new PointsChanged();
		EventManager.AddPointsChangedInvoker(this);

		//Bonus streak support
		bonusBarStageChanged = new BonusBarStageChanged();
		EventManager.AddBonusBarStageChangedInvoker(this);

		// Apply impulse force to get bird moving
		const float MinImpulseForce = 2f;
		const float MaxImpulseForce = 4f;
		//float angle = Random.Range(0, 2 * Mathf.PI);
		Vector2 direction = new Vector2(flyDirection, 0);
		float magnitude = UnityEngine.Random.Range(MinImpulseForce, MaxImpulseForce);
		GetComponent<Rigidbody2D>().AddForce(
			direction * magnitude,
			ForceMode2D.Impulse);
	}

	// Update is called once per frame
	protected void Update()
	{
		Vector3 position = transform.position;
		bool outOfBounds = position.x >= ScreenUtils.ScreenRight ||
			position.x <= ScreenUtils.ScreenLeft ||
			position.y >= ScreenUtils.ScreenTop ||
			position.y <= ScreenUtils.ScreenBottom;
        if (outOfBounds)
        {
			DestroyOutOfScreen();
        }
	}

	public void AddPointsChangedListener(UnityAction<int> listener)
	{
		pointsChanged.AddListener(listener);
	}
	public void AddBonusBarStageChangedListener(UnityAction<int> listener)
	{
		bonusBarStageChanged.AddListener(listener);
	}

    #region Protected methods

    protected virtual void OnMouseDown()
    {
		Instantiate(deathAnimation, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
		pointsChanged.Invoke(PointsPerNPEntity);
		bonusBarStageChanged.Invoke(StagesPerNPEntity);
	}

	// Destroy objects outside of the screen
	protected virtual void DestroyOutOfScreen()
	{
		Destroy(gameObject);
		pointsChanged.Invoke(-PointsPerNPEntity);
	}
	#endregion

}
