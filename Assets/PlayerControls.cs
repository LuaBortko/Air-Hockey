using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10.0f;             // Define a velocidade da raquete
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(playerPos, mousePos);

        if(distance > 0.1f){
            Vector2 dir = mousePos - playerPos;
            dir.Normalize();
            Vector2 forceVec = dir * speed;
            float forceX = forceVec.x;
            float forceY = forceVec.y;

            var vel = rb2d.linearVelocity;
            vel.x = forceX;
            vel.y = forceY;

            rb2d.linearVelocity = vel; 

        }else{

            rb2d.linearVelocity = Vector2.zero;

        }

        // Controle para o player não passar das bordas

        if (playerPos.y > 4.45f) {                  
            playerPos.y = 4.45f;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (playerPos.y < 0.5f) {
            playerPos.y = 0.5f;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
        }else if (playerPos.x > 2.8f) {                  
            playerPos.x = 2.8f;                     // Corrige a posicao da raquete caso ele ultrapasse o limite da direita
        }
        else if (playerPos.x < -2.8f) {
            playerPos.x = -2.8f;                    // Corrige a posicao da raquete caso ele ultrapasse o limite da esquerda
        }
        transform.position = playerPos;               // Atualiza a posição da raquete

    }
}
