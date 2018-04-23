Imports DevExpress.Utils.Drawing
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace KeepGroupsExpanded
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim TempXViewsPrinting As DevExpress.XtraGrid.Design.XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
			gridView1.Columns("Discontinued").GroupIndex = 0

			gridView1.ExpandAllGroups()
			gridView1.OptionsMenu.EnableGroupPanelMenu = False
		End Sub

		Private Sub gridView1_CustomDrawGroupRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles gridView1.CustomDrawGroupRow
			Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo
			info = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)
			info.ButtonBounds = Rectangle.Empty
			info.GroupText = " " & info.GroupText.TrimStart()
			e.Cache.FillRectangle(e.Appearance.GetBackBrush(e.Cache), e.Bounds)
			ObjectPainter.DrawObject(e.Cache, e.Painter, e.Info)
			e.Handled = True
		End Sub

		Private Sub gridView1_GroupRowCollapsing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles gridView1.GroupRowCollapsing
			e.Allow = False
		End Sub
	End Class
End Namespace