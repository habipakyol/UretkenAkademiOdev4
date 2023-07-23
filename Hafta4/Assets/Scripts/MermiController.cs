using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletDecal;

    private float speed = 50f;
    private float timetoDestroy = 2f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    public GameObject diePrefab;
  

  
    private void OnEnable()
    {
        Destroy(gameObject, timetoDestroy);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < .01f)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        GameObject decal = Instantiate(bulletDecal, contact.point + contact.normal * .0001f, Quaternion.LookRotation(contact.normal));
        Destroy(decal, 0.5f);
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            GameObject decal0 = Instantiate(bulletDecal, contact.point + contact.normal * .0001f, Quaternion.LookRotation(contact.normal));
            Destroy(decal0, 0.5f);
            Destroy(collision.gameObject);
            if (diePrefab != null)
            {
                GameObject deathParticle = Instantiate(diePrefab, transform.position, Quaternion.identity);
                Destroy(deathParticle, 0.8f);
            }

        }
        
        if (collision.gameObject.CompareTag("cevrebilesen"))
        {
            GameObject decal0 = Instantiate(bulletDecal, contact.point + contact.normal * .0001f, Quaternion.LookRotation(contact.normal));
            Destroy(decal0, 0.1f);
            Destroy(gameObject);
        }

    }
}
