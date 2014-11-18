using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

	// Use this for initialization
	void Start () {
        var tempPlayerState = AppState.Instance.g_players;
        if (tempPlayerState.p1Active)
        {
            Player1.SetActive(true);
            Player1.GetComponent<Player1Controller>().scoreText.SetActive(true);
        }
        else
        {
            Player1.SetActive(false);
            Player1.GetComponent<Player1Controller>().scoreText.SetActive(false);
        }

        if (tempPlayerState.p2Active)
        {
            Player2.SetActive(true);
            Player2.GetComponent<Player1Controller>().scoreText.SetActive(true);
        }
        else
        {
            Player2.SetActive(false);
            Player2.GetComponent<Player1Controller>().scoreText.SetActive(false);
        }

        if (tempPlayerState.p3Active)
        {
            Player3.SetActive(true);
            Player3.GetComponent<Player1Controller>().scoreText.SetActive(true);
        }
        else
        {
            Player3.SetActive(false);
            Player3.GetComponent<Player1Controller>().scoreText.SetActive(false);
        }

        if (tempPlayerState.p4Active)
        {
            Player4.SetActive(true);
            Player4.GetComponent<Player1Controller>().scoreText.SetActive(true);
        }
        else
        {
            Player4.SetActive(false);
            Player4.GetComponent<Player1Controller>().scoreText.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
