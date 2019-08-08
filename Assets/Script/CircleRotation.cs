using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{

    [SerializeField]
    Transform thisTransform;

    [SerializeField]
    float rotationSpeed = 50;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        if (!GameController.instance.ISGamePlay)
            return;

        thisTransform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Knief"))
        {
            Knief hitKnief = other.GetComponent<Knief>(); ;
            Vector3 velocityOfKnief = hitKnief.kniefRd.velocity;
            hitKnief.kniefRd.velocity = Vector3.zero;
            if (hitKnief.HitToKnief)
            {
                hitKnief.kniefRd.velocity = -velocityOfKnief;
                return;
            }
            else
            {
                hitKnief.kniefRd.useGravity = false;
                hitKnief.IsSettle = true;
                hitKnief.kniefTransform.SetParent(thisTransform);
                hitKnief.kniefTransform.eulerAngles = Vector3.up;
                hitKnief.kniefThrowRef.SetAnotherKnief();
            }
        }
    }
}
