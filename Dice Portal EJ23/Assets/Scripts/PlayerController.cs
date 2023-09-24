using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace BossGame.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public int velocidade;

        public bool movendo, noAr, olhandoDireita,naParede;

        
        
        private float h; //input horizontal
        private SpriteRenderer renderer;
        private Rigidbody2D rb;

        private BoxCollider2D playerCollider;
       
        
       
        private void Start()
        {
            
            Transform child = transform.GetChild(0);
            child.TryGetComponent(out renderer);
        
            //pegando ref para o rigidbody2d e collider
            TryGetComponent(out rb);
            TryGetComponent(out playerCollider);
        }
 

        private void Update()
        {
            h = Input.GetAxis("Horizontal");
            movendo = h != 0; //se o input é diferente de zero, tá se movendo
            if (h > 0) //olhando pra direita
            {
                olhandoDireita = true;
                renderer.flipX = false;
                //a sprite que to usando ja olha pra direita
                //só precisa espelhar (flipar) se for olhar pra esquerda
            }
            if (h < 0)//olhando pra esquerda
            {
                olhandoDireita = false;
                renderer.flipX = true;
            }
            
            //movendo boneco
            Movendo();
            
         }

        void Movendo()
        {
            if (h != 0 && !naParede)
            {
                transform.position += new Vector3(h,0,0) * (velocidade * Time.deltaTime);
                movendo = true;
            }
            else
            {
                movendo = false;
            }
        }
       
        //metodos usados pra desenhar linhas na tela,
        //visivel se clicar no botao gizmo da aba de game

    }
}
