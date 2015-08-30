Public NotInheritable Class SplashScreen1



    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      

        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

     

        Version.Text = "Version : " & My.Application.Info.Version.ToString
        'Copyright info
        Copyright.Text = "Copyright : " & My.Application.Info.Copyright
        LoadLocalSettings()
        isSoundOn = MyLocalSettings.SpeechSpeaker
        If isSoundOn Then
            mySpeaker = New Speech.Synthesis.SpeechSynthesizer
            mySpeaker.Volume = 100
            mySpeaker.Rate = -1
            mySpeaker.SelectVoiceByHints(Speech.Synthesis.VoiceGender.Female)
            mySpeaker.SpeakAsync("Welcome to Room Rent System") '. Version " & My.Application.Info.Version.ToString & vbNewLine & My.Application.Info.Copyright) '
            'mySpeaker.SpeakAsync("Ad. This software is designed by Lincoln Scott and Developed by Bidyut Das") '. Version " & My.Application.Info.Version.ToString & vbNewLine & My.Application.Info.Copyright) '
        End If
    End Sub

End Class
