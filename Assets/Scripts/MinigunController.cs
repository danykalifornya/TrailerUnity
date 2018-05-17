using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunController : MonoBehaviour {

    public GameObject bullet;
    public GameObject granade;
    private float granadePower = 13f;
    private int bulletSpeed = 20;
    private int offsetRotation = -90;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x + 0.012f, transform.position.y);
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Granade();
        }
    }

    void Fire()
    {
        //create bullet toward mouse
        GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;

        //ad Velocity toiward mouse position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shot.transform.position;
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(difference.x, difference.y).normalized * bulletSpeed;

        //Rotate bullet toward mouse position
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        shot.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offsetRotation);

        //destroy after 2 seconds
        Destroy(shot, 2.5f);
    }

    void Granade()
    {
        GameObject shot = Instantiate(granade, transform.position, Quaternion.identity) as GameObject;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shot.transform.position;
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(difference.x, difference.y).normalized * granadePower;
        //shot.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.mousePosition.x, Input.mousePosition.y).normalized * granadePower;

        Destroy(shot, 4);
    }
}
