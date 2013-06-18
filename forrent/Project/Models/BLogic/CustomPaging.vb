Public Class CustomPaging
    Private objLink As LinkButton = Nothing
    Private objLabel As Label = Nothing
    Private intStartRecord As Integer = 0
    Private intEndRecord As Integer = 0
    Private strUniqueCode As String = ""
    Private objViewState As StateBag
    Private phTop As PlaceHolder = Nothing
    Private phBottom As PlaceHolder = Nothing
    Private strPreviousImage As String = ""
    Private strNextImage As String = ""
    Public Delegate Sub BindGridDelegate(ByVal pi As Integer)
    Private delBindGrid As BindGridDelegate
    Private PageClass As String = ""

    Sub New(ByVal UniqueCode As String, ByVal objVS As StateBag, ByVal objTopPlaceHolder As PlaceHolder, ByVal objBottomPlaceHolder As PlaceHolder, ByVal PreviousImage As String, ByVal NextImage As String, ByVal fnc_BindGrid As BindGridDelegate, ByVal strPageClass As String)
        strUniqueCode = UniqueCode
        objViewState = objVS
        phTop = objTopPlaceHolder
        phBottom = objBottomPlaceHolder
        strPreviousImage = PreviousImage
        strNextImage = NextImage
        delBindGrid = fnc_BindGrid
        PageClass = strPageClass
    End Sub

    Public Sub GenerateControls()
        If CInt(objViewState(strUniqueCode + "TotalPage")) > 1 Then
            If CInt(objViewState(strUniqueCode + "TotalPage")) > 1 And CInt(objViewState(strUniqueCode + "CurrentPageIndex")) <> 1 Then
                If phTop IsNot Nothing Then
                    objLink = New LinkButton()
                    objLink.ID = strUniqueCode + "Prev"
                    objLink.Visible = True
                    objLink.Text = strPreviousImage
                    AddHandler objLink.Click, AddressOf lnkPage_Previous
                    phTop.Controls.Add(objLink)
                    phTop.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                End If

                If phBottom IsNot Nothing Then
                    objLink = New LinkButton()
                    objLink.ID = strUniqueCode + "Prev1"
                    objLink.Text = strPreviousImage
                    AddHandler objLink.Click, AddressOf lnkPage_Previous
                    phBottom.Controls.Add(objLink)
                    phBottom.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                End If
            End If

            If CInt(objViewState(strUniqueCode + "CurrentPageIndex")) <= 7 Then
                intStartRecord = 1
                intEndRecord = 8
                If CInt(objViewState(strUniqueCode + "TotalPage")) > 8 Then
                    intEndRecord = 8
                Else
                    intEndRecord = objViewState(strUniqueCode + "TotalPage")
                End If
            Else
                If (CInt(objViewState(strUniqueCode + "CurrentPageIndex")) / 8).ToString.IndexOf(".") > 0 Then
                    intStartRecord = (objViewState(strUniqueCode + "CurrentPageIndex") / 8).ToString.Substring(0, (objViewState(strUniqueCode + "CurrentPageIndex") / 8).ToString.IndexOf(".")) * 8
                Else
                    intStartRecord = (8 * CInt((objViewState(strUniqueCode + "CurrentPageIndex") / 8)))
                End If
                If intStartRecord > CInt(objViewState(strUniqueCode + "TotalPage")) Then
                    intStartRecord = (8 * (CInt((objViewState(strUniqueCode + "CurrentPageIndex") / 8)) - 1))
                End If
                If intStartRecord + 8 < CInt(objViewState(strUniqueCode + "TotalPage")) Then
                    intEndRecord = intStartRecord + 8
                Else
                    intEndRecord = CInt(objViewState(strUniqueCode + "TotalPage"))
                End If
            End If

            For i As Integer = intStartRecord To intEndRecord
                If CInt(objViewState(strUniqueCode + "CurrentPageIndex")) <> i Then
                    If phTop IsNot Nothing Then
                        objLink = New LinkButton()
                        objLink.ID = strUniqueCode + i.ToString()
                        objLink.Text = i
                        objLink.CssClass = _LinkClass
                        AddHandler objLink.Click, AddressOf lnkPage_click
                        phTop.Controls.Add(objLink)
                        phTop.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    End If

                    If phBottom IsNot Nothing Then
                        objLink = New LinkButton()
                        objLink.ID = strUniqueCode + (i + CInt(objViewState(strUniqueCode + "TotalRecords"))).ToString()
                        objLink.Text = i
                        objLink.CssClass = _LinkClass
                        AddHandler objLink.Click, AddressOf lnkPage_click
                        phBottom.Controls.Add(objLink)
                        phBottom.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    End If

                Else
                    If phTop IsNot Nothing Then
                        objLabel = New Label()
                        objLabel.ID = strUniqueCode + i.ToString()
                        objLabel.Text = i
                        If PageClass.Trim.Length > 0 Then
                            objLabel.CssClass = PageClass
                        End If
                        phTop.Controls.Add(objLabel)
                        phTop.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    End If

                    If phBottom IsNot Nothing Then
                        objLabel = New Label()
                        objLabel.ID = strUniqueCode + (i + CInt(objViewState(strUniqueCode + "TotalRecords"))).ToString()
                        objLabel.Text = i
                        If PageClass.Trim.Length > 0 Then
                            objLabel.CssClass = PageClass
                        End If
                        phBottom.Controls.Add(objLabel)
                        phBottom.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    End If
                End If
            Next
            If CInt(objViewState(strUniqueCode + "TotalPage")) > 1 And CInt(objViewState(strUniqueCode + "CurrentPageIndex")) < CInt(objViewState(strUniqueCode + "TotalRecords")) Then
                If phTop IsNot Nothing Then
                    objLink = New LinkButton()
                    objLink.ID = strUniqueCode + "Next"
                    objLink.Visible = True
                    objLink.Text = strNextImage
                    AddHandler objLink.Click, AddressOf lnkPage_Next
                    phTop.Controls.Add(objLink)
                    phTop.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                End If

                If phBottom IsNot Nothing Then
                    objLink = New LinkButton()
                    objLink.ID = strUniqueCode + "Next1"
                    objLink.Text = strNextImage
                    AddHandler objLink.Click, AddressOf lnkPage_Next
                    phBottom.Controls.Add(objLink)
                    phBottom.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                End If
            End If
        End If
        ShowHidePrevNext()
    End Sub

    Private _LinkClass As String = ""

    Property PageLinkClass()
        Get
            Return _LinkClass
        End Get
        Set(ByVal value)
            _LinkClass = value
        End Set
    End Property

    Public Property TotalPages() As Integer
        Get
            Return CInt(objViewState(strUniqueCode + "TotalPage"))
        End Get
        Set(ByVal value As Integer)
            objViewState(strUniqueCode + "TotalPage") = value
        End Set
    End Property

    Public Property CurrentPage() As Integer
        Get
            Return CInt(objViewState(strUniqueCode + "CurrentPageIndex"))
        End Get
        Set(ByVal value As Integer)
            objViewState(strUniqueCode + "CurrentPageIndex") = value
        End Set
    End Property

    Public Property TotalRecords() As Integer
        Get
            Return CInt(objViewState(strUniqueCode + "TotalRecords"))
        End Get
        Set(ByVal value As Integer)
            objViewState(strUniqueCode + "TotalRecords") = value
        End Set
    End Property

    Public Sub ResetControls()
        If phTop IsNot Nothing Then
            phTop.Controls.Clear()
        End If
        If phBottom IsNot Nothing Then
            phBottom.Controls.Clear()
        End If
    End Sub

    Private Sub lnkPage_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(CType(sender, LinkButton).ID.Replace(strUniqueCode, "")) > objViewState(strUniqueCode + "TotalRecords")) Then
            objViewState(strUniqueCode + "CurrentPageIndex") = CInt(CType(sender, LinkButton).ID.Replace(strUniqueCode, "")) - objViewState(strUniqueCode + "TotalRecords")
        Else
            objViewState(strUniqueCode + "CurrentPageIndex") = CInt(CType(sender, LinkButton).ID.Replace(strUniqueCode, ""))
        End If
        delBindGrid(objViewState(strUniqueCode + "CurrentPageIndex"))
    End Sub

    Private Sub lnkPage_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(objViewState(strUniqueCode + "CurrentPageIndex")) <> 1) Then
            objViewState(strUniqueCode + "CurrentPageIndex") = CInt(objViewState(strUniqueCode + "CurrentPageIndex")) - 1
        End If
        delBindGrid(objViewState(strUniqueCode + "CurrentPageIndex"))
    End Sub

    Private Sub lnkPage_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(objViewState(strUniqueCode + "CurrentPageIndex")) < CInt(objViewState(strUniqueCode + "TotalPage"))) Then
            objViewState(strUniqueCode + "CurrentPageIndex") = CInt(objViewState(strUniqueCode + "CurrentPageIndex")) + 1
        Else
            objViewState(strUniqueCode + "CurrentPageIndex") = CInt(objViewState(strUniqueCode + "CurrentPageIndex"))
        End If
        delBindGrid(objViewState(strUniqueCode + "CurrentPageIndex"))
    End Sub

    Private Sub ShowHidePrevNext()
        If (CInt(objViewState(strUniqueCode + "CurrentPageIndex")) = CInt(objViewState(strUniqueCode + "TotalPage"))) Then
            If phTop IsNot Nothing AndAlso phTop.FindControl(strUniqueCode + "Next") IsNot Nothing Then
                phTop.FindControl(strUniqueCode + "Next").Visible = False
            End If
            If phBottom IsNot Nothing AndAlso phBottom.FindControl(strUniqueCode + "Next1") IsNot Nothing Then
                phBottom.FindControl(strUniqueCode + "Next1").Visible = False
            End If
        Else
            If phTop IsNot Nothing AndAlso phTop.FindControl(strUniqueCode + "Next") IsNot Nothing Then
                phTop.FindControl(strUniqueCode + "Next").Visible = True
            End If
            If phBottom IsNot Nothing AndAlso phBottom.FindControl(strUniqueCode + "Next1") IsNot Nothing Then
                phBottom.FindControl(strUniqueCode + "Next1").Visible = True
            End If
        End If
    End Sub
End Class