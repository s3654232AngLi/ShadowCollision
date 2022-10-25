using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {
	PlayerInput playerInput;
	bool isRewinding = false;

	public float recordTime = 20f;

	List<PointInTime> pointsInTime;

	Rigidbody rb;

    // Use this for initialization
    private void Awake()
    {
		playerInput = new PlayerInput();

	}
	void Start () 
	{
		playerInput.Enable();
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody>();
		playerInput.Player1.TimeRewind.performed += _ => StartRewind();
		playerInput.Player1.TimeRewind.canceled += _ => DisableRewind();
	}
	
	void Text()
    {
		Debug.Log("Press");
    }

	// Update is called once per frame
	void Update () {
		

		
	}

	void FixedUpdate ()
	{
		if (isRewinding)
        {
			Debug.Log("Rewind");
			Rewind();
		}

        else
        {
			Debug.Log("RewindStop");
			Record();
		}
			
	}

	void Rewind ()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		} else
		{
			StopRewind();
		}
		
	}

	void Record ()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			pointsInTime.RemoveAt(pointsInTime.Count - 1);
		}

		pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}

	public void StartRewind ()
	{
		Debug.Log("R");
		isRewinding = true;
		rb.isKinematic = true;
		rb.useGravity = false;
	}

	void DisableRewind()
    {
		rb.isKinematic = false;
		rb.useGravity = true;
	}

	public void StopRewind ()
	{
		isRewinding = false;
		
	}
}
