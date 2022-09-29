using UnityEngine;

public class Explosion : MonoBehaviour
{
    #region Fields
    [SerializeField]    
    ParticleSystem explosionParticle;
    float timer = 0;
    const float destroyTime = 2f;
    #endregion
    
    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        explosionParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > destroyTime)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
