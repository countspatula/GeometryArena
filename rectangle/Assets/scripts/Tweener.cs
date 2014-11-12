using UnityEngine;
using System.Collections;

public class Tweener : MonoBehaviour {

	//event for when tweener reaches target
	public delegate void TargetAction ();
	public event TargetAction ReachedTarget;
	
	public GameObject target;
    public float speed = 1.0f;
    bool reached = false;
    public float EndThreshold = 0.001f;
	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void FixedUpdate () {
        if(reached)
        {
            return;
        }
        reached = tweenDecider(speed, EndThreshold);
	}

    public bool tweenDecider(float p_speed, float p_threshold)
    {

        var objectToMove = this.gameObject;
        //var target = p_toTween.target;

		//distance is expensive, maybe based on time?
	    objectToMove.transform.position = Lerp(objectToMove.transform.position, target.transform.position, p_speed);
	    if (Vector3.Distance(objectToMove.transform.position, target.transform.position) < p_threshold)
	    {
	        return true;
	    }

		//reached target event is now satisfied
		ReachedTarget ();
        return false;
    }
	

    public static Vector3 Lerp(Vector3 source, Vector3 destination, float speed)
    {
        Vector3 pos = Vector3.Lerp(source, destination, speed * Time.fixedDeltaTime);

        return pos;
    }

}
