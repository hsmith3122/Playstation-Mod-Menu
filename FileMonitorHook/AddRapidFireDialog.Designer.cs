namespace FileMonitorHook
{
    partial class AddRapidFireDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pActivators = new System.Windows.Forms.Panel();
            this.dpadaGroup = new System.Windows.Forms.GroupBox();
            this.dpadaNE = new System.Windows.Forms.RadioButton();
            this.dpadaSE = new System.Windows.Forms.RadioButton();
            this.dpadaSW = new System.Windows.Forms.RadioButton();
            this.dpadaNW = new System.Windows.Forms.RadioButton();
            this.dpadaW = new System.Windows.Forms.RadioButton();
            this.dpadaS = new System.Windows.Forms.RadioButton();
            this.dpadaE = new System.Windows.Forms.RadioButton();
            this.dpadaNone = new System.Windows.Forms.PictureBox();
            this.dpadaN = new System.Windows.Forms.RadioButton();
            this.clbaBumpers = new System.Windows.Forms.CheckedListBox();
            this.clbaShapes = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dpadrGroup = new System.Windows.Forms.GroupBox();
            this.dpadrNE = new System.Windows.Forms.RadioButton();
            this.dpadrSE = new System.Windows.Forms.RadioButton();
            this.dpadrSW = new System.Windows.Forms.RadioButton();
            this.dpadrNW = new System.Windows.Forms.RadioButton();
            this.dpadrW = new System.Windows.Forms.RadioButton();
            this.dpadrS = new System.Windows.Forms.RadioButton();
            this.dpadrE = new System.Windows.Forms.RadioButton();
            this.dpadrNone = new System.Windows.Forms.PictureBox();
            this.dpadrN = new System.Windows.Forms.RadioButton();
            this.clbrBumpers = new System.Windows.Forms.CheckedListBox();
            this.clbrShapes = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.modName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.pActivators.SuspendLayout();
            this.dpadaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpadaNone)).BeginInit();
            this.panel1.SuspendLayout();
            this.dpadrGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpadrNone)).BeginInit();
            this.SuspendLayout();
            // 
            // pActivators
            // 
            this.pActivators.Controls.Add(this.dpadaGroup);
            this.pActivators.Controls.Add(this.clbaBumpers);
            this.pActivators.Controls.Add(this.clbaShapes);
            this.pActivators.Controls.Add(this.label2);
            this.pActivators.Controls.Add(this.label1);
            this.pActivators.Location = new System.Drawing.Point(12, 12);
            this.pActivators.Name = "pActivators";
            this.pActivators.Size = new System.Drawing.Size(335, 435);
            this.pActivators.TabIndex = 0;
            // 
            // dpadaGroup
            // 
            this.dpadaGroup.Controls.Add(this.dpadaNE);
            this.dpadaGroup.Controls.Add(this.dpadaSE);
            this.dpadaGroup.Controls.Add(this.dpadaSW);
            this.dpadaGroup.Controls.Add(this.dpadaNW);
            this.dpadaGroup.Controls.Add(this.dpadaW);
            this.dpadaGroup.Controls.Add(this.dpadaS);
            this.dpadaGroup.Controls.Add(this.dpadaE);
            this.dpadaGroup.Controls.Add(this.dpadaNone);
            this.dpadaGroup.Controls.Add(this.dpadaN);
            this.dpadaGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dpadaGroup.ForeColor = System.Drawing.Color.White;
            this.dpadaGroup.Location = new System.Drawing.Point(21, 226);
            this.dpadaGroup.Name = "dpadaGroup";
            this.dpadaGroup.Size = new System.Drawing.Size(292, 188);
            this.dpadaGroup.TabIndex = 4;
            this.dpadaGroup.TabStop = false;
            this.dpadaGroup.Text = "Directional Pad";
            // 
            // dpadaNE
            // 
            this.dpadaNE.AutoSize = true;
            this.dpadaNE.Location = new System.Drawing.Point(183, 43);
            this.dpadaNE.Name = "dpadaNE";
            this.dpadaNE.Size = new System.Drawing.Size(17, 16);
            this.dpadaNE.TabIndex = 8;
            this.dpadaNE.TabStop = true;
            this.dpadaNE.UseVisualStyleBackColor = true;
            this.dpadaNE.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadaSE
            // 
            this.dpadaSE.AutoSize = true;
            this.dpadaSE.Location = new System.Drawing.Point(183, 142);
            this.dpadaSE.Name = "dpadaSE";
            this.dpadaSE.Size = new System.Drawing.Size(17, 16);
            this.dpadaSE.TabIndex = 7;
            this.dpadaSE.TabStop = true;
            this.dpadaSE.UseVisualStyleBackColor = true;
            this.dpadaSE.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadaSW
            // 
            this.dpadaSW.AutoSize = true;
            this.dpadaSW.Location = new System.Drawing.Point(97, 142);
            this.dpadaSW.Name = "dpadaSW";
            this.dpadaSW.Size = new System.Drawing.Size(17, 16);
            this.dpadaSW.TabIndex = 6;
            this.dpadaSW.TabStop = true;
            this.dpadaSW.UseVisualStyleBackColor = true;
            this.dpadaSW.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadaNW
            // 
            this.dpadaNW.AutoSize = true;
            this.dpadaNW.Location = new System.Drawing.Point(97, 43);
            this.dpadaNW.Name = "dpadaNW";
            this.dpadaNW.Size = new System.Drawing.Size(17, 16);
            this.dpadaNW.TabIndex = 5;
            this.dpadaNW.TabStop = true;
            this.dpadaNW.UseVisualStyleBackColor = true;
            this.dpadaNW.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadaW
            // 
            this.dpadaW.AutoSize = true;
            this.dpadaW.Location = new System.Drawing.Point(74, 90);
            this.dpadaW.Name = "dpadaW";
            this.dpadaW.Size = new System.Drawing.Size(17, 16);
            this.dpadaW.TabIndex = 4;
            this.dpadaW.TabStop = true;
            this.dpadaW.UseVisualStyleBackColor = true;
            this.dpadaW.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadaS
            // 
            this.dpadaS.AutoSize = true;
            this.dpadaS.Location = new System.Drawing.Point(137, 152);
            this.dpadaS.Name = "dpadaS";
            this.dpadaS.Size = new System.Drawing.Size(17, 16);
            this.dpadaS.TabIndex = 3;
            this.dpadaS.TabStop = true;
            this.dpadaS.UseVisualStyleBackColor = true;
            this.dpadaS.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadaE
            // 
            this.dpadaE.AutoSize = true;
            this.dpadaE.Location = new System.Drawing.Point(197, 90);
            this.dpadaE.Name = "dpadaE";
            this.dpadaE.Size = new System.Drawing.Size(17, 16);
            this.dpadaE.TabIndex = 2;
            this.dpadaE.TabStop = true;
            this.dpadaE.UseVisualStyleBackColor = true;
            this.dpadaE.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadaNone
            // 
            this.dpadaNone.Image = global::FileMonitorHook.Properties.Resources.Arrows_eight_long;
            this.dpadaNone.Location = new System.Drawing.Point(97, 53);
            this.dpadaNone.Name = "dpadaNone";
            this.dpadaNone.Size = new System.Drawing.Size(94, 93);
            this.dpadaNone.TabIndex = 1;
            this.dpadaNone.TabStop = false;
            this.dpadaNone.Click += new System.EventHandler(this.dpadNone_Click);
            // 
            // dpadaN
            // 
            this.dpadaN.AutoSize = true;
            this.dpadaN.Location = new System.Drawing.Point(137, 31);
            this.dpadaN.Name = "dpadaN";
            this.dpadaN.Size = new System.Drawing.Size(17, 16);
            this.dpadaN.TabIndex = 0;
            this.dpadaN.TabStop = true;
            this.dpadaN.UseVisualStyleBackColor = true;
            this.dpadaN.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // clbaBumpers
            // 
            this.clbaBumpers.FormattingEnabled = true;
            this.clbaBumpers.Items.AddRange(new object[] {
            "L1",
            "L2",
            "L3",
            "R1",
            "R2",
            "R3"});
            this.clbaBumpers.Location = new System.Drawing.Point(189, 98);
            this.clbaBumpers.Name = "clbaBumpers";
            this.clbaBumpers.Size = new System.Drawing.Size(124, 106);
            this.clbaBumpers.TabIndex = 3;
            // 
            // clbaShapes
            // 
            this.clbaShapes.FormattingEnabled = true;
            this.clbaShapes.Items.AddRange(new object[] {
            "Triangle",
            "Circle",
            "Square",
            "Cross",
            "Options",
            "Touchpad"});
            this.clbaShapes.Location = new System.Drawing.Point(21, 98);
            this.clbaShapes.Name = "clbaShapes";
            this.clbaShapes.Size = new System.Drawing.Size(124, 106);
            this.clbaShapes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR-A II", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.MaximumSize = new System.Drawing.Size(300, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "When held, these keys will activate Rapid Fire Mode for the others";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Activators";
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.White;
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok.Location = new System.Drawing.Point(600, 536);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(90, 32);
            this.ok.TabIndex = 1;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dpadrGroup);
            this.panel1.Controls.Add(this.clbrBumpers);
            this.panel1.Controls.Add(this.clbrShapes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(355, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 435);
            this.panel1.TabIndex = 5;
            // 
            // dpadrGroup
            // 
            this.dpadrGroup.Controls.Add(this.dpadrNE);
            this.dpadrGroup.Controls.Add(this.dpadrSE);
            this.dpadrGroup.Controls.Add(this.dpadrSW);
            this.dpadrGroup.Controls.Add(this.dpadrNW);
            this.dpadrGroup.Controls.Add(this.dpadrW);
            this.dpadrGroup.Controls.Add(this.dpadrS);
            this.dpadrGroup.Controls.Add(this.dpadrE);
            this.dpadrGroup.Controls.Add(this.dpadrNone);
            this.dpadrGroup.Controls.Add(this.dpadrN);
            this.dpadrGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dpadrGroup.ForeColor = System.Drawing.Color.White;
            this.dpadrGroup.Location = new System.Drawing.Point(21, 226);
            this.dpadrGroup.Name = "dpadrGroup";
            this.dpadrGroup.Size = new System.Drawing.Size(292, 188);
            this.dpadrGroup.TabIndex = 4;
            this.dpadrGroup.TabStop = false;
            this.dpadrGroup.Text = "Directional Pad";
            // 
            // dpadrNE
            // 
            this.dpadrNE.AutoSize = true;
            this.dpadrNE.Location = new System.Drawing.Point(183, 43);
            this.dpadrNE.Name = "dpadrNE";
            this.dpadrNE.Size = new System.Drawing.Size(17, 16);
            this.dpadrNE.TabIndex = 8;
            this.dpadrNE.TabStop = true;
            this.dpadrNE.UseVisualStyleBackColor = true;
            this.dpadrNE.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadrSE
            // 
            this.dpadrSE.AutoSize = true;
            this.dpadrSE.Location = new System.Drawing.Point(183, 142);
            this.dpadrSE.Name = "dpadrSE";
            this.dpadrSE.Size = new System.Drawing.Size(17, 16);
            this.dpadrSE.TabIndex = 7;
            this.dpadrSE.TabStop = true;
            this.dpadrSE.UseVisualStyleBackColor = true;
            this.dpadrSE.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadrSW
            // 
            this.dpadrSW.AutoSize = true;
            this.dpadrSW.Location = new System.Drawing.Point(97, 142);
            this.dpadrSW.Name = "dpadrSW";
            this.dpadrSW.Size = new System.Drawing.Size(17, 16);
            this.dpadrSW.TabIndex = 6;
            this.dpadrSW.TabStop = true;
            this.dpadrSW.UseVisualStyleBackColor = true;
            this.dpadrSW.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadrNW
            // 
            this.dpadrNW.AutoSize = true;
            this.dpadrNW.Location = new System.Drawing.Point(97, 43);
            this.dpadrNW.Name = "dpadrNW";
            this.dpadrNW.Size = new System.Drawing.Size(17, 16);
            this.dpadrNW.TabIndex = 5;
            this.dpadrNW.TabStop = true;
            this.dpadrNW.UseVisualStyleBackColor = true;
            this.dpadrNW.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadrW
            // 
            this.dpadrW.AutoSize = true;
            this.dpadrW.Location = new System.Drawing.Point(74, 90);
            this.dpadrW.Name = "dpadrW";
            this.dpadrW.Size = new System.Drawing.Size(17, 16);
            this.dpadrW.TabIndex = 4;
            this.dpadrW.TabStop = true;
            this.dpadrW.UseVisualStyleBackColor = true;
            this.dpadrW.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadrS
            // 
            this.dpadrS.AutoSize = true;
            this.dpadrS.Location = new System.Drawing.Point(137, 152);
            this.dpadrS.Name = "dpadrS";
            this.dpadrS.Size = new System.Drawing.Size(17, 16);
            this.dpadrS.TabIndex = 3;
            this.dpadrS.TabStop = true;
            this.dpadrS.UseVisualStyleBackColor = true;
            this.dpadrS.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadrE
            // 
            this.dpadrE.AutoSize = true;
            this.dpadrE.Location = new System.Drawing.Point(197, 90);
            this.dpadrE.Name = "dpadrE";
            this.dpadrE.Size = new System.Drawing.Size(17, 16);
            this.dpadrE.TabIndex = 2;
            this.dpadrE.TabStop = true;
            this.dpadrE.UseVisualStyleBackColor = true;
            this.dpadrE.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // dpadrNone
            // 
            this.dpadrNone.Image = global::FileMonitorHook.Properties.Resources.Arrows_eight_long;
            this.dpadrNone.Location = new System.Drawing.Point(97, 53);
            this.dpadrNone.Name = "dpadrNone";
            this.dpadrNone.Size = new System.Drawing.Size(94, 93);
            this.dpadrNone.TabIndex = 1;
            this.dpadrNone.TabStop = false;
            this.dpadrNone.Click += new System.EventHandler(this.dpadNone_Click);
            // 
            // dpadrN
            // 
            this.dpadrN.AutoSize = true;
            this.dpadrN.Location = new System.Drawing.Point(137, 31);
            this.dpadrN.Name = "dpadrN";
            this.dpadrN.Size = new System.Drawing.Size(17, 16);
            this.dpadrN.TabIndex = 0;
            this.dpadrN.TabStop = true;
            this.dpadrN.UseVisualStyleBackColor = true;
            this.dpadrN.CheckedChanged += new System.EventHandler(this.dpad_CheckedChanged);
            // 
            // clbrBumpers
            // 
            this.clbrBumpers.FormattingEnabled = true;
            this.clbrBumpers.Items.AddRange(new object[] {
            "L1",
            "L2",
            "L3",
            "R1",
            "R2",
            "R3"});
            this.clbrBumpers.Location = new System.Drawing.Point(189, 98);
            this.clbrBumpers.Name = "clbrBumpers";
            this.clbrBumpers.Size = new System.Drawing.Size(124, 106);
            this.clbrBumpers.TabIndex = 3;
            // 
            // clbrShapes
            // 
            this.clbrShapes.FormattingEnabled = true;
            this.clbrShapes.Items.AddRange(new object[] {
            "Triangle",
            "Circle",
            "Square",
            "Cross",
            "Options",
            "Touchpad"});
            this.clbrShapes.Location = new System.Drawing.Point(21, 98);
            this.clbrShapes.Name = "clbrShapes";
            this.clbrShapes.Size = new System.Drawing.Size(124, 106);
            this.clbrShapes.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR-A II", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(18, 41);
            this.label3.MaximumSize = new System.Drawing.Size(300, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 45);
            this.label3.TabIndex = 1;
            this.label3.Text = "These keys will be rapidly tapped when all of the activator keys are held";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Rapid Fire Keys";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("OCR-A II", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(29, 463);
            this.label5.MaximumSize = new System.Drawing.Size(325, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 45);
            this.label5.TabIndex = 6;
            this.label5.Text = "For \"crouch spamming\", activate with your \"shoot\" button, and rapid fire your \"cr" +
    "ouch\" button";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("OCR-A II", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(352, 463);
            this.label6.MaximumSize = new System.Drawing.Size(325, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(319, 45);
            this.label6.TabIndex = 7;
            this.label6.Text = "Turn semi-automatic weapons into full auto by choosing your \"shoot\" button as bot" +
    "h the activator and rapid fire keys";
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(32, 536);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(90, 32);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            // 
            // modName
            // 
            this.modName.Location = new System.Drawing.Point(389, 541);
            this.modName.MaxLength = 30;
            this.modName.Name = "modName";
            this.modName.Size = new System.Drawing.Size(205, 22);
            this.modName.TabIndex = 9;
            this.modName.TextChanged += new System.EventHandler(this.modName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("OCR B MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(307, 544);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Name: ";
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.delete.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(143, 536);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(90, 32);
            this.delete.TabIndex = 10;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Visible = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // AddRapidFireDialog
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(700, 580);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.modName);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.pActivators);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 580);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 580);
            this.Name = "AddRapidFireDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.pActivators.ResumeLayout(false);
            this.pActivators.PerformLayout();
            this.dpadaGroup.ResumeLayout(false);
            this.dpadaGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpadaNone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.dpadrGroup.ResumeLayout(false);
            this.dpadrGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpadrNone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pActivators;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbaBumpers;
        private System.Windows.Forms.CheckedListBox clbaShapes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.GroupBox dpadaGroup;
        private System.Windows.Forms.PictureBox dpadaNone;
        private System.Windows.Forms.RadioButton dpadaN;
        private System.Windows.Forms.RadioButton dpadaNE;
        private System.Windows.Forms.RadioButton dpadaSE;
        private System.Windows.Forms.RadioButton dpadaSW;
        private System.Windows.Forms.RadioButton dpadaNW;
        private System.Windows.Forms.RadioButton dpadaW;
        private System.Windows.Forms.RadioButton dpadaS;
        private System.Windows.Forms.RadioButton dpadaE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox dpadrGroup;
        private System.Windows.Forms.RadioButton dpadrNE;
        private System.Windows.Forms.RadioButton dpadrSE;
        private System.Windows.Forms.RadioButton dpadrSW;
        private System.Windows.Forms.RadioButton dpadrNW;
        private System.Windows.Forms.RadioButton dpadrW;
        private System.Windows.Forms.RadioButton dpadrS;
        private System.Windows.Forms.RadioButton dpadrE;
        private System.Windows.Forms.PictureBox dpadrNone;
        private System.Windows.Forms.RadioButton dpadrN;
        private System.Windows.Forms.CheckedListBox clbrBumpers;
        private System.Windows.Forms.CheckedListBox clbrShapes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox modName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button delete;
    }
}