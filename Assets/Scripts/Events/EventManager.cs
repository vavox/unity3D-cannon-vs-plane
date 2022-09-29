using System.Collections.Generic;
using UnityEngine.Events;

public static class EventManager
{
    #region Fields
    static List<Plane> planePositionInvokers = new List<Plane>();
    static List<UnityAction<float, float>> planePositionListeners = new List<UnityAction<float, float>>();

    static List<Cannon> cannonPositionInvokers = new List<Cannon>();
    static List<UnityAction<float, float>> cannonPositionListeners = new List<UnityAction<float, float>>();

    static List<PlaneTracker> fireShootingAngleInvokers = new List<PlaneTracker>();
    static List<UnityAction<float>> fireShootingAngleListeners = new List<UnityAction<float>>();
    
    static List<Plane> getTargetVelocityInvokers = new List<Plane>();
    static List<UnityAction<float, float>> getTargetVelocityListeners = new List<UnityAction<float, float>>();

    static List<GameplayManager> getCannonBallVelocityInvokers = new List<GameplayManager>();
    static List<UnityAction<float>> getCannonBallVelocityListeners = new List<UnityAction<float>>();
    
    static List<HUDManager> setTargetVelocityInvokers = new List<HUDManager>();
    static List<UnityAction<float>> setTargetVelocityListeners = new List<UnityAction<float>>();

    static List<GameplayManager> setNewTargetVelocityInvokers = new List<GameplayManager>();
    static List<UnityAction<float>> setNewTargetVelocityListeners = new List<UnityAction<float>>();
    
    static List<HUDManager> setCannonBallVelocityInvokers = new List<HUDManager>();
    static List<UnityAction<float>> setCannonBallVelocityListeners = new List<UnityAction<float>>();
    
    static List<HUDManager> setBurstNumberInvokers = new List<HUDManager>();
    static List<UnityAction<float>> setBurstNumberListeners = new List<UnityAction<float>>();
    
    static List<HUDManager> setBurstTimeInvokers = new List<HUDManager>();
    static List<UnityAction<float>> setBurstTimeListeners = new List<UnityAction<float>>();
    #endregion

    #region PlanePositionTrackerEvent
    public static void AddPlanePositionInvoker(Plane invoker)
    {
        planePositionInvokers.Add(invoker);
        foreach(UnityAction<float, float> listener in planePositionListeners)
        {
            invoker.AddPlanePositionListener(listener);
        }    
    }

    public static void AddPlanePositionListener(UnityAction<float, float> listener)
    {
        planePositionListeners.Add(listener);
        foreach(Plane invoker in planePositionInvokers)
        {
            invoker.AddPlanePositionListener(listener);
        }
    }

    public static void RemovePlanePositionInvoker(Plane invoker)
    {
        // remove invoker from list
        planePositionInvokers.Remove(invoker);
    }
    #endregion

    #region CannonPositionTrackerEvent
    public static void AddCannonPositionInvoker(Cannon invoker)
    {
        cannonPositionInvokers.Add(invoker);
        foreach(UnityAction<float, float> listener in cannonPositionListeners)
        {
            invoker.AddCannonPositionListener(listener);
        }    
    }

    public static void AddCannonPositionListener(UnityAction<float, float> listener)
    {
        cannonPositionListeners.Add(listener);
        foreach(Cannon invoker in cannonPositionInvokers)
        {
            invoker.AddCannonPositionListener(listener);
        }
    }

    public static void RemoveCannonPositionInvoker(Cannon invoker)
    {
        // remove invoker from list
        cannonPositionInvokers.Remove(invoker);
    }
    #endregion

    #region SetFireShootAngleEvent
    public static void AddFireShootingAngleInvoker(PlaneTracker invoker)
    {
        fireShootingAngleInvokers.Add(invoker);
        foreach(UnityAction<float> listener in fireShootingAngleListeners)
        {
            invoker.AddFireShootingAngleListener(listener);
        }    
    }

    public static void AddFireShootingAngleListener(UnityAction<float> listener)
    {
        fireShootingAngleListeners.Add(listener);
        foreach(PlaneTracker invoker in fireShootingAngleInvokers)
        {
            invoker.AddFireShootingAngleListener(listener);
        }
    }

    public static void RemoveFireShootingAngleInvoker(PlaneTracker invoker)
    {
        // remove invoker from list
        fireShootingAngleInvokers.Remove(invoker);
    }
    #endregion

    #region GetTargetVelocityEvent
    public static void AddGetTargetVelocityInvoker(Plane invoker)
    {
        getTargetVelocityInvokers.Add(invoker);
        foreach(UnityAction<float, float> listener in getTargetVelocityListeners)
        {
            invoker.AddGetTargetVelocityListener(listener);
        }    
    }

    public static void AddGetTargetVelocityListener(UnityAction<float, float> listener)
    {
        getTargetVelocityListeners.Add(listener);
        foreach(Plane invoker in getTargetVelocityInvokers)
        {
            invoker.AddGetTargetVelocityListener(listener);
        }
    }

