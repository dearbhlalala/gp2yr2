using UnityEngine;

public class DoorAnimate : MonoBehaviour
{
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    void OnTriggerEnter(Collider other){

	
        if (other.gameObject.name == "Soldier" && anim.GetBool("doorOpen") == false) {

            anim.SetBool ("doorOpen", true);
            Debug.Log ("Door Open:" + other.gameObject.name);
        }
    }

    void OnTriggerExit(Collider other){
	
	if (other.gameObject.name == "Soldier") {

		anim.SetBool ("doorOpen", false);
		Debug.Log ("Door Close:" + other.gameObject.name);
	} 
}
}
