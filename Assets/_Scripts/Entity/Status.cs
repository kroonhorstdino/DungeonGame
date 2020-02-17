using System;
using UnityEngine;

namespace Raptor.Entity
{
    public class StatusHandler
    {
        [SerializeField] StatFloat _health;

        public EntityBase Entity { get; private set; }

        private void Awake()
        {

        }
    }

}