Public Class frmMaptest

    Private Sub frmMaptest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim htm As String = <HTML><![CDATA[<iframe
        '                          Width = "600"
        '                        Height = "450"
        '                        frameborder="0" style="border:0"
        '                        src="https://www.google.com/maps/embed/v1/place?key=AIzaSyB401t_ObRkih8dkMIsIqZl-yUsODao3GU&q=Space+Needle,Seattle+WA">
        '                    </iframe>]]></HTML>

        Dim htm As String = <HTML><![CDATA[<iframe 
                                frameborder="0" style="border:0"
                                src="https://www.google.com/maps/embed/v1/directions?key=AIzaSyB401t_ObRkih8dkMIsIqZl-yUsODao3GU&origin=M.B.Tilla,Agartala&destination=Amtali,Tripura&avoid=tolls|highways">
                            </iframe>]]></HTML>
        'WebBrowser1.DocumentStream = (New HtmlDocument)

        Try
            IO.File.WriteAllText("htmmmm.html", htm)
            WebBrowser1.Navigate(My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "htmmmm.html"))
            ' WebBrowser1.Document.Write(htm)

        Catch ex As Exception
        End Try

    End Sub
End Class