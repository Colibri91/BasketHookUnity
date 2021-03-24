using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoopmaker : MonoBehaviour
{
    public bally ballScript;
    public GameObject hoop;
    public float height;
    public float time;

    private void Start()
    {
        StartCoroutine(SpawnObject(time));
    }

    public IEnumerator SpawnObject(float time)
    {
        while (!ballScript.isDead)
        {
            var hooper = (GameObject) Instantiate(hoop, new Vector3(3, Random.Range(-height, height), 0), Quaternion.identity);
            Destroy(hooper, time + 10);
            yield return new WaitForSeconds(time);
            
        }
        
    }
}
