using UnityEngine;
using UnityEngine.Events;

public class PlaneTracker : MonoBehaviour
{
    #region Fields
    SetFireShootAngleEvent setFireShootAngleEvent = new SetFireShootAngleEvent();

    Vector2 targetPosition;
    Vector2 cannonPosition;
    Vector2 targetVelocity = Vector2.zero;

    float time;
    float angle = 0;
    float distance = 1;
    float cannonBallVelocity = 800;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddFireShootingAngleInvoker(this);
        EventManager.AddPlanePositionListener(GetTargetPosition);
        EventManager.AddCannonPositionListener(GetCannonPosition);
        EventManager.AddGetTargetVelocityListener(GetTargetVelocity);
        EventManager.AddGetCannonBallVelocityListener(GetCannonBallVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        setFireShootAngleEvent.Invoke(GetFireShootAngle());
        SetTrackerPosition();
    }
    #endregion

    #region Private methods
    void GetTargetPosition(float posX, float posY)
    {
        targetPosition = new Vector2(posX, posY);
    }

    void GetCannonPosition(float posX, float posY)
    {
        cannonPosition = new Vector2(posX, posY);
    }

    // Setting tracker position based on cannon ball hit time and target velocity
    void SetTrackerPosition()
    {
        Vector3 trackerPosition = new Vector3(targetPosition.x + targetVelocity.x * time, 
                                                targetPosition.y + targetVelocity.y * time,
                                                gameObject.transform.position.z);
        gameObject.transform.position = trackerPosition;
    }

    // Calculating angle from cannon object to target tracker
    float GetFireShootAngle()
    {
        distance = Vector2.Distance(cannonPosition, gameObject.transform.position);
        angle = Mathf.Acos(HeightToTarget()/distance) * Mathf.Rad2Deg;
        time = distance/cannonBallVelocity;
        if(gameObject.transform.position.x > 0)
        {
            return angle;
        }
        else
        {
            return -angle;
        }
    }

    // Calculating height from cannon object to tracker object
    float HeightToTarget()
    {
        float cannonAbsoluteY = Mathf.Abs(cannonPosition.y);
        float trackerAbsoluteY = Mathf.Abs(gameObject.transform.position.y);
        return cannonAbsoluteY + trackerAbsoluteY;
    }

    void GetTargetVelocity(float velocityX, float velocityY)
    {
        targetVelocity.x = velocityX;
        targetVelocity.y = velocityY;
    }

    void GetCannonBallVelocity(float velocity)
    {
        cannonBallVelocity = velocity/0.001f;
        Debug.Log("got velocity " + velocity);
    }
    #endregion

    #region Event methods
    public void AddFireShootingAngleListener(UnityAction<float> listener)
    {
        setFireShootAngleEvent.AddListener(listener);
    }
    #endregion
}
