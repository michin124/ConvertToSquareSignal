namespace TestKnobControl
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.knobControl4 = new KnobControl.KnobControl();
            this.knobControl3 = new KnobControl.KnobControl();
            this.knobControl2 = new KnobControl.KnobControl();
            this.knobControl1 = new KnobControl.KnobControl();
            this.SuspendLayout();
            // 
            // knobControl4
            // 
            this.knobControl4.DrawDivInside = true;
            this.knobControl4.EndAngle = 360F;
            this.knobControl4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobControl4.KnobBackColor = System.Drawing.Color.LightCoral;
            this.knobControl4.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.circle;
            this.knobControl4.LargeChange = 5;
            this.knobControl4.Location = new System.Drawing.Point(704, 31);
            this.knobControl4.Margin = new System.Windows.Forms.Padding(4);
            this.knobControl4.Maximum = 10;
            this.knobControl4.Minimum = 0;
            this.knobControl4.Name = "knobControl4";
            this.knobControl4.PointerColor = System.Drawing.Color.White;
            this.knobControl4.ScaleColor = System.Drawing.Color.Black;
            this.knobControl4.ScaleDivisions = 11;
            this.knobControl4.ScaleFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobControl4.ScaleFontAutoSize = false;
            this.knobControl4.ScaleSubDivisions = 4;
            this.knobControl4.ShowLargeScale = true;
            this.knobControl4.ShowSmallScale = false;
            this.knobControl4.Size = new System.Drawing.Size(200, 200);
            this.knobControl4.SmallChange = 1;
            this.knobControl4.StartAngle = 180F;
            this.knobControl4.TabIndex = 3;
            this.knobControl4.Value = 3;
            // 
            // knobControl3
            // 
            this.knobControl3.EndAngle = 405F;
            this.knobControl3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobControl3.KnobBackColor = System.Drawing.Color.White;
            this.knobControl3.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line;
            this.knobControl3.LargeChange = 5;
            this.knobControl3.Location = new System.Drawing.Point(484, 31);
            this.knobControl3.Margin = new System.Windows.Forms.Padding(4);
            this.knobControl3.Maximum = 100;
            this.knobControl3.Minimum = 0;
            this.knobControl3.Name = "knobControl3";
            this.knobControl3.PointerColor = System.Drawing.Color.SlateBlue;
            this.knobControl3.ScaleColor = System.Drawing.Color.Black;
            this.knobControl3.ScaleDivisions = 11;
            this.knobControl3.ScaleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knobControl3.ScaleFontAutoSize = false;
            this.knobControl3.ScaleSubDivisions = 1;
            this.knobControl3.ShowLargeScale = true;
            this.knobControl3.ShowSmallScale = true;
            this.knobControl3.Size = new System.Drawing.Size(200, 200);
            this.knobControl3.SmallChange = 1;
            this.knobControl3.StartAngle = 135F;
            this.knobControl3.TabIndex = 2;
            this.knobControl3.Value = 0;
            // 
            // knobControl2
            // 
            this.knobControl2.EndAngle = 440F;
            this.knobControl2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobControl2.KnobBackColor = System.Drawing.Color.Black;
            this.knobControl2.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.circle;
            this.knobControl2.LargeChange = 5;
            this.knobControl2.Location = new System.Drawing.Point(252, 31);
            this.knobControl2.Margin = new System.Windows.Forms.Padding(4);
            this.knobControl2.Maximum = 100;
            this.knobControl2.Minimum = -100;
            this.knobControl2.Name = "knobControl2";
            this.knobControl2.PointerColor = System.Drawing.Color.SlateBlue;
            this.knobControl2.ScaleColor = System.Drawing.Color.White;
            this.knobControl2.ScaleDivisions = 21;
            this.knobControl2.ScaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.knobControl2.ScaleSubDivisions = 4;
            this.knobControl2.ShowLargeScale = true;
            this.knobControl2.ShowSmallScale = false;
            this.knobControl2.Size = new System.Drawing.Size(200, 200);
            this.knobControl2.SmallChange = 1;
            this.knobControl2.StartAngle = 100F;
            this.knobControl2.TabIndex = 1;
            this.knobControl2.Value = -30;
            // 
            // knobControl1
            // 
            this.knobControl1.EndAngle = 405F;
            this.knobControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobControl1.KnobBackColor = System.Drawing.Color.DarkGray;
            this.knobControl1.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line;
            this.knobControl1.LargeChange = 5;
            this.knobControl1.Location = new System.Drawing.Point(25, 31);
            this.knobControl1.Margin = new System.Windows.Forms.Padding(4);
            this.knobControl1.Maximum = 100;
            this.knobControl1.Minimum = 0;
            this.knobControl1.Name = "knobControl1";
            this.knobControl1.PointerColor = System.Drawing.Color.RoyalBlue;
            this.knobControl1.ScaleColor = System.Drawing.Color.White;
            this.knobControl1.ScaleDivisions = 11;
            this.knobControl1.ScaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.knobControl1.ScaleSubDivisions = 4;
            this.knobControl1.ShowLargeScale = true;
            this.knobControl1.ShowSmallScale = false;
            this.knobControl1.Size = new System.Drawing.Size(200, 200);
            this.knobControl1.SmallChange = 1;
            this.knobControl1.StartAngle = 180F;
            this.knobControl1.TabIndex = 0;
            this.knobControl1.Value = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(940, 254);
            this.Controls.Add(this.knobControl4);
            this.Controls.Add(this.knobControl3);
            this.Controls.Add(this.knobControl2);
            this.Controls.Add(this.knobControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "KnobControl Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private KnobControl.KnobControl knobControl1;
        private KnobControl.KnobControl knobControl2;
        private KnobControl.KnobControl knobControl3;
        private KnobControl.KnobControl knobControl4;
    }
}

