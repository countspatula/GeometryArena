using UnityEngine;
using System.Collections;

public class ResetGUI : MonoBehaviour {

	// Use this for initialization
    void OnEnable()
    {
        for(int i = 0; i < 4; i++)
        {
            transform.GetChild(i).GetComponent<TextMesh>().text = "X 0";
        }

        transform.GetChild(4).GetComponent<TextMesh>().text = "";
        transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
    }
}
