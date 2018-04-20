using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {


    
	//// Use this for initialization
	//void Start () {
    //       Destroy(gameObject, 2f);
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    void OnEnable()
    {
        Invoke("Destroy", 1f);
    }

    void Destroy ()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
