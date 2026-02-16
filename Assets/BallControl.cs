using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d; 
    public AudioSource source;
    // Determina o comportamento da bola nas colisões com os Players (raquetes)
    void OnCollisionEnter2D (Collision2D coll) {
        source.Play();
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = (rb2d.linearVelocity.x / 2) + (coll.collider.attachedRigidbody.linearVelocity.x / 3);
            vel.y = rb2d.linearVelocity.y;
            rb2d.linearVelocity = vel;
        }
    }

    void ResetBall(){
        float rand = Random.Range(0, 2);
        if(rand < 1){
            BallP1();
        } else {
            BallP2();
        }

    }

    void BallP2(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = new Vector3(0f, 2f, transform.position.z);
    }

    void BallP1(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = new Vector3(0f, -2f, transform.position.z);
    }

    void BallSome(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = new Vector3(10f, 0f, transform.position.z);
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        //Invoke("GoBall", 1);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        source = GetComponent<AudioSource>();
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
