using UnityEngine;
using UnityEngine.Events;

public class Cannon : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject cannonBall;

    CannonPositionTrackerEvent cannonPositionTrackerEvent = new CannonPositionTrackerEvent();

    float fireShootAngle = 0.1f;
    float burstNumber = 1;
    float burstCount = 1;
    float burstTimer = 2.1f;
    float burstTime = 0.1f;

    bool canShoot = false;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddCannonPositionInvoker(this);
        EventManager.AddFireShootingAngleListener(GetFireShootAngle);
        EventManager.AddSetBurstNumberListener(SetBurstNumber);
        EventManager.AddSetBurstTimeListener(SetBurstTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeRotation();
    }

    void Update()
    {
        // Cannon position transferring
        cannonPositionTrackerEvent.Invoke(gameObject.transform.position.x,
                                            gameObject.transform.position.y);

        // Setting number of cannonBalls to be shot
        if(Input.GetKeyDown(KeyCode.Space))
        {
            burstCount = burstNumber;
            canShoot = true;
        }

        if(canShoot)
        {
            FireShoot();
        }
    }
    #endregion

    #region Private methods
    // Rotating cannon
    void ChangeRotation()
    {
        // Rotate the cannon by converting the angles into a quaternion.
        if(!float.IsNaN(fireShootAngle))
        {    
            Quaternion target = Quaternion.Euler(0f, 180f, fireShootAngle);
            transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, target,  Time.deltaTime * 50);
        }
    }

    // Shooting preset amount of cannon balls
    void FireShoot()
    {
        if(burstCount > 0)
        {
            if(burstTimer > burstTime)
            {
                AudioManager.Play(AudioClipName.FireShooting);
                Instantiate(cannonBall, gameObject.transform.position, gameObject.transform.rotation);
                burstTimer = 0;
                burstCount--;
            }
            burstTimer += Time.deltaTime;
        }
        else
        {
            burstTimer = burstTime + 0.1f;
            burstCount = burstNumber;
            canShoot = false;
        }
    }
    
    void GetFireShootAngle(float angle)
    {
        fireShootAngle = angle;
    }


    void SetBurstNumber(float number)
    {
        burstNumber = number;
    }

    void SetBurstTime(float time)
    {
        burstTime = time;
    }
    #endregion

    #region Event methods
    public void AddCannonPositionListener(UnityAction<float, float> listener)
    {
        cannonPositionTrackerEvent.AddListener(listener);
    }
    #endregion
}
