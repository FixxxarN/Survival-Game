using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Animals.Bugs
{
    public class Bee : Bug
    {
        private bool Attacking = false;

        void Start()
        {
            flyingSpeed = 0.5f;
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Attacking == false)
                Flying();
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                Attacking = true;
                rigidbody.velocity = (other.transform.position - gameObject.transform.position).normalized * flyingSpeed * 2;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                Attacking = false;
            }
        }
    }
}
