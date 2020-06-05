using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShowHideLabel
{
    public class MainPageVM : NotifiablePropertyModel
    {
        public ICommand AddLabelTouch => new Command(Addlabel);
        public ICommand RemoveLabelTouch => new Command(RemoveLabel);

        private int count = 0;

        public StackLayout StackLayoutTarget { get; internal set; }

        private void Addlabel()
        {
            if(StackLayoutTarget != null)
            {
                count++;
                //Moving the IsVisible setting to before the label is added corrects the bad behaviour
                //StackLayoutTarget.IsVisible = true;

                StackLayoutTarget.Children.Add(new Label
                {
                    Text = $"{count}th label added",
                    TextColor = Color.DarkRed,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    HorizontalTextAlignment = TextAlignment.Start,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    //Neither of the following help
                    //IsVisible = true,
                    //HeightRequest = 20
                });

                //This will not show the label added above
                StackLayoutTarget.IsVisible = true;
            }
        }

        private void RemoveLabel()
        {
            if (StackLayoutTarget != null)
            {
                var lastLabel = StackLayoutTarget.Children.OfType<Label>().LastOrDefault();

                if (lastLabel != null && lastLabel.TextColor == Color.DarkRed)
                {
                    StackLayoutTarget.Children.Remove(lastLabel);
                    if(StackLayoutTarget.Children.Any() != true)
                    {
                        StackLayoutTarget.IsVisible = false;
                    }
                }
            }
        }
    }
}
