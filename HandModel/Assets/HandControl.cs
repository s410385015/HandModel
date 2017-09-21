using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour {



	[System.Serializable]
	public class Wrist{
		public GameObject obj;
		[Range(0f,360f)]
		public float x = 0;
		[Range(0f,360f)]
		public float y = 90;
		[Range(0f,360f)]
		public float z = 0;

		private float _x;
		private float _y;
		private float _z;
		private Quaternion q=Quaternion.identity;

		public void Set()
		{
			if (obj != null) {
				x = obj.transform.rotation.eulerAngles.x;
				y = obj.transform.rotation.eulerAngles.y;
				z = obj.transform.rotation.eulerAngles.z;
				_x = obj.transform.rotation.eulerAngles.x;
				_y = obj.transform.rotation.eulerAngles.y;
				_z = obj.transform.rotation.eulerAngles.z;
			}
		}
		public void Rotate()
		{
			if (obj != null) {
				q.eulerAngles= new Vector3 (x,y,z);
				obj.transform.rotation = q;
			}
		}
		public void Reset()
		{
			x = _x;
			y = _y;
			z = _z;
		}
	}

	[System.Serializable]
	public class Finger{
		public GameObject obj;
		[Range(-60f,60f)]
		public float x = 0;
		private float y = 0;
		[Range(-180,180f)]
		public float z = 0;
		private float _x;
		private float _y;
		private float _z;

		private Quaternion q=Quaternion.identity;
		public void Set()
		{
			if (obj != null) {
				x = obj.transform.rotation.eulerAngles.x;
				y = obj.transform.rotation.eulerAngles.y;
				z = obj.transform.rotation.eulerAngles.z;
				_x = obj.transform.rotation.eulerAngles.x;
				_y = obj.transform.rotation.eulerAngles.y;
				_z = obj.transform.rotation.eulerAngles.z;
			}
		}
		public void Rotate()
		{
			if (obj != null) {
				q.eulerAngles= new Vector3 (x,y,z);
				obj.transform.rotation = q;
			}
		}
		public void SetY()
		{
			y = obj.transform.rotation.eulerAngles.y;
		}
		public void Reset()
		{
			x = _x;
			y = _y;
			z = _z;
		}
	}

	private bool isStart=false;




	public Wrist wrist;
	public Finger[] index=new Finger[3];
	public Finger[] middle=new Finger[3];
	public Finger[] ring=new Finger[3];
	public Finger[] pinky=new Finger[3];
	public Finger[] thumb=new Finger[2];


	// Use this for initialization
	void Start () {
		
	}



	// Update is called once per frame
	void Update () {
		if (isStart) {
			wrist.Rotate ();
			//SetRotation ();


			foreach (Finger f in index) {f.SetY ();f.Rotate();}
			foreach (Finger f in middle) {f.SetY ();f.Rotate();}
			foreach (Finger f in ring) {f.SetY ();f.Rotate();}
			foreach (Finger f in pinky) {f.SetY ();f.Rotate();}
			foreach (Finger f in thumb) {f.SetY ();f.Rotate();}
		}
	}


	public void SetRotation()
	{
		wrist.Set ();
		foreach (Finger f in index) {f.Set ();}
		foreach (Finger f in middle) {f.Set ();}
		foreach (Finger f in ring) {f.Set ();}
		foreach (Finger f in pinky) {f.Set ();}
		foreach (Finger f in thumb) {f.Set ();}
		isStart = true;
	}
	public void Reset()
	{
		wrist.Reset ();
		foreach (Finger f in index) {f.Reset ();}
		foreach (Finger f in middle) {f.Reset ();}
		foreach (Finger f in ring) {f.Reset ();}
		foreach (Finger f in pinky) {f.Reset ();}
		foreach (Finger f in thumb) {f.Reset ();}
	}

	public void OnShot()
	{
		index [0].z = -17;
		index [1].z = -133;
		index [2].z = -165;

		ring [0].z = 30;
		ring [1].z = -59;
		ring [2].z = -139;

		pinky [0].z = 15;
		pinky [1].z = -82;
		pinky [2].z = -138;

		thumb [0].z = 61;
		thumb [1].z = -34;
	}
}
