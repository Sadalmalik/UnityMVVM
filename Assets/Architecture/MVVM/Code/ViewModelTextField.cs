using TMPro;
using TMPro.SpriteAssetUtilities;
using UnityEngine;

namespace Sadalmalik.MVVM
{
    public class ViewModelTextField : ViewModel
    {
        public TMP_InputField label;
        
        private bool _ignoreChange;
        
        public override void Init()
        {
            label.onValueChanged.AddListener(HandleTextChanged);
        }
        
        protected override void Refresh()
        {
            base.Refresh();
            
            _ignoreChange = true;
            label.text = Value?.ToString();
            _ignoreChange = false;
        }
        
        private void HandleTextChanged(string value)
        {
            if (_ignoreChange) return;

            if (field.FieldType == typeof(string))
            {
                field?.SetValue(Model, value);
            }
            if (field.FieldType == typeof(int))
            {
                field?.SetValue(Model, int.Parse(value));
            }
            
            InvokeModelChanged();
        }
    }
}
