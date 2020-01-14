<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>

<%@ Register Src="~/wucMenu.ascx" TagPrefix="uc1" TagName="wucMenu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      
                <uc1:wucMenu runat="server" ID="wucMenu" />
          

        <div class="container">

            <div>

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" AllowPaging="True" DataKeyNames="cid" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" PageSize="20">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="cid" DataNavigateUrlFormatString="Default.aspx?cid={0}" HeaderText="编辑" Text="编辑">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="5em" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="isrentout" HeaderText="租入|出" />
                        <asp:HyperLinkField DataNavigateUrlFields="cid" DataNavigateUrlFormatString="EnterData.aspx?cid={0}" DataTextField="cname" HeaderText="工地名称" >
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="ctotalfees" HeaderText="费用" >
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ctime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="时间">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>

            </div>
        </div>
    </form>
</body>
</html>
