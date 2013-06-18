Imports System.Configuration
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports Facebook
Imports BusinessAccessLayer.BusinessLayer

Public Class manage_saved_sidebar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
                ViewState("CurrentPageIndex") = 1
                BindHeaderData()
                SearchData()
            Catch ex As Exception
                ltrMsg.Text = "Error: " & ex.Message.ToString
            End Try
        Else

            GenerateControls()
        End If
    End Sub

    Private Sub BindHeaderData()
        Try
            Dim obj As New BALLoggingActivity
            Dim ds As DataSet
            ds = obj.BindSearchData()
            selCompany.Items.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                selCompany.DataSource = ds.Tables(0)
                selCompany.DataValueField = "c_Id"
                selCompany.DataTextField = "c_Name"
                selCompany.DataBind()
            Else
                selCompany.DataSource = Nothing
                selCompany.DataBind()
            End If
            selCompany.Items.Insert(0, New ListItem("-- All Companies --", "0"))
            selIndustry.Items.Clear()
            If ds.Tables(1).Rows.Count > 0 Then
                selIndustry.DataSource = ds.Tables(1)
                selIndustry.DataValueField = "i_Id"
                selIndustry.DataTextField = "i_Name"
                selIndustry.DataBind()
            Else
                selIndustry.DataSource = Nothing
                selIndustry.DataBind()
            End If
            selIndustry.Items.Insert(0, New ListItem("-- All Industries --", "0"))
            selUser.Items.Clear()
            If ds.Tables(2).Rows.Count > 0 Then
                selUser.DataSource = ds.Tables(2)
                selUser.DataValueField = "u_Id"
                selUser.DataTextField = "u_Username"
                selUser.DataBind()
            Else
                selUser.DataSource = Nothing
                selUser.DataBind()
            End If
            selUser.Items.Insert(0, New ListItem("-- All Users --", "0"))
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub
    Private Sub BindGrid(ByVal pi As Integer)
        'Try
        ViewState("CurrentPageIndex") = pi
        Dim obj As New BALLoggingActivity
        obj.CompanyID = CInt(ViewState("Company").ToString())
        obj.IndustryID = CInt(ViewState("Industry").ToString())
        obj.UserID = CInt(ViewState("User").ToString())
        obj.FromDate = Convert.ToString(ViewState("FromDate"))
        obj.ToDate = Convert.ToString(ViewState("ToDate"))
        obj.PageIndex = CInt(ViewState("CurrentPageIndex"))
        obj.SortBy = ViewState("SortBy").ToString()
        obj.Order = ViewState("Order").ToString()

        Dim ds As New DataSet
        ds = obj.BindSavedSidebars()

        If ds.Tables(0).Rows.Count > 0 Then
            grdSidebar.DataSource = ds.Tables(0)
            grdSidebar.DataBind()
            trTopPaging.Visible = True
            trBottomPaging.Visible = True
        Else
            grdSidebar.DataSource = Nothing
            grdSidebar.DataBind()
            trTopPaging.Visible = False
            trBottomPaging.Visible = False
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            If CInt(ds.Tables(1).Rows(0).Item("TotalPage")) <= 1 Then
                trTopPaging.Visible = False
                trBottomPaging.Visible = False
            Else
                trTopPaging.Visible = True
                trBottomPaging.Visible = True
            End If
            ViewState("TotalPage") = ds.Tables(1).Rows(0).Item("TotalPage")
            ViewState("TotalRecords") = ds.Tables(1).Rows(0).Item("TotalRec")
        End If

        phPaging.Controls.Clear()
        phPaging1.Controls.Clear()
        GenerateControls()

        'Catch ex As Exception
        '    ltrMsg.Text = "Error: " & ex.Message
        'End Try
    End Sub



