Demonstration of a bug in Xamarin Forms 4.6.0.847 - 4.4.0.991757 and probably more

If you add a label to a vertical stack layout programatically then remove it then readd setting the stacklayout to IsVisible false each time when it has no children

On the second add the stacklayout is set to visible, it does have a child label but the contents are still invisible

There was a similiar bug in GTK https://github.com/xamarin/Xamarin.Forms/issues/3665 this one has a work around to add a HeightRequest to the label but this does not work here

This bug is present in both Android and iOS

To reproduce the bug;
- Run the solution
- Click the Add label button
  - Label and stacklayout are correctly shown
- Click the remove label button
  - Label is removed from stacklayout 
  - As there are no children the stacklayout is set to IsVisible false correctly
- Click the Add Label button
  - Label is added to stacklayout
  - Stacklayout is set to IsVisible true
  - Stacklayout is shown
  - **Label is not shown**

First dynamic label add              |  Second dynamic label add
:-------------------------:|:-------------------------:
<img src="https://github.com/duindain/xamarin_add_remove_label/blob/master/screenshots/first_label_added.png" width="300" height="550"> | <img src="https://github.com/duindain/xamarin_add_remove_label/blob/master/screenshots/second_label_added.png" width="300" height="550">

Workaround:

Set the stacklayout to IsVisible true before adding the dynamic content and the content will be correctly shown
