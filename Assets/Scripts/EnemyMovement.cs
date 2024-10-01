using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using System;

public class EnemyMovement : MonoBehaviour 
{
  private GameObject player;
  NavMeshAgent na;
  ResourseGeneration rg;
  public float speed = 2.0f;
  bool isDone = false;
  public int AtkDamage = 8;
  public bool  IsAvailable = true;
  public float Cooldown = 1f;
  public List<Animation> AttackAnimations;
  int curAnim = 0;
  

  // Use this for initialization
  void Start () 
  {
    rg = GameObject.Find("Map").GetComponent<ResourseGeneration>();
      player = GameObject.Find("Player");
      na = gameObject.GetComponent<NavMeshAgent>();
      na.updateUpAxis = false;
      na.updateRotation = false;
        
  }
  
  // Update is called once per frame
  void Update () 
  {
    Quaternion rotation = Quaternion.LookRotation
    (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
    transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    Attack();
    if (rg.IsBaked && isDone == false){

      isDone = true;
    }
    if (isDone){
      na.SetDestination(player.transform.position);
      
    } 
    
  }
  public IEnumerator StartCooldown()
       {
        IsAvailable = false;

        yield return new WaitForSeconds(Cooldown);

        IsAvailable = true;
    }
  public void Attack()
    {
        if (Math.Abs(transform.position.x - player.transform.position.x) <= 3 && Math.Abs(transform.position.y - player.transform.position.y) <= 3)
        {
            if (IsAvailable == true)
            {
                AttackAnimations[curAnim].Play();
                if (curAnim < AttackAnimations.Count-1)
                {
                    curAnim++;
                }
                else
                {
                    curAnim = 0;
                }
                player.GetComponent<PlayerHealth>().Damage(AtkDamage);
                StartCoroutine(StartCooldown());
            }

        }
    }
}