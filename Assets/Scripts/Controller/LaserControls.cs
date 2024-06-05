using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControls : MonoBehaviour
{
    public GameObject[] Laser;
    public float LaserSpeed = 8f;
    private float countPlus = 0f;
    public int Wave_Counts = 1;
    public bool isLaserSpawn;
    void Start()
    {
        isLaserSpawn = true;
    }
   
    void Update()
    {
        countPlus += Time.deltaTime;
        if(countPlus > 15f)
        {
            if(Wave_Counts != 5) Wave_Counts += 1;
            LaserSpeed += 2;
            GameManager.instance.WaveCounts += 1;
            countPlus = 0f;
        }
        for (int i = 0; i < Wave_Counts; i++)
        {
            Laser[i].SetActive(true);
        }
        if (Wave_Counts == 1)
        {
            Vector3 laser0Temp = Laser[0].transform.rotation.eulerAngles;
            laser0Temp.y += Time.deltaTime * LaserSpeed;
            Laser[0].transform.rotation = Quaternion.Euler(0, laser0Temp.y, 0);
        }
        else if(Wave_Counts == 2)
        {
            Vector3 laser0Temp = Laser[0].transform.rotation.eulerAngles;
            laser0Temp.y -= Time.deltaTime * LaserSpeed;
            Laser[0].transform.rotation = Quaternion.Euler(0, laser0Temp.y, 0);

            Vector3 laser1Temp = Laser[1].transform.position;
            laser1Temp.x -= Time.deltaTime * LaserSpeed;
            Laser[1].transform.position = new Vector3 (laser1Temp.x, laser1Temp.y, laser1Temp.z);
        }
        else if (Wave_Counts == 3)
        {
            
            Vector3 laser0Temp = Laser[0].transform.rotation.eulerAngles;
            laser0Temp.y += Time.deltaTime * LaserSpeed;
            Laser[0].transform.rotation = Quaternion.Euler(0, laser0Temp.y, 0);

            Vector3 laser1Temp = Laser[1].transform.position;
            laser1Temp.x += Time.deltaTime * LaserSpeed;
            Laser[1].transform.position = new Vector3(laser1Temp.x, laser1Temp.y, laser1Temp.z);

            Vector3 laser2Temp = Laser[2].transform.rotation.eulerAngles;
            laser2Temp.y += Time.deltaTime * LaserSpeed;
            Laser[2].transform.rotation = Quaternion.Euler(0, laser2Temp.y, 0);
        }
        else if (Wave_Counts == 4)
        {
            Vector3 laser0Temp = Laser[0].transform.rotation.eulerAngles;
            laser0Temp.y -= Time.deltaTime * LaserSpeed;
            Laser[0].transform.rotation = Quaternion.Euler(0, laser0Temp.y, 0);

            Vector3 laser1Temp = Laser[1].transform.position;
            laser1Temp.x -= Time.deltaTime * LaserSpeed;
            Laser[1].transform.position = new Vector3(laser1Temp.x, laser1Temp.y, laser1Temp.z);

            Vector3 laser2Temp = Laser[2].transform.rotation.eulerAngles;
            laser2Temp.y -= Time.deltaTime * LaserSpeed;
            Laser[2].transform.rotation = Quaternion.Euler(0, laser2Temp.y, 0);

            Vector3 laser3Temp = Laser[3].transform.position;
            laser3Temp.z += Time.deltaTime * LaserSpeed/.75f;
            Laser[3].transform.position = new Vector3(laser3Temp.x, laser3Temp.y, laser3Temp.z);
        }
        else if (Wave_Counts == 5)
        {
            Vector3 laser0Temp = Laser[0].transform.rotation.eulerAngles;
            laser0Temp.y += Time.deltaTime * LaserSpeed;
            Laser[0].transform.rotation = Quaternion.Euler(0, laser0Temp.y, 0);

            Vector3 laser1Temp = Laser[1].transform.position;
            laser1Temp.x += Time.deltaTime * LaserSpeed;
            Laser[1].transform.position = new Vector3(laser1Temp.x, laser1Temp.y, laser1Temp.z);

            Vector3 laser2Temp = Laser[2].transform.rotation.eulerAngles;
            laser2Temp.y += Time.deltaTime * LaserSpeed;
            Laser[2].transform.rotation = Quaternion.Euler(0, laser2Temp.y, 0);

            Vector3 laser3Temp = Laser[3].transform.position;
            laser3Temp.z -= Time.deltaTime * LaserSpeed/.75f;
            Laser[3].transform.position = new Vector3(laser3Temp.x, laser3Temp.y, laser3Temp.z);


            Vector3 laser4Temp = Laser[4].transform.rotation.eulerAngles;
            laser4Temp.y += Time.deltaTime * LaserSpeed;
            Laser[4].transform.rotation = Quaternion.Euler(0, laser4Temp.y, 0);
        }

    }

    
}
