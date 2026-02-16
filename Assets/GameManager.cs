using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int PlayerScore2 = 0; // Pontuação do player 2
    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola

    public static void Score (string wallID) {
        GameManager gm = FindAnyObjectByType<GameManager>();
        if (wallID == "top"){
            PlayerScore1++;
            if(PlayerScore1 != 5){
                gm.theBall.SendMessage("BallP2", null, SendMessageOptions.RequireReceiver);
            }
        } else{
            PlayerScore2++;
            if(PlayerScore2 != 5){
                gm.theBall.SendMessage("BallP1", null, SendMessageOptions.RequireReceiver);
            }
        }
    }

    void Restart(string msg){
        theBall.SendMessage("BallSome", null, SendMessageOptions.RequireReceiver);
        GUI.Label(new Rect(Screen.width / 2 - 230, 200, 2000, 1000), msg);
        if (GUI.Button(new Rect(Screen.width / 2 - 100,  Screen.height/2 - 20 , 200, 200), "Play Again"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
        if (GUI.Button(new Rect(Screen.width / 2 - 60,  Screen.height - 20 - 100 , 120, 100), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 5)
        {
            Restart("PLAYER ONE WINS");
        } else if (PlayerScore2 == 5)
        {
            Restart("PLAYER TWO WINS");
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("ball"); // Busca a referência da bola
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
