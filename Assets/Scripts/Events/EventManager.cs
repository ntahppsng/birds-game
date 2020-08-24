using Assets.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event manager
/// </summary>
public static class EventManager
{
    // PointsChanged support
    static List<PointsChanger> pointsChangedInvokers = new List<PointsChanger>();
    static List<UnityAction<int>> pointsChangedListeners = 
        new List<UnityAction<int>>();

    // BonusBarRestarted support
    static List<Background> bonusBarRestartedInvokers = new List<Background>();
    static List<UnityAction> bonusBarRestartedListeners = 
        new List<UnityAction>();

    // BonusBarStageChanged support
    static List<MonoBehaviour> bonusBarStageChangedInvokers = new List<MonoBehaviour>();
    static List<UnityAction<int>> bonusBarStageChangedListeners =
        new List<UnityAction<int>>();

    // BonusBarCompleted support
    static List<MonoBehaviour> bonusBarCompletedInvokers = new List<MonoBehaviour>();
    static List<UnityAction> bonusBarCompletedListeners =
        new List<UnityAction>();

    // GameEnded support
    static List<MonoBehaviour> gameEndedInvokers = new List<MonoBehaviour>();
    static List<UnityAction<int,int>> gameEndedListeners =
        new List<UnityAction<int,int>>();

    #region Public methods

    /// <summary>
    /// Adds the given script as a points added invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddPointsChangedInvoker(PointsChanger invoker)
    {
        // add invoker to list and add all listeners to invoker
        pointsChangedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsChangedListeners)
        {
            invoker.AddPointsChangedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a points added listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddPointsChangedListener(UnityAction<int> listener)
    {
        // add listener to list and to all invokers
        pointsChangedListeners.Add(listener);
        foreach (PointsChanger invoker in pointsChangedInvokers)
        {
            invoker.AddPointsChangedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBonusBarRestartedInvoker(Background invoker)
    {
        // add invoker to list and add all listeners to invoker
        bonusBarRestartedInvokers.Add(invoker);
        foreach (UnityAction listener in bonusBarRestartedListeners)
        {
            invoker.AddBonusBarRestartedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBonusBarRestartedListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        bonusBarRestartedListeners.Add(listener);
        foreach (Background invoker in bonusBarRestartedInvokers)
        {
            invoker.AddBonusBarRestartedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBonusBarStageChangedInvoker(NPEntity invoker)
    {
        // add invoker to list and add all listeners to invoker
        bonusBarStageChangedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in bonusBarStageChangedListeners)
        {
            invoker.AddBonusBarStageChangedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBonusBarStageChangedListener(UnityAction<int> listener)
    {
        // add listener to list and to all invokers
        bonusBarStageChangedListeners.Add(listener);
        foreach (NPEntity invoker in bonusBarStageChangedInvokers)
        {
            invoker.AddBonusBarStageChangedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBonusBarCompletedInvoker(BonusBar invoker)
    {
        // add invoker to list and add all listeners to invoker
        bonusBarCompletedInvokers.Add(invoker);
        foreach (UnityAction listener in bonusBarCompletedListeners)
        {
            invoker.AddBonusBarCompletedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBonusBarCompletedListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        bonusBarCompletedListeners.Add(listener);
        foreach (BonusBar invoker in bonusBarCompletedInvokers)
        {
            invoker.AddBonusBarCompletedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a ball lost invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddGameEndedInvoker(HUD invoker)
    {
        // add invoker to list and add all listeners to invoker
        gameEndedInvokers.Add(invoker);
        foreach (UnityAction<int,int> listener in gameEndedListeners)
        {
            invoker.AddGameEndedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a ball lost listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddGameEndedListener(UnityAction<int,int> listener)
    {
        // add listener to list and to all invokers
        gameEndedListeners.Add(listener);
        foreach (HUD invoker in gameEndedInvokers)
        {
            invoker.AddGameEndedListener(listener);
        }
    }


    #endregion
}
