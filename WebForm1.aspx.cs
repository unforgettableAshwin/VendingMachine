using System;
using System.Web.UI.WebControls;

namespace WebBasedVendingMachine
{
    enum sessionIDs
    {
        cashEntered
        , itemRowSelected
        , fivesAvailable
        , dollarsAvailable
        , quartersAvailable
        , dimesAvailable
        , nickelsAvailable
        , fivesEntered
        , dollarsEntered
        , quartersEntered
        , dimesEntered
        , nickelsEntered
    }

    enum inventoryColumn
    {
        itemNumber
        , price
        , description
        , quantity
    }

    public partial class WebForm1 : System.Web.UI.Page
    {
        public decimal cashEntered
        {
            get
            {
                object o = Session[sessionIDs.cashEntered.ToString()];
                if (o == null)
                    return 0M;
                else
                {
                    return (decimal)o;
                }
            }
            private set
            {
                Session[sessionIDs.cashEntered.ToString()] = value;
                totalCashEntered.Text = cashEntered.ToString("C");
            }
        }

        public int itemRowSelected
        {
            get
            {
                object o = Session[sessionIDs.itemRowSelected.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.itemRowSelected.ToString()] = value; }
        }

        public int fivesAvailable
        {
            get
            {
                object o = Session[sessionIDs.fivesAvailable.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.fivesAvailable.ToString()] = value; }
        }

        public int dollarsAvailable
        {
            get
            {
                object o = Session[sessionIDs.dollarsAvailable.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.dollarsAvailable.ToString()] = value; }
        }

        public int quartersAvailable
        {
            get
            {
                object o = Session[sessionIDs.quartersAvailable.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.quartersAvailable.ToString()] = value; }
        }

        public int dimesAvailable
        {
            get
            {
                object o = Session[sessionIDs.dimesAvailable.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.dimesAvailable.ToString()] = value; }
        }

        public int nickelsAvailable
        {
            get
            {
                object o = Session[sessionIDs.nickelsAvailable.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.nickelsAvailable.ToString()] = value; }
        }

        public int fivesEntered
        {
            get
            {
                object o = Session[sessionIDs.fivesEntered.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.fivesEntered.ToString()] = value; }
        }

        public int dollarsEntered
        {
            get
            {
                object o = Session[sessionIDs.dollarsEntered.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.dollarsEntered.ToString()] = value; }
        }

        public int quartersEntered
        {
            get
            {
                object o = Session[sessionIDs.quartersEntered.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.quartersEntered.ToString()] = value; }
        }

        public int dimesEntered
        {
            get
            {
                object o = Session[sessionIDs.dimesEntered.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.dimesEntered.ToString()] = value; }
        }

        public int nickelsEntered
        {
            get
            {
                object o = Session[sessionIDs.nickelsEntered.ToString()];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            private set { Session[sessionIDs.nickelsEntered.ToString()] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Button0.Click += new EventHandler(keypad_clicked);
            Button1.Click += new EventHandler(keypad_clicked);
            Button2.Click += new EventHandler(keypad_clicked);
            Button3.Click += new EventHandler(keypad_clicked);
            Button4.Click += new EventHandler(keypad_clicked);
            Button5.Click += new EventHandler(keypad_clicked);
            Button6.Click += new EventHandler(keypad_clicked);
            Button7.Click += new EventHandler(keypad_clicked);
            Button8.Click += new EventHandler(keypad_clicked);
            Button9.Click += new EventHandler(keypad_clicked);
            ButtonDel.Click += new EventHandler(keypad_clicked);

            add1dollar.Click += new EventHandler(cashAdded);
            add5dollars.Click += new EventHandler(cashAdded);
            addA_dime.Click += new EventHandler(cashAdded);
            addA_nickel.Click += new EventHandler(cashAdded);
            addA_quarter.Click += new EventHandler(cashAdded);

            if (!IsPostBack)
            {   //  Initial load:
                fivesAvailable = 5;
                dollarsAvailable = 5;
                quartersAvailable = 5;
                dimesAvailable = 5;
                nickelsAvailable = 5;
            }
        }

        private void cashAdded(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            decimal amount = 0;

            switch (button.ID)
            {
                case "add1dollar":
                    amount = 1;
                    ++dollarsEntered;
                    break;

                case "add5dollars":
                    amount = 5;
                    ++fivesEntered;
                    break;

                case "addA_dime":
                    amount = 0.1M;
                    ++dimesEntered;
                    break;

                case "addA_nickel":
                    amount = 0.05M;
                    ++nickelsEntered;
                    break;

                case "addA_quarter":
                    amount = 0.25M;
                    ++quartersEntered;
                    break;
            }

            cashEntered += amount;
            Feedback.Text = string.Empty;
        }

        private void keypad_clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Del")
                deleteCharacter();
            else
            {
                string s = currentSelection.Text;
                currentSelection.Text = (s.Length > 1 ? s.Substring(1) : s) + button.Text;
            }

            select.Enabled = (currentSelection.Text.Length > 0);
            Feedback.Text = string.Empty;
        }

        private void deleteCharacter()
        {
            string s = currentSelection.Text;
            int length = s.Length;
            if (length > 0)
                currentSelection.Text = s.Remove(--length);
        }

        protected void cashOrCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cashOrCredit.SelectedValue == "Cash")
            {
                panelCash.Visible = true;
                panelCredit.Visible = false;
                Feedback.Text = string.Empty;
            }
            else
            {
                Feedback.Text = calculateChange(fivesEntered, dollarsEntered, quartersEntered, dimesEntered, nickelsEntered);
                PanelConfirm.Visible = false;
                select.Enabled = false;
                zeroCashentered();
                panelCredit.Visible = true;
                panelCash.Visible = false;
            }

