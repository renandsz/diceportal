using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Portal : MonoBehaviour
    {
        public int portalId;
        public int destinyId;
        public bool isHidden;

        public TextMeshProUGUI t;

        private void Awake()
        {
            Transform txt = transform.GetChild(0).GetChild(0);
            t = txt.GetComponent<TextMeshProUGUI>();
        }

        public void ChangeDestiny(int portalId)
        {
            destinyId = portalId;
        }

        public void SetHidden(bool isHidden) {
            this.isHidden = isHidden;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (isHidden == false)
                {
                    Debug.Log("Player enter at portal");
                    GameManager.Instance.MovePlayerToPortal(destinyId);
                }
            }
        }

        private void Update()
        {
            t.text = destinyId.ToString();
        }
    }
}
