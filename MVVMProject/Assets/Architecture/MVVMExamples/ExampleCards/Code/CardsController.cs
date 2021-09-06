using System;
using System.Collections;
using System.Collections.Generic;
using Sadalmalik.MVVM;
using UnityEngine;

namespace Sadalmalik.ExampleMVVM
{
	public class CardsController : MonoBehaviour
	{
		public ViewModel viewModel;
		public CardsModel cardsModel;

		public void Awake()
		{
			cardsModel.CardSaved += SaveCard;
			
			viewModel.Init();
			viewModel.SetModel(cardsModel);
		}
		
		private void SaveCard()
		{
            cardsModel.cards.Add(cardsModel.currentCard);
            
            cardsModel.currentCard = new Card();
            
            viewModel.UpdatedModel();
		}
	}
}