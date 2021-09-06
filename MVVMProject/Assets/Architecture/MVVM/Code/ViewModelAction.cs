using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Sadalmalik.MVVM
{
	public class ViewModelAction : ViewModel
	{
		public Button button;
		
		[NonSerialized] public MethodInfo method;

		public override void Init()
		{
			button.onClick.AddListener(InvokeAction);
		}

		protected override void Refresh()
		{
			method = null;
			
			if (!string.IsNullOrEmpty(targetField))
			{
				method = Model?.GetType().GetMethod(targetField);
			}
		}
		
		private void InvokeAction()
		{
			if (method != null)
			{
				method.Invoke(Model, null);
			}
		}
	}
}