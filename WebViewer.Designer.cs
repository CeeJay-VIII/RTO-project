
namespace Regional_Transport_Office__CodeBreakerz_
{
    partial class WebViewer
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.btnHome_webBrowser = new System.Windows.Forms.Button();
            this.btnExit_webBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(1, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(766, 445);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            // 
            // btnHome_webBrowser
            // 
            this.btnHome_webBrowser.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnHome_webBrowser.Location = new System.Drawing.Point(13, 454);
            this.btnHome_webBrowser.Name = "btnHome_webBrowser";
            this.btnHome_webBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnHome_webBrowser.TabIndex = 1;
            this.btnHome_webBrowser.Text = "Home";
            this.btnHome_webBrowser.UseVisualStyleBackColor = false;
            this.btnHome_webBrowser.Click += new System.EventHandler(this.btnHome_webBrowser_Click);
            // 
            // btnExit_webBrowser
            // 
            this.btnExit_webBrowser.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnExit_webBrowser.Location = new System.Drawing.Point(682, 454);
            this.btnExit_webBrowser.Name = "btnExit_webBrowser";
            this.btnExit_webBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnExit_webBrowser.TabIndex = 1;
            this.btnExit_webBrowser.Text = "Exit";
            this.btnExit_webBrowser.UseVisualStyleBackColor = false;
            this.btnExit_webBrowser.Click += new System.EventHandler(this.btnExit_webBrowser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "CodeBreakers</>";
            // 
            // WebViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 489);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit_webBrowser);
            this.Controls.Add(this.btnHome_webBrowser);
            this.Controls.Add(this.webBrowser);
            this.MaximizeBox = false;
            this.Name = "WebViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Trader Manual";
            this.Load += new System.EventHandler(this.WebViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button btnHome_webBrowser;
        private System.Windows.Forms.Button btnExit_webBrowser;
        private System.Windows.Forms.Label label1;
    }
}