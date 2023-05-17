Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Text


Public Class Livro
    Private CI00_ID_LIVRO As Integer
    Private CI00_NM_LIVRO As String
    Private CI00_NM_AUTOR As String
    Private CI00_NU_ANO As String
    Private CI00_NU_PAGINAS As String

    Public Property Codigo() As Integer
        Get
            Return CI00_ID_LIVRO
        End Get
        Set(ByVal Value As Integer)
            CI00_ID_LIVRO = Value
        End Set
    End Property

    Public Property NomeLivro() As String
        Get
            Return CI00_NM_LIVRO
        End Get
        Set(ByVal Value As String)
            CI00_NM_LIVRO = Value
        End Set
    End Property
    Public Property Autor() As String
        Get
            Return CI00_NM_AUTOR
        End Get
        Set(ByVal Value As String)
            CI00_NM_AUTOR = Value
        End Set
    End Property
    Public Property Ano() As String
        Get
            Return CI00_NU_ANO
        End Get
        Set(ByVal Value As String)
            CI00_NU_ANO = Value
        End Set
    End Property
    Public Property Paginas() As String
        Get
            Return CI00_NU_PAGINAS
        End Get
        Set(ByVal Value As String)
            CI00_NU_PAGINAS = Value
        End Set
    End Property

    Public Sub New(Optional ByVal Codigo As Integer = 0)
        If Codigo > 0 Then
            Obter(Codigo)
        End If
    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI00_LIVROS")
        strSQL.Append(" where CI00_ID_LIVRO = " & Codigo)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("CI00_ID_LIVRO") = ProBanco(CI00_ID_LIVRO, eTipoValor.CHAVE)
        dr("CI00_NM_LIVRO") = ProBanco(CI00_NM_LIVRO, eTipoValor.TEXTO)
        dr("CI00_NM_AUTOR") = ProBanco(CI00_NM_AUTOR, eTipoValor.TEXTO)
        dr("CI00_NU_ANO") = ProBanco(CI00_NU_ANO, eTipoValor.TEXTO)
        dr("CI00_NU_PAGINAS") = ProBanco(CI00_NU_PAGINAS, eTipoValor.TEXTO)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Sub Obter(ByVal Codigo As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI00_LIVROS")
        strSQL.Append(" where CI00_ID_LIVRO = " & Codigo)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            CI00_ID_LIVRO = DoBanco(dr("CI00_ID_LIVRO"), eTipoValor.CHAVE)
            CI00_NM_LIVRO = DoBanco(dr("CI00_NM_LIVRO"), eTipoValor.TEXTO)
            CI00_NM_AUTOR = DoBanco(dr("CI00_NM_AUTOR"), eTipoValor.TEXTO)
            CI00_NU_ANO = DoBanco(dr("CI00_NU_ANO"), eTipoValor.TEXTO)
            CI00_NU_PAGINAS = DoBanco(dr("CI00_NU_PAGINAS"), eTipoValor.TEXTO)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional ByVal Codigo As Integer = 0,
                              Optional ByVal NomeLivro As String = "",
                              Optional ByVal CPF As String = "",
                              Optional ByVal Autor As String = "",
                              Optional ByVal Cep As String = "",
                              Optional ByVal Estado As String = "",
                              Optional ByVal Ano As String = "",
                              Optional ByVal Paginas As String = "",
                              Optional ByVal Email As String = "",
                              Optional ByVal Telefone As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI00_LIVROS")
        strSQL.Append(" where CI00_ID_LIVRO is not null")

        If Codigo > 0 Then
            strSQL.Append(" and CI00_ID_LIVRO = " & Codigo)
        End If

        If NomeLivro <> "" Then
            strSQL.Append(" and upper(CI00_NM_LIVRO) like '%" & NomeLivro.ToUpper & "%'")
        End If

        If Autor <> "" Then
            strSQL.Append(" and upper(CI00_NM_AUTOR) like '%" & Autor.ToUpper & "%'")
        End If

        If Ano <> "" Then
            strSQL.Append(" and upper(CI00_NU_ANO) like '%" & Ano.ToUpper & "%'")
        End If

        If Paginas <> "" Then
            strSQL.Append(" and upper(CI00_NU_PAGINAS) like '%" & Paginas.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "CI00_NM_Livro", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select CI00_ID_LIVRO as CODIGO, CI00_NM_LIVRO as DESCRICAO")
        strSQL.Append(" from CI00_LIVROS")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        '
        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(CI00_ID_LIVRO) from CI00_LIVROS")

        With cnn.AbrirDataTable(strSQL.ToString)
            If Not IsDBNull(.Rows(0)(0)) Then
                CodigoUltimo = .Rows(0)(0)
            Else
                CodigoUltimo = 0
            End If
        End With

        '
        cnn = Nothing

        Return CodigoUltimo

    End Function

    Public Function Excluir(ByVal Codigo As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from CI00_LIVROS")
        strSQL.Append(" where CI00_ID_LIVRO = " & Codigo)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        '
        cnn = Nothing

        Return LinhasAfetadas
    End Function

End Class
