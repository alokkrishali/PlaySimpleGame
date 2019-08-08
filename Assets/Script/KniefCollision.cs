using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KniefCollision : MonoBehaviour
{

    Transform thisTransform;


    private void Start()
    {
        thisTransform = GetComponentInParent<Transform>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knief") && GameController.instance.ISGamePlay)
        {
            Knief hitKnief = null;
            hitKnief = other.GetComponentInParent<Knief>();
            hitKnief.HitToKnief = true;
            if (hitKnief.IsSettle)
                return;

            hitKnief.kniefRd.useGravity = true;
            hitKnief.kniefRd.mass += 1;
            GameController.instance.GameOver();
        }
    }
}
