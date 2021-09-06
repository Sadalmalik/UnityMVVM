using System;
using System.Collections.Generic;
using Sadalmalik.MVVM;
using UnityEngine;

namespace Sadalmalik.TestMVVM
{
	[Serializable]
	public class TestModel1
	{
		public string content;
		public string changeable;
		public string[] lines;
		
		public void TestAction()
		{
			Debug.Log("TestModel1.TestAction");
		}
	}

	[Serializable]
	public class TestModel2
	{
		public int content;
		public string changeable;
		public List<string> lines;
	}

	[Serializable]
	public class TestModel3
	{
		public bool content;
		public string changeable;
		
		public void TestAction()
		{
			Debug.Log("TestModel3.TestAction");
		}
	}

	public class MVVMTest : MonoBehaviour
	{
		public ViewModel Target;
		[Space]
		public TestModel1 testModel1;
		public TestModel2 testModel2;
		public TestModel3 testModel3;
		[Space]
		public bool setModel1;
		public bool setModel2;
		public bool setModel3;

		public void Awake()
		{
			Target.Init();
		}

		public void Update()
		{
			Trigger(ref setModel1, SetModel1);
			Trigger(ref setModel2, SetModel2);
			Trigger(ref setModel3, SetModel3);
		}
		
		private void Trigger(ref bool trigger, Action act)
		{
			if (trigger) { trigger=false; act?.Invoke(); }
		}
		
		private void SetModel1()
		{
			Target.SetModel(testModel1);
		}
		
		private void SetModel2()
		{
			Target.SetModel(testModel2);
		}
		
		private void SetModel3()
		{
			Target.SetModel(testModel3);
		}
	}
}