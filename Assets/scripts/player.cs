using UnityEngine;

public class playerController : MonoBehaviour
{
    public int vidaPlayer = 150;
    public float Velocidade = 10.0f;
    public float jumpForce;
    public bool chao;
    public float dash = 100.0f;

    void Start()
    {
       
    }

    void Update()
    {
        //  ZERA a direção no início de cada frame , porque se não tiver o boneco sai voando loucamente
        Vector3 direcao = Vector3.zero;

        float velocidadeAtual = Velocidade ;

        if (Input.GetKey("left shift"))
        {
            velocidadeAtual = Velocidade * 2.0f ;
        }       

        if (Input.GetKey("w"))
        {
            direcao += Vector3.forward;
        }

        if (Input.GetKey("a"))
        {
            direcao += Vector3.left;
        }

        if (Input.GetKey("s"))
        {
            direcao += Vector3.back;
        }

        if (Input.GetKey("d"))
        {
            direcao += Vector3.right;
        }

        if (direcao != Vector3.zero)
        {
            transform.Translate(direcao.normalized * velocidadeAtual * Time.deltaTime);
        }

        if (Input.GetKey("space") && chao == true)
        {
            transform.Translate(Vector3.up * jumpForce );
            chao = false;
        }

        if (Input.GetKey("q"))
        {
            transform.Translate(direcao.normalized * dash * Time.deltaTime);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // Dica: verifique se a tag no seu jogo está exatamente assim (maiúsculas/minúsculas importam!)
            if (!collision.gameObject.CompareTag("playerTag")) 
            {
                chao = true;
            }
        }
    }
}