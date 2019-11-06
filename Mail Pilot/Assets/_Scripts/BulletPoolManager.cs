using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    //TODO: create a structure to contain a collection of bullets
    public int bulletAmount = 50;
    static Queue<GameObject> bullets;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        bullets = new Queue<GameObject>();

        for(int i = 0; i < bulletAmount; i++)
        {
            GameObject bulletShoot = Instantiate(bullet);
            bulletShoot.SetActive(false);
            bullets.Enqueue(bulletShoot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bullets.Count);
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Vector3 pos, Quaternion id)
    {

        GameObject bulletGet = bullets.Dequeue();
        bulletGet.SetActive(true);
        bulletGet.transform.position = pos;
        bulletGet.transform.rotation = id;
        return bulletGet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullets.Enqueue(bullet);
        bullet.SetActive(true);
    }
}