            panelPurchase.Visible = true;
        }

        protected void selectClick(object sender, EventArgs e)
        {
            itemRowSelected = 0;
            for (int i = 1; i < 11; i++)
                if (Inventory.Rows[i].Cells[(int)inventoryColumn.itemNumber].Text == currentSelection.Text)
                {
                    if (Inventory.Rows[i].Cells[(int)inventoryColumn.quantity].Text != "0")
                    {
                        itemRowSelected = i;
                        PanelConfirm.Visible = true;
                        PanelKeypad.Visible = false;
                        Feedback.Text = "You selected " + Inventory.Rows[itemRowSelected].Cells[(int)inventoryColumn.description].Text + ".  Please click Confirm or Cancel to continue.";
                        break;
                    }
                }

            if (itemRowSelected == 0) Feedback.Text = "Please select an item in inventory.";
        }

        protected void purchase_Click(object sender, EventArgs e)
        {
            if (cashOrCredit.SelectedValue == "Cash")
                purchaseUsingCash();
            else
                purchaseUsingCredit();
        }

        private void purchaseUsingCredit()
        {
            if (creditCard.Text.Length == 16)
            {
                decimal price = Convert.ToDecimal(Inventory.Rows[itemRowSelected].Cells[(int)inventoryColumn.price].Text);

                decimal transactionFee = price * 0.05M;

                Feedback.Text = "Please take your item.  Card charged " + (price + transactionFee).ToString("C") + " (Price (" + price.ToString("C") + ") + 5% Transaction Fee (" + transactionFee.ToString("C") + "))";
                reduceInventory();
                resetForNextItem();
            }
            else
            {
                Feedback.Text = "Invalid card.";
            }
        }

        private void purchaseUsingCash()
        {
            string changeDetail = string.Empty;

            decimal price = Convert.ToDecimal(Inventory.Rows[itemRowSelected].Cells[(int)inventoryColumn.price].Text);


            if (price > cashEntered)
                Feedback.Text = "Please enter more cash to purchase this item.";
            else
            {
                if (price == cashEntered)
                {
                    addCashEntered();
                    zeroCashentered();
                    resetForNextItem();
                    reduceInventory();
                    Feedback.Text = "Please take your item.";
                }
                else
                {
                    addCashEntered();
                    if (changeAvailable(price, out changeDetail))
                    {
                        zeroCashentered();
                        resetForNextItem();
                        reduceInventory();
                        Feedback.Text = "Please take your item.  " + changeDetail;
                    }
                    else
                    {
                        fivesAvailable -= fivesEntered;
                        dollarsAvailable -= dollarsEntered;
                        quartersAvailable -= quartersEntered;
                        dimesAvailable -= dimesEntered;
                        nickelsAvailable -= nickelsEntered;
                        Feedback.Text = "Unable to make change.  " + calculateChange(fivesEntered, dollarsEntered, quartersEntered, dimesEntered, nickelsEntered);
                        returnCashEntered();
                    }
                }
            }
        }

        private void reduceInventory()
        {
            int quantity = Convert.ToInt16(Inventory.Rows[itemRowSelected].Cells[(int)inventoryColumn.quantity].Text);

            Inventory.Rows[itemRowSelected].Cells[(int)inventoryColumn.quantity].Text = (--quantity).ToString();
        }

