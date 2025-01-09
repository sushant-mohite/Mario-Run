using UnityEngine;

public class CutterRotator : MonoBehaviour
{
    public float xRotate = 100f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotate * Time.deltaTime,0,0);
    }
       
}
