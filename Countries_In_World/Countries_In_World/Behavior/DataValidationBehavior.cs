using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Countries_In_World.Behavior
{
    public class DataValidationBehavior:Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += Bindable_TextChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged += Bindable_TextChanged;
            base.OnDetachingFrom(bindable);
        }
        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = e.NewTextValue.Length >= 9;
            Entry entry = (Entry)sender;
            if (!string.IsNullOrWhiteSpace(entry.Text)) 
                entry.TextColor = isValid ? Color.Black : Color.Red;
        }
    }
}
