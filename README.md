Demonstration of a bug in Xamarin Forms 4.6.0.847 and 4.5.0

If you add a label to a vertical stack layout programatically then remove it then readd setting the stacklayout to IsVisible false each time when it has no children

On the second add the stacklayout is set to visible, it does have a child label but the contents are still invisible

There was a similiar bug in GTK https://github.com/xamarin/Xamarin.Forms/issues/3665 this one has a work around to add a HeightRequest to the label but this does not work here

This bug is present in both Android and iOS

Workaround:

Set the stacklayout to IsVisible true before adding the dynamic content and the content will be correctly shown
