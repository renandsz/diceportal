using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public Transform player;
        public List<Portal> portals;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void MovePlayerToPortal(int portalId) 
        {
            // Hidden Portal
            Portal pDestiny = GetPortal(portalId);
            pDestiny.SetHidden(true);

            // Teleport Player
            player.transform.position = pDestiny.transform.position;

            // Change Portal Destinies;

        
        }

        public void ChangePortalDestinies()
        { 
            //
        }

        public Portal GetPortal(int portalId)
        {
            Portal portal = null;

            foreach (Portal p in portals)
            {
                if (p.portalId == portalId) 
                {
                    Debug.Log("Tem portal! ID: " + p.portalId);
                    portal = p;
                    break; 
                }
            }

            return portal;
        }
    }
}