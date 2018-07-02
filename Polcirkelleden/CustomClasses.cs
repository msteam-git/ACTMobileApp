using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Polcirkelleden
{
    public class CustomImageCell : ImageCell { }

    public interface IBaseUrl { string Get(); }

    public class ClickImage : Xamarin.Forms.Image
    {
        public static BindableProperty OnClickProperty =
            BindableProperty.Create("OnClick", typeof(Command), typeof(ClickImage));

        public Command Command
        {
            get { return (Command)GetValue(OnClickProperty); }
            set { SetValue(OnClickProperty, value); }
        }

        public ClickImage()
        {
            GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(DisTap) });
        }

        private void DisTap(object sender)
        {
            if (Command != null)
            {
                Command.Execute(sender);
            }
        }

    }

    public class Names
    {
        [XmlElement(ElementName = "name")]
        public List<string> Name { get; set; }
    }
}