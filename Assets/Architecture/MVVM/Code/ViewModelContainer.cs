using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sadalmalik.MVVM
{
    public class ViewModelContainer : ViewModel
    {
        public List<ViewModel> children = new List<ViewModel>();
    
        public override void Init()
        {
            children.Clear();
            var queue = new Queue<Transform>();
            queue.Enqueue(transform);
            while (queue.Count>0)
            {
                var skip = false;
                var next = queue.Dequeue();
                var components = next.GetComponents<ViewModel>();

                foreach (var viewModel in components)
                {
                    if (ReferenceEquals(viewModel, this))
                        continue;
                    
                    children.Add(viewModel);
                    viewModel.ModelChanged += InvokeModelChanged;
                    viewModel.Init();
                    
                    skip |= viewModel is ViewModelContainer;
                }

                if (skip)
                    continue;
                
                foreach (Transform child in next)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public override void SetModel(object model)
        {
            base.SetModel(model);
            
            foreach (var child in children)
                child.SetModel(Value);
        }
        
        public override void UpdatedModel()
        {
            var oldValue = Value;
        
            base.UpdatedModel();
            
            if (oldValue != Value)
            {
                foreach (var child in children)
                    child.SetModel(Value);
            }
            else
            {
                foreach (var child in children)
                    child.UpdatedModel();
            }
        }
    }
}