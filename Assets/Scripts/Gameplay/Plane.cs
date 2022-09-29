using UnityEngine;
using UnityEngine.Events;

public class Plane : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject explosionPrefab;

    PlanePositionTrackerEvent planePositionTrackerEvent = new PlanePositionTrackerEvent();
    GetTargetVelocityEvent getTargetVelocityEvent = new GetTargetVelocityEvent();

    const float VelocityLowerBorder = 0.1f;
    const float VelocityUpperBorder = 0.4f;
    const float ConvertConstant = 0.001f;

    float velocity = 0;
    float timer1 = 0;
    float timer2 = 0;
    float[] signArr = {-1, 1};
    float direction = 0;

    bool canSetDirection = true;
    bool setCurveTrajectory = false;
    bool linear = true;

    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddPlanePositionInvoker(this);
        EventManager.AddGetTargetVelocityInvoker(this);
        EventManager.AddSetNewTargetVelocityListener(ChangeVelocity);
        Initializing();
    }

    // Update is called once per frame
    void Update()
    {
        planePositionTrackerEvent.Invoke(gameObject.transform.position.x, 
                                            gameObject.transform.position.y);
        getTargetVelocityEvent.Invoke(gameObject.GetComponent<Rigidbody>().velocity.x,
                                        gameObject.GetComponent<Rigidbody>().velocity.y);
        
        // Setting Y direction of a curve trajectory
        if(!linear)
        {
            timer1 += Time.deltaTime;
        }

        if(timer1 > 0.5f)
        {
            timer1 = 0;
            setCurveTrajectory = true;
            direction *= -1;
        }

        if(timer2 > 1f)
        {
            setCurveTrajectory = false;
            timer2 = 0;
        }

        if(setCurveTrajectory)
        {
            timer2 += Time.deltaTime;
            CurveTrajectory(direction);
        }

        ShowVelocity();
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    private void FixedUpdate()
    {
        // Moving target object
        if(canSetDirection)
        {
            ChangeVelocity(0);
            canSetDirection = !canSetDirection;
            Vector3 movementVector = new Vector3(1, 0, -1);
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(movementVector*velocity, ForceMode.Impulse);
        }
    }

    // Destroying target object when colliding with cannon ball object
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("CannonBall"))
        {
            TargetDestroying();
            Destroy(collision.gameObject);
        }
    }

    // Destroying target object that is triggered by cannon object
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Cannon"))
        {
            TargetDestroying();
        }
    }
    #endregion

    #region Private methods
    float GetRandomVelocity()
    {
        float newVelocity = Mathf.Round(Random.Range(VelocityLowerBorder, VelocityUpperBorder) / -ConvertConstant);
        return newVelocity;
    }

    void ChangeVelocity(float velocity)
    {
        Vector3 newVelocity = new Vector3(velocity/ConvertConstant, 0, 0);
        gameObject.GetComponent<Rigidbody>().velocity = newVelocity;
    }

    void GetRandomHeight()
    {
        Vector3 newPosition = gameObject.transform.position;
        newPosition.y = Random.Range(400, 700);
        gameObject.transform.position = newPosition;
    }

    // Setting rotation to create not linear trajectory
    void CurveTrajectory(float sign)
    { 
        canSetDirection = true;
        transform.Rotate(Vector3.right * sign * velocity/1.25f * Time.deltaTime);
    }

    // Initializing target object with random trajectory
    void Initializing()
    {
        GetRandomHeight();
        velocity = GetRandomVelocity(); 
        linear = (Random.value > 0.5f);
        if(linear)
        {
            canSetDirection = true;
        }
        else
        {
            canSetDirection = true;
            setCurveTrajectory = true;
            direction = signArr[Random.Range(0, 2)];
        }
    }

    // Destroying gameObject with effects
    void TargetDestroying()
    {
        AudioManager.Play(AudioClipName.Explosion);
        Instantiate(explosionPrefab, gameObject.transform.position,
                        gameObject.transform.rotation);

        Destroy(gameObject);
    }

    // Displaying target object speed at the console log
    void ShowVelocity()
    {
        Debug.Log("Plane speed(km/s): " + 
                    gameObject.GetComponent<Rigidbody>().velocity.magnitude *
                    ConvertConstant);   
    }
    #endregion

    #region Event methods
    public void AddPlanePositionListener(UnityAction<float, float> listener)
    {
        planePositionTrackerEvent.AddListener(listener);
    }

    public void AddGetTargetVelocityListener(UnityAction<float, float> listener)
    {
        getTargetVelocityEvent.AddListener(listener);
    }    
    #endregion
}