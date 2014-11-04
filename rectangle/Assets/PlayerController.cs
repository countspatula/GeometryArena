using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour
{
    CustomGeometry geom;
    public int player = 0;

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    // Use this for initialization
    void Start()
    {
        geom = GetComponent<CustomGeometry>();
        collider.bounds.Expand(new Vector3(0, 0, 0.5f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = player; i < player + 1; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
                else
                {
                    Debug.Log("GamePad " + player + " is not connected");
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);

        //if (Input.GetAxis("RightTrigger" + player) < -0.001f)
        //{
        //    geom.shoot();
        //}

        if (state.Triggers.Right > 0.5)
        {
            geom.shoot();
        }

        transform.position += new Vector3(state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y) / 10.0f;

        //this.transform.position += new Vector3(Input.GetAxis("LeftStick" + player + "X"), -Input.GetAxis("LeftStick" + player + "Y")) / 20.0f;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(state.ThumbSticks.Right.Y, state.ThumbSticks.Right.X) * Mathf.Rad2Deg));

        //this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(Input.GetAxis("RightStick" + player + "Y"), -Input.GetAxis("RightStick" + player + "X")) * Mathf.Rad2Deg));
        // shoot();
        // GenerateMesh(NumVerts);
    }
}
