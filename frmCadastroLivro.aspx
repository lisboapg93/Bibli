<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmCadastroLivro.aspx.vb" Inherits="frmCadastroLivro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="content-header">
    </section>
    <section class="content">
        <h4 class="page-header">Cadastro Livro</h4>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- Small boxes (Stat box) -->
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-blue">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="Nome">Nome:</label>
                                            <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtNomeLivro" name="Nome" placeholder="Ex.: João" MaxLength="50" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="Autor">Autor:</label>
                                            <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtAutor" name="Autor" placeholder="Ex.: da Silva" MaxLength="250" />
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <div class="form-group">
                                        <label for="Ano">Ano:</label>
                                        <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtAno" name="Ano" placeholder="Ex.: 1995" MaxLength="4" />
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <div class="form-group">
                                        <label for="Paginas">Páginas:</label>
                                        <asp:TextBox runat="server" required="required" type="text" class="form-control" ID="txtPaginas" name="Paginas" placeholder="Ex.: 253" MaxLength="100" />
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
                                        <asp:GridView ID="grdLivro" runat="server" CssClass="table table-bordered" PagerStyle-CssClass="paginacao" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="CI00_ID_LIVRO">
                                            <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="CI00_ID_LIVRO" SortExpression="CI00_ID_LIVRO" HeaderText="Codigo" />
                                                <asp:BoundField DataField="CI00_NM_LIVRO" SortExpression="CI00_NM_LIVRO" HeaderText="Nome" />
                                                <asp:BoundField DataField="CI00_NM_AUTOR" SortExpression="CI00_NM_AUTOR" HeaderText="Autor" />
                                                <asp:BoundField DataField="CI00_NU_ANO" SortExpression="CI00_NU_ANO" HeaderText="Ano" />
                                                <asp:BoundField DataField="CI00_NU_PAGINAS" SortExpression="CI00_NU_PAGINAS" HeaderText="Paginas" />
                                                <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <div class="btn-group">
                                                            <asp:LinkButton ID="lnkExcluirAluno" runat="server" class="btn btn-social-icon bg-red" CommandName="EXCLUIR" ToolTip="ExcluirAluno">
                                                                <i id="iExcluirAluno" runat="server" class="fa fa-mortar-board"></i>
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

