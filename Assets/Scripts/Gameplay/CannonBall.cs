using UnityEngine;

public class CannonBall : MonoBehaviour
{
    #region Fields
    float velocity = 0.8f;
    const float ConvertConstant = 0.001f;

    bool canShoot = true;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddGetCannonBallVelocityListener(ChangeVelocity);
    }   

    void Update()
    {
        // Moving cannon ball object
        if(canShoot)
        {
            canShoot = !canShoot;
            gameObject.GetComponent<Rigidbody>().AddForce(velocity/ConvertConstant * transform.up, ForceMode.Impulse);
            ShowVelocity();
        }
    }
    #endregion

    #region Private methods
    // Displaying cannon ball object speed in console log
    void ShowVelocity()
    {
        float currentSpeed = gameObject.GetComponent<Rigidbody>().velocity.magnitude * ConvertConstant;
        Debug.Log("Ball speed(km/s): " + currentSpeed);   
    }

    void ChangeVelocity(float newVelocity)
    {
        velocity = newVelocity;
    }
    #endregion
}