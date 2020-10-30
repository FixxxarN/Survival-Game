using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Animals.Bugs
{
    public class Bee : Bug
    {
        private bool attacking = false;

        void Start()
        {
            anim = GetComponent<Animator>();
            flyingSpeed = 0.5f;
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            anim.SetBool("alive", alive);
            if (!attacking && alive)
                Flying();

            if (!alive)
            {
                rigidbody.gravityScale = 1;
                StartCoroutine(Die());
            }
        }

        private IEnumerator Die()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.name == "Player" && alive)
            {
                attacking = true;
                rigidbody.velocity = (other.transform.position - gameObject.transform.position).normalized * flyingSpeed * 2;
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(10);
                attacking = false;
                alive = false;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                attacking = false;
            }
        }
    }
}
