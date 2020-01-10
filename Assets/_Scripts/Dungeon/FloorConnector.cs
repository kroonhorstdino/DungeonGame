using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RocketRaptor.Dungeon.Environment
{
    /// <summary>
    /// Controller for a connectro between floors
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class FloorConnector : MonoBehaviour
    {
        //Trigger for the door
        Collider2D _trigger;

        private void OnEnable()
        {
            foreach (Collider2D col in GetComponents<Collider2D>())
            {
                if (col.isTrigger)
                {
                    _trigger = col;
                    break;
                }
            }
        }

        //TODO: Door implement it!
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            Debug.Log("Hallo");

            Component tempController;
            PlayerController controller;

            if (TryGetComponent(typeof(PlayerController), out tempController))
            {
                controller = (PlayerController)tempController;
            }
            else
            {
                return;
            }
        }
    }
}
