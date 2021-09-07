using System;

namespace Sadalmalik.MVVM
{
	public interface IViewModel
	{
		object Model { get; }
		object Value { get; }
		
		event Action ModelChanged;
		
		void Init();
		void SetModel(object model);
		void UpdatedModel();
	}
}