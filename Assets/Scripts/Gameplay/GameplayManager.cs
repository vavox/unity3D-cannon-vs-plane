using UnityEngine;
using UnityEngine.Events;

public class GameplayManager : MonoBehaviour
{
    #region Fields 
    [SerializeField]
    GameObject targetObject;
    [SerializeField]
    GameObject cannon;

    GetCannonBallVelocityEvent getCannonBallVelocityEvent = new GetCannonBallVelocityEvent();
    SetNewTargetVelocityEvent setNewTargetVelocityEvent = new SetNewTargetVelocityEvent();

    float cannonBallVelocity = 0.8f;
    float targetVelocity = 0;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddGetCannonBallVelocityInvoker(this);
        EventManager.AddSetNewTargetVelocityInvoker(this);
        EventManager.AddSetCannonBallVelocityListener(SetCannonBallVelocity);
        EventManager.AddSetTargetVelocityListener(SetTargetVelocity);
        Instantiate(cannon);
    }

    // Update is called once per frame
    void Update()
    {
        getCannonBallVelocityEvent.Invoke(cannonBallVelocity);
        if(targetVelocity != 0)
        { setNewTargetVelocityEvent.Invoke(targetVelocity); }
        TargetSpawner();
    }
    #endregion

    #region Private methods
    void TargetSpawner()
    {
        if(GameObject.FindGameObjectsWithTag("Plane").Length == 0)
        {
            Instantiate(targetObject);
        }
    }

    void SetCannonBallVelocity(float velocity)
    {
        cannonBallVelocity = velocity;
    }

    void SetTargetVelocity(float velocity)
    {
        targetVelocity = -velocity;
    }
    #endregion

    #region Event methods
    public void AddGetCannonBallVelocityListener(UnityAction<float> listener)
    {
        getCannonBallVelocityEvent.AddListener(listener);
    }

    public void AddSetNewTargetVelocityListener(UnityAction<float> listener)
    {
        setNewTargetVelocityEvent.AddListener(listener);
    }
    #endregion
}
