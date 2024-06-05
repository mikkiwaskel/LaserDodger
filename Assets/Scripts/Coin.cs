using UnityEngine;

public class Coin : MonoBehaviour
{
    public int rotateSpeed = 200;


    void FixedUpdate()
    {
        Vector3 temp = transform.localEulerAngles;
        temp.y += Time.deltaTime * rotateSpeed;
        transform.localEulerAngles = temp;
    }
}
