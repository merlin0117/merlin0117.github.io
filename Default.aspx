<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
           
                <div >
                    <h3 style="margin:0;padding:0">承租方基本信息</h3>
                    <p>工地名称：<asp:TextBox ID="tbName" runat="server"></asp:TextBox></p>

                    <p>电话号码：<asp:TextBox ID="tbTel" runat="server"></asp:TextBox></p>
                       <p>租入|出：<asp:DropDownList ID="DropDownList1" runat="server">
                           <asp:ListItem>租出</asp:ListItem>
                           <asp:ListItem>租入</asp:ListItem>
                           </asp:DropDownList></p>
                    <p>
                        <asp:Button ID="btnName" runat="server" Text="基本信息提交" Style="height: 21px" OnClick="btnName_Click" />
                        &nbsp;&nbsp;&nbsp;
             
             <asp:Button ID="btnAlter" runat="server" Text="编辑" OnClick="btnAlter_Click" />

                    </p>
                    <p style="height: 2em; line-height: 2em;">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </p>

                </div>

                <div style="float: left; width: 30%">
                    <h3>日租金单价<asp:Image ID="Image2" runat="server" ImageUrl="~/Pic/complete.png" Visible="False" Width="30px" />
                    </h3>

                    <p>
                        钢管：
                <asp:TextBox ID="tbTubeUnitPrice" runat="server">0.0</asp:TextBox>
                    </p>

                    <p>
                        扣件：
                <asp:TextBox ID="tbFastenerUnitPrice" runat="server">0.0</asp:TextBox>
                    </p>
                    <p>
                        顶托：
                    <asp:TextBox ID="tbJackingUnitPrice" runat="server">0.0</asp:TextBox>
                    </p>
                    <p>
                        套筒：
                    <asp:TextBox ID="tbSleeveUnitPrice" runat="server">0.0</asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="btnUnit" runat="server" Text="日租金率提交" OnClick="btnUnit_Click" />
                        &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAlter2" runat="server" Text="编辑" OnClick="btnAlter2_Click" />
                    </p>
                </div>

                <div style="width: 30%; float: left">
                    <h3>运费单价<asp:Image ID="Image3" runat="server" ImageUrl="~/Pic/complete.png" Visible="False" Width="30px" />
                    </h3>

                    <p>
                        钢管：
                        <asp:TextBox ID="tbTubeFright" runat="server">0.</asp:TextBox>
                    </p>

                    <p>
                        扣件：
                        <asp:TextBox ID="tbFastenerFright" runat="server">0.</asp:TextBox>
                    </p>
                    <p>
                        顶托：
                        <asp:TextBox ID="tbJackingFright" runat="server">0.</asp:TextBox>
                    </p>
                    <p>
                        套筒：
                    <asp:TextBox ID="tbSleeveFright" runat="server">0.</asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="btnFreight" runat="server" Text="运费单价提交" OnClick="btnFreight_Click" />
                        &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAlter3" runat="server" Text="编辑" OnClick="btnAlter3_Click" />
                    </p>
                </div>
                            <div style="float: right; width: 30%">
                    <h3>赔偿单价<asp:Image ID="Image4" runat="server" ImageUrl="~/Pic/complete.png" Visible="False" Width="30px" />
                                </h3>

                    <p>
                        钢管：
                <asp:TextBox ID="tbMtube" runat="server"></asp:TextBox>
                    </p>

                    <p>
                        扣件：
                <asp:TextBox ID="tbMfastener" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        顶托：
                    <asp:TextBox ID="tbMjacking" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        套筒：
                    <asp:TextBox ID="tbMsleeve" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="btnCompensate" runat="server" Text="赔偿单价提交" OnClick="btnCompensate_Click" />
                        &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAlter4" runat="server" Text="编辑" OnClick="btnAlter4_Click" />
                    </p>
                </div>


                <br style="clear: both" />
                <br />

                
                    <asp:HyperLink ID="hlNext" runat="server" Font-Bold="True" Font-Size="Medium">下一步：输入数据</asp:HyperLink>
           
        </div>
    </form>
</body>
</html>
