using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GunScript : MonoBehaviour
{
    public int ammo = 6;
    public int shotCount = 0;
    bool isReloading;
    public GameObject[] bulletIcons;
    public GameObject reloadUI;
    public Slider reloadBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isReloading = false;
        reloadUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&!isReloading && ammo >0)
        {
            Shoot();
        }
        else if (Input.GetMouseButtonDown(0) &&!isReloading && ammo <=0)
        {
            StartCoroutine(Reload());
        }
        //Manually reloads the gun
        if (Input.GetKeyDown(KeyCode.R)&&!isReloading&&ammo<6)
        {
            StartCoroutine(Reload());
        }
        //add automatic reload if ammo = 0;
    }
    
    void Shoot()
    {
        if (ammo > 0 && !isReloading)
        {
            bulletIcons[ammo - 1].SetActive(false);
            shotCount++;
            ammo--;
            Debug.Log(ammo+" bullets remaining");    
        }
        
    }
    IEnumerator Reload()
    {
        isReloading = true;
        reloadUI.SetActive(true);
        reloadBar.value = 0;
        float timer = 0;
        Debug.Log("Started reload");

        //Reload UI here
        while (timer < 2.0f)
        {
            timer += Time.deltaTime;
            reloadBar.value = timer;
            yield return null;
        }
        //yield return new WaitForSeconds(2f);
        
        for (int x = 0; x < bulletIcons.Length; x++)
        {
            bulletIcons[x].SetActive(true);
        }
        ammo = 6;
        isReloading = false;
        Debug.Log ("reload finished");
        reloadUI.SetActive(false);
    }
}
