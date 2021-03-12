<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChurchList.ascx.cs" Inherits="RockWeb.Plugins.org_abwe.RockMissions.Churches.ChurchList" %>

<asp:UpdatePanel ID="upnlChurches" runat="server">
    <ContentTemplate>

        <Rock:NotificationBox ID="nbWarningMessage" runat="server" NotificationBoxType="Danger" Visible="true" />

        <asp:Panel ID="pnlChurchList" CssClass="panel panel-block" runat="server">

            <div class="panel-heading">
                <h1 class="panel-title"><i class="fa fa-briefcase"></i> Church List</h1>
            </div>
            <div class="panel-body">

                <div class="grid grid-panel">
                    <!-- TODO add filter by state, sending church, supporting church -->
                    <Rock:GridFilter ID="gfChurchFilter" runat="server">
                        <Rock:RockTextBox ID="tbChurchName" runat="server" Label="Church Name"></Rock:RockTextBox>  <!-- this should search by "contains" not necessarily an exact match -->
                        <Rock:RockDropDownList ID="ddlActiveFilter" runat="server" Label="Active Status">
                            <asp:ListItem Text="[All]" Value="all"></asp:ListItem>
                            <asp:ListItem Text="Active" Value="active"></asp:ListItem>
                            <asp:ListItem Text="Inactive" Value="inactive"></asp:ListItem>
                        </Rock:RockDropDownList>
                    </Rock:GridFilter>

                    <!-- add columns Number Sent, Number People/Projects Supporting (eliminate contacts)-->
                    <Rock:ModalAlert ID="mdGridWarning" runat="server" />
                    <Rock:Grid ID="gChurchList" runat="server" RowItemText="Church" EmptyDataText="No Churches Found" AllowSorting="true" OnRowSelected="gChurchList_RowSelected" IsChurch="true">
                        <Columns>
                            <Rock:SelectField></Rock:SelectField>
                            <Rock:RockBoundField DataField="ChurchName" HeaderText="Church Name" SortExpression="LastName" />
                            <Rock:RockLiteralField SortExpression="State" HeaderText="State" ID="lState" OnDataBound="lState_DataBound" />
                            <Rock:RockLiteralField SortExpression="PhoneNumber, Email" HeaderText="Contact Information" ID="lContactInformation" OnDataBound="lContactInformation_DataBound" />
                            <Rock:RockLiteralField SortExpression="Address.City,Address.Street1" HeaderText="Address" ID="lAddress" OnDataBound="lAddress_DataBound" />
                        </Columns>
                    </Rock:Grid>

                </div>

            </div>

        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>
