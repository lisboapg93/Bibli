<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmCadastroUsuario.aspx.vb" Inherits="frmCadastroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
    </section>
    <section class="content">
        <h4 class="page-header">Cadastro de Usuário</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- Small boxes (Stat box) -->
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-blue">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="Nome">Nome:</label>
                                            <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtNome" name="Nome" placeholder="Ex.: João" MaxLength="50" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="CPF">CPF:</label>
                                            <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtCPF" name="CPF" placeholder="Ex.: 010.011.111-00" MaxLength="14" />
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="CEP">CEP:</label>
                                            <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtCEP" name="CEP" placeholder="Ex.: 01011-100" MaxLength="8" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="Cidade">Cidade:</label>
                                            <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtCidade" name="Cidade" MaxLength="50" placeholder="Ex.: São Luis" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="Email">E-mail:</label>
                                            <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtEmail" name="Email" placeholder="Ex.: email@email.com" MaxLength="100" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="Telefone">Telefone:</label>
                                            <asp:TextBox runat="server" required="required" type="tel" class="form-control" ID="txtTelefone" name="Telefone" placeholder="Ex.: (11) 2020-3030" MaxLength="15" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer">
                                <div class="col-md-6">
                                    <asp:Button class="btn btn-success" runat="server" ID="btnSalvar" Text="Salvar" />
                                </div>
                            </div>

                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="lblRegistros" runat="server" CssClass="badge bg-aqua" />
                                        <asp:GridView ID="grdUsuario" runat="server" CssClass="table table-bordered" PagerStyle-CssClass="paginacao" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="CI01_ID_ALUNO">
                                            <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="CI01_ID_ALUNO" SortExpression="CI01_ID_ALUNO" HeaderText="Codigo" />
                                                <asp:BoundField DataField="CI01_NM_ALUNO" SortExpression="CI01_NM_ALUNO" HeaderText="Nome" />
                                                <asp:BoundField DataField="CI01_NU_CPF" SortExpression="CI01_NU_CPF" HeaderText="CPF" DataFormatString="{0:###.###.###-##}" />
                                                <asp:BoundField DataField="CI01_NM_CIDADE" SortExpression="CI01_NM_CIDADE" HeaderText="Cidade" />
                                                <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <div class="btn-group">
                                                            <asp:LinkButton ID="lnkExcluirUsuario" runat="server" class="btn btn-social-icon bg-red" CommandName="EXCLUIR" ToolTip="ExcluirUsuario">
                                                                <i id="iExcluirUsuario" runat="server" class="fa fa-mortar-board"></i>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>
