using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [Header("CharacterStats")]
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float sprintBonus = 6f;
    //[SerializeField] float range = 100;

    [Header("Shooting")]
    [SerializeField] float maxPower;
    [SerializeField] float minPower;
    [SerializeField] float chargingSpeed;
    [SerializeField] Image chargingImage;
    private float currentPower;
    private bool isCharging;

    [SerializeField] ParticleSystem weaponFlash;
    [SerializeField] ParticleSystem chargingParticles;
    [SerializeField] AudioSource chargingSound;
    [SerializeField] AudioSource shootSound;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] Transform raycastStart;

    private RaycastHit hitObject;

    private Vector3 velocity;
    private bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        } else
        {
            //Debug.Log("Not Grounded");
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            Sprint();

            //if (Input.GetMouseButtonDown(1))
            //{
            //    weaponFlash.Play();
            //    shootSound.Play();
            //    RaycastHit hit;
            //    Physics.Raycast(raycastStart.position, raycastStart.rotation * Vector3.forward, out hit, 100);
            //    if (hit.collider != null && hit.collider.tag == "Enemy")
            //    {

            //        hit.collider.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
            //    }
            //} else 

            if(isCharging == true)
            {
                //RaycastHit hit;
                Physics.Raycast(raycastStart.position, raycastStart.rotation * Vector3.forward, out hitObject, Mathf.Infinity);
                hitObject.collider.gameObject.GetComponent<Ball>()?.AimedAt();
                if (currentPower <= maxPower)
                {
                    currentPower += Time.deltaTime * chargingSpeed;

                }
                else if (currentPower > maxPower)
                {
                    currentPower = maxPower;
                }
                if(currentPower <= maxPower)
                {
                    chargingImage.transform.localScale = new Vector3(currentPower / maxPower, 1, 1);
                }
                
            }
            

            if (Input.GetMouseButtonDown(0))
            {
                isCharging = true;
                chargingParticles.Play();
                chargingSound.Play();
                
            }

            if (Input.GetMouseButtonUp(0))
            {
                isCharging = false;
                chargingParticles.Stop();
                chargingSound.Stop();
                weaponFlash.Play();
                shootSound.Play();
                RaycastHit hit;
                Physics.Raycast(raycastStart.position, raycastStart.rotation * Vector3.forward, out hit, Mathf.Infinity);
                chargingImage.transform.localScale = new Vector3(0, 1, 1);
                //Debug.DrawLine(raycastStart.position + Vector3.forward, hit.point, Color.red, 10f);
                if (hit.collider != null && (hit.collider.tag == "Enemy" || hit.collider.tag == "Ball"))
                {
                    hit.collider.GetComponent<Rigidbody>().AddForce(raycastStart.rotation * Vector3.forward * currentPower);
                }
                currentPower = 0;
            }
        }
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += sprintBonus;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= sprintBonus;
        }
    }
}
