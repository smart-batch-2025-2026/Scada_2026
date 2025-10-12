using System;
using System.Drawing;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    partial class ComponentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button btnNew, btnEdit, btnDelete, btnImport, btnExport, btnPrint, btnExit;
        private Button btnAggregate, btnCement, btnWater, btnAdditive, btnColour, btnAdding, btnAggMix;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            dataGridView1 = new DataGridView();
            btnNew = new Button(); btnEdit = new Button(); btnDelete = new Button();
            btnImport = new Button(); btnExport = new Button(); btnPrint = new Button(); btnExit = new Button();
            btnAggregate = new Button(); btnCement = new Button(); btnWater = new Button();
            btnAdditive = new Button(); btnColour = new Button(); btnAdding = new Button(); btnAggMix = new Button();

            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            this.SuspendLayout();

            // DataGridView
            dataGridView1.Location = new Point(20, 100);
            dataGridView1.Size = new Size(820, 360);
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Helper for action buttons
            void SetupActionButton(Button btn, string text, Image img, Point loc, EventHandler handler)
            {
                btn.Location = loc;
                btn.Size = new Size(100, 44);
                btn.Text = " " + text;
                btn.Image = img;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextAlign = ContentAlignment.MiddleRight;
                btn.Click += handler;
                btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            }

            // Action buttons
            SetupActionButton(btnNew, "New", Properties.Resources.icon_new, new Point(20, 470), btnNew_Click);
            SetupActionButton(btnEdit, "Edit", Properties.Resources.icon_new, new Point(130, 470), btnEdit_Click);
            SetupActionButton(btnDelete, "Delete", Properties.Resources.icon_delete, new Point(240, 470), btnDelete_Click);
            SetupActionButton(btnImport, "Import", Properties.Resources.importing_componants, new Point(350, 470), btnImport_Click);
            SetupActionButton(btnExport, "Export", Properties.Resources.exporting_componants, new Point(460, 470), btnExport_Click);
            SetupActionButton(btnPrint, "Print", Properties.Resources.printing_icon, new Point(570, 470), btnPrint_Click);
            SetupActionButton(btnExit, "Exit", Properties.Resources.exit_icon, new Point(740, 470), btnExit_Click);
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Helper for filter buttons
            void SetupFilterButton(Button btn, string text, Image img, Color back, Point loc, EventHandler handler)
            {
                btn.Location = loc;
                btn.Size = new Size(100, 64);
                btn.Text = text;
                btn.Image = img;
                btn.TextImageRelation = TextImageRelation.ImageAboveText;
                btn.BackColor = back;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Tag = "filter";
                btn.Click += handler;
            }

            // Filter Buttons
            SetupFilterButton(btnAggregate, "Aggregate", Properties.Resources.aggregate, Color.SandyBrown, new Point(20, 20), btnAggregate_Click);
            SetupFilterButton(btnCement, "Cement", Properties.Resources.cement, Color.LightGray, new Point(130, 20), btnCement_Click);
            SetupFilterButton(btnWater, "Water", Properties.Resources.water, Color.LightBlue, new Point(240, 20), btnWater_Click);
            SetupFilterButton(btnAdditive, "Additive", Properties.Resources.additive, Color.LightGreen, new Point(350, 20), btnAdditive_Click);
            SetupFilterButton(btnColour, "Colour", Properties.Resources.color, Color.LightPink, new Point(460, 20), btnColour_Click);
            SetupFilterButton(btnAdding, "Adding", Properties.Resources.adding, Color.LightYellow, new Point(570, 20), btnAdding_Click);
            SetupFilterButton(btnAggMix, "AggMix", Properties.Resources.Aggregates_mixtures, Color.LightCoral, new Point(680, 20), btnAggMix_Click);

            // Form setup
            this.ClientSize = new Size(860, 530);
            this.Controls.Add(dataGridView1);
            this.Controls.AddRange(new Control[]
            {
                btnNew, btnEdit, btnDelete, btnImport, btnExport, btnPrint, btnExit,
                btnAggregate, btnCement, btnWater, btnAdditive, btnColour, btnAdding, btnAggMix
            });
            this.Text = "Components Management";
            this.Load += new EventHandler(this.ComponentsForm_Load);

            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
