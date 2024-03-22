namespace Producer_Consumer
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.producerLabel = new System.Windows.Forms.Label();
            this.consumerLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.producerState = new System.Windows.Forms.Label();
            this.consumerState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // producerLabel
            // 
            this.producerLabel.AutoSize = true;
            this.producerLabel.Location = new System.Drawing.Point(51, 43);
            this.producerLabel.Name = "producerLabel";
            this.producerLabel.Size = new System.Drawing.Size(50, 16);
            this.producerLabel.TabIndex = 0;
            this.producerLabel.Text = "Juanito";
            // 
            // consumerLabel
            // 
            this.consumerLabel.AutoSize = true;
            this.consumerLabel.Location = new System.Drawing.Point(698, 43);
            this.consumerLabel.Name = "consumerLabel";
            this.consumerLabel.Size = new System.Drawing.Size(57, 16);
            this.consumerLabel.TabIndex = 1;
            this.consumerLabel.Text = "Doble R";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(363, 202);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "empezar";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // producerState
            // 
            this.producerState.AutoSize = true;
            this.producerState.Location = new System.Drawing.Point(57, 97);
            this.producerState.Name = "producerState";
            this.producerState.Size = new System.Drawing.Size(44, 16);
            this.producerState.TabIndex = 3;
            this.producerState.Text = "label1";
            // 
            // consumerState
            // 
            this.consumerState.AutoSize = true;
            this.consumerState.Location = new System.Drawing.Point(698, 108);
            this.consumerState.Name = "consumerState";
            this.consumerState.Size = new System.Drawing.Size(44, 16);
            this.consumerState.TabIndex = 4;
            this.consumerState.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.consumerState);
            this.Controls.Add(this.producerState);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.consumerLabel);
            this.Controls.Add(this.producerLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label producerLabel;
        private System.Windows.Forms.Label consumerLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label producerState;
        private System.Windows.Forms.Label consumerState;
    }
}

