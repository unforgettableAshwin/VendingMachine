<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebBasedVendingMachine.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vending Machine</title>
    <style>
        .number {
            text-align: right;
        }

        .text {
            text-align: left;
        }

        .leftSpace {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Inventory" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text">Item #</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text">Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text">Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text">Quantity</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell>01</asp:TableCell>
                    <asp:TableCell CssClass="number">1.00</asp:TableCell>
                    <asp:TableCell>Chocolate Bar</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>02</asp:TableCell>
                    <asp:TableCell CssClass="number">0.50</asp:TableCell>
                    <asp:TableCell>Comb</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>03</asp:TableCell>
                    <asp:TableCell CssClass="number">1.80</asp:TableCell>
                    <asp:TableCell>Brush</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>04</asp:TableCell>
                    <asp:TableCell CssClass="number">3.00</asp:TableCell>
                    <asp:TableCell>Red Nail Polish</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>05</asp:TableCell>
                    <asp:TableCell CssClass="number">2.00</asp:TableCell>
                    <asp:TableCell>Nail Clipper and File</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>06</asp:TableCell>
                    <asp:TableCell CssClass="number">0.75</asp:TableCell>
                    <asp:TableCell>Baby Wipes</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>07</asp:TableCell>
                    <asp:TableCell CssClass="number">0.25</asp:TableCell>
                    <asp:TableCell>Aspirin</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>08</asp:TableCell>
                    <asp:TableCell CssClass="number">1.00</asp:TableCell>
                    <asp:TableCell>Ibuprofen</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>09</asp:TableCell>
                    <asp:TableCell CssClass="number">1.00</asp:TableCell>
                    <asp:TableCell>Acetaminophen</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>10</asp:TableCell>
                    <asp:TableCell CssClass="number">1.00</asp:TableCell>
                    <asp:TableCell>Minty Gum</asp:TableCell>
                    <asp:TableCell CssClass="number">5</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br />
        Current Selection:&nbsp&nbsp<asp:Label ID="currentSelection" runat="server" Width="20px"></asp:Label>
        <asp:Button ID="select" runat="server" Text="Select" OnClick="selectClick" CssClass="leftSpace" Enabled="False" />&nbsp<asp:Button ID="cancelSelection" runat="server" Text="Cancel" OnClick="cancelSelection_Click" />
        &nbsp&nbsp<asp:Label ID="Feedback" runat="server"></asp:Label>
        <asp:Panel ID="PanelConfirm" runat="server" Visible="False">
            <asp:Button ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" />
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="PanelKeypad" runat="server">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="Button1" runat="server" Text="1" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button2" runat="server" Text="2" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button3" runat="server" Text="3" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="Button4" runat="server" Text="4" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button5" runat="server" Text="5" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button6" runat="server" Text="6" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="Button7" runat="server" Text="7" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button8" runat="server" Text="8" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button9" runat="server" Text="9" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="ButtonDel" runat="server" Text="Del" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button0" runat="server" Text="0" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="panelCashOrCredit" runat="server" Visible="False">
            <asp:RadioButtonList ID="cashOrCredit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cashOrCredit_SelectedIndexChanged">
                <asp:ListItem>Cash</asp:ListItem>
                <asp:ListItem>Credit</asp:ListItem>
            </asp:RadioButtonList>
        </asp:Panel>
        <asp:Panel ID="panelCash" runat="server" Visible="False">
            <asp:Button ID="add5dollars" runat="server" Text="Add $5" />
            &nbsp<asp:Button ID="add1dollar" runat="server" Text="Add $1" />
            &nbsp<asp:Button ID="addA_quarter" runat="server" Text="Add $0.25" />
            &nbsp<asp:Button ID="addA_dime" runat="server" Text="Add $0.10" />
            &nbsp<asp:Button ID="addA_nickel" runat="server" Text="Add $0.05" />
            &nbsp<asp:Label ID="totalCashEntered" runat="server" Width="40px"></asp:Label>
            &nbsp
        </asp:Panel>
        <asp:Panel ID="panelCredit" runat="server" Visible="False">
            Credit Card Number:
            <asp:TextBox ID="creditCard" runat="server" AutoCompleteType="Disabled" MaxLength="17"></asp:TextBox>
        </asp:Panel>

        <br />
        <asp:Panel ID="panelPurchase" runat="server" Visible="False">
            <asp:Button ID="purchase" runat="server" OnClick="purchase_Click" Text="Purchase" />
        </asp:Panel>
        <asp:TextBox ID="d" runat="server" Height="47px" TextMode="MultiLine" Width="850px" Visible="False"></asp:TextBox>
    </form>
</body>
</html>
