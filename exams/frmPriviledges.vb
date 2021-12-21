Imports System.Text

Public Class frmPriviledges
    Private Sub frmPriviledges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        End If

        Dim myTable = generateDataTable("select Title, partnername as Name, Designation, Department from system_users left join partners on partners.partnerName = system_users.partner where domain = md5('Examination')")
        usersDGV.DataSource = myTable
        loadTreeView()
    End Sub
    Dim menus = String.Empty
    Dim treeView = New Dictionary(Of String, List(Of String))

    Private Sub loadTreeView()
        treeView.Clear()

        Dim configurations = {"Performance Comments", "Principal Comments", "Report Form Configurations", "Merit List Configurations"}
        Dim subjects = {"Add Split Subject", "Edit Split Subject", "Assign Subject Taken", "Assign Index Number"}
        Dim Grading = {"Class Based Grading Scheme", "Subject Based Grading"}
        Dim Examinations = {"Create Examination", "Edit Examination", "Create National Examination", "Edit National Examination"}
        Dim Performance_entry = {"Local Examination", "National Examination"}
        Dim Results = {"Student Performance Profile", "Student Performance Index", "General Performance", "Student Performance", "Subject Performance", "Subject Performance Index"}
        Dim Users = {"System Users", "User Rights And Priviledges"}
        Dim ChangeLook = {"Application Font", "Restore Default Look And Feel"}

        treeView.Add("Configuration", configurations.ToList())
        treeView.Add("Subjects", subjects.ToList())
        treeView.Add("Grading", Grading.ToList())
        treeView.Add("Examinations", Examinations.ToList())
        treeView.Add("Performance Entry", Performance_entry.ToList())
        treeView.Add("Results", Results.ToList())
        treeView.Add("Users", Users.ToList())
        treeView.Add("Change Look", ChangeLook.ToList())

        myTreeView.Nodes.Clear()

        Dim counter = 0
        Dim s, item As String

        For Each s In treeView.keys
            myTreeView.Nodes.Add(s)
            For Each item In treeView(s)
                If menus.Length > 0 Then
                    If menus.Contains(item) Then
                        myTreeView.Nodes(counter).Nodes.Add(item).Checked = True
                    Else
                        myTreeView.Nodes(counter).Nodes.Add(item)
                    End If
                Else
                    myTreeView.Nodes(counter).Nodes.Add(item)
                End If
            Next
            counter += 1
        Next
        myTreeView.ExpandAll()
    End Sub

    Private Function CheckedNames(ByVal theNodes As TreeNodeCollection)
        Dim aResult As New List(Of String)
        If Not IsNothing(theNodes) Then
            For Each aNode As TreeNode In theNodes

                If aNode.Checked = True Then

                    aResult.Add(aNode.Text)
                End If

                aResult.AddRange(CheckedNames(aNode.Nodes))
            Next
        End If
        Return aResult
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim s = String.Empty
        Dim selectedItems = CheckedNames(myTreeView.Nodes)
        Dim items = New StringBuilder()

        For Each s In selectedItems
            items.Append(s + " , ")
        Next

        If usersDGV.SelectedRows.Count > 0 Then
            Dim user = usersDGV.SelectedRows(0).Cells(1).Value.ToString()
            If qwrite("delete from priviledges where user = '" + user + "' and domain = 'Exam'") And
                    qwrite("INSERT INTO `priviledges` (`user`, `rights`, `domain`) VALUES ('" + escape_string(user) + "', '" + escape_string(items.ToString()) + "', 'Exam');") Then

                success("The Operation Was Successful")
            End If
        End If

    End Sub

    Private Sub usersDGV_SelectionChanged(sender As Object, e As EventArgs) Handles usersDGV.SelectionChanged
        If usersDGV.SelectedRows.Count > 0 Then

            Dim user = usersDGV.SelectedRows(0).Cells(1).Value.ToString()

            menus = getMenus(user)
            If menus.Length > 0 Then

                loadTreeView()

            End If
        End If
    End Sub



End Class