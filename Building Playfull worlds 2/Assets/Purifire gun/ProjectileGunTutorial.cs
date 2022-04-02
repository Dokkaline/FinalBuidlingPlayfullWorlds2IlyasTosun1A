
using UnityEngine;
using System.Collections;
using TMPro;


public class ProjectileGunTutorial : MonoBehaviour
{
    public LayerMask layerMask;
    public Camera fpsCam;
    public int gunDamage = 20;
    public float weaponRange = 100f;
    public GameObject Player;
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;


    void Start()
    {
        laserLineRenderer = GetComponent<LineRenderer>();
        Vector3[] initLaserPositions = new Vector3[2] { fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)), fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)) };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth + 0.3f;
        laserLineRenderer.endWidth = laserWidth;
        laserLineRenderer.startColor = new Color(255, 255, 255);
        laserLineRenderer.endColor = new Color(254, 254, 254);

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Player.GetComponent<ScoringSystem>().theScore > 0)
        {
            Shoot();
            Player.GetComponent<ScoringSystem>().theScore--;
        }
       
    }

    public void Shoot()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, layerMask))
        {
            Vector3 endPosition = gameObject.transform.position + (weaponRange * gameObject.transform.forward);
            endPosition = hit.point;

            Debug.DrawLine(rayOrigin, fpsCam.transform.forward, Color.red, 2);
            Debug.Log(hit);
            EnemyHealth health = hit.collider.GetComponentInParent<EnemyHealth>();
            if (health != null)
            {
                Debug.Log("Hoi");
                health.TakeDamage(gunDamage);
            }

            StartCoroutine(ShootLazer(endPosition));
        }
    }

    IEnumerator ShootLazer(Vector3 endPos)
    {
        laserLineRenderer.enabled = true;
        laserLineRenderer.SetPosition(0, gameObject.transform.position);
        laserLineRenderer.SetPosition(1, endPos);

        yield return new WaitForSeconds(2f);

        laserLineRenderer.enabled = false;
    }
    




    /*  //bullet 
      public GameObject bullet;

      public LayerMask layermask;

      //bullet force
      public float shootForce, upwardForce;

      //Gun stats
      public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
      public int magazineSize, bulletsPerTap;
      public bool allowButtonHold;

      public int bulletsLeft, bulletsShot;

      //Recoil
      public Rigidbody playerRb;
      public float recoilForce;

      //bools
      bool shooting, readyToShoot, reloading;

      //Reference
      public Camera fpsCam;
      public Transform attackPoint;

      //Graphics
      public GameObject muzzleFlash;
      public TextMeshProUGUI ammunitionDisplay;

      //bug fixing :D
      public bool allowInvoke = true;

      private void Awake()
      {
          //make sure magazine is full

          readyToShoot = true;
      }

      private void Update()
      {
          MyInput();

          //Set ammo display, if it exists :D
          if (ammunitionDisplay != null)
              ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
      }
      private void MyInput()
      {
          //Check if allowed to hold down button and take corresponding input
          if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
          else shooting = Input.GetKeyDown(KeyCode.Mouse0);



          //Shooting
          if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
          {
              //Set bullets shot to 0
              bulletsShot = 0;

              Shoot();
          }
      }

      private void Shoot()
      {
          readyToShoot = false;

          //Find the exact hit position using a raycast
          Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
          RaycastHit hit;

          //check if ray hits something
          Vector3 targetPoint;
          if (Physics.Raycast(ray, out hit))
              targetPoint = hit.point;
          else
              targetPoint = ray.GetPoint(75); //Just a point far away from the player

          //Calculate direction from attackPoint to targetPoint
          Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

          //Calculate spread
          float x = Random.Range(-spread, spread);
          float y = Random.Range(-spread, spread);

          //Calculate new direction with spread
          Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

          //Instantiate bullet/projectile
          GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
          //Rotate bullet to shoot direction
          currentBullet.transform.forward = directionWithSpread.normalized;

          //Add forces to bullet
          currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
          currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

          //Instantiate muzzle flash, if you have one
          if (muzzleFlash != null)
              Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

          bulletsLeft--;
          bulletsShot++;

          //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
          if (allowInvoke)
          {
              Invoke("ResetShot", timeBetweenShooting);
              allowInvoke = false;

              //Add recoil to player (should only be called once)
              playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
          }

          //if more than one bulletsPerTap make sure to repeat shoot function
          if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
              Invoke("Shoot", timeBetweenShots);
      }
      private void ResetShot()
      {
          //Allow shooting and invoking again
          readyToShoot = true;
          allowInvoke = true;
      } */



}
