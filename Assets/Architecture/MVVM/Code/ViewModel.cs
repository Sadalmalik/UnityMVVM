using System;
using System.Reflection;
using UnityEngine;

namespace Sadalmalik.MVVM
{
	public class ViewModel : MonoBehaviour, IViewModel
	{
		public string targetField;

		[NonSerialized] public FieldInfo field;

		public object Model { get; protected set; }
		public object Value { get; protected set; }

		public event Action ModelChanged;

		public virtual void Init()
		{
		}

		public virtual void SetModel(object model)
		{
			Model = model;
			
			var isNull = Model==null;
			gameObject.SetActive(!isNull);
			if (isNull) return;
			
			Refresh();
		}

		public virtual void UpdatedModel()
		{
			Refresh();
		}
		
		protected virtual void Refresh()
		{
			if (string.IsNullOrEmpty(targetField))
			{
				Value = Model;
			}
			else
			{
				field = Model?.GetType().GetField(targetField);
				Value = field?.GetValue(Model);
			}
		}

		protected void InvokeModelChanged()
		{
			ModelChanged?.Invoke();
		}
	}
}