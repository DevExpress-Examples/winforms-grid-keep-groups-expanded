using DevExpress.Utils.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeepGroupsExpanded {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
            gridView1.Columns["Discontinued"].GroupIndex = 0;

            gridView1.ExpandAllGroups();
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
        }

        private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e) {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info;
            info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
            info.ButtonBounds = Rectangle.Empty;
            info.GroupText = " " + info.GroupText.TrimStart();
            e.Cache.FillRectangle(e.Appearance.GetBackBrush(e.Cache), e.Bounds);
            ObjectPainter.DrawObject(e.Cache, e.Painter, e.Info);
            e.Handled = true;
        }

        private void gridView1_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e) {
            e.Allow = false;
        }
    }
}