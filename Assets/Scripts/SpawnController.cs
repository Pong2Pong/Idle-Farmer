using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject objToSpawn;
    public GameObject Field;
    public int objLimit;
    void Update()
    {
        if(Field.transform.childCount<objLimit)
        {
            print("a");
            float xPos = Random.Range(Field.transform.position.x, Field.transform.position.x - Field.transform.localScale.x*5);
            float zPos = Random.Range(Field.transform.position.z, Field.transform.position.z + Field.transform.localScale.z*5);
            Quaternion rot = new Quaternion(0,Random.Range(0.0f,1.8f),0,1);
            Vector3 Position = new Vector3(xPos, 0, zPos);
            GameObject newPlant =  Instantiate(objToSpawn, Position, rot) as GameObject;
            newPlant.transform.SetParent(Field.transform);
        }
    }
}
