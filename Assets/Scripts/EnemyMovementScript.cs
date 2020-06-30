using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {
    public float movementSpeed;
    private Transform movePoint;

    private GameObject directionCube;
    public GameObject cubePrefab;

    public GameObject playerObject;

    private bool triggeringEnemy = false;
    private bool moving = false;

    private bool collidedWithPlayer = false;

    private bool isAttackingPlayer = false;

    private bool shouldStareAtPlayer = false;


    private GameObject enemy;

    // Update is called once per frame
    void Update() {
        StartCoroutine(ChangeDirectionCubePosition());
        movePoint = PlayerCasting.currentTransform;

        if (collidedWithPlayer ) {
            if (!isAttackingPlayer) {
                moving = false;
                GetComponent<Animator>().SetBool("isMoving", moving);
                GetComponent<Animator>().SetBool("isAttacking", true);
                StartCoroutine(DamagePlayer());
            }
            if (shouldStareAtPlayer) {
                directionCube.transform.position = movePoint.position;
                this.transform.LookAt(new Vector3(directionCube.transform.position.x, this.transform.position.y, directionCube.transform.position.z));
            }
            return;
        }

        if (!directionCube) {
            directionCube = Instantiate(cubePrefab, movePoint.position, Quaternion.identity);
            directionCube.GetComponent<BoxCollider>().enabled = false;
        }

        if (directionCube) {
            moving = !(transform.position == directionCube.transform.position);
            GetComponent<Animator>().SetBool("isMoving", moving);
        }


        if (moving) {
            Move();
        } else {
            Destroy(directionCube);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //Destroy(other.gameObject);
            collidedWithPlayer = true;
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    public void Move() {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(directionCube.transform.position.x, this.transform.position.y, directionCube.transform.position.z), movementSpeed);
        this.transform.LookAt(new Vector3(directionCube.transform.position.x, this.transform.position.y, directionCube.transform.position.z));
    }

    IEnumerator ChangeDirectionCubePosition() {
        yield return new WaitForSeconds(1f);
        directionCube.transform.position = movePoint.position;
    }

    IEnumerator DamagePlayer() {
        isAttackingPlayer = true;
        yield return new WaitForSeconds(0.5f);
        playerObject.GetComponent<HealthSystem>().DamagePlayerFor(10f);
        GetComponent<Animator>().SetBool("isAttacking", false);
        yield return new WaitForSeconds(1f);
        shouldStareAtPlayer = true;
        yield return new WaitForSeconds(2f);
        shouldStareAtPlayer = false;
        this.movementSpeed = movementSpeed + 0.01f;
        collidedWithPlayer = false;
        isAttackingPlayer = false;
        GetComponent<BoxCollider>().isTrigger = true;
        //  pla
    }
}
