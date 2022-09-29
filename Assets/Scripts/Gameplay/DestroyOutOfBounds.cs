using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    #region UnityMethods
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < ScreenUtils.ScreenLeft || 
        gameObject.transform.position.x > ScreenUtils.ScreenRight ||
        gameObject.transform.position.y < ScreenUtils.ScreenBottom ||
        gameObject.transform.position.y > ScreenUtils.ScreenTop)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
