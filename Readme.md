<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128630090/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E828)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Keep all groups expanded

This example automatically expands all group rows on application startup and hides expand/collapse buttons to prevent users from collapsing group rows.

The [GroupRowCollapsing](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.GroupRowCollapsing) event is handled to prevent users from collapsing group rows:

```csharp
private void gridView1_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e) {
    e.Allow = false;
}
```

The [CustomDrawGroupRow](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomDrawGroupRow) event is handled to hide expand/collapse buttons:

```csharp
private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e) {
    DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info;
    info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
    info.ButtonBounds = Rectangle.Empty;
    info.GroupText = " " + info.GroupText.TrimStart();
    e.Cache.FillRectangle(e.Appearance.GetBackBrush(e.Cache), e.Bounds);
    ObjectPainter.DrawObject(e.Cache, e.Painter, e.Info);
    e.Handled = true;
}
```


## Files to Review

* [Form1.cs](./CS/KeepGroupsExpanded/Form1.cs) (VB: [Form1.vb](./VB/KeepGroupsExpanded/Form1.vb))
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-keep-groups-expanded&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-keep-groups-expanded&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
