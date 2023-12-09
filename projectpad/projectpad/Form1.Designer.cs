namespace projectpad
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonProduct = new System.Windows.Forms.Button();
            this.buttonSalesOffer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Master";
            // 
            // buttonProduct
            // 
            this.buttonProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProduct.Location = new System.Drawing.Point(311, 76);
            this.buttonProduct.Name = "buttonProduct";
            this.buttonProduct.Size = new System.Drawing.Size(185, 40);
            this.buttonProduct.TabIndex = 1;
            this.buttonProduct.Text = "Product Transaction";
            this.buttonProduct.UseVisualStyleBackColor = true;
            this.buttonProduct.Click += new System.EventHandler(this.buttonProduct_Click);
            // 
            // buttonSalesOffer
            // 
            this.buttonSalesOffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalesOffer.Location = new System.Drawing.Point(311, 134);
            this.buttonSalesOffer.Name = "buttonSalesOffer";
            this.buttonSalesOffer.Size = new System.Drawing.Size(185, 40);
            this.buttonSalesOffer.TabIndex = 2;
            this.buttonSalesOffer.Text = "Sales Offer";
            this.buttonSalesOffer.UseVisualStyleBackColor = true;
            this.buttonSalesOffer.Click += new System.EventHandler(this.buttonSalesOffer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSalesOffer);
            this.Controls.Add(this.buttonProduct);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonProduct;
        private System.Windows.Forms.Button buttonSalesOffer;
    }
}

