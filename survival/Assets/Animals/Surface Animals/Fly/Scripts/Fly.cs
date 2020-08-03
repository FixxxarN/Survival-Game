using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Animals.Bugs
{
    public class Fly : Bug
    {
        private bool FecesInFocus = false;
        void Start()
        {
            flyingSpeed = 0.5f;
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if(!FecesInFocus)
            {
                Flying();
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if(other.gameObject.tag == "Animal feces")
            {
                FecesInFocus = true;
                rigidbody.velocity = ((other.transform.position + new Vector3(0, 0.25f, 0) - gameObject.transform.position).normalized * 10);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Animal feces")
            {
                FecesInFocus = false;
            }
        }
    }
}
