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
        void Start()
        {
            flyingSpeed = 0.7f;
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Flying();
        }
    }
}
