using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vidaPlayer = 5;


    public void Damage(int enemyDamage)
    {
        vidaPlayer -= enemyDamage;

        if(vidaPlayer <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
