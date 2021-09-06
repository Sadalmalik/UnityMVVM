using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sadalmalik.MVVM
{
	public class ViewModelCollection : ViewModel
	{
		public ViewModel prefab;
		public RectTransform container;

		private List<ViewModel> _views = new List<ViewModel>();

		protected override void Refresh()
		{
			base.Refresh();

			int i = 0;
			var iterator = (IEnumerable) Value;
			if (iterator!=null)
			{
				foreach (var item in iterator)
				{
					if (i < _views.Count)
					{
						_views[i].SetModel(item);
					}
					else
					{
						var view = Lock();
						view.SetModel(item);
						_views.Add(view);
					}
					i++;
				}
			}
			
			int start = i;
			for (; i < _views.Count; i++)
			{
				Free(_views[i]);
			}
			_views.RemoveRange(start, _views.Count - start);
		}

#region Inner Pool

		private Queue<ViewModel> _pool = new Queue<ViewModel>();

		private ViewModel Lock()
		{
			ViewModel view;
			if (_pool.Count > 0)
			{
				view = _pool.Dequeue();
			}
			else
			{
				view = Instantiate(prefab, container);
				view.Init();
			}

			view.gameObject.SetActive(true);
			return view;
		}

		private void Free(ViewModel view)
		{
			view.gameObject.SetActive(false);
			_pool.Enqueue(view);
		}

#endregion
	}
}