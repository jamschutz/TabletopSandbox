using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace jsch.JewelHeist
{
    public class PlayerHand : MonoBehaviour
    {
        [Header("Transforms")]
        public Vector2 firstCardSlotSizeDelta;
        public Vector3 firstCardSlotPosition;
        public float horizontalSpaceBetweenCards;
        
        [Header("Prefabs")]
        public GameObject whiteCardPrefab;
        public GameObject blueCardPrefab;
        public GameObject greenCardPrefab;
        public GameObject redCardPrefab;
        public GameObject yellowCardPrefab;

        [Header("Helper")]
        public Card[] initialHand;

        private Dictionary<Card, GameObject> hand;


        void Start()
        {
            hand = new Dictionary<Card, GameObject>();
            foreach(var card in initialHand) {
                AddCard(card);
            }
        }


        public void AddCard(Card card)
        {
            var newCardObject = InstantiateCard(card);
            hand.Add(card, newCardObject);
        }


        public void RemoveCard(Card card)
        {
            hand.Remove(card);
        }


        GameObject InstantiateCard(Card card)
        {
            // create correct color card
            GameObject newCard;
            switch(card.type) {
                case Card.CardType.White:
                    newCard = GameObject.Instantiate(whiteCardPrefab, transform);
                    break;
                case Card.CardType.Blue:
                    newCard = GameObject.Instantiate(blueCardPrefab, transform);
                    break;
                case Card.CardType.Green:
                    newCard = GameObject.Instantiate(greenCardPrefab, transform);
                    break;
                case Card.CardType.Red:
                    newCard = GameObject.Instantiate(redCardPrefab, transform);
                    break;
                case Card.CardType.Yellow:
                    newCard = GameObject.Instantiate(yellowCardPrefab, transform);
                    break;
                default:
                    newCard = GameObject.Instantiate(whiteCardPrefab);
                    Debug.LogError($"You instantiated a card with type {card.type.ToString()} but forgot to add to the PlayerHand switch case!");
                    break;
            }

            // set position
            var rectTransfrom = newCard.GetComponent<RectTransform>();
            rectTransfrom.localPosition += new Vector3(horizontalSpaceBetweenCards * hand.Count, 0, 0);

            // set text
            var text = newCard.GetComponentInChildren<TMP_Text>();
            text.text = card.value.ToString();

            return newCard;
        }
    }
}

