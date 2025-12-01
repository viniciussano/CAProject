namespace CAProject
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.createReservationButton = new System.Windows.Forms.Button();
            this.deleteReservationButton = new System.Windows.Forms.Button();
            this.updateReservationButton = new System.Windows.Forms.Button();
            this.searchReservationButton = new System.Windows.Forms.Button();
            this.guestName = new System.Windows.Forms.TextBox();
            this.guestEmail = new System.Windows.Forms.TextBox();
            this.phoneNumber = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkin = new System.Windows.Forms.DateTimePicker();
            this.checkout = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.one = new System.Windows.Forms.RadioButton();
            this.two = new System.Windows.Forms.RadioButton();
            this.three = new System.Windows.Forms.RadioButton();
            this.four = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.roomType = new System.Windows.Forms.DomainUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.totalRate = new System.Windows.Forms.TextBox();
            this.searchReservation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.selectRoomNo = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(865, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 99);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel Reservation System";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(57, 706);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1820, 277);
            this.listBox1.TabIndex = 1;
            // 
            // createReservationButton
            // 
            this.createReservationButton.Location = new System.Drawing.Point(494, 668);
            this.createReservationButton.Name = "createReservationButton";
            this.createReservationButton.Size = new System.Drawing.Size(147, 23);
            this.createReservationButton.TabIndex = 2;
            this.createReservationButton.Text = "Create Reservation";
            this.createReservationButton.UseVisualStyleBackColor = true;
            this.createReservationButton.Click += new System.EventHandler(this.createReservationButton_Click);
            // 
            // deleteReservationButton
            // 
            this.deleteReservationButton.Location = new System.Drawing.Point(1299, 284);
            this.deleteReservationButton.Name = "deleteReservationButton";
            this.deleteReservationButton.Size = new System.Drawing.Size(147, 23);
            this.deleteReservationButton.TabIndex = 3;
            this.deleteReservationButton.Text = "Delete Reservation";
            this.deleteReservationButton.UseVisualStyleBackColor = true;
            this.deleteReservationButton.Click += new System.EventHandler(this.deleteReservationButton_Click);
            // 
            // updateReservationButton
            // 
            this.updateReservationButton.Location = new System.Drawing.Point(1299, 230);
            this.updateReservationButton.Name = "updateReservationButton";
            this.updateReservationButton.Size = new System.Drawing.Size(147, 23);
            this.updateReservationButton.TabIndex = 4;
            this.updateReservationButton.Text = "Update Reservation";
            this.updateReservationButton.UseVisualStyleBackColor = true;
            this.updateReservationButton.Click += new System.EventHandler(this.updateReservationButton_Click);
            // 
            // searchReservationButton
            // 
            this.searchReservationButton.Location = new System.Drawing.Point(1299, 176);
            this.searchReservationButton.Name = "searchReservationButton";
            this.searchReservationButton.Size = new System.Drawing.Size(147, 23);
            this.searchReservationButton.TabIndex = 5;
            this.searchReservationButton.Text = "Search Reservation";
            this.searchReservationButton.UseVisualStyleBackColor = true;
            this.searchReservationButton.Click += new System.EventHandler(this.searchReservationButton_Click);
            // 
            // guestName
            // 
            this.guestName.Location = new System.Drawing.Point(494, 128);
            this.guestName.Name = "guestName";
            this.guestName.Size = new System.Drawing.Size(362, 20);
            this.guestName.TabIndex = 6;
            // 
            // guestEmail
            // 
            this.guestEmail.Location = new System.Drawing.Point(494, 193);
            this.guestEmail.Name = "guestEmail";
            this.guestEmail.Size = new System.Drawing.Size(362, 20);
            this.guestEmail.TabIndex = 7;
            // 
            // phoneNumber
            // 
            this.phoneNumber.Location = new System.Drawing.Point(494, 266);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(362, 20);
            this.phoneNumber.TabIndex = 8;
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(494, 326);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(362, 20);
            this.address.TabIndex = 9;
            this.address.Click += new System.EventHandler(this.address_TextChanged);
            this.address.TextChanged += new System.EventHandler(this.address_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Check-in Date";
            this.label5.Click += new System.EventHandler(this.address_TextChanged);
            // 
            // checkin
            // 
            this.checkin.Location = new System.Drawing.Point(494, 437);
            this.checkin.MaxDate = new System.DateTime(2028, 12, 31, 0, 0, 0, 0);
            this.checkin.MinDate = new System.DateTime(2025, 12, 1, 0, 0, 0, 0);
            this.checkin.Name = "checkin";
            this.checkin.Size = new System.Drawing.Size(200, 20);
            this.checkin.TabIndex = 15;
            // 
            // checkout
            // 
            this.checkout.Location = new System.Drawing.Point(494, 500);
            this.checkout.MaxDate = new System.DateTime(2028, 12, 31, 0, 0, 0, 0);
            this.checkout.MinDate = new System.DateTime(2025, 12, 1, 0, 0, 0, 0);
            this.checkout.Name = "checkout";
            this.checkout.Size = new System.Drawing.Size(200, 20);
            this.checkout.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 500);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Check-out Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total number of guests";
            // 
            // one
            // 
            this.one.AutoSize = true;
            this.one.Checked = true;
            this.one.Location = new System.Drawing.Point(494, 383);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(31, 17);
            this.one.TabIndex = 19;
            this.one.TabStop = true;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = true;
            // 
            // two
            // 
            this.two.AutoSize = true;
            this.two.Location = new System.Drawing.Point(542, 383);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(31, 17);
            this.two.TabIndex = 20;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            // 
            // three
            // 
            this.three.AutoSize = true;
            this.three.Location = new System.Drawing.Point(590, 383);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(31, 17);
            this.three.TabIndex = 21;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            // 
            // four
            // 
            this.four.AutoSize = true;
            this.four.Location = new System.Drawing.Point(640, 383);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(31, 17);
            this.four.TabIndex = 22;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Guest Name";
            // 
            // roomType
            // 
            this.roomType.Items.Add("Single Room");
            this.roomType.Items.Add("Double Room");
            this.roomType.Items.Add("Triple Room");
            this.roomType.Items.Add("Family Room");
            this.roomType.Location = new System.Drawing.Point(494, 561);
            this.roomType.Name = "roomType";
            this.roomType.Size = new System.Drawing.Size(120, 20);
            this.roomType.TabIndex = 24;
            this.roomType.Text = "Choose Room";
            this.roomType.SelectedItemChanged += new System.EventHandler(this.roomType_SelectedItemChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(361, 563);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Select room type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(389, 613);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Total Rate";
            // 
            // totalRate
            // 
            this.totalRate.Location = new System.Drawing.Point(494, 613);
            this.totalRate.Name = "totalRate";
            this.totalRate.Size = new System.Drawing.Size(120, 20);
            this.totalRate.TabIndex = 27;
            // 
            // searchReservation
            // 
            this.searchReservation.Location = new System.Drawing.Point(1257, 128);
            this.searchReservation.Name = "searchReservation";
            this.searchReservation.Size = new System.Drawing.Size(262, 20);
            this.searchReservation.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1127, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Enter Guest\'s Name";
            // 
            // selectRoomNo
            // 
            this.selectRoomNo.FormattingEnabled = true;
            this.selectRoomNo.Location = new System.Drawing.Point(783, 536);
            this.selectRoomNo.Name = "selectRoomNo";
            this.selectRoomNo.Size = new System.Drawing.Size(140, 95);
            this.selectRoomNo.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(794, 505);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Select Room Number";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1340, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 63);
            this.button1.TabIndex = 33;
            this.button1.Text = "Close System";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1910, 1011);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.selectRoomNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.searchReservation);
            this.Controls.Add(this.totalRate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.roomType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.four);
            this.Controls.Add(this.three);
            this.Controls.Add(this.two);
            this.Controls.Add(this.one);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkout);
            this.Controls.Add(this.checkin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.address);
            this.Controls.Add(this.phoneNumber);
            this.Controls.Add(this.guestEmail);
            this.Controls.Add(this.guestName);
            this.Controls.Add(this.searchReservationButton);
            this.Controls.Add(this.updateReservationButton);
            this.Controls.Add(this.deleteReservationButton);
            this.Controls.Add(this.createReservationButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Hotel Reservation System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button createReservationButton;
        private System.Windows.Forms.Button deleteReservationButton;
        private System.Windows.Forms.Button updateReservationButton;
        private System.Windows.Forms.Button searchReservationButton;
        private System.Windows.Forms.TextBox guestName;
        private System.Windows.Forms.TextBox guestEmail;
        private System.Windows.Forms.TextBox phoneNumber;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker checkin;
        private System.Windows.Forms.DateTimePicker checkout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton one;
        private System.Windows.Forms.RadioButton two;
        private System.Windows.Forms.RadioButton three;
        private System.Windows.Forms.RadioButton four;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DomainUpDown roomType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox totalRate;
        private System.Windows.Forms.TextBox searchReservation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox selectRoomNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
    }
}

