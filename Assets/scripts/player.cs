using UnityEngine;


public class playerController : MonoBehaviour
{
    public int vidaPlayer = 150;
    public float Velocidade = 10.0f;
    public float jumpForce;
    public bool chao;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Velocidade * Time.deltaTime);
        }


        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Velocidade * Time.deltaTime);
        }


        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Velocidade * Time.deltaTime);
        }


        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Velocidade * Time.deltaTime);
        }


        if (Input.GetKeyDown("space") && chao == true)
        {
            transform.Translate(new Vector3( 0, 3,0) * jumpForce * Time.deltaTime);
            chao = false;
        }

        if (Input.GetMouseButton(0))
        {
            // mouse esquerdo pra ataque 
        }


    }


     void OnCollisionEnter(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (!collision.gameObject.CompareTag("playerTag"))
                {
                    chao = true;
                }
            }
        }


}

