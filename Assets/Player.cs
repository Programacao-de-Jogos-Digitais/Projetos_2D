using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Controla a velodicadade da bola
    public float Speed;

    //Controla a força do pulo
    public float JumpForce;

    //Controla a fisíca do objeto
    private Rigidbody2D rig;

    //Verifica se esta pulando
    private bool isJumping;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //controla a velocidade do Player
        rig.velocity = new Vector2(Speed, rig.velocity.y);

        //Se clicar no mouse e isJumping for falso
        //Só pula uma vez
        if(Input.GetMouseButtonDown(0) && !isJumping) {
            //Debug.Log("Botão esquerdo do mouse foi pressionado");
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            
            //liberado para pular
            isJumping = true;
            //Debug.Log("isJumping = "+isJumping);
        }

    }
    
    //Checar se o player esta colidindo com o chão
    void OnCollisionEnter2D(Collision2D collision){
        //Se o personagem bater em algum objeto com a layer 8
        if(collision.gameObject.layer == 8){
            //Muda a variável para falso, 
            //pois quando bate no chão não esta pulando
            isJumping = false;
            //Exibe no console qual camada a Plataforma está
            //Debug.Log("Objeto da Camada: "+collision.gameObject.layer);
            
            //Qual nome do objeto da colisão
            //Debug.Log("O objeto colidiu com " + collision.gameObject.name);
        }
    }
}
