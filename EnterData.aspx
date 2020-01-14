<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnterData.aspx.cs" Inherits="EnterData" %>

<%@ Register Src="~/wucMenu.ascx" TagPrefix="uc1" TagName="wucMenu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>


    <style type="text/css">
        .btnAdd {
            width: 48%;
            height: 3em;
            line-height: 3em;
            margin-right: 28px;
        }

        .btnAdd1 {
            width: 48%;
            height: 3em;
            line-height: 3em;
            /* float: right;*/
        }

        .btnCal {
            width: 224px;
            height: 55px;
            line-height: 55px;
            margin-left: 28px;
        }

        .btnInport {
            width: 730px;
            height: 50px;
            line-height: 50px;
            margin-left: 28px;
            float: right;
        }

        .tbtube {
            background-image: url('Pic/tube.png');
            background-repeat: no-repeat;
            background-position: left center;
            width: 150px;
            height: 50px;
            line-height: 50px;
            padding-left: 70px;
            margin-right: 28px;
        }

        .tbfastener {
            background-image: url('Pic/fastener.png');
            background-repeat: no-repeat;
            background-position: left center;
            width: 150px;
            height: 50px;
            line-height: 50px;
            padding-left: 70px;
            margin-right: 28px;
        }

        .tbjacking {
            background-image: url('Pic/jacking.png');
            background-repeat: no-repeat;
            background-position: left center;
            width: 150px;
            height: 50px;
            line-height: 50px;
            padding-left: 70px;
            margin-right: 28px;
        }

        .tbsleeve {
            background-image: url('Pic/sleeve.png');
            background-repeat: no-repeat;
            background-position: left center;
            width: 150px;
            height: 50px;
            line-height: 50px;
            padding-left: 70px;
        }

        .tbtime {
            background-image: url('Pic/time.png');
            background-repeat: no-repeat;
            background-position: left center;
            width: 150px;
            height: 50px;
            line-height: 50px;
            padding-left: 70px;
        }

        .bgColor1 {
            background-color: grey;
            height: 50px;
            line-height: 50px;
        }

        .file {
            width: 150px;
        }

        table, th, td {
            border-collapse: collapse;
            border: 1px solid black;
            font-size: small;
        }

        .boderNone {
            border-right: 1px solid #FFF;
        }

        thead {
            display: table-header-group;
        }

        .auto-style1 {
            width: 97%;
        }

        .auto-style2 {
            height: 15px;
        }

        .auto-style4 {
            height: 15px;
            width: 193px;
            font-weight: bold;
        }

        .auto-style5 {
            width: 193px;
        }

        .auto-style6 {
            width: 193px;
            font-weight: bold;
        }

        .auto-style7 {
            width: 193px;
            font-weight: bold;
            height: 16px;
        }

        .auto-style8 {
            height: 16px;
        }
    </style>

    <style media="print" type="text/css">
        .noprint {
            visibility: hidden;
        }
    </style>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        function printme() {
            document.body.innerHTML = document.getElementById('div1').innerHTML;
            window.print();
            window.location.reload();
        }

        function showTime() {
            var divTime = document.getElementById("divTime");
            var divIsout = document.getElementById("divIsout");
            divTime.style.display = 'block';
            divIsout.style.display = 'none';

            document.getElementById("lblWeiruku").style.display = "none";
            document.getElementById("lblChuku").style.display = "none";
            document.getElementById("lblRuku").style.display = "none";
            document.getElementById("lblTotIsout").style.display = "none";

            document.getElementById("Label6").style.display = "block";
            document.getElementById("Label7").style.display = "block";
            document.getElementById("Label8").style.display = "block";
            document.getElementById("Label9").style.display = "block";
            document.getElementById("lblRentFees").style.display = "block";
            document.getElementById("lblTotal").style.display = "block";

        }

        function showIsout() {
            var divTime = document.getElementById("divTime");
            var divIsout = document.getElementById("divIsout");
            divIsout.style.display = 'block';
            divTime.style.display = 'none';

            document.getElementById("lblWeiruku").style.display = "block";
            document.getElementById("lblChuku").style.display = "block";
            document.getElementById("lblRuku").style.display = "block";
            document.getElementById("lblTotIsout").style.display = "block";

            document.getElementById("Label6").style.display = "none";
            document.getElementById("Label7").style.display = "none";
            document.getElementById("Label8").style.display = "none";
            document.getElementById("Label9").style.display = "none";
            document.getElementById("lblRentFees").style.display = "none";
            document.getElementById("lblTotal").style.display = "none";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:wucMenu runat="server" ID="wucMenu" />

        <div class="container">


            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

            <br />
            <br />
            <asp:Panel ID="Panel2" runat="server" Visible="false" CssClass="bgColor1">

                <asp:FileUpload ID="fld" runat="server" CssClass="file" />

                <asp:Button ID="btn" runat="server" Text="开始导入......" CssClass="btnInport" TabIndex="8" OnClick="btn_Click" />

                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Upload/1.xlsx">模板下载</asp:HyperLink>
            </asp:Panel>

            <br />


            <div>

                <asp:TextBox ID="tbDateTime" runat="server" CssClass="tbtime" TabIndex="1"></asp:TextBox>

                <asp:Button ID="btnResult" runat="server" OnClick="btnResult_Click" Text="费用合计" CssClass="btnCal" TabIndex="9" />
                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="导出到EXCEL" CssClass="btnCal" TabIndex="10" />
                <asp:Button ID="Button1" runat="server" Text="导入excel数据" CssClass="btnCal" OnClick="Button1_Click" />


                <br />
                <br />

                <asp:TextBox ID="tbTube" runat="server" CssClass="tbtube" TabIndex="2" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:TextBox ID="tbFastener" runat="server" CssClass="tbfastener" TabIndex="3" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:TextBox ID="tbJacking" runat="server" CssClass="tbjacking" TabIndex="4" AutoCompleteType="Disabled"></asp:TextBox>



                <asp:TextBox ID="tbSleeve" runat="server" CssClass="tbsleeve" TabIndex="5" AutoCompleteType="Disabled"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="出库" OnClick="btnAdd_Click" CssClass="btnAdd" TabIndex="6" />

                <asp:Button ID="btnAddIn" runat="server" Text="入库" OnClick="btnAddIn_Click" CssClass="btnAdd1" TabIndex="7" />



            </div>
            <hr />

            <div id="div1">

                <div id="div2">

                    <asp:Panel ID="Panel1" runat="server">

                                                    <div class="noprint">
                                <a href="javascript:showTime()" target="_blank" style="float: left; border: 1px solid #000000; vertical-align: middle; text-align: center; width: 48%; display: block; height: 2em; line-height: 2em;" class="noprint">按时间天数计算</a>
                                <a href="javascript:showIsout()" target="_blank" style="float: left; margin-left: 30px; border: 1px solid #000000; vertical-align: middle; text-align: center; width: 48%; display: block; height: 2em; line-height: 2em;" class="noprint">按出入库计算</a>

                                <br style="clear: both" />
                                                        <br />
                                                                    <a href="javascript:printme()" target="_blank" style="  border: 1px solid #000000; vertical-align: middle; text-align: center; width: 99%; display: block; height: 2em; line-height: 2em;">打印</a>

                            </div>

                        <div id="divExport" runat="server">
                            <h3 style="width: 48%; text-align: left; display: inline-block; line-height: 2em;">建材租用方：
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                　　联系电话
                                <asp:Label ID="Label26" runat="server"></asp:Label>
                            </h3>
                            <h3 style="width: 48%; text-align: right; display: inline-block; line-height: 2em;">承租方：何代成　　联系电话：13973658148
                            </h3>


                            <br style="clear: both" />

                            <div id="divtotal">
                                <table class="auto-style1" style="text-align: center; line-height: normal; vertical-align: middle">
                                    <tr>
                                        <td class="auto-style5">&nbsp;</td>
                                        <td><b>钢管（米）</b></td>
                                        <td><b>扣件（个）</b></td>
                                        <td><b>顶托（个）</b></td>
                                        <td><b>套筒（个）</b></td>
                                        <td><b>合计（元）</b></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6" style="text-align: center; padding-right: 10px;">日租金（元/每天/单位）</td>
                                        <td>
                                            <asp:Label ID="lblTubeFright" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFastenerFright" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblJackingFright" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSleeveFright" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6" style="text-align: center; padding-right: 10px;">运费单程（元/单位）</td>
                                        <td>
                                            <asp:Label ID="lblTubeFright1" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFastenerFright1" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblJackingFright1" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSleeveFright1" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6" style="text-align: center; padding-right: 10px;">赔偿单价（元/单位）</td>
                                        <td>
                                            <asp:Label ID="lblTubeFright2" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFastenerFright2" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblJackingFright2" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSleeveFright2" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6" style="text-align: center; padding-right: 10px;">出库合计</td>
                                        <td>
                                            <asp:Label ID="Label14" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label16" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label17" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblChuku" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6" style="text-align: center; padding-right: 10px;">入库合计</td>
                                        <td>
                                            <asp:Label ID="Label18" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label20" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label21" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRuku" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6" style="text-align: center; padding-right: 10px;">未入库合计</td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblWeiruku" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style7" style="text-align: center; padding-right: 10px;">租金合计（元）</td>
                                        <td class="auto-style8">
                                            <asp:Label ID="Label6" runat="server">0</asp:Label>
                                        </td>
                                        <td class="auto-style8">
                                            <asp:Label ID="Label7" runat="server">0</asp:Label>
                                        </td>
                                        <td class="auto-style8">
                                            <asp:Label ID="Label8" runat="server">0</asp:Label>
                                        </td>
                                        <td class="auto-style8">
                                            <asp:Label ID="Label9" runat="server">0</asp:Label>
                                        </td>
                                        <td class="auto-style8">
                                            <asp:Label ID="lblRentFees" runat="server" Font-Bold="True" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style4" style="text-align: center; padding-right: 10px;">运费合计（元）</td>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label10" runat="server">0</asp:Label>
                                        </td>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label11" runat="server">0</asp:Label>
                                        </td>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label12" runat="server">0</asp:Label>
                                        </td>
                                        <td class="auto-style2">
                                            <asp:Label ID="Label13" runat="server">0</asp:Label>
                                        </td>
                                        <td class="auto-style2">
                                            <asp:Label ID="lblTransmitFees" runat="server" Font-Bold="True" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6" style="text-align: center; padding-right: 10px;">赔偿合计（元）</td>
                                        <td>
                                            <asp:Label ID="Label22" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label23" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label24" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label25" runat="server">0</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True">0</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6" style="text-align: center; padding-right: 10px;">费用总计（元）</td>
                                        <td colspan="5">
                                            <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Text="0"></asp:Label>
                                            　　<asp:Label ID="lblTotIsout" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                </table>

                            </div>


                            <br />
                            <div id="divTime" style="display:none">
                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="rid,rtime" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSorting="GridView1_Sorting" ShowFooter="True" Width="109%" HorizontalAlign="Center" CaptionAlign="Bottom" OnPreRender="GridView1_PreRender">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="rtime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="日期">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rtube" HeaderText="钢管">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rfastener" HeaderText="扣件">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rjacking" HeaderText="顶托">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rsleeve" HeaderText="套筒">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="f钢管">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="f扣件">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="f顶托">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="f套筒">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="天数">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="费用">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="isout" HeaderText="出/入库">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:CommandField HeaderText="编辑" ShowEditButton="True" ItemStyle-CssClass="noprint" HeaderStyle-CssClass="noprint" FooterStyle-CssClass="noprint">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle CssClass="noprint" />
                                            <ItemStyle CssClass="noprint" />
                                        </asp:CommandField>
                                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ItemStyle-CssClass="noprint" HeaderStyle-CssClass="noprint" FooterStyle-CssClass="noprint">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle CssClass="noprint" />
                                            <ItemStyle CssClass="noprint" />
                                        </asp:CommandField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </div>

                           
                         


                        </div>
                           <div id="divIsout" style=" margin-left: 0; padding-left: 0;"  >
                                <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" CaptionAlign="Bottom" CellPadding="4" DataKeyNames="rid,rtime" ForeColor="#333333" GridLines="None" HorizontalAlign="left" OnPreRender="GridView2_PreRender" OnRowDataBound="GridView2_RowDataBound" ShowFooter="True" Width="97%">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="rtime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="出库日期">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rtube" HeaderText="钢管">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rfastener" HeaderText="扣件">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rjacking" HeaderText="顶托">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rsleeve" HeaderText="套筒">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="天数">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="费用">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="isout" HeaderText="出/入库">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                                <br />
                                <asp:GridView ID="GridView3" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="rid,rtime" ForeColor="#333333" GridLines="None" ShowFooter="True" Width="97%" HorizontalAlign="left" CaptionAlign="Bottom" OnPreRender="GridView3_PreRender" OnRowDataBound="GridView3_RowDataBound">

                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="rtime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="入库日期">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rtube" HeaderText="钢管">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rfastener" HeaderText="扣件">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rjacking" HeaderText="顶托">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="rsleeve" HeaderText="套筒">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="天数">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="费用">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="isout" HeaderText="出/入库">
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Justify" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />

                                </asp:GridView>

                            </div>
                        <br />
                        <br />
                    </asp:Panel>

                </div>


            </div>
        </div>



    </form>
</body>
</html>