#Region " Custom Paging "
    Dim objlink As LinkButton
    Dim objlabel As Label
    Dim intStartRecord, intEndRecord As Integer

    Sub GenerateControls()
        If (ViewState("TotalPage") > 1) Then
            Dim i As Integer
            If (ViewState("TotalPage") > 1 And ViewState("CurrentPageIndex") <> 1) Then
                ''''Generating previous button''
                objlink = New LinkButton()
                objlink.ID = "Prev"
                objlink.Visible = True
                objlink.Text = "<img src=""../Content/adminimages/net-arrow-Previous.gif"" width=""4"" height=""8"" hspace=""5"" align=""absmiddle"" border=""0"">Previous"
                AddHandler objlink.Click, AddressOf lnkPage_Previous
                phPaging.Controls.Add(objlink)
                phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))

                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Prev1"
                objlink.Text = "<img src=""../Content/adminimages/net-arrow-Previous.gif"" width=""4"" height=""8"" hspace=""5"" align=""absmiddle"" border=""0"">Previous"
                AddHandler objlink.Click, AddressOf lnkPage_Previous
                phPaging1.Controls.Add(objlink)
                phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''
            End If
            If (ViewState("CurrentPageIndex") <= 7) Then
                intStartRecord = 1
                intEndRecord = 8
                If (ViewState("TotalPage") > 8) Then
                    intEndRecord = 8
                Else
                    intEndRecord = ViewState("TotalPage")
                End If
            Else
                If ((ViewState("CurrentPageIndex") / 8).ToString.IndexOf(".") > 0) Then
                    intStartRecord = (ViewState("CurrentPageIndex") / 8).ToString.Substring(0, (ViewState("CurrentPageIndex") / 8).ToString.IndexOf(".")) * 8
                Else
                    intStartRecord = (8 * CInt((ViewState("CurrentPageIndex") / 8)))
                End If
                If (intStartRecord > ViewState("TotalPage")) Then
                    intStartRecord = (8 * (CInt((ViewState("CurrentPageIndex") / 8)) - 1))
                End If
                If (intStartRecord + 8 < ViewState("TotalPage")) Then
                    intEndRecord = intStartRecord + 8
                Else
                    intEndRecord = ViewState("TotalPage")
                End If
            End If
            For i = intStartRecord To intEndRecord
                If (ViewState("CurrentPageIndex") <> i) Then
                    objlink = New LinkButton()
                    objlink.ID = i
                    objlink.Text = i
                    AddHandler objlink.Click, AddressOf lnkPage_click
                    phPaging.Controls.Add(objlink)
                    phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    ''''''------------------''''''
                    objlink = New LinkButton()
                    objlink.ID = i + ViewState("TotalRecords")
                    objlink.Text = i
                    AddHandler objlink.Click, AddressOf lnkPage_click
                    phPaging1.Controls.Add(objlink)
                    phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                Else
                    objlabel = New Label()
                    objlabel.ID = i
                    objlabel.Text = i
                    phPaging.Controls.Add(objlabel)
                    phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                    objlabel.CssClass = "currentPage"
                    ''''''------------------''''''
                    objlabel = New Label()
                    objlabel.ID = i + ViewState("TotalRecords")
                    objlabel.Text = i
                    objlabel.CssClass = "currentPage"
                    phPaging1.Controls.Add(objlabel)
                    phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                End If
            Next
            If (ViewState("TotalPage") > 1 And ViewState("CurrentPageIndex") < ViewState("TotalPage")) Then
                ''''Generating next button '
                objlink = New LinkButton()
                objlink.ID = "Next"
                objlink.Visible = True
                objlink.Text = "Next<img src=""../Content/adminimages/net-arrow-Next.gif"" width=""4"" height=""8"" hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPage_Next
                phPaging.Controls.Add(objlink)
                phPaging.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''''------------------''''''
                objlink = New LinkButton()
                objlink.ID = "Next1"
                objlink.Text = "Next<img src=""../Content/adminimages/net-arrow-Next.gif"" width=""4"" height=""8"" hspace=""5"" align=""absmiddle"" border=""0"">"
                AddHandler objlink.Click, AddressOf lnkPage_Next
                phPaging1.Controls.Add(objlink)
                phPaging1.Controls.Add(New LiteralControl("&nbsp;&nbsp;"))
                ''''-----'''''''

            End If
        End If
        showHidePrevNext()
    End Sub

    Private Sub lnkPage_click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CInt(CType(sender, LinkButton).ID) > ViewState("TotalRecords")) Then
            ViewState("CurrentPageIndex") = CType(sender, LinkButton).ID - ViewState("TotalRecords")
        Else
            ViewState("CurrentPageIndex") = CType(sender, LinkButton).ID
        End If
        BindGrid(ViewState("CurrentPageIndex"))
    End Sub

    Private Sub lnkPage_Previous(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndex") <> 1) Then
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex") - 1
        End If
        BindGrid(ViewState("CurrentPageIndex"))
    End Sub

    Private Sub lnkPage_Next(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ViewState("CurrentPageIndex") < ViewState("TotalPage")) Then
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex") + 1
        Else
            ViewState("CurrentPageIndex") = ViewState("CurrentPageIndex")
        End If
        BindGrid(ViewState("CurrentPageIndex"))
    End Sub

    Sub showHidePrevNext()
        If (ViewState("CurrentPageIndex") = ViewState("TotalPage")) Then
            If (Not IsNothing(frm.FindControl("Next"))) Then
                frm.FindControl("Next").Visible = False
                frm.FindControl("Next1").Visible = False
            End If
        Else
            If (Not IsNothing(frm.FindControl("Next"))) Then
                frm.FindControl("Next").Visible = True
                frm.FindControl("Next1").Visible = True
            End If
        End If
    End Sub
#End Region

    Private Sub btnSearch_ServerClick(sender As Object, e As System.EventArgs) Handles btnSearch.ServerClick
        SearchData()
    End Sub

    Sub SearchData()
        ViewState("Company") = selCompany.Value
        ViewState("Industry") = selIndustry.Value
        ViewState("User") = selUser.Value
        If IsDate(txtFromDate.Value) Then
            ViewState("FromDate") = txtFromDate.Value
        Else
            ViewState("FromDate") = ""
        End If

        If IsDate(txtToDate.Value) Then
            ViewState("ToDate") = txtToDate.Value
        Else
            ViewState("ToDate") = ""
        End If
        ViewState("SortBy") = selSortBy.Value
        ViewState("Order") = selOrder.Value
        BindGrid(ViewState("CurrentPageIndex"))
    End Sub

    Private Sub btnDownload_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.ServerClick
        SearchAutoPostStatistics()
    End Sub

    Sub SearchAutoPostStatistics()
        ViewState("Company") = selCompany.Value
        ViewState("Industry") = selIndustry.Value
        ViewState("User") = selUser.Value
        If IsDate(txtFromDate.Value) Then
            ViewState("FromDate") = txtFromDate.Value
        Else
            ViewState("FromDate") = ""
        End If

        If IsDate(txtToDate.Value) Then
            ViewState("ToDate") = txtToDate.Value
        Else
            ViewState("ToDate") = ""
        End If

        ' ViewState("CurrentPageIndex") = 1
        ViewState("SortBy") = selSortBy.Value
        ViewState("Order") = selOrder.Value
        'BindGrid(ViewState("CurrentPageIndex"))
        Create_Csv()

    End Sub
#Region "Create CSV"
    Sub Create_Csv()
        Try
            Dim obj As New BALLoggingActivity
            obj.CompanyID = CInt(ViewState("Company").ToString())
            obj.IndustryID = CInt(ViewState("Industry").ToString())
            obj.UserID = CInt(ViewState("User").ToString())
            obj.FromDate = Convert.ToString(ViewState("FromDate"))
            obj.ToDate = Convert.ToString(ViewState("ToDate"))
            ' obj.PageIndex = CInt(ViewState("CurrentPageIndex"))
            obj.SortBy = ViewState("SortBy").ToString()
            obj.Order = ViewState("Order").ToString()

            Dim ds As New DataSet
            ds = obj.DownLoadSavedSidebars()

            Dim strPath As String = "SavedSidebars-Statistics-" & CStr(Day(Now)) & CStr(Month(Now)) & CStr(Year(Now)) & CStr(Hour(Now)) & CStr(Minute(Now)) & CStr(Second(Now)) & ".csv"
            Response.Expires = 0
            Response.Clear()
            Response.AddHeader("Content-Disposition", "inline;filename=" & strPath & "")
            Response.AddHeader("Content-type", "text/csv")

            Response.Write(""" ID "",")

            Response.Write(""" Name "",")
            ' Response.Write(""" Content "",")
            Response.Write(""" Image "",")
            Response.Write(""" User "",")
            Response.Write(""" Facebook User ID "",")
            Response.Write(""" Company "",")
            Response.Write(""" Industry "",")
            Response.Write(""" Created Date "",")
            Response.Write(""" Updated Date"",")
            Response.Write(vbNewLine)
            Dim i As Integer
            For i = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(i)
                    Response.Write("""" & .Item("sd_Id").ToString() & """,")

                    Response.Write("""" & .Item("sd_Name").ToString() & """,")
                    '  Response.Write("""" & .Item("sd_Content").ToString() & """,")
                    Response.Write("""" & .Item("sd_Image").ToString() & """,")
                    Response.Write("""" & .Item("sd_UserId").ToString() & """,")
                    Response.Write("""" & .Item("sd_FBUserId").ToString() & """,")
                    Response.Write("""" & .Item("sd_CompanyId").ToString() & """,")
                    Response.Write("""" & .Item("sd_IndustryId").ToString() & """,")
                    Response.Write("""" & .Item("sd_CreatedDate").ToString() & """,")
                    Response.Write("""" & .Item("sd_UpdatedDate").ToString() & """,")

                    Response.Write(vbNewLine)
                End With
            Next
            ds.Dispose()
            Response.Flush()
            'Response.Close()
            Response.End()
        Catch ex As Exception
            ltrMsg.Text = "Error: " & ex.Message
        End Try
    End Sub
#End Region

End Class