        private bool changeAvailable(decimal price, out string changeDetail)
        {
            decimal change = cashEntered - price;

            int required5s = 0
                , required1s = 0
                , required25s = 0
                , required10s = 0
                , required05s = 0;

            var ableToMakechange = true;

            changeDetail = string.Empty;
            decimal TCA = totalChangeAvailable(fivesAvailable, dollarsAvailable, quartersAvailable, dimesAvailable, nickelsAvailable);
            if (TCA < change)
                ableToMakechange = false;

            if (ableToMakechange)
            {
                required5s = (int)(change / 5);
                if (required5s > 0)
                    if (required5s > fivesAvailable)
                        required5s = fivesAvailable;

                change -= required5s * 5;
            }

            if (change > 0)
            {
                required1s = (int)(change);
                if (required1s > 0)
                    if (required1s > dollarsAvailable)
                        required1s = dollarsAvailable;

                change -= required1s;
            }

            if (change > 0)
            {
                required25s = (int)(change / 0.25M);
                if (required25s > 0)
                    if (required25s > quartersAvailable)
                        required25s = quartersAvailable;

                change -= required25s * 0.25M;
            }

            if (change > 0)
            {
                required10s = (int)(change / 0.10M);
                if (required10s > 0)
                    if (required10s > dimesAvailable)
                        required10s = dimesAvailable;

                change -= required10s * 0.10M;
            }

            if (change > 0)
            {
                required05s = (int)(change / 0.05M);
                if (required05s > 0)
                    if (required05s > nickelsAvailable)
                        required05s = nickelsAvailable;

                change -= required05s * 0.05M;
            }

            if (change > 0) ableToMakechange = false;

            if (ableToMakechange)
            {
                changeDetail = calculateChange(required5s, required1s, required25s, required10s, required05s);
                fivesAvailable -= required5s;
                dollarsAvailable -= required1s;
                quartersAvailable -= required25s;
                dimesAvailable -= required10s;
                nickelsAvailable -= required05s;
            }

            return ableToMakechange;
        }

        private decimal totalChangeAvailable(
            int i5s
            , int i1s
            , int i25s
            , int i10s
            , int i05s)
        {
            return i5s * 5 + i1s + i25s * 0.25M + i10s * 0.1M + i05s * 0.05M;
        }

        private void addCashEntered()
        {
            fivesAvailable += fivesEntered;
            dollarsAvailable += dollarsEntered;
            quartersAvailable += quartersEntered;
            dimesAvailable += dimesEntered;
            nickelsAvailable += nickelsEntered;
        }

        private void zeroCashentered()
        {
            fivesEntered = 0;
            dollarsEntered = 0;
            quartersEntered = 0;
            dimesEntered = 0;
            nickelsEntered = 0;
            cashEntered = 0;
        }

        protected void cancelSelection_Click(object sender, EventArgs e)
        {
            Feedback.Text = calculateChange(fivesEntered, dollarsEntered, quartersEntered, dimesEntered, nickelsEntered);
            returnCashEntered();
        }

        private void returnCashEntered()
        {
            resetForNextItem();
            zeroCashentered();
        }

        private void resetForNextItem()
        {
            PanelConfirm.Visible = false;
            currentSelection.Text = string.Empty;
            select.Enabled = false;
            panelCashOrCredit.Visible = false;
            panelCash.Visible = false;
            panelCredit.Visible = false;
            panelPurchase.Visible = false;
            cashOrCredit.ClearSelection();
            PanelKeypad.Visible = true;
            creditCard.Text = string.Empty;
        }

        private string calculateChange(
            int i5s
            , int i1s
            , int i25s
            , int i10s
            , int i05s)
        {
            string s = string.Empty;

            if (i5s > 0) s = i5s.ToString() + " five dollar bill(s)";
            if (i1s > 0)
            {
                if (s.Length > 0) s += ", ";
                s += i1s.ToString() + " dollar bill(s)";
            }

            if (i25s > 0)
            {
                if (s.Length > 0) s += ", ";
                s += i25s.ToString() + " quarter(s)";
            }

            if (i10s > 0)
            {
                if (s.Length > 0) s += ", ";
                s += i10s.ToString() + " dime(s)";
            }

            if (i05s > 0)
            {
                if (s.Length > 0) s += ", ";
                s += i05s.ToString() + " nickel(s)";
            }

            if (s.Length > 0)
                s = "Change returned: " + s + ".";

            return s;
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            PanelConfirm.Visible = false;
            panelCashOrCredit.Visible = true;
            Feedback.Text = string.Empty;
        }
    }
}