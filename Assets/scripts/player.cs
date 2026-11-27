using UnityEngine;


public class playerController : MonoBehaviour
{
    public int vidaPlayer = 100;
    public float Velocidade = 10.0f;
    public float jumpForce = 10;
    public float queda = 2.5f;        
    public bool chao;
    public float dash = 10;
    private Rigidbody rb;


    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //  ZERA a direção no início de cada frame , porque se não tiver o boneco sai voando loucamente
        Vector3 direcao = Vector3.zero;


        float velocidadeAtual = Velocidade ;


        // Sprint
        if (Input.GetKey("left shift"))
        {
            velocidadeAtual = Velocidade * 2.0f ;
        }


        // Andar pra frente
        if (Input.GetKey("w"))
        {
            direcao += Vector3.forward;
        }
        //Andar pra esquerda
        if (Input.GetKey("a"))
        {
            direcao += Vector3.left;
        }


        //Andar pra trás
        if (Input.GetKey("s"))
        {
            direcao += Vector3.back;
        }


        //Andar pra direita
        if (Input.GetKey("d"))
        {
            direcao += Vector3.right;
        }


        // Dá um direção ao personagem
        if (direcao != Vector3.zero)
        {
            transform.Translate(direcao.normalized * velocidadeAtual * Time.deltaTime);
        }


        // Pulo
        if (Input.GetKeyDown("space") && chao)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            chao = false;
        }


        // Dash
        if (Input.GetKey("q"))
        {
            transform.Translate(direcao.normalized * dash * Time.deltaTime);
        }


    }


    // Faz a queda ser mais rápida
    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (queda - 1f), ForceMode.Acceleration);
    }


    // evita contar parede como chão
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                chao = true;
                return;
            }
        }
    }


    void OnCollisionExit(Collision collision)
    {
        chao = false;
    }
}