    public static void RemoveGetTargetVelocityInvoker(Plane invoker)
    {
        // remove invoker from list
        getTargetVelocityInvokers.Remove(invoker);
    }
    #endregion

    #region GetCannonBallVelocityEvent
    public static void AddGetCannonBallVelocityInvoker(GameplayManager invoker)
    {
        getCannonBallVelocityInvokers.Add(invoker);
        foreach(UnityAction<float> listener in getCannonBallVelocityListeners)
        {
            invoker.AddGetCannonBallVelocityListener(listener);
        }    
    }

    public static void AddGetCannonBallVelocityListener(UnityAction<float> listener)
    {
        getCannonBallVelocityListeners.Add(listener);
        foreach(GameplayManager invoker in getCannonBallVelocityInvokers)
        {
            invoker.AddGetCannonBallVelocityListener(listener);
        }
    }

    public static void RemoveGetCannonBallVelocityInvoker(GameplayManager invoker)
    {
        // remove invoker from list
        getCannonBallVelocityInvokers.Remove(invoker);
    }
    #endregion
    
    #region SetTargetVelocityEvent
    public static void AddSetTargetVelocityInvoker(HUDManager invoker)
    {
        setTargetVelocityInvokers.Add(invoker);
        foreach(UnityAction<float> listener in setTargetVelocityListeners)
        {
            invoker.AddSetTargetVelocityListener(listener);
        }    
    }

    public static void AddSetTargetVelocityListener(UnityAction<float> listener)
    {
        setTargetVelocityListeners.Add(listener);
        foreach(HUDManager invoker in setTargetVelocityInvokers)
        {
            invoker.AddSetTargetVelocityListener(listener);
        }
    }

    public static void RemoveSetTargetVelocityInvoker(HUDManager invoker)
    {
        // remove invoker from list
        setTargetVelocityInvokers.Remove(invoker);
    }
    #endregion

    #region SetNewTargetVelocityEvent
    public static void AddSetNewTargetVelocityInvoker(GameplayManager invoker)
    {
        setNewTargetVelocityInvokers.Add(invoker);
        foreach(UnityAction<float> listener in setNewTargetVelocityListeners)
        {
            invoker.AddSetNewTargetVelocityListener(listener);
        }    
    }

    public static void AddSetNewTargetVelocityListener(UnityAction<float> listener)
    {
        setNewTargetVelocityListeners.Add(listener);
        foreach(GameplayManager invoker in setNewTargetVelocityInvokers)
        {
            invoker.AddSetNewTargetVelocityListener(listener);
        }
    }

    public static void RemoveSetNewTargetVelocityInvoker(GameplayManager invoker)
    {
        // remove invoker from list
        setNewTargetVelocityInvokers.Remove(invoker);
    }
    #endregion

    #region SetCannonBallVelocityEvent
    public static void AddSetCannonBallVelocityInvoker(HUDManager invoker)
    {
        setCannonBallVelocityInvokers.Add(invoker);
        foreach(UnityAction<float> listener in setCannonBallVelocityListeners)
        {
            invoker.AddSetCannonBallVelocityListener(listener);
        }    
    }

    public static void AddSetCannonBallVelocityListener(UnityAction<float> listener)
    {
        setCannonBallVelocityListeners.Add(listener);
        foreach(HUDManager invoker in setCannonBallVelocityInvokers)
        {
            invoker.AddSetCannonBallVelocityListener(listener);
        }
    }

    public static void RemoveSetCannonBallVelocityInvoker(HUDManager invoker)
    {
        // remove invoker from list
        setCannonBallVelocityInvokers.Remove(invoker);
    }
    #endregion

    #region SetBurstNumberEvent
    public static void AddSetBurstNumberInvoker(HUDManager invoker)
    {
        setBurstNumberInvokers.Add(invoker);
        foreach(UnityAction<float> listener in setBurstNumberListeners)
        {
            invoker.AddSetBurstNumberListener(listener);
        }    
    }

    public static void AddSetBurstNumberListener(UnityAction<float> listener)
    {
        setBurstNumberListeners.Add(listener);
        foreach(HUDManager invoker in setBurstNumberInvokers)
        {
            invoker.AddSetBurstNumberListener(listener);
        }
    }

    public static void RemoveSetBurstNumberInvoker(HUDManager invoker)
    {
        // remove invoker from list
        setBurstNumberInvokers.Remove(invoker);
    }
    #endregion

    #region SetBurstTimeEvent
    public static void AddSetBurstTimeInvoker(HUDManager invoker)
    {
        setBurstTimeInvokers.Add(invoker);
        foreach(UnityAction<float> listener in setBurstTimeListeners)
        {
            invoker.AddSetBurstTimeListener(listener);
        }    
    }

    public static void AddSetBurstTimeListener(UnityAction<float> listener)
    {
        setBurstTimeListeners.Add(listener);
        foreach(HUDManager invoker in setBurstTimeInvokers)
        {
            invoker.AddSetBurstTimeListener(listener);
        }
    }

    public static void RemoveetBurstTimeInvoker(HUDManager invoker)
    {
        // remove invoker from list
        setBurstTimeInvokers.Remove(invoker);
    }
    #endregion
}
