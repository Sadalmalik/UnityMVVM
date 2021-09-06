using TMPro;

namespace Sadalmalik.MVVM
{
    public class ViewModelText : ViewModel
    {
        public TMP_Text label;
        public string template;
        
        protected override void Refresh()
        {
            base.Refresh();
            
            label.text = string.Format(template, Value);
        }
    }
}