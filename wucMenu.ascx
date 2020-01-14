<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMenu.ascx.cs" Inherits="wucMenu" %>
<style type="text/css">
    ul.ulMenu {
        width: 100%;
        margin: 0;
        padding: 0;
    }

        ul.ulMenu li {
            float: left;
            display: inline-block;
            width: 49%;
            margin: 0;
            padding:  0;
        }

            ul.ulMenu li a {
                display: block;
                width: 98%;
                line-height: 2em;
                height: 2em;
                text-align: left;
                border: 1px solid white;
                padding: 5px;
                margin:5px;
                font-weight: bold;
                color: white;
                font-size: 14pt;
            }

    .floatMenu {
        background-color: #507CD1;
        position: absolute;        
        padding:0;
        z-index: 9999;
        width: 100%;
        margin: 0;
       
    }
</style>

<div class="floatMenu">
    <div style="width: 1000px; margin: 0 auto; padding: 0">
        <ul class="ulMenu">
            <li  style="margin-right:10px">
                <a href="Default.aspx">添加工地名称</a>
            </li>
            <li>
                <a href="List.aspx">工地名称列表</a>
            </li>


        </ul>
    </div>
    
</div>


