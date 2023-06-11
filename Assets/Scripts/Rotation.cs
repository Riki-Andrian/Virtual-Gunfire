using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public bool reverse = false;
    public bool rotateZ = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.reverse)
        {
        transform.Rotate(new Vector3(0f,1f,0f) * Time.deltaTime * this.rotationSpeed);
        }
        else if(this.rotateZ)
        {
            transform.Rotate(new Vector3(0f,0f,1f) * Time.deltaTime * this.rotationSpeed);  
        }
        else{
            transform.Rotate(new Vector3(0f,-1f,0f) * Time.deltaTime * this.rotationSpeed);
        }
    }

    public void SetRotationSpeed(float speed)
	{
		this.rotationSpeed = speed;
	}

	public void SetReverse(bool reverse)
	{
		this.reverse = reverse;
	}

    public void SetRotateZ(bool rotateZ)
	{
		this.rotateZ = rotateZ;
	}
}
