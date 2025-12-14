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
            this.closeButton = new System.Windows.Forms.Button();
            this.listAllReservationsButton = new System.Windows.Forms.Button();
            this.sortByCheckInButton = new System.Windows.Forms.Button();
            this.sortByNameButton = new System.Windows.Forms.Button();
            this.clearSearchButton = new System.Windows.Forms.Button();
            this.clearForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1153, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 99);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel Reservation System";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(76, 869);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(2425, 340);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // createReservationButton
            // 
            this.createReservationButton.Location = new System.Drawing.Point(659, 822);
            this.createReservationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createReservationButton.Name = "createReservationButton";
            this.createReservationButton.Size = new System.Drawing.Size(196, 28);
            this.createReservationButton.TabIndex = 2;
            this.createReservationButton.Text = "Create Reservation";
            this.createReservationButton.UseVisualStyleBackColor = true;
            this.createReservationButton.Click += new System.EventHandler(this.createReservationButton_Click);
            // 
            // deleteReservationButton
            // 
            this.deleteReservationButton.Location = new System.Drawing.Point(1732, 350);
            this.deleteReservationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteReservationButton.Name = "deleteReservationButton";
            this.deleteReservationButton.Size = new System.Drawing.Size(196, 28);
            this.deleteReservationButton.TabIndex = 3;
            this.deleteReservationButton.Text = "Delete Reservation";
            this.deleteReservationButton.UseVisualStyleBackColor = true;
            this.deleteReservationButton.Click += new System.EventHandler(this.deleteReservationButton_Click);
            // 
            // updateReservationButton
            // 
            this.updateReservationButton.Location = new System.Drawing.Point(1732, 283);
            this.updateReservationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.updateReservationButton.Name = "updateReservationButton";
            this.updateReservationButton.Size = new System.Drawing.Size(196, 28);
            this.updateReservationButton.TabIndex = 4;
            this.updateReservationButton.Text = "Update Reservation";
            this.updateReservationButton.UseVisualStyleBackColor = true;
            this.updateReservationButton.Click += new System.EventHandler(this.updateReservationButton_Click);
            // 
            // searchReservationButton
            // 
            this.searchReservationButton.Location = new System.Drawing.Point(1732, 217);
            this.searchReservationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchReservationButton.Name = "searchReservationButton";
            this.searchReservationButton.Size = new System.Drawing.Size(196, 28);
            this.searchReservationButton.TabIndex = 5;
            this.searchReservationButton.Text = "Search Reservation";
            this.searchReservationButton.UseVisualStyleBackColor = true;
            this.searchReservationButton.Click += new System.EventHandler(this.searchReservationButton_Click);
            // 
            // guestName
            // 
            this.guestName.Location = new System.Drawing.Point(659, 158);
            this.guestName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guestName.Name = "guestName";
            this.guestName.Size = new System.Drawing.Size(481, 22);
            this.guestName.TabIndex = 6;
            // 
            // guestEmail
            // 
            this.guestEmail.Location = new System.Drawing.Point(659, 238);
            this.guestEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guestEmail.Name = "guestEmail";
            this.guestEmail.Size = new System.Drawing.Size(481, 22);
            this.guestEmail.TabIndex = 7;
            // 
            // phoneNumber
            // 
            this.phoneNumber.Location = new System.Drawing.Point(659, 327);
            this.phoneNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(481, 22);
            this.phoneNumber.TabIndex = 8;
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(659, 401);
            this.address.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(481, 22);
            this.address.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 246);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 331);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 405);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 538);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Check-in Date";
            // 
            // checkin
            // 
            this.checkin.Location = new System.Drawing.Point(659, 538);
            this.checkin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkin.MaxDate = new System.DateTime(2028, 12, 31, 0, 0, 0, 0);
            this.checkin.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.checkin.Name = "checkin";
            this.checkin.Size = new System.Drawing.Size(265, 22);
            this.checkin.TabIndex = 15;
            this.checkin.ValueChanged += new System.EventHandler(this.checkin_ValueChanged);
            // 
            // checkout
            // 
            this.checkout.Location = new System.Drawing.Point(659, 615);
            this.checkout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkout.MaxDate = new System.DateTime(2028, 12, 31, 0, 0, 0, 0);
            this.checkout.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.checkout.Name = "checkout";
            this.checkout.Size = new System.Drawing.Size(265, 22);
            this.checkout.TabIndex = 16;
            this.checkout.ValueChanged += new System.EventHandler(this.checkout_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 615);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Check-out Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 474);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total number of guests";
            // 
            // one
            // 
            this.one.AutoSize = true;
            this.one.Checked = true;
            this.one.Location = new System.Drawing.Point(659, 471);
            this.one.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(32, 20);
            this.one.TabIndex = 19;
            this.one.TabStop = true;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = true;
            // 
            // two
            // 
            this.two.AutoSize = true;
            this.two.Location = new System.Drawing.Point(723, 471);
            this.two.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(32, 20);
            this.two.TabIndex = 20;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            // 
            // three
            // 
            this.three.AutoSize = true;
            this.three.Location = new System.Drawing.Point(787, 471);
            this.three.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(32, 20);
            this.three.TabIndex = 21;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            // 
            // four
            // 
            this.four.AutoSize = true;
            this.four.Location = new System.Drawing.Point(853, 471);
            this.four.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(32, 20);
            this.four.TabIndex = 22;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(507, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Guest Name";
            // 
            // roomType
            // 
            this.roomType.Items.Add("Single Room");
            this.roomType.Items.Add("Double Room");
            this.roomType.Items.Add("Triple Room");
            this.roomType.Items.Add("Family Room");
            this.roomType.Location = new System.Drawing.Point(659, 690);
            this.roomType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.roomType.Name = "roomType";
            this.roomType.Size = new System.Drawing.Size(160, 22);
            this.roomType.TabIndex = 24;
            this.roomType.Text = "Choose Room";
            this.roomType.SelectedItemChanged += new System.EventHandler(this.roomType_SelectedItemChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(481, 693);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Select room type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(519, 754);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Total Rate";
            // 
            // totalRate
            // 
            this.totalRate.Location = new System.Drawing.Point(659, 754);
            this.totalRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.totalRate.Name = "totalRate";
            this.totalRate.Size = new System.Drawing.Size(159, 22);
            this.totalRate.TabIndex = 27;
            // 
            // searchReservation
            // 
            this.searchReservation.Location = new System.Drawing.Point(1676, 158);
            this.searchReservation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchReservation.Name = "searchReservation";
            this.searchReservation.Size = new System.Drawing.Size(348, 22);
            this.searchReservation.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1469, 164);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 16);
            this.label11.TabIndex = 30;
            this.label11.Text = "Enter Reservation Number";
            // 
            // selectRoomNo
            // 
            this.selectRoomNo.FormattingEnabled = true;
            this.selectRoomNo.ItemHeight = 16;
            this.selectRoomNo.Location = new System.Drawing.Point(1029, 630);
            this.selectRoomNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectRoomNo.Name = "selectRoomNo";
            this.selectRoomNo.Size = new System.Drawing.Size(305, 148);
            this.selectRoomNo.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1099, 602);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "Select Room Number";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // closeButton
            // 
            this.closeButton.CausesValidation = false;
            this.closeButton.Location = new System.Drawing.Point(2219, 702);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(93, 78);
            this.closeButton.TabIndex = 33;
            this.closeButton.Text = "Close System";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // listAllReservationsButton
            // 
            this.listAllReservationsButton.Location = new System.Drawing.Point(1732, 471);
            this.listAllReservationsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listAllReservationsButton.Name = "listAllReservationsButton";
            this.listAllReservationsButton.Size = new System.Drawing.Size(204, 49);
            this.listAllReservationsButton.TabIndex = 34;
            this.listAllReservationsButton.Text = "List All Reservations";
            this.listAllReservationsButton.UseVisualStyleBackColor = true;
            this.listAllReservationsButton.Click += new System.EventHandler(this.listAllReservationsButton_Click);
            // 
            // sortByCheckInButton
            // 
            this.sortByCheckInButton.Location = new System.Drawing.Point(1756, 668);
            this.sortByCheckInButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sortByCheckInButton.Name = "sortByCheckInButton";
            this.sortByCheckInButton.Size = new System.Drawing.Size(152, 65);
            this.sortByCheckInButton.TabIndex = 35;
            this.sortByCheckInButton.Text = "Sort by Check-in Date";
            this.sortByCheckInButton.UseVisualStyleBackColor = true;
            this.sortByCheckInButton.Click += new System.EventHandler(this.sortByCheckInButton_Click);
            // 
            // sortByNameButton
            // 
            this.sortByNameButton.Location = new System.Drawing.Point(1756, 560);
            this.sortByNameButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sortByNameButton.Name = "sortByNameButton";
            this.sortByNameButton.Size = new System.Drawing.Size(152, 78);
            this.sortByNameButton.TabIndex = 36;
            this.sortByNameButton.Text = "Sort By Name";
            this.sortByNameButton.UseVisualStyleBackColor = true;
            this.sortByNameButton.Click += new System.EventHandler(this.sortByNameButton_Click);
            // 
            // clearSearchButton
            // 
            this.clearSearchButton.Location = new System.Drawing.Point(2009, 217);
            this.clearSearchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearSearchButton.Name = "clearSearchButton";
            this.clearSearchButton.Size = new System.Drawing.Size(188, 28);
            this.clearSearchButton.TabIndex = 37;
            this.clearSearchButton.Text = "Clear Search";
            this.clearSearchButton.UseVisualStyleBackColor = true;
            this.clearSearchButton.Click += new System.EventHandler(this.clearSearchButton_Click);
            // 
            // clearForm
            // 
            this.clearForm.Location = new System.Drawing.Point(931, 822);
            this.clearForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearForm.Name = "clearForm";
            this.clearForm.Size = new System.Drawing.Size(187, 28);
            this.clearForm.TabIndex = 38;
            this.clearForm.Text = "Clear Form";
            this.clearForm.UseVisualStyleBackColor = true;
            this.clearForm.Click += new System.EventHandler(this.clearForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2547, 1244);
            this.Controls.Add(this.clearForm);
            this.Controls.Add(this.clearSearchButton);
            this.Controls.Add(this.sortByNameButton);
            this.Controls.Add(this.sortByCheckInButton);
            this.Controls.Add(this.listAllReservationsButton);
            this.Controls.Add(this.closeButton);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Hotel Reservation System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
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
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button listAllReservationsButton;
        private System.Windows.Forms.Button sortByCheckInButton;
        private System.Windows.Forms.Button sortByNameButton;
        private System.Windows.Forms.Button clearSearchButton;
        private System.Windows.Forms.Button clearForm;
    }
}

