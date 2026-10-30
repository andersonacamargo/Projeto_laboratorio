using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int vidaEnemy;
    public float VelocidadeEnemy = 2.0f;
    public Transform target;
    public bool playerDetected = false;
    public int enemyDamage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(-3.61f, 1.11f, -2.64f);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected == true)
        {
            float step = VelocidadeEnemy * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }
}