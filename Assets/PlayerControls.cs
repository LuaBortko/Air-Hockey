using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 7.0f;             // Define a velocidade da raquete
    public float boundY = 0f;            // Define os limites em Y
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
        
        Vector3 dir = mousePos - playerPos;
        dir.Normalize();
        Vector2 forceVec = dir * speed;
        float forceX = forceVec.x;
        float forceY = forceVec.y;

        var vel = rb2d.linearVelocity;
        vel.x = forceX;
        vel.y = forceY;
        rb2d.linearVelocity = vel; 

    }
}
