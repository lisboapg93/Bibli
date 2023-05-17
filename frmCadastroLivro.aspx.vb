Enum ColunasGrid_grdLivro As Integer
    Selecionar
    ID_LIVRO
    buttons
End Enum
Partial Class frmCadastroLivro
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CarregarGridLivro()
        End If
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

#Region "Funções de Cadastro"
    Private Sub LimparCampos()

        txtNomeLivro.Text = ""
        txtAutor.Text = ""
        txtAno.Text = ""
        txtPaginas.Text = ""

        txtNomeLivro.Focus()
    End Sub

    Private Sub Salvar()
        Dim objLivro As New Livro(ViewState("Codigo"))
        With objLivro
            .NomeLivro = txtNomeLivro.Text
            .Autor = txtAutor.Text
            .Ano = txtAno.Text
            .Paginas = txtPaginas.Text

            .Salvar()
        End With
        objLivro = Nothing
    End Sub

    Private Sub Excluir(ByVal CodigoLivro As Integer)
        Dim objLivro As New Livro

        If objLivro.Excluir(CodigoLivro) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If

        objLivro = Nothing

        LimparCampos()
        CarregarGridLivro()
    End Sub

    Private Sub Voltar()
        Response.Redirect(Request.Url.ToString)

        LimparCampos()
    End Sub
#End Region

#Region "Eventos de Cadastro"
    Protected Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Salvar()
        LimparCampos()
        CarregarGridLivro()
    End Sub

#End Region

#Region "Funções de Listagem"
    Private Sub CarregarGridLivro()
        Dim objLivro As New Livro

        grdLivro.DataSource = objLivro.Pesquisar(ViewState("OrderBy"))
        grdLivro.DataBind()

        objLivro = Nothing

        lblRegistros.Text = DirectCast(grdLivro.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub
#End Region

#Region "Eventos de Listagem"
    Protected Sub grdLivro_RowCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdLivro.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdLivro.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub grdLivro_PageIndexChanging(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdLivro.PageIndexChanging
        grdLivro.PageIndex = e.NewPageIndex
        CarregarGridLivro()
    End Sub

    Private Sub grdLivro_Sorting(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdLivro.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGridLivro()
    End Sub



#End Region
End Class
