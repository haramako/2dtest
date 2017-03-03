using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class ActiveOnTrigger : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Active", true);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Active", false);
        }
    }
}
