using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    //Controla a fisíca do objeto
    private Rigidbody2D rig;

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
        }

        //Checar se o player esta colidindo com o chão
        void OnCollisionEnter2D(Collision2D colisor){
            //Se o personagem bater em algum objeto com a layer 8
            if(colisor.gameObject.layer == 8){
                //Muda a variável para falso, 
                //pois quando bate no chão não esta pulando
                isJumping = false;
            }
        }
    }
}
