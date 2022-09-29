using UnityEngine;

public class Propellor : MonoBehaviour
{   
    #region Fields
    const float PropellorRotationVelocity = 1000f; 
    #endregion

    #region Unity methods
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.forward, PropellorRotationVelocity * Time.deltaTime);   
    }
    #endregion
}
