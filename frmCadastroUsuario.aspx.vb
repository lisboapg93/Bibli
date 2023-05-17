Enum ColunasGrid_grdUsuario As Integer
    Selecionar
    ID_Usuario
    buttons
End Enum
Partial Class frmCadastroUsuario
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CarregarGridUsuario()
        End If
        Validacao.Outros(txtCPF, False, "CPF",, Validacao.eFormato.CPF)
        Validacao.Outros(txtTelefone, False, "CPF",, Validacao.eFormato.CELULAR)
        Validacao.Outros(txtCEP, False, "CPF",, Validacao.eFormato.CEP)
        Validacao.Outros(txtEmail, False, "CPF",, Validacao.eFormato.EMAIL)
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

#Region "Funções de Cadastro"
    Private Function VerificarCpf() As Boolean
        Dim objUsuario As New Usuario
        Dim Existe As Boolean = False

        With objUsuario.Pesquisar(,,, Replace(Replace(txtCPF.Text, ".", ""), "-", ""))
            If .Rows.Count > 0 Then
                MsgBox("CPF já Cadastrado", eCategoriaMensagem.ALERTA)
                Existe = True
            End If
        End With

        objUsuario = Nothing
        Return Existe
    End Function

    Private Sub LimparCampos()

        txtCPF.Text = ""
        txtNome.Text = ""
        txtCEP.Text = ""
        txtCidade.Text = ""
        txtEmail.Text = ""
        txtTelefone.Text = ""

        txtNome.Focus()
    End Sub

    Private Sub Salvar()
        Dim objUsuario As New Usuario(ViewState("Codigo"))
        With objUsuario
            .NomeUsuario = Trim(Validacao.RetirarEspacos(txtNome.Text))
            If VerificarCpf() = True Then
                Exit Sub
            End If
            .CPF = Replace(Replace(txtCPF.Text, ".", ""), "-", "")
            .Cep = txtCEP.Text
            .Cidade = txtCidade.Text
            .Email = txtEmail.Text
            .Telefone = txtTelefone.Text

            .Salvar()
        End With
        objUsuario = Nothing
    End Sub

    Private Sub Excluir(ByVal CodigoUsuario As Integer)
        Dim objUsuario As New Usuario

        If objUsuario.Excluir(CodigoUsuario) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If

        objUsuario = Nothing

        LimparCampos()
        CarregarGridUsuario()
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
        CarregarGridUsuario()
    End Sub
#End Region

#Region "Funções de Listagem"
    Private Sub CarregarGridUsuario()
        Dim objUsuario As New Usuario

        grdUsuario.DataSource = objUsuario.Pesquisar(ViewState("OrderBy"))
        grdUsuario.DataBind()

        objUsuario = Nothing

        lblRegistros.Text = DirectCast(grdUsuario.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub
#End Region

#Region "Eventos de Listagem"
    Protected Sub grdUsuario_RowCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdUsuario.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdUsuario.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub grdUsuario_PageIndexChanging(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdUsuario.PageIndexChanging
        grdUsuario.PageIndex = e.NewPageIndex
        CarregarGridUsuario()
    End Sub

    Private Sub grdUsuario_Sorting(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdUsuario.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGridUsuario()
    End Sub
#End Region
End Class
