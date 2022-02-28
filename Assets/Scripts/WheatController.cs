using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatController : MonoBehaviour
{
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] private float growthTime;
    [SerializeField] private float targetScale;
    private Vector3 sizeDiff;
    private float growth;
    private float maxScale = 0;
    private bool max = false;

    void Start()
    {
        
        if(gameObject.transform.localScale.x>maxScale) maxScale = gameObject.transform.localScale.x;
        if(gameObject.transform.localScale.y>maxScale) maxScale = gameObject.transform.localScale.y;
        if(gameObject.transform.localScale.z>maxScale) maxScale = gameObject.transform.localScale.z;
        if(targetScale>maxScale) maxScale = targetScale;
        sizeDiff.x = (maxScale-gameObject.transform.localScale.x);
        sizeDiff.y = (maxScale-gameObject.transform.localScale.y);
        sizeDiff.z = (maxScale-gameObject.transform.localScale.z);
    }
    void Update()
    {
		if (max == false) 
        {
            growth += 1 * Time.deltaTime;
			base.gameObject.transform.localScale += new Vector3
            (Time.deltaTime * sizeDiff.x / growthTime,
            Time.deltaTime * sizeDiff.y / growthTime,
            Time.deltaTime * sizeDiff.z / growthTime);
            
		}
		if (growth >= growthTime ) {
			max = true;
		}
    }
    private void OnTriggerEnter(Collider collider) 
    {
        if((collider.gameObject.tag == "Scythe") && max)
        {
            GameObject wheatPoint = Instantiate(objToSpawn, gameObject.transform.position + Vector3.up*2, Quaternion.identity) as GameObject;
            wheatPoint.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1.0f,1.0f),1.0f,Random.Range(-1.0f,1.0f));
            Destroy(gameObject);
        }
        
    }
}

