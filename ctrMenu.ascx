<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctrMenu.ascx.vb" Inherits="NewExtranet_ctrMenu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<section class="sidebar">
    <div class="user-panel" id="divGoverno" runat="server">
    </div>
    <div class="user-panel" id="divUsuario" runat="server">
        <div class="pull-left image">
            <img src="img/avatar7.png" class="img-circle" alt="User Image" />
        </div>
        <div class="pull-left info">
            <p>
                Ola,
                <asp:Label ID="lblUsuario" runat="server" Text="" />
            </p>

            <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
            <asp:LinkButton ID="lnkSair" runat="server" Text="Sair" />
        </div>
    </div>

    <ul class="sidebar-menu" style="position: absolute;">
        <li class="active">
            <li id="liPaginaInicial" runat="server" visible="True"><a href="Default.aspx"><i class="fa fa-home"></i>Página Inicial</a></li>
        </li>
        <li id="liTesteSeduc" runat="server" visible="True" class="treeview">
            <a href="#">
                <i class="fa fa-pencil-square"></i>
                <span>Cadastros</span>
                <i class="fa fa-angle-left pull-right"></i>
            </a>
            <ul class="treeview-menu">
                <li id="liCadastro" runat="server" visible="True"><a href="frmCadastroUsuario.aspx"><i class="fa fa-angle-double-right"></i>Cadastro Usuário</a></li>
                <li id="li1" runat="server" visible="True"><a href="frmCadastroLivro.aspx"><i class="fa fa-angle-double-right"></i>Cadastro Livro</a></li>
            </ul>
            
        </li>
    </ul>
</section>

