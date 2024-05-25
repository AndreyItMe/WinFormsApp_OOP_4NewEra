namespace WinFormsApp_OOP_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox = new ListBox();
            pictureBox1 = new PictureBox();
            toolStrip1 = new ToolStrip();
            toolStripLabelDeSerBIN = new ToolStripLabel();
            toolStripLabelSerBIN = new ToolStripLabel();
            toolStripLabelSerJSON = new ToolStripLabel();
            toolStripLabelDeSerJSON = new ToolStripLabel();
            cbKindOfProps = new PropertyGrid();
            listBox1 = new ListBox();
            bDeleteFigure = new Button();
            bReCreate = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(0, 27);
            listBox.Margin = new Padding(3, 2, 3, 2);
            listBox.Name = "listBox";
            listBox.Size = new Size(132, 109);
            listBox.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(138, 27);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(560, 525);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabelDeSerBIN, toolStripLabelSerBIN, toolStripLabelSerJSON, toolStripLabelDeSerJSON });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(974, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelDeSerBIN
            // 
            toolStripLabelDeSerBIN.Name = "toolStripLabelDeSerBIN";
            toolStripLabelDeSerBIN.Size = new Size(56, 22);
            toolStripLabelDeSerBIN.Text = "DeSerBIN";
            toolStripLabelDeSerBIN.Click += toolStripLabelDeSerBIN_Click;
            // 
            // toolStripLabelSerBIN
            // 
            toolStripLabelSerBIN.Name = "toolStripLabelSerBIN";
            toolStripLabelSerBIN.Size = new Size(42, 22);
            toolStripLabelSerBIN.Text = "SerBIN";
            toolStripLabelSerBIN.Click += toolStripLabelSerBIN_Click;
            // 
            // toolStripLabelSerJSON
            // 
            toolStripLabelSerJSON.Name = "toolStripLabelSerJSON";
            toolStripLabelSerJSON.Size = new Size(51, 22);
            toolStripLabelSerJSON.Text = "SerJSON";
            toolStripLabelSerJSON.Click += toolStripLabelSerJSON_Click;
            // 
            // toolStripLabelDeSerJSON
            // 
            toolStripLabelDeSerJSON.Name = "toolStripLabelDeSerJSON";
            toolStripLabelDeSerJSON.Size = new Size(65, 22);
            toolStripLabelDeSerJSON.Text = "DeSerJSON";
            toolStripLabelDeSerJSON.Click += toolStripLabelDeSerJSON_Click;
            // 
            // cbKindOfProps
            // 
            cbKindOfProps.Location = new Point(704, 219);
            cbKindOfProps.Name = "cbKindOfProps";
            cbKindOfProps.Size = new Size(258, 147);
            cbKindOfProps.TabIndex = 4;
            cbKindOfProps.SelectedGridItemChanged += cbKindOfProps_SelectedGridItemChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(703, 29);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(259, 184);
            listBox1.TabIndex = 5;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // bDeleteFigure
            // 
            bDeleteFigure.Location = new Point(838, 375);
            bDeleteFigure.Name = "bDeleteFigure";
            bDeleteFigure.Size = new Size(124, 29);
            bDeleteFigure.TabIndex = 6;
            bDeleteFigure.Text = "Удалить фигуру";
            bDeleteFigure.UseVisualStyleBackColor = true;
            bDeleteFigure.Click += bDeleteFigure_Click;
            // 
            // bReCreate
            // 
            bReCreate.Location = new Point(703, 375);
            bReCreate.Name = "bReCreate";
            bReCreate.Size = new Size(124, 29);
            bReCreate.TabIndex = 7;
            bReCreate.Text = "Перерисовать";
            bReCreate.UseVisualStyleBackColor = true;
            bReCreate.Click += bReCreate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 555);
            Controls.Add(bReCreate);
            Controls.Add(bDeleteFigure);
            Controls.Add(listBox1);
            Controls.Add(cbKindOfProps);
            Controls.Add(toolStrip1);
            Controls.Add(pictureBox1);
            Controls.Add(listBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Click += Form1_Click;
            MouseClick += Form1_MouseClick;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox;
        private PictureBox pictureBox1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabelDeSerBIN;
        private ToolStripLabel toolStripLabelSerBIN;
        private ToolStripLabel toolStripLabelSerJSON;
        private ToolStripLabel toolStripLabelDeSerJSON;
        private PropertyGrid cbKindOfProps;
        private ListBox listBox1;
        private Button bDeleteFigure;
        private Button bReCreate;
    }
}